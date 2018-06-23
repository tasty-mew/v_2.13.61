using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroToParallelProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRunMethodsInParallel_Click(object sender, EventArgs e)
        {
            //Synchronous calls:
            DisplayRandoms();
            DisplayDivisibles();
            //DisplayRandoms method runs first to completion, before
            //DisplayDivisibles gets to start
            //meanwhile the GUI is locked.  All othre UI controls
            //do not respond to user clicks.
        }
        //method1 to display random numbers
        private void DisplayRandoms()
        {
            Random rand = new Random();
            for(int i = 1; i<=3000; i++)
            {
                int x = rand.Next();
                //richTextBox1.AppendText(x +"\n");
                SetText(x + "\n", richTextBox1);
                //force it to display on every cycle
               // richTextBox1.Refresh();
               // richTextBox1.ScrollToCaret();
            }
        }
        //method2 to display numbers that divisible by 3
        private void DisplayDivisibles()
        {
            Random rand = new Random();
            int i = 1;
            while(i<=3000)
            {
                int x = rand.Next();
                if(x%3 == 0)
                {
                    SetText(x.ToString(), richTextBox2);
                    //richTextBox2.AppendText(x + "\n");
                    i++;
                    //force it to display
                    //richTextBox2.Refresh();
                    //richTextBox2.ScrollToCaret();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //every windows application has a single line of execution
            //called the main thread, or called also the UI thread.

            //Accomplish: create secondary threads to run in parallel
            //with UIThread
            //use the class Task defined in the System.Threading.Tasks
            //(sometimes you need to have System.Threading (old library)
            //which still defines classes that you may use)

            //option 1:
            //use: The Task constructor:
            //public Task(Action action)
            //Action action = new Action(DisplayRandoms); //old syntax
            Action action1 = DisplayRandoms; //acceptable/current syntax
            Task task1 = new Task(action1);

            //second task using lambda expression
            Task task2 = new Task(() => DisplayDivisibles());
            //start the task
            task1.Start();
            task2.Start();
        }

        //resolve cross threading
        //all UI belongs to the UI thread.  Any task cannot access a UI contro
        //directly
        private void SetText(string text, RichTextBox richtextbox)
        {
            if(richtextbox.InvokeRequired)
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
        //create and start two tasks using property: Factory
        private void button1_Click(object sender, EventArgs e)
        {
            //creates and starts new task
            Task.Factory.StartNew(() => DisplayRandoms());
            Task.Factory.StartNew(() => DisplayDivisibles());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
