using System.Drawing;
using System.Windows.Forms;

namespace CodeSnippetEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AuthorTextBox = new TextBox();
            SnippetListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            TitleTextBox = new TextBox();
            label3 = new Label();
            ShortcutTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            CodeTempleteRichTextBox = new RichTextBox();
            AddButton = new Button();
            MinusButton = new Button();
            CloneButton = new Button();
            VariableListBox = new ListBox();
            VariableIdTextBox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            DefaultNameTextBox = new TextBox();
            RemoveVariableButton = new Button();
            AddVariableButton = new Button();
            label8 = new Label();
            label9 = new Label();
            LanguageComboBox = new ComboBox();
            label10 = new Label();
            SurroundsWithCheckBox = new CheckBox();
            ExpansionCheckBox = new CheckBox();
            RefactoringCheckBox = new CheckBox();
            AutoAddVariableButton = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label11 = new Label();
            ImportListBox = new ListBox();
            NamespaceTextBox = new TextBox();
            label12 = new Label();
            DeleteNamespaceButton = new Button();
            AddNamespaceButton = new Button();
            groupBox3 = new GroupBox();
            menuStrip1 = new MenuStrip();
            編集EToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveOverwriteToolStripMenuItem = new ToolStripMenuItem();
            SaveNewToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            InsertEndAtCaretButton = new Button();
            InsertEndAtLastButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // AuthorTextBox
            // 
            AuthorTextBox.Location = new Point(6, 34);
            AuthorTextBox.Name = "AuthorTextBox";
            AuthorTextBox.Size = new Size(149, 23);
            AuthorTextBox.TabIndex = 1;
            AuthorTextBox.Tag = "";
            AuthorTextBox.TextChanged += TextBox_TextChanged;
            // 
            // SnippetListBox
            // 
            SnippetListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SnippetListBox.FormattingEnabled = true;
            SnippetListBox.ItemHeight = 15;
            SnippetListBox.Location = new Point(12, 42);
            SnippetListBox.Name = "SnippetListBox";
            SnippetListBox.Size = new Size(205, 439);
            SnippetListBox.TabIndex = 2;
            SnippetListBox.SelectedIndexChanged += SnippetListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 16);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Author:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 60);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 5;
            label2.Text = "Title:";
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(6, 78);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(304, 23);
            TitleTextBox.TabIndex = 4;
            TitleTextBox.TextChanged += TextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(161, 16);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "Shortcut:";
            // 
            // ShortcutTextBox
            // 
            ShortcutTextBox.Location = new Point(161, 34);
            ShortcutTextBox.Name = "ShortcutTextBox";
            ShortcutTextBox.Size = new Size(149, 23);
            ShortcutTextBox.TabIndex = 3;
            ShortcutTextBox.TextChanged += TextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 104);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 9;
            label4.Text = "SnippetType:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(223, 228);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 11;
            label5.Text = "Code:";
            // 
            // CodeTempleteRichTextBox
            // 
            CodeTempleteRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CodeTempleteRichTextBox.Location = new Point(223, 246);
            CodeTempleteRichTextBox.Name = "CodeTempleteRichTextBox";
            CodeTempleteRichTextBox.Size = new Size(788, 235);
            CodeTempleteRichTextBox.TabIndex = 10;
            CodeTempleteRichTextBox.Text = "";
            CodeTempleteRichTextBox.TextChanged += TextBox_TextChanged;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddButton.Location = new Point(194, 492);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(23, 23);
            AddButton.TabIndex = 3;
            AddButton.Text = "+";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // MinusButton
            // 
            MinusButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            MinusButton.Location = new Point(165, 492);
            MinusButton.Name = "MinusButton";
            MinusButton.Size = new Size(23, 23);
            MinusButton.TabIndex = 4;
            MinusButton.Text = "-";
            MinusButton.UseVisualStyleBackColor = true;
            MinusButton.Click += MinusButton_Click;
            // 
            // CloneButton
            // 
            CloneButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CloneButton.Location = new Point(12, 492);
            CloneButton.Name = "CloneButton";
            CloneButton.Size = new Size(70, 23);
            CloneButton.TabIndex = 5;
            CloneButton.Text = "Clone";
            CloneButton.UseVisualStyleBackColor = true;
            CloneButton.Click += CloneButton_Click;
            // 
            // VariableListBox
            // 
            VariableListBox.FormattingEnabled = true;
            VariableListBox.ItemHeight = 15;
            VariableListBox.Location = new Point(6, 37);
            VariableListBox.Name = "VariableListBox";
            VariableListBox.Size = new Size(147, 109);
            VariableListBox.TabIndex = 1;
            VariableListBox.SelectedIndexChanged += VariableListBox_SelectedIndexChanged;
            // 
            // VariableIdTextBox
            // 
            VariableIdTextBox.Location = new Point(159, 37);
            VariableIdTextBox.Name = "VariableIdTextBox";
            VariableIdTextBox.Size = new Size(128, 23);
            VariableIdTextBox.TabIndex = 5;
            VariableIdTextBox.TextChanged += VariableTextBox_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(159, 19);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 19;
            label6.Text = "Id:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(159, 63);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 21;
            label7.Text = "DefaultName:";
            // 
            // DefaultNameTextBox
            // 
            DefaultNameTextBox.Location = new Point(159, 81);
            DefaultNameTextBox.Name = "DefaultNameTextBox";
            DefaultNameTextBox.Size = new Size(128, 23);
            DefaultNameTextBox.TabIndex = 6;
            DefaultNameTextBox.TextChanged += VariableTextBox_TextChanged;
            // 
            // RemoveVariableButton
            // 
            RemoveVariableButton.Location = new Point(101, 152);
            RemoveVariableButton.Name = "RemoveVariableButton";
            RemoveVariableButton.Size = new Size(23, 23);
            RemoveVariableButton.TabIndex = 3;
            RemoveVariableButton.Text = "-";
            RemoveVariableButton.UseVisualStyleBackColor = true;
            RemoveVariableButton.Click += RemoveVariableButton_Click;
            // 
            // AddVariableButton
            // 
            AddVariableButton.Location = new Point(130, 152);
            AddVariableButton.Name = "AddVariableButton";
            AddVariableButton.Size = new Size(23, 23);
            AddVariableButton.TabIndex = 2;
            AddVariableButton.Text = "+";
            AddVariableButton.UseVisualStyleBackColor = true;
            AddVariableButton.Click += AddVariableButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 19);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 24;
            label8.Text = "Variables:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 24);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 25;
            label9.Text = "Snippets:";
            // 
            // LanguageComboBox
            // 
            LanguageComboBox.FormattingEnabled = true;
            LanguageComboBox.Location = new Point(223, 202);
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new Size(105, 23);
            LanguageComboBox.TabIndex = 9;
            LanguageComboBox.TextChanged += TextBox_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(223, 184);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 27;
            label10.Text = "Language:";
            // 
            // SurroundsWithCheckBox
            // 
            SurroundsWithCheckBox.AutoSize = true;
            SurroundsWithCheckBox.Location = new Point(6, 122);
            SurroundsWithCheckBox.Name = "SurroundsWithCheckBox";
            SurroundsWithCheckBox.Size = new Size(105, 19);
            SurroundsWithCheckBox.TabIndex = 28;
            SurroundsWithCheckBox.Text = "SurroundsWith";
            SurroundsWithCheckBox.UseVisualStyleBackColor = false;
            SurroundsWithCheckBox.CheckedChanged += SnippetTypeCheckBox_CheckedChanged;
            // 
            // ExpansionCheckBox
            // 
            ExpansionCheckBox.AutoSize = true;
            ExpansionCheckBox.Location = new Point(117, 122);
            ExpansionCheckBox.Name = "ExpansionCheckBox";
            ExpansionCheckBox.Size = new Size(80, 19);
            ExpansionCheckBox.TabIndex = 29;
            ExpansionCheckBox.Text = "Expansion";
            ExpansionCheckBox.UseVisualStyleBackColor = true;
            ExpansionCheckBox.CheckedChanged += SnippetTypeCheckBox_CheckedChanged;
            // 
            // RefactoringCheckBox
            // 
            RefactoringCheckBox.AutoSize = true;
            RefactoringCheckBox.Location = new Point(203, 122);
            RefactoringCheckBox.Name = "RefactoringCheckBox";
            RefactoringCheckBox.Size = new Size(87, 19);
            RefactoringCheckBox.TabIndex = 30;
            RefactoringCheckBox.Text = "Refactoring";
            RefactoringCheckBox.UseVisualStyleBackColor = true;
            RefactoringCheckBox.CheckedChanged += SnippetTypeCheckBox_CheckedChanged;
            // 
            // AutoAddVariableButton
            // 
            AutoAddVariableButton.Location = new Point(6, 181);
            AutoAddVariableButton.Name = "AutoAddVariableButton";
            AutoAddVariableButton.Size = new Size(147, 23);
            AutoAddVariableButton.TabIndex = 4;
            AutoAddVariableButton.Text = "Add from the Code";
            AutoAddVariableButton.UseVisualStyleBackColor = true;
            AutoAddVariableButton.Click += AutoAddVariableButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(AutoAddVariableButton);
            groupBox1.Controls.Add(VariableListBox);
            groupBox1.Controls.Add(VariableIdTextBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(DefaultNameTextBox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(RemoveVariableButton);
            groupBox1.Controls.Add(AddVariableButton);
            groupBox1.Location = new Point(548, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 213);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Literal:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(ImportListBox);
            groupBox2.Controls.Add(NamespaceTextBox);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(DeleteNamespaceButton);
            groupBox2.Controls.Add(AddNamespaceButton);
            groupBox2.Location = new Point(850, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(161, 213);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Import:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 19);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 24;
            label11.Text = "Imports:";
            // 
            // ImportListBox
            // 
            ImportListBox.FormattingEnabled = true;
            ImportListBox.ItemHeight = 15;
            ImportListBox.Location = new Point(6, 37);
            ImportListBox.Name = "ImportListBox";
            ImportListBox.Size = new Size(147, 109);
            ImportListBox.TabIndex = 1;
            ImportListBox.SelectedIndexChanged += ImportListBox_SelectedIndexChanged;
            // 
            // NamespaceTextBox
            // 
            NamespaceTextBox.Location = new Point(6, 181);
            NamespaceTextBox.Name = "NamespaceTextBox";
            NamespaceTextBox.Size = new Size(147, 23);
            NamespaceTextBox.TabIndex = 4;
            NamespaceTextBox.TextChanged += NamespaceTextBox_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 163);
            label12.Name = "label12";
            label12.Size = new Size(71, 15);
            label12.TabIndex = 19;
            label12.Text = "Namespace:";
            // 
            // DeleteNamespaceButton
            // 
            DeleteNamespaceButton.Location = new Point(101, 152);
            DeleteNamespaceButton.Name = "DeleteNamespaceButton";
            DeleteNamespaceButton.Size = new Size(23, 23);
            DeleteNamespaceButton.TabIndex = 3;
            DeleteNamespaceButton.Text = "-";
            DeleteNamespaceButton.UseVisualStyleBackColor = true;
            DeleteNamespaceButton.Click += DeleteNamespaceButton_Click;
            // 
            // AddNamespaceButton
            // 
            AddNamespaceButton.Location = new Point(130, 152);
            AddNamespaceButton.Name = "AddNamespaceButton";
            AddNamespaceButton.Size = new Size(23, 23);
            AddNamespaceButton.TabIndex = 2;
            AddNamespaceButton.Text = "+";
            AddNamespaceButton.UseVisualStyleBackColor = true;
            AddNamespaceButton.Click += AddNamespaceButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(AuthorTextBox);
            groupBox3.Controls.Add(TitleTextBox);
            groupBox3.Controls.Add(RefactoringCheckBox);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(ExpansionCheckBox);
            groupBox3.Controls.Add(ShortcutTextBox);
            groupBox3.Controls.Add(SurroundsWithCheckBox);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(223, 27);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(319, 146);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Header:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 編集EToolStripMenuItem, AboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 24);
            menuStrip1.TabIndex = 35;
            menuStrip1.Text = "menuStrip1";
            // 
            // 編集EToolStripMenuItem
            // 
            編集EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem, SaveOverwriteToolStripMenuItem, SaveNewToolStripMenuItem });
            編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            編集EToolStripMenuItem.Size = new Size(57, 20);
            編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(255, 22);
            OpenToolStripMenuItem.Text = "開く(&O)...";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveOverwriteToolStripMenuItem
            // 
            SaveOverwriteToolStripMenuItem.Name = "SaveOverwriteToolStripMenuItem";
            SaveOverwriteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveOverwriteToolStripMenuItem.Size = new Size(255, 22);
            SaveOverwriteToolStripMenuItem.Text = "上書き保存(&E)";
            SaveOverwriteToolStripMenuItem.Click += SaveOverwriteToolStripMenuItem_Click;
            // 
            // SaveNewToolStripMenuItem
            // 
            SaveNewToolStripMenuItem.Name = "SaveNewToolStripMenuItem";
            SaveNewToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveNewToolStripMenuItem.Size = new Size(255, 22);
            SaveNewToolStripMenuItem.Text = "名前を付けて保存(&S)...";
            SaveNewToolStripMenuItem.Click += SaveNewToolStripMenuItem_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(77, 20);
            AboutToolStripMenuItem.Text = "About(&A)...";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // InsertEndAtCaretButton
            // 
            InsertEndAtCaretButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            InsertEndAtCaretButton.Location = new Point(741, 492);
            InsertEndAtCaretButton.Name = "InsertEndAtCaretButton";
            InsertEndAtCaretButton.Size = new Size(132, 23);
            InsertEndAtCaretButton.TabIndex = 36;
            InsertEndAtCaretButton.Text = "Insert $end$ at caret";
            InsertEndAtCaretButton.UseVisualStyleBackColor = true;
            InsertEndAtCaretButton.Click += InsertEndAtCaretButton_Click;
            // 
            // InsertEndAtLastButton
            // 
            InsertEndAtLastButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            InsertEndAtLastButton.Location = new Point(879, 492);
            InsertEndAtLastButton.Name = "InsertEndAtLastButton";
            InsertEndAtLastButton.Size = new Size(132, 23);
            InsertEndAtLastButton.TabIndex = 37;
            InsertEndAtLastButton.Text = "Insert $end$ at last";
            InsertEndAtLastButton.UseVisualStyleBackColor = true;
            InsertEndAtLastButton.Click += InsertEndAtLastButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 527);
            Controls.Add(InsertEndAtLastButton);
            Controls.Add(InsertEndAtCaretButton);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label9);
            Controls.Add(CloneButton);
            Controls.Add(MinusButton);
            Controls.Add(AddButton);
            Controls.Add(CodeTempleteRichTextBox);
            Controls.Add(label5);
            Controls.Add(label10);
            Controls.Add(SnippetListBox);
            Controls.Add(LanguageComboBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "CodeSnippetEditor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox AuthorTextBox;
        private ListBox SnippetListBox;
        private Label label1;
        private Label label2;
        private TextBox TitleTextBox;
        private Label label3;
        private TextBox ShortcutTextBox;
        private Label label4;
        private Label label5;
        private RichTextBox CodeTempleteRichTextBox;
        private Button AddButton;
        private Button MinusButton;
        private Button CloneButton;
        private ListBox VariableListBox;
        private TextBox VariableIdTextBox;
        private Label label6;
        private Label label7;
        private TextBox DefaultNameTextBox;
        private Button RemoveVariableButton;
        private Button AddVariableButton;
        private Label label8;
        private Label label9;
        private ComboBox LanguageComboBox;
        private Label label10;
        private CheckBox SurroundsWithCheckBox;
        private CheckBox ExpansionCheckBox;
        private CheckBox RefactoringCheckBox;
        private Button AutoAddVariableButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label11;
        private ListBox ImportListBox;
        private TextBox NamespaceTextBox;
        private Button DeleteNamespaceButton;
        private Button AddNamespaceButton;
        private GroupBox groupBox3;
        private Label label12;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 編集EToolStripMenuItem;
        private ToolStripMenuItem SaveNewToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveOverwriteToolStripMenuItem;
        private Button InsertEndAtCaretButton;
        private Button InsertEndAtLastButton;
    }
}