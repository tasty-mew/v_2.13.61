using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resolving_UI_Locking_With_Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if this code runs then the UI is not blocked
            //otherwise it is
            //increment the count in the textbox
            //read it
            //increment it
            //save it back

            int count = int.Parse(textBox1.Text);
            count++;
            textBox1.Text = count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //synchronous call: run method in the UI thread
            DoSomeWork();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //asynchronous call: run method inside of Task
            //this time, use the Run method to create and start a new task
            Task.Run(() => DoSomeWork());
        }
        //define a method that does some work that takes few seconds
        //to run
        private void DoSomeWork()
        {
            Random rand = new Random();
            double total = 0;
            int count = 0;
            while(count <= 100000000)
            {
                int x = rand.Next(1000000, 5000000);
                if(x%3 == 0)
                {
                    total += x;
                    count++;
                }
            }
            double average = total / count;
            //display
            SetText(average.ToString("n3"), richTextBox1);
        }
        private void SetText(string text, RichTextBox richtextbox)
        {
            if (richtextbox.InvokeRequired)
            {
                //if cross threading
                //use a delegate type that has the same signature as the
                //SetText.  You can use the .Net Action delegate
                Action<string, RichTextBox> action = SetText;
                richtextbox.Invoke(action, text, richtextbox);
            }
            else
            {
                richtextbox.AppendText(text + "\n");
                richtextbox.ScrollToCaret();
                richTextBox1.Refresh();
            }
        }
    }
}
