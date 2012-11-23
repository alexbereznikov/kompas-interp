namespace KompasSharp.Plugin.Forms
{
    using System;
    using System.Windows.Forms;

    using Kompas6API5;

    using KompasSharp.Interp;

    public partial class MainForm : Form
    {
        #region Constants and Fields

        private readonly Interpretator interpretator;

        #endregion

        #region Constructors and Destructors

        public MainForm(KompasObject kompas)
        {
            this.InitializeComponent();
            this.interpretator = new Interpretator(kompas);
        }

        #endregion

        #region Methods

        private void runCommandButton_Click(object sender, EventArgs e)
        {
            string text = this.commandTextBox.Text;
            this.commandTextBox.Text = string.Empty;

            if (text == string.Empty)
            {
                return;
            }

            this.resultTextBox.Text += "> " + text + Environment.NewLine;
            this.resultTextBox.Text += this.interpretator.Interpret(text) + Environment.NewLine;
        }

        #endregion
    }
}