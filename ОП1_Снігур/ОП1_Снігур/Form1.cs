using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace ОП1_Снігур
{
    public partial class Form1 : Form
    {
        List<Завдання1> list = new List<Завдання1>();
        internal const string filename = "Task1_2.json";
        public Form1()
        {
            InitializeComponent();
            list.Add(new Завдання1() { Lesson = "Ліжко", time = "10:00", time0 = "8:30", Сomment = "Піднятись і піти здати цю кляту лабу" });
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "ToTime";
            comboBox2.DataSource = list;
            comboBox2.DisplayMember = "Lesson";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Завдання1 task = (Завдання1)comboBox1.SelectedValue;
            Serialize(task.ToString());
            timeStartBox.Text = task.time0;
            timeEndBox.Text = task.time;
            placeBox.Text = task.Lesson;
            textBox.Text = task.Сomment;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var index = list.FindIndex(Завдання1 => Завдання1.ToTime == comboBox1.Text);
            list[index] = new Завдання1() { time0 = timeStartBox.Text, time = timeEndBox.Text, Lesson = placeBox.Text, Сomment = textBox.Text };
            refreshList(list);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            list.Add(new Завдання1() { time0 = timeStartBox.Text, time = timeEndBox.Text, Lesson = placeBox.Text, Сomment = textBox.Text });
            refreshList(list);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            list.RemoveAt(list.FindIndex(Завдання1 => Завдання1.ToTime == comboBox1.Text));
            list.Add (new Завдання1() { time0=timeStartBox.Text, time=timeEndBox.Text });
            refreshList(list);
        }

        private void refreshList(List<Завдання1> list)
        {
            BindingList<Завдання1> bindinglist = new BindingList<Завдання1>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = bindinglist;
            comboBox1.DataSource = bSource;
            comboBox1.DataSource = list;
            comboBox2.DataSource = bSource;
            comboBox2.DataSource = list;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            list.Add(new Завдання1() { time0 = timeStartBox.Text, time = timeEndBox.Text, Lesson = placeBox.Text, Сomment = textBox.Text });
            refreshList(list);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            list.RemoveAt(list.FindIndex(Завдання1 => Завдання1.ToTime == comboBox1.Text));
            refreshList(list);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var index = list.FindIndex(Завдання1 => Завдання1.ToTime == comboBox1.Text);
            list.RemoveAt(index);
            list.Add(new Завдання1() { time0 = timeStartBox.Text, time = timeEndBox.Text, Lesson = placeBox.Text, Сomment = textBox.Text });
            refreshList(list);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Завдання1 task = (Завдання1)comboBox1.SelectedValue;
            DateTime Time0 = Convert.ToDateTime(task.time0);
            DateTime Time = Convert.ToDateTime(task.time);
            timeStartBox1.Text = (Time0.Hour+":"+Time0.Minute);
            DateTime x = DateTime.ParseExact("2009-05-08 01:30:00,000", "yyyy-MM-dd HH:mm:ss,fff", null);
            if (Time0.Minute > Time.Minute)
                lengthBox.Text = DeSerialize(Serialize((Time.Hour - Time0.Hour - x.Hour).ToString() + ":" + (Time.Minute - Time0.Minute + 2 * x.Minute).ToString()));
            else
                lengthBox.Text = DeSerialize(Serialize(Time.Hour - Time0.Hour)) + ":" + DeSerialize(Serialize((Time.Minute - Time0.Minute).ToString()));
            foreach (var y in list)
                if (Convert.ToDateTime(y.time0) == Time)
                    taskBox1.Text = "Ні";
                else
                    taskBox1.Text = "Так";
            foreach (var y in list)
                if (Convert.ToDateTime(y.time0) < Time & Convert.ToDateTime(y.time0) > Time0)
                    taskBox2.Text = "Ні";
                else
                    taskBox2.Text = "Так";
        }
        private void Serialize(string x)
        {
            const string filename = "time1.json";

            var createStream = File.Create(filename);
            JsonSerializer.Serialize(createStream, x);
            createStream.Dispose();
        }
        private string DeSerialize(string x)
        {
            var openStream = File.OpenRead(filename);
            var deserialized = JsonSerializer.Deserialize<Завдання1>(openStream);
            return deserialized.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
