using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Connect_Four
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int difficulty=0;
            if (radioButton1.Checked == true)
                difficulty = 1;
            else if (radioButton2.Checked == true)
                difficulty = 2;
            else if (radioButton3.Checked == true)
                difficulty = 3;

            this.Hide();                                    //dont know how this snippet works
            var form1 = new Form1(difficulty);              //got from http://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form  
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }
    }
}
