using CodeSnippetEditor.SnippetDefinition;
using CodeSnippetEditor.SnippetDefinition.Snippet;

namespace CodeSnippetEditor.Messages
{
    /// <summary>
    /// Form から SnippetManager へ送るメッセージです。
    /// </summary>
    public interface IMessage { }

    /// <summary>
    /// SnippetManager から Form へ送る命令です。
    /// </summary>
    public interface IOperation { }

    /// <summary>
    /// スニペットを追加することを伝えるメッセージです。
    /// </summary>
    /// <param name="Index">-1のときは新規に追加します。0以上のときはその index のスニペットをクローンします。</param>
    public record AddSnippetMessage(int Index = -1) : IMessage;
    public record AddSnippetOperation(string[] Snippets, int SelectedIndex) : IOperation;

    public record DeleteSnippetMessage(int Index) : IMessage;
    public record DeleteSnippetOperation(int Index) : IOperation;

    public record ChangeSnippetIndexMessage(int Index = -1) : IMessage;
    public record ChangeSnippetIndexOperation(int Index, CodeSnippet Snippet) : IOperation;

    public record ChangeVariableIndexMessage(int SnippetIndex, int VariableIndex) : IMessage;
    public record ChangeVariableIndexOperation(int SnippetIndex, int VariableIndex, Literal Literal) : IOperation;

    public record AddVariableMessage(int Index) : IMessage;
    public record AddVariableOperation(int VariableIndex, Literal[] Literals) : IOperation;

    public record DeleteVariableMessage(int SIndex, int VIndex) : IMessage;
    public record DeleteVariableOperation(int VariableIndex) : IOperation;

    public record ChangedAuthorMessage(int Index, string Author) : IMessage;
    public record ChangedAuthorOperation(string Author) : IOperation;

    public record ChangedTitleMessage(int Index, string Title) : IMessage;
    public record ChangedTitleOperation(int Index, string Title) : IOperation;

    public record ChangedLanguageMessage(int Index, string Language) : IMessage;
    public record ChangedLanguageOperation(string Langage) : IOperation;

    public record ChangedShortcutMessage(int Index, string Shortcut) : IMessage;
    public record ChangedShortcutOperation(string Shortcut) : IOperation;

    public record ChangedCodeMessage(int Index, string Code) : IMessage;
    public record ChangedCodeOperation(string Code) : IOperation;

    public record ChangedVariableIdMessage(int SnippetIndex, int VariableIndex, string Id) : IMessage;
    public record ChangedVariableIdOperation(int SnippetIndex, int VariableIndex, string Id) : IOperation;

    public record ChangedVariableDefaultMessage(int SnippetIndex, int VariableIndex, string Default) : IMessage;
    public record ChangedVariableDefaultOperation(int SnippetIndex, int VariableIndex, string Default) : IOperation;

    public record ChangedSnippetTypeMessage(int Index, SnippetType SnippetType, bool Enabled) : IMessage;
    public record ChangedSnippetTypeOperation(SnippetType SnippetType, bool Enabled) : IOperation;

    public record AddVariableFromCodeMessage(int Index) : IMessage;
    public record AddVariableFromCodeOperation(int SIndex, int VIndex, string[] Variables) : IOperation;

    public record AddImportMessage(int SnippetIndex, string Namespace) : IMessage;
    public record AddImportOperation(int SnippetIndex, int ImportIndex, string[] Imports) : IOperation;

    public record DeleteImportMessage(int SnippetIndex, int ImportIndex) : IMessage;
    public record DeleteImportOperation(int SnippetIndex, int ImportIndex) : IOperation;

    public record ChangedNamespaceMessage(int SnippetIndex, int ImportIndex, string Namespace) : IMessage;
    public record ChangedNamespaceOperation(int SnippetIndex, int ImportIndex, string Namespace) : IOperation;

    public record ChangeImportIndexMessage(int SnippetIndex, int ImportIndex) : IMessage;
    public record ChangeImportIndexOperation(int SnippetIndex, int ImportIndex, Import Import) : IOperation;

    public record OpenFileMessage(string Path) : IMessage;
    public interface IOpenFileOperation : IOperation
    {
        public record Success(int SnippetIndex, string[] Snippets, string Filename) : IOpenFileOperation;
        public record Failure() : IOpenFileOperation;
    }
}
