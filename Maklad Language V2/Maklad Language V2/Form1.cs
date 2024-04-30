using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;
namespace Maklad_Language_V2
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("Maklad v2.cgt",listBox1,listBox2);
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            p.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Splitting the text into lexeme and token
            string lexeme = "lexeme";
            string token = "token";

            // Creating the formatted text
            string formattedText = $"{lexeme}\t\t{token}";

            // Adding the text to listBox2 with green color
            listBox2.Items.Add(formattedText);

            listBox2.ForeColor = Color.Green;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
