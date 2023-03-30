using CodeSnippetEditor.Forms;
using CodeSnippetEditor.Messages;
using CodeSnippetEditor.SnippetDefinition.Snippet;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CodeSnippetEditor;

public partial class Form1 : Form, IRedoUndo<IOperation>
{
    public Form1()
    {
        InitializeComponent();
        _manager = new(this);
        InitComboBox();
        InitTextTypeTag();
        InitSnippetTypeTag();

        _snippetTypesCheckBoxes = new CheckBox[]
        {
            SurroundsWithCheckBox,
            ExpansionCheckBox,
            RefactoringCheckBox,
        };

        void InitComboBox()
        {
            string[] languages = new string[]
            {
                "CSharp",
                "VB",
                "CPP",
                "XAML",
                "XML",
                "JavaScript",
                "TypeScript",
                "SQL",
                "HTML",
            };

            LanguageComboBox.Items.AddRange(languages);
        }

        void InitTextTypeTag()
        {
            AuthorTextBox.Tag = TextType.Author;
            TitleTextBox.Tag = TextType.Title;
            LanguageComboBox.Tag = TextType.Language;
            ShortcutTextBox.Tag = TextType.Shortcut;
            CodeTempleteRichTextBox.Tag = TextType.Code;

            VariableIdTextBox.Tag = TextType.VariableId;
            DefaultNameTextBox.Tag = TextType.VariableDefaultName;

            NamespaceTextBox.Tag = TextType.NameSpace;
        }

        void InitSnippetTypeTag()
        {
            SurroundsWithCheckBox.Tag = SnippetType.SurroundsWith;
            ExpansionCheckBox.Tag = SnippetType.Expansion;
            RefactoringCheckBox.Tag = SnippetType.Refactoring;
        }
    }

    private readonly CheckBox[] _snippetTypesCheckBoxes;

    private readonly SnippetManager _manager;

    private void AddButton_Click(object sender, EventArgs e)
    {
        _manager.Dispatch(new AddSnippetMessage());

        var language = "CSharp";
        if (string.IsNullOrWhiteSpace(language) is false)
        {
            var index = SnippetListBox.SelectedIndex;
            _manager.Dispatch(new ChangedLanguageMessage(index, language));
        }
    }

    private void MinusButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new DeleteSnippetMessage(index));
    }


    private void SnippetListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new ChangeSnippetIndexMessage(index));
    }

    private void CloneButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new AddSnippetMessage(index));
    }

    private void VariableListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var variableIndex = VariableListBox.SelectedIndex;
        if (variableIndex is -1) return;

        _manager.Dispatch(new ChangeVariableIndexMessage(index, variableIndex));
    }

    private void AddVariableButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new AddVariableMessage(index));
    }

    private void RemoveVariableButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var variableIndex = VariableListBox.SelectedIndex;
        if (variableIndex is -1) return;

        _manager.Dispatch(new DeleteVariableMessage(index, variableIndex));
    }

    enum TextType
    {
        Author,
        Title,
        Shortcut,
        SnippetType,
        Language,
        Code,
        VariableId,
        VariableDefaultName,
        NameSpace,
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        var (text, textType) = sender switch
        {
            TextBox c => (c.Text, c.Tag),
            RichTextBox c => (c.Text, c.Tag),
            ComboBox c => (c.Text, c.Tag),
            _ => throw new NotImplementedException()
        };

        IMessage message = textType switch
        {
            TextType.Author => new ChangedAuthorMessage(index, text),
            TextType.Title => new ChangedTitleMessage(index, text),
            TextType.Language => new ChangedLanguageMessage(index, text),
            TextType.Shortcut => new ChangedShortcutMessage(index, text),
            TextType.Code => new ChangedCodeMessage(index, text),
            _ => throw new NotImplementedException(),
        };
        _manager.Dispatch(message);
    }

    private void VariableTextBox_TextChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var variableIndex = VariableListBox.SelectedIndex;
        if (variableIndex is -1) return;

        var (text, textType) = sender switch
        {
            TextBox c => (c.Text, c.Tag),
            _ => throw new NotImplementedException()
        };

        IMessage message = textType switch
        {
            TextType.VariableId => new ChangedVariableIdMessage(index, variableIndex, text),
            TextType.VariableDefaultName => new ChangedVariableDefaultMessage(index, variableIndex, text),
            _ => throw new NotImplementedException(),
        };
        _manager.Dispatch(message);
    }

    private void SnippetTypeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var check = (CheckBox)sender;

        _manager.Dispatch(new ChangedSnippetTypeMessage(index, (SnippetType)check.Tag!, check.Checked));
    }

    private void AutoAddVariableButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new AddVariableFromCodeMessage(index));
    }

    private void AddNamespaceButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;

        _manager.Dispatch(new AddImportMessage(index, "System"));
    }

    private void DeleteNamespaceButton_Click(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var importIndex = ImportListBox.SelectedIndex;
        if (importIndex is -1) return;

        _manager.Dispatch(new DeleteImportMessage(index, importIndex));
    }

    private void NamespaceTextBox_TextChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var importIndex = ImportListBox.SelectedIndex;
        if (importIndex is -1) return;

        var (text, textType) = sender switch
        {
            TextBox c => (c.Text, c.Tag),
            _ => throw new NotImplementedException()
        };

        IMessage message = textType switch
        {
            TextType.NameSpace => new ChangedNamespaceMessage(index, importIndex, text),
            _ => throw new NotImplementedException(),
        };
        _manager.Dispatch(message);
    }

    private void ImportListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var index = SnippetListBox.SelectedIndex;
        if (index is -1) return;
        var importIndex = ImportListBox.SelectedIndex;
        if (importIndex is -1) return;

        _manager.Dispatch(new ChangeImportIndexMessage(index, importIndex));
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using AboutForm aboutForm = new();
        aboutForm.ShowDialog();
    }

    private string? _filename;

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using OpenFileDialog ofd = new()
        {
            Filter = "(*.snippet)|*.snippet",
        };

        var result = ofd.ShowDialog();

        if (result == DialogResult.OK)
        {
            _filename = ofd.FileName;
            _manager.Dispatch(new OpenFileMessage(ofd.FileName));
        }
    }

    private void SaveNewToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog sfd = new()
        {
            Filter = "(*.snippet)|*.snippet",
            AddExtension = true,
        };

        var res = sfd.ShowDialog();
        if (res == DialogResult.OK)
        {
            var path = sfd.FileName;
            _filename = path;
            _manager.SaveFile(path);
        }
    }

    private void SaveOverwriteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_filename))
        {
            SaveNewToolStripMenuItem_Click(sender, e);
            return;
        }

        _manager.SaveFile(_filename);
    }

    private void InsertEndAtLastButton_Click(object sender, EventArgs e)
    {
        CodeTempleteRichTextBox.AppendText("$end$");
    }

    private void InsertEndAtCaretButton_Click(object sender, EventArgs e)
    {
        var pos = CodeTempleteRichTextBox.SelectionStart;
        var newCode = CodeTempleteRichTextBox.Text.Insert(pos, "$end$");
        CodeTempleteRichTextBox.Text = newCode;
    }

    void IRedoUndo<IOperation>.ExecuteRedo(IOperation operation)
    {
        Action action = operation switch
        {
            IOpenFileOperation.Success(int index, string[] snippets, string filename) => () => OpenFile(index, snippets, filename),
            IOpenFileOperation.Failure => () => FailureOpeningFile(),
            // Snippet
            AddSnippetOperation op => () => AddSnippet(op),
            DeleteSnippetOperation op => () => DeleteSnippet(op),
            ChangeSnippetIndexOperation op => () => ChangeSnippetIndex(op),
            ChangeVariableIndexOperation op => () => ChangeVariableIndex(op),
            // Header
            ChangedAuthorOperation op => () => ChangeAuthor(op),
            ChangedShortcutOperation op => () => ChangeShortcut(op),
            ChangedTitleOperation op => () => ChangeTitle(op),
            ChangedSnippetTypeOperation op => () => ChangeSnippetType(op),
            // Literal
            AddVariableOperation op => () => AddVariable(op),
            AddVariableFromCodeOperation(int sIndex, int vIndex, string[] variables) => () => AutoAddVariable(sIndex, vIndex, variables),
            DeleteVariableOperation(int vIndex) => () => DeleteVariable(vIndex),
            ChangedVariableIdOperation op => () => ChangeVariableId(op),
            ChangedVariableDefaultOperation op => () => ChangeVariableDefault(op),
            // Code
            ChangedCodeOperation op => () => ChangedCode(op),
            ChangedLanguageOperation op => () => ChangeLanguage(op),
            // Import
            AddImportOperation(int sIndex, int iIndex, string[] imports) => () => AddImport(sIndex, iIndex, imports),
            DeleteImportOperation(int sIndex, int iIndex) => () => DeleteImport(sIndex, iIndex),
            ChangeImportIndexOperation(int sIndex, int iIndex, Import import) => () => ChangeImportIndex(sIndex, iIndex, import),
            ChangedNamespaceOperation(int sIndex, int iIndex, string @namespace) => () => ChangedNamespace(sIndex, iIndex, @namespace),
            _ => throw new NotImplementedException($"{operation.GetType()} の実装を忘れていませんか。")
        };

        action();

        void AddSnippet(AddSnippetOperation operation)
        {
            var (snippets, selectedIndex) = operation;

            SnippetListBox.Items.Clear();
            SnippetListBox.Items.AddRange(snippets.Select(x => x.ToString()).ToArray());

            SnippetListBox.SelectedIndex = selectedIndex;
        }

        void ChangeSnippetIndex(ChangeSnippetIndexOperation op)
        {
            var (index, snippet) = op;
            SnippetListBox.SelectedIndex = index;
            AuthorTextBox.Text = snippet.Header.Author;
            CodeTempleteRichTextBox.Text = snippet.Snippet.Code.Content;
            TitleTextBox.Text = snippet.Header.Title;
            ShortcutTextBox.Text = snippet.Header.Shortcut;
            LanguageComboBox.Text = snippet.Snippet.Code.Language;

            foreach (var checkBox in _snippetTypesCheckBoxes)
            {
                var type = checkBox.Text;
                checkBox.Checked = snippet.Header.SnippetTypes.Contains(type);
            }

            ClearLiteralGroup();
            ClearNamespaceGroup();

            void ClearLiteralGroup()
            {
                VariableListBox.Items.Clear();
                VariableListBox.Items.AddRange(snippet.Snippet.Declarations.Select(x => x.ToString()).ToArray());

                VariableIdTextBox.Clear();
                DefaultNameTextBox.Clear();
            }

            void ClearNamespaceGroup()
            {
                ImportListBox.Items.Clear();
                ImportListBox.Items.AddRange(snippet.Snippet.Imports.Import.Select(x => x.Namespace).ToArray());

                NamespaceTextBox.Clear();
            }
        }

        static void FailureOpeningFile()
        {
            MessageBox.Show("ファイルの読み込みに失敗しました。", "エラー");
        }

        void OpenFile(int index, string[] snippets, string filename)
        {
            SnippetListBox.Items.Clear();
            SnippetListBox.Items.AddRange(snippets);

            SnippetListBox.SelectedIndex = index;

            Text = $"{filename} - CodeSnippetEditor";
        }

        void ChangedNamespace(int sIndex, int iIndex, string @namespace)
        {
            NamespaceTextBox.Text = @namespace;
            ImportListBox.Items[iIndex] = @namespace;
        }

        void DeleteImport(int sIndex, int iIndex)
        {
            SnippetListBox.SelectedIndex = sIndex;

            ImportListBox.Items.RemoveAt(iIndex);
            ImportListBox.SelectedIndex = iIndex - 1;
        }

        void AddImport(int sIndex, int iIndex, string[] imports)
        {
            SnippetListBox.SelectedIndex = sIndex;

            ImportListBox.Items.Clear();
            ImportListBox.Items.AddRange(imports);
            ImportListBox.SelectedIndex = iIndex;
        }

        void ChangeImportIndex(int sIndex, int iIndex, Import import)
        {
            ImportListBox.SelectedIndex = iIndex;
            NamespaceTextBox.Text = import.Namespace;
        }

        void AutoAddVariable(int sIndex, int vIndex, string[] variables)
        {
            SnippetListBox.SelectedIndex = sIndex;

            VariableListBox.Items.Clear();
            VariableListBox.Items.AddRange(variables);
            VariableListBox.SelectedIndex = vIndex;
        }

        void DeleteVariable(int vIndex)
        {
            VariableListBox.Items.RemoveAt(vIndex);

            VariableIdTextBox.ResetText();
            DefaultNameTextBox.ResetText();
            VariableListBox.SelectedIndex = vIndex - 1;
        }

        void ChangeVariableDefault(ChangedVariableDefaultOperation op)
        {
            var (sIndex, vIndex, name) = op;
            DefaultNameTextBox.Text = name;
        }

        void ChangeVariableId(ChangedVariableIdOperation op)
        {
            var (sIndex, vIndex, id) = op;
            VariableIdTextBox.Text = id;
            VariableListBox.Items[vIndex] = id;
        }

        void AddVariable(AddVariableOperation op)
        {
            var (index, literals) = op;

            VariableListBox.Items.Clear();
            VariableListBox.Items.AddRange(literals.Select(x => x.ToString()).ToArray());

            VariableListBox.SelectedIndex = index;
        }

        void ChangeVariableIndex(ChangeVariableIndexOperation op)
        {
            VariableIdTextBox.Text = op.Literal.ID;
            DefaultNameTextBox.Text = op.Literal.Default;
        }

        void ChangeLanguage(ChangedLanguageOperation op)
        {
            LanguageComboBox.Text = op.Langage;
        }

        void ChangeTitle(ChangedTitleOperation op)
        {
            var (index, title) = op;
            TitleTextBox.Text = title;
            SnippetListBox.Items[index] = title;
        }

        void ChangeShortcut(ChangedShortcutOperation op)
        {
            ShortcutTextBox.Text = op.Shortcut;
        }

        void ChangedCode(ChangedCodeOperation op)
        {
            Debug.WriteLine(op.Code);
            var position = CodeTempleteRichTextBox.SelectionStart;
            CodeTempleteRichTextBox.Text = op.Code;
            CodeTempleteRichTextBox.SelectionStart = position;
        }

        void ChangeSnippetType(ChangedSnippetTypeOperation op) => _ = op.SnippetType switch
        {
            SnippetType.SurroundsWith => SurroundsWithCheckBox.Checked = op.Enabled,
            SnippetType.Expansion => ExpansionCheckBox.Checked = op.Enabled,
            SnippetType.Refactoring => RefactoringCheckBox.Checked = op.Enabled,
            _ => throw new NotImplementedException($"{nameof(ChangeSnippetType)} {op.SnippetType}"),
        };

        void ChangeAuthor(ChangedAuthorOperation op)
        {
            AuthorTextBox.Text = op.Author;
        }

        void DeleteSnippet(DeleteSnippetOperation op)
        {
            var index = op.Index;
            SnippetListBox.Items.RemoveAt(index);

            // listBox の SelectedIndex が -1 になっている間にテキストをリセットする。
            ResetHeader();
            ResetVariable();
            ResetImport();
            ResetCode();

            SnippetListBox.SelectedIndex = index - 1;

            void ResetSnippetTypes()
            {
                ExpansionCheckBox.Checked = false;
                RefactoringCheckBox.Checked = false;
                SurroundsWithCheckBox.Checked = false;
            }

            void ResetHeader()
            {
                AuthorTextBox.ResetText();
                TitleTextBox.ResetText();
                ShortcutTextBox.ResetText();
                ResetSnippetTypes();
            }

            void ResetVariable()
            {
                VariableListBox.Items.Clear();
                DefaultNameTextBox.Clear();
                VariableIdTextBox.Clear();
            }

            void ResetImport()
            {
                ImportListBox.Items.Clear();
                NamespaceTextBox.Clear();
            }

            void ResetCode()
            {
                LanguageComboBox.ResetText();
                CodeTempleteRichTextBox.ResetText();
            }
        }
    }

    void IRedoUndo<IOperation>.ExecuteUndo(IOperation operation)
    {

    }

    void IRedoUndo<IOperation>.SetProgress(int step) { }
}
