/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/14/2024
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
namespace codefromformlayout
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
	 		StringBuilder sourceCode = new StringBuilder();
            GenerateSourceCode(this.Controls, sourceCode);
            MessageBox.Show(sourceCode.ToString(), "Generated Source Code");
            TextBox tmp  = new TextBox();
            tmp.Text = sourceCode.ToString();
            Clipboard.SetText(tmp.Text.ToString());
		}
		
		

        private void GenerateSourceCode(Control.ControlCollection controls, StringBuilder sourceCode)
        {
            foreach (Control control in controls)
            {
                sourceCode.AppendLine("// {control.GetType().Name}");
                sourceCode.AppendLine("var {control.Name} = new {control.GetType().Name}();");
                sourceCode.AppendLine("{control.Name}.Location = new System.Drawing.Point({control.Location.X}, {control.Location.Y});");
                sourceCode.AppendLine("{control.Name}.Size = new System.Drawing.Size({control.Size.Width}, {control.Size.Height});");
                sourceCode.AppendLine("{control.Name}.Text = \"{control.Text}\";");
                sourceCode.AppendLine("this.Controls.Add({control.Name});");
                sourceCode.AppendLine();

                if (control.Controls.Count > 0)
                {
                    GenerateSourceCode(control.Controls, sourceCode);
                   
                }
            }
        }
	}
}
