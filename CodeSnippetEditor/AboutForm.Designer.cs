using System.Drawing;
using System.Windows.Forms;

namespace CodeSnippetEditor.Forms
{
    partial class AboutForm
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
            label1 = new Label();
            label2 = new Label();
            LibraryLinkLabel = new LinkLabel();
            label4 = new Label();
            VersionLabel = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(288, 45);
            label1.TabIndex = 0;
            label1.Text = "CodeSnippetEditor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "© 2023 crimson-tea";
            // 
            // LibraryLinkLabel
            // 
            LibraryLinkLabel.AutoSize = true;
            LibraryLinkLabel.Location = new Point(12, 143);
            LibraryLinkLabel.Name = "LibraryLinkLabel";
            LibraryLinkLabel.Size = new Size(0, 15);
            LibraryLinkLabel.TabIndex = 3;
            LibraryLinkLabel.LinkClicked += LibraryLinkLabel_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(306, 33);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 7;
            label4.Text = "version:";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(351, 33);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(40, 15);
            VersionLabel.TabIndex = 8;
            VersionLabel.Text = "0.0.0.0";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(130, 54);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(279, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/crimson-tea/CodeSnippetEditor";
            linkLabel1.LinkClicked += LibraryLinkLabel_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 89);
            Controls.Add(linkLabel1);
            Controls.Add(VersionLabel);
            Controls.Add(label4);
            Controls.Add(LibraryLinkLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "AboutForm";
            Text = "CodeSnippetEditorについて";
            KeyDown += AboutForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private LinkLabel LibraryLinkLabel;
        private Label label4;
        private Label VersionLabel;
        private LinkLabel linkLabel1;
    }
}