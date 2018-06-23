using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task_ContinueWith
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                Random rand = new Random();
                //you can call a method or choose
                //to add your code here
                SetText("Task1 running...", richTextBox1);
                for(int i = 1; i <= 50; i++)
                {
                    SetText(rand.Next(1000).ToString(), richTextBox1);
                    //slow it down
                    Thread.Sleep(100);
                }
            });
            //create a second task that runs when task1 completes
            //it is achieved by using the ContinueWith method:

            //public Task ContinueWith(Action<Task> continuationAction)
            //Action<Task>
            //An action to run when the Task completes.
            //When run, the delegate will be passed the completed
            //task as an argument.
            //So the ContinueWith method is passed a reference to 
            //task1
            Task task2 = task1.ContinueWith(t =>
            {
                SetText("---------------", richTextBox1);
                SetText("task2 is running...", richTextBox1);
                for(int i=1; i<25; i++)
                {
                    SetText(i.ToString(), richTextBox1);
                    Thread.Sleep(200);
                }
            });
            //the Action<Task> is telling you that this action
            //delegate takes a Task parameter, what that means is
            //the lambda expression has a parameter of type Task
            //here t means a Task type, which represents a reference
            //to task1
        }
    }
}
