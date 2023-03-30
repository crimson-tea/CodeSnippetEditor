using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CodeSnippetEditor.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            VersionLabel.Text = GetVersion();

            static string GetVersion()
            {
                var asm = Assembly.GetExecutingAssembly();
                var asmName = asm.GetName();
                return asmName?.Version?.ToString() ?? "0.0.0.0";
            }
        }

        private readonly string _edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        private void LibraryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            var link = linkLabel.Text;
            linkLabel.LinkVisited = true;

            if (Path.Exists(_edgePath))
            {
                Process.Start(_edgePath, link);
            }
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }
        }
    }
}
