using CodeSnippetEditor.SnippetDefinition;
using CodeSnippetEditor.SnippetDefinition.Header;
using CodeSnippetEditor.SnippetDefinition.Snippet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSnippetEditor
{
    public enum SnippetType { SurroundsWith, Expansion, Refactoring }

    internal static class SnippetManipulation
    {
        public static CodeSnippet CloneSnippet(CodeSnippet original)
        {
            return original with
            {
                Header = original.Header with { Title = $"{original.Header.Title} - clone" },
                Snippet = original.Snippet with
                {
                    Declarations = original.Snippet.Declarations.ToArray(),
                    Imports = new(original.Snippet.Imports.Import.ToArray()),
                },
            };
        }

        internal static CodeSnippet AddImport(CodeSnippet original, string @namespace)
        {
            var newImport = original.Snippet.Imports.Import.Append(new Import(@namespace)).ToArray();
            var newImports = new Imports(newImport);
            return original with { Snippet = original.Snippet with { Imports = newImports, }, };
        }

        internal static CodeSnippet DeleteImport(CodeSnippet original, int importIndex)
        {
            var originalImport = original.Snippet.Imports.Import;
            var newImport = originalImport.Take(importIndex).Concat(originalImport.Skip(importIndex + 1)).ToArray();
            var newImports = new Imports(newImport);
            return original with { Snippet = original.Snippet with { Imports = newImports, }, };
        }

        internal static CodeSnippet UpdateAuthor(CodeSnippet original, string author)
        {
            return original with { Header = original.Header with { Author = author, }, };
        }

        internal static CodeSnippet UpdateNamespace(CodeSnippet original, int importIndex, string @namespace)
        {
            var originalImport = original.Snippet.Imports.Import;
            var newImportsImport = new Import(@namespace);
            var newImport = originalImport.ToArray();
            newImport[importIndex] = newImportsImport;

            var newImports = new Imports(newImport);
            return original with { Snippet = original.Snippet with { Imports = newImports, }, };
        }

        internal static string[] ExtractVariableId(string code)
        {
            List<string> variables = new();
            using StringReader sr = new(code);
            while (sr.Peek() > 0)
            {
                var line = sr.ReadLine()!;
                bool isPrevId = false;
                foreach (var item in line.Split('$').Skip(1))
                {
                    if (isPrevId || string.IsNullOrWhiteSpace(item))
                    {
                        isPrevId = false;
                        continue;
                    }

                    // Debug.WriteLine(item);

                    if (item is not "end" && char.IsLetter(item.First()) && item.All(char.IsLetterOrDigit))
                    {
                        variables.Add(item);
                        isPrevId = true;
                    }
                }
            }

            // variables.ForEach(x => Debug.WriteLine($"variable: {x}"));
            return variables.ToArray();
        }

        internal static CodeSnippet AddVariableFromCode(CodeSnippet original)
        {
            var addVariableIds = SnippetManipulation.ExtractVariableId(original.Snippet.Code.Content);
            var newVariables = original.Snippet.Declarations.Concat(addVariableIds
                .Select(x => new Literal(id: x, defaultName: x)))
                    .DistinctBy(x => x.ID).ToArray();

            return original with { Snippet = original.Snippet with { Declarations = newVariables, }, };
        }

        internal static CodeSnippet DeleteVariable(CodeSnippet original, int vIndex)
        {
            // var original = original with { };
            var declarations = original.Snippet.Declarations.Take(vIndex).Concat(original.Snippet.Declarations.Skip(vIndex + 1)).ToArray();
            return original with { Snippet = original.Snippet with { Declarations = declarations, }, };
        }

        internal static CodeSnippet UpdateVariableId(CodeSnippet original, int variableIndex, string id)
        {
            var originalLiteral = original.Snippet.Declarations[variableIndex];
            var newLiteral = originalLiteral with { ID = id };

            var newLiterals = original.Snippet.Declarations.ToArray();
            newLiterals[variableIndex] = newLiteral;

            var newSinppet = original with
            {
                Snippet = original.Snippet with
                {
                    Declarations = newLiterals,
                },
            };

            return newSinppet;
        }

        internal static CodeSnippet UpdateVariableDefault(CodeSnippet original, int variableIndex, string defaultName)
        {
            var originalLiteral = original.Snippet.Declarations[variableIndex];

            var newLiteral = originalLiteral with { Default = defaultName };
            var newLiterals = original.Snippet.Declarations.ToArray();
            newLiterals[variableIndex] = newLiteral;

            var newSinppet = original with
            {
                Snippet = original.Snippet with
                {
                    Declarations = newLiterals,
                },
            };

            return newSinppet;
        }

        internal static CodeSnippet AddVariable(CodeSnippet original)
        {
            var defaultVariable = new Literal("newVariable");
            return original with { Snippet = original.Snippet with { Declarations = original.Snippet.Declarations.Append(defaultVariable).ToArray(), }, };
        }

        internal static CodeSnippet UpdateTitle(CodeSnippet original, string title)
        {
            return original with { Header = original.Header with { Title = title, }, };
        }

        internal static CodeSnippet UpdateCode(CodeSnippet original, string code)
        {
            var newCode = original.Snippet.Code with { Content = code };
            return original with { Snippet = original.Snippet with { Code = newCode, }, };
        }

        internal static CodeSnippet UpdateSnippetType(CodeSnippet original, string type, bool enabled)
        {
            var newSnippetTypes = enabled
                ? original.Header.SnippetTypes.Append(type).Distinct().ToArray()
                : original.Header.SnippetTypes.Except(new string[] { type }).ToArray();
            return original with { Header = original.Header with { SnippetTypes = newSnippetTypes, }, };
        }

        internal static CodeSnippet UpdateShortcut(CodeSnippet original, string shortcut)
        {
            return original with { Header = original.Header with { Shortcut = shortcut, }, };
        }

        internal static CodeSnippet UpdateLanguage(CodeSnippet original, string language)
        {
            var newCode = original.Snippet.Code with { Language = language };
            return original with { Snippet = original.Snippet with { Code = newCode, }, };
        }


        internal static CodeSnippet NullToEmptyVale(CodeSnippet o)
        {
            var format = o.Format ?? string.Empty;

            var (title, shortcut, description, author, SnippetTypes) = o.Header ?? new Header();
            var header = new Header(title ?? string.Empty, shortcut ?? string.Empty, description ?? string.Empty, author ?? string.Empty, SnippetTypes ?? Array.Empty<string>());

            var code = o.Snippet?.Code ?? new Code();
            code.Content ??= string.Empty;

            var imports = ToNonNullImports(o.Snippet?.Imports);
            var declarations = ToNonNullDeclarations(o.Snippet?.Declarations);

            var snippet = new Snippet(declarations, code, imports);

            return new(header, snippet, format);
        }

        private static Imports ToNonNullImports(Imports? imports)
        {
            if (imports is null)
            {
                return new();
            }

            var import = ToNonNullImports(imports.Import);
            var nonNullImports = imports with
            {
                Import = import,
            };

            return nonNullImports;

            static Import[] ToNonNullImports(Import[]? importArray)
            {
                if (importArray is null)
                {
                    return Array.Empty<Import>();
                }
                return importArray.Where(x => x is not null).Select(ToNonNullImport).ToArray();

                static Import ToNonNullImport(Import import)
                {
                    var @namespace = import.Namespace ?? string.Empty;
                    return new(@namespace);
                }
            }
        }

        private static Literal[] ToNonNullDeclarations(Literal[]? declarations)
        {
            if (declarations is null)
            {
                return Array.Empty<Literal>();
            }
            return declarations.Where(x => x is not null).Select(ToNonNullLiteral).ToArray();

            static Literal ToNonNullLiteral(Literal literal)
            {
                var (id, function, toolTip, defaultName, editable, editableSpecified) = literal;
                return new(id ?? string.Empty, function ?? string.Empty, toolTip ?? string.Empty, defaultName ?? string.Empty, editable, editableSpecified);
            }
        }
    }
}
