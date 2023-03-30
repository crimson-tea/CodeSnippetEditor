using System;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CodeSnippetEditor.SnippetDefinition
{
    /// <remarks/>
    /// <summary>
    /// 複数のコードスニペットをまとめるクラス。
    /// CodeSnippets
    ///   CodeSnippetsCodeSnippet
    ///     CodeSnippetsCodeSnippetHeader
    ///     CodeSnippetsCodeSnippetSnippet
    ///       Code
    ///       CodeSnippetsCodeSnippetSnippetLiteral
    ///     CodeSnippetsCodeSnippetSnippetImports
    ///       CodeSnippetsCodeSnippetSnippetImportsImport
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet", IsNullable = false)]
    public record CodeSnippets([property: XmlElement("CodeSnippet")] CodeSnippet[] CodeSnippet)
    {
        public CodeSnippets() : this(Array.Empty<CodeSnippet>()) { }
    }

    /// <remarks/>
    /// <summary>
    /// コードスニペット。
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
    public record CodeSnippet(
        Header.Header Header,
        Snippet.Snippet Snippet,
        [property: XmlAttribute()] string Format)
    {
        public CodeSnippet() : this(new(), new(), Format: "1.0.0") { }

        public override string ToString() => Header.Title;
    }

    namespace Header
    {
        /// <remarks/>
        /// <summary>
        /// コードスニペットのヘッダー。
        /// コード本体以外の概要などが入る。
        /// </summary>
        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Header(string Title,
            string Shortcut,
            string Description,
            string Author,
            [property: XmlArrayItem("SnippetType", IsNullable = false)] string[] SnippetTypes)
        {
            public Header() : this("NewSnippet", string.Empty, string.Empty, string.Empty, Array.Empty<string>()) { }
        }
    }

    namespace Snippet
    {
        /// <remarks/>
        /// <summary>
        /// コードスニペット定義。
        /// </summary>
        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Snippet(
            [property: XmlArrayItem("Literal", IsNullable = false)] Literal[] Declarations,
            // CodeSnippetsCodeSnippetSnippetCode Code,
            Code Code,
            Imports Imports)
        {
            public Snippet() : this(Array.Empty<Literal>(), new(), new()) { }
        }

        /// <remarks/>
        /// <summary>
        /// コードスニペットの変数定義。
        /// </summary>
        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Literal(
            string ID,
            string Function,
            string ToolTip,
            string Default,
            [property: XmlAttribute()] bool Editable,
            [property: XmlIgnore()] bool EditableSpecified)
        {
            public Literal(string id) : this(ID: id, string.Empty, string.Empty, string.Empty, false, false) { }
            public Literal(string id, string defaultName) : this(ID: id, string.Empty, string.Empty, Default: defaultName, false, false) { }

            public Literal() : this(string.Empty, string.Empty, string.Empty, string.Empty, false, false) { }
            public override string ToString() => $"{ID}";
            public void Deconstruct(out string id, out string defaultName) => (id, defaultName) = (ID, Default);
        }

        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Code([property: XmlAttribute()] string Language)
        {
            public Code() : this(string.Empty) { }

            [XmlIgnore]
            public string Content { get; set; } = string.Empty;

            [XmlText]
            public XmlNode[] CDataContent
            {
                get => new XmlNode[] { new XmlDocument().CreateCDataSection(Content) };
                set
                {
                    Content = value switch
                    {
                        XmlNode[] nodes when nodes.Length == 1 => nodes.Single() switch
                        {
                            XmlNode node => node.InnerText,
                            _ => string.Empty,
                        },
                        _ => string.Empty,
                    };
                }
            }
        }

        /// <remarks/>
        /// <summary>
        /// <paramref name="CodeSnippetsCodeSnippetSnippetImportsImport"/> をまとめるクラス。 
        /// </summary>
        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Imports([property: XmlElement("Import", IsNullable = false)] Import[] Import)
        {
            public Imports() : this(Array.Empty<Import>()) { }
        }

        /// <remarks/>
        /// <summary>
        /// 名前空間の設定をする。
        /// </summary>
        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
        public record Import(string Namespace)
        {
            public Import() : this(string.Empty) { }
        }
    }
}
