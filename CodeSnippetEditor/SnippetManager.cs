using CodeSnippetEditor.Messages;
using CodeSnippetEditor.SnippetDefinition;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CodeSnippetEditor
{
    public class SnippetManager
    {
        private readonly RedoUndo<IOperation> _redoUndo;
        public SnippetManager(IRedoUndo<IOperation> control)
        {
            _redoUndo = new RedoUndo<IOperation>(control);
        }

        private readonly List<CodeSnippet> _snippets = new();
        public List<CodeSnippet> Snippets => _snippets;

        public static CodeSnippet DefaultSnippet => new();

        internal (List<CodeSnippet> snippets, int index) Update(int index, string author, string title, string shortcut, SnippetType snippetType, string code, string language)
        {
            var old = _snippets[index];
            var newSnippet = old with
            {
                Header = old.Header with
                {
                    Author = author,
                    Title = title,
                    Shortcut = shortcut,
                    SnippetTypes = new[] { snippetType.ToString() },
                },
                Snippet = old.Snippet with
                {
                    Code = old.Snippet.Code with
                    {
                        Language = language,
                        Content = code,
                    },
                },
            };
            _snippets[index] = newSnippet;
            return (_snippets, index);
        }

        public void SaveFile(string path)
        {
            XmlSerializer serializer = new(typeof(CodeSnippets));
            using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(fs, ToCodeSnippets(_snippets));

            static CodeSnippets ToCodeSnippets(List<CodeSnippet> snippets) => new(snippets.ToArray());
        }

        /// <summary>
        /// 操作を表すメッセージを受け取り、状態を更新します。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal void Dispatch(IMessage message)
        {
            IOperation operation = message switch
            {
                OpenFileMessage msg => OpenFile(msg.Path),
                // snippet
                ChangeSnippetIndexMessage msg => ChangeSnippetIndex(msg.Index),
                AddSnippetMessage msg => AddNewSnippet(msg.Index),
                DeleteSnippetMessage msg => DeleteSnippet(msg.Index),
                // header
                ChangedAuthorMessage msg => ChangedAuthor(msg.Index, msg.Author),
                ChangedTitleMessage msg => ChangedTitle(msg.Index, msg.Title),
                ChangedShortcutMessage msg => ChangedShortcut(msg.Index, msg.Shortcut),
                ChangedSnippetTypeMessage msg => ChangedSnippetType(msg.Index, msg.SnippetType, msg.Enabled),
                // code
                ChangedCodeMessage msg => ChangedCode(msg.Index, msg.Code),
                ChangedLanguageMessage msg => ChangedLanguage(msg.Index, msg.Language),
                // literal
                ChangeVariableIndexMessage msg => ChangeVariableIndex(msg.SnippetIndex, msg.VariableIndex),
                AddVariableMessage msg => AddVariable(msg.Index),
                AddVariableFromCodeMessage msg => AddVariableFromCode(msg.Index),
                DeleteVariableMessage msg => DeleteVariable(msg.SIndex, msg.VIndex),
                ChangedVariableIdMessage msg => ChangeVariableId(msg.SnippetIndex, msg.VariableIndex, msg.Id),
                ChangedVariableDefaultMessage msg => ChangeVariableDefault(msg.SnippetIndex, msg.VariableIndex, msg.Default),
                // import
                ChangeImportIndexMessage msg => ChangeImportIndex(msg.SnippetIndex, msg.ImportIndex),
                AddImportMessage msg => AddImport(msg.SnippetIndex, msg.Namespace),
                DeleteImportMessage msg => DeleteImport(msg.SnippetIndex, msg.ImportIndex),
                ChangedNamespaceMessage msg => ChangedNamespace(msg.SnippetIndex, msg.ImportIndex, msg.Namespace),
                _ => throw new NotImplementedException($"{message.GetType()}"),
            };

            _redoUndo.Execute(operation);

            IOperation AddNewSnippet(int index)
            {
                var snippet = CreateSnippet(index);
                _snippets.Add(snippet);
                return new AddSnippetOperation(_snippets.Select(x => x.Header.Title).ToArray(), _snippets.Count - 1);

                CodeSnippet CreateSnippet(int index) => index == -1 ? DefaultSnippet : SnippetManipulation.CloneSnippet(_snippets[index]);
            }

            IOperation ChangedAuthor(int index, string author)
            {
                _snippets[index] = SnippetManipulation.UpdateAuthor(_snippets[index], author);
                return new ChangedAuthorOperation(author);
            }

            IOperation DeleteSnippet(int index)
            {
                _snippets.RemoveAt(index);
                return new DeleteSnippetOperation(index);
            }

            IOperation ChangeSnippetIndex(int index) => new ChangeSnippetIndexOperation(index, _snippets[index]);

            IOperation ChangedNamespace(int index, int importIndex, string @namespace)
            {
                _snippets[index] = SnippetManipulation.UpdateNamespace(_snippets[index], importIndex, @namespace);
                return new ChangedNamespaceOperation(index, importIndex, @namespace);
            }

            IOperation DeleteImport(int index, int importIndex)
            {
                _snippets[index] = SnippetManipulation.DeleteImport(_snippets[index], importIndex);
                return new DeleteImportOperation(index, importIndex);
            }

            IOperation AddImport(int index, string @namespace)
            {
                _snippets[index] = SnippetManipulation.AddImport(_snippets[index], @namespace);
                var newImport = _snippets[index].Snippet.Imports.Import;
                return new AddImportOperation(index, newImport.Length - 1, newImport.Select(x => x.Namespace).ToArray());
            }

            IOperation ChangeImportIndex(int snippetIndex, int importIndex)
            {
                return new ChangeImportIndexOperation(snippetIndex, importIndex, _snippets[snippetIndex].Snippet.Imports.Import[importIndex]);
            }

            IOperation AddVariableFromCode(int index)
            {
                _snippets[index] = SnippetManipulation.AddVariableFromCode(_snippets[index]);
                var newVariables = _snippets[index].Snippet.Declarations;
                return new AddVariableFromCodeOperation(index, newVariables.Length - 1, newVariables.Select(x => x.ID).ToArray());
            }

            IOperation DeleteVariable(int sIndex, int vIndex)
            {
                _snippets[sIndex] = SnippetManipulation.DeleteVariable(_snippets[sIndex], vIndex);
                return new DeleteVariableOperation(vIndex);
            }

            IOperation ChangeVariableId(int snippetIndex, int variableIndex, string id)
            {
                _snippets[snippetIndex] = SnippetManipulation.UpdateVariableId(_snippets[snippetIndex], variableIndex, id);
                return new ChangedVariableIdOperation(snippetIndex, variableIndex, id);
            }

            IOperation ChangeVariableDefault(int snippetIndex, int variableIndex, string defaultName)
            {
                _snippets[snippetIndex] = SnippetManipulation.UpdateVariableDefault(_snippets[snippetIndex], variableIndex, defaultName);
                return new ChangedVariableDefaultOperation(snippetIndex, variableIndex, defaultName);
            }

            IOperation ChangeVariableIndex(int snippetIndex, int variableIndex)
            {
                Debug.Assert(snippetIndex < _snippets.Count);
                Debug.Assert(variableIndex < _snippets[snippetIndex].Snippet.Declarations.Length);
                return new ChangeVariableIndexOperation(snippetIndex, variableIndex, _snippets[snippetIndex].Snippet.Declarations[variableIndex]);
            }

            IOperation AddVariable(int index)
            {
                _snippets[index] = SnippetManipulation.AddVariable(_snippets[index]);
                var newVariables = _snippets[index].Snippet.Declarations;
                return new AddVariableOperation(newVariables.Length - 1, newVariables);
            }

            IOperation ChangedTitle(int index, string title)
            {
                _snippets[index] = SnippetManipulation.UpdateTitle(_snippets[index], title);
                return new ChangedTitleOperation(index, title);
            }

            IOperation ChangedCode(int index, string code)
            {
                _snippets[index] = SnippetManipulation.UpdateCode(_snippets[index], code);
                return new ChangedCodeOperation(code);
            }

            IOperation ChangedSnippetType(int index, SnippetType type, bool enabled)
            {
                _snippets[index] = SnippetManipulation.UpdateSnippetType(_snippets[index], type.ToString(), enabled);
                return new ChangedSnippetTypeOperation(type, enabled);
            }

            IOperation ChangedShortcut(int index, string shortcut)
            {
                var original = _snippets[index];
                _snippets[index] = SnippetManipulation.UpdateShortcut(original, shortcut);
                return new ChangedShortcutOperation(shortcut);
            }

            IOperation ChangedLanguage(int index, string language)
            {
                var original = _snippets[index];
                _snippets[index] = SnippetManipulation.UpdateLanguage(original, language);
                return new ChangedLanguageOperation(language);
            }
        }

        private IOperation OpenFile(string path)
        {
            _snippets.Clear();

            try
            {
                XmlSerializer serializer = new(typeof(CodeSnippets));
                using FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.Read);
                var snippets = serializer.Deserialize(fs) as CodeSnippets;

                if (snippets is CodeSnippets { CodeSnippet: CodeSnippet[] codeSnippetsCodeSnippet })
                {
                    _snippets.AddRange(codeSnippetsCodeSnippet.Select(SnippetManipulation.NullToEmptyVale));
                }

                return new IOpenFileOperation.Success(_snippets.Count - 1, _snippets.Select(x => x.Header.Title).ToArray(), path);
            }
            catch (Exception)
            {
                return new IOpenFileOperation.Failure();
            }
        }
    }
}
