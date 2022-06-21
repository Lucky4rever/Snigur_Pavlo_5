using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОП2_2_Снігур
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Trees> tree = new List<Trees>();
        List<Trees> sortedtree = new List<Trees>();
        private void Form1_Load(object sender, EventArgs e)
        {
            tree.Add(new Trees() { Type = "Дуб", Age=32, Health="Здорове", Pests=false});
            tree.Add(new Trees() { Type = "Дуб", Age=24, Health= "Потребує догляду", Pests=true});
            tree.Add(new Trees() { Type = "Ялина", Age=32, Health="Хворе", Pests=false});
            tree.Add(new Trees() { Type = "Клен", Age=54, Health= "Засихає", Pests=false});
            tree.Add(new Trees() { Type = "Клен", Age=16, Health="Здорове", Pests=false});
            tree.Add(new Trees() { Type = "Клен", Age=16, Health="Потребує догляду", Pests=true});
            sortedtree = tree;
            comboBox1.DataSource = tree;
            comboBox1.DisplayMember = "Type";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Trees x = (Trees)comboBox1.SelectedItem;
                textBox1.Text = x.Type;
                textBox2.Text = x.Age.ToString();
                textBox3.Text = x.Health;
                textBox4.Text = x.Pests ? "Із шкідниками" : "Без шкідників";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sortedtree = tree.OrderBy(o => o.Type).ToList();
            Resoursing();
        }
        private void Resoursing()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = sortedtree;
            comboBox1.DisplayMember = "Type";
            textBox6.Text=(5*sortedtree.Distinct().Count()).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sortedtree = tree.OrderBy(o => o.Age).ToList();
            Resoursing();
        }
        public void Search()
        {
            List<string> name = new List<string>();
            foreach(var a in tree)
                name.Add(a.Type.ToString());
            var h = new Dictionary<string, int>();
            foreach (var i in name)
            {
                int res;
                if (h.TryGetValue(i, out res))
                    h[i] += 1;
                else
                    h.Add(i, 1);
            }
            h = h.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            sortedtree.Clear();
            foreach(var a in h)
                foreach (var b in tree)
                    if (a.Key == b.Type)
                        sortedtree.Add(b);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search();
            Resoursing();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sortedtree.Add(new Trees() { Type = textBox1.Text, Age = Int32.Parse(textBox2.Text), Health=textBox3.Text, Pests = (textBox4.Text== "Із шкідниками") ? true : false });
            Resoursing();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Trees x = (Trees)comboBox1.SelectedItem;
            sortedtree.Remove(x);
            Resoursing();
        }
    }
}
