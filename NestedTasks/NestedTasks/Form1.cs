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

namespace NestedTasks
{
    //Nested tasks are tasks that are stated from within
    //another task or (an outer task)
    //
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Start an outer task
            Task outerTask = Task.Factory.StartNew(() =>
            {
                SetText("outerTask starting...", listBox1);
                //have this task do start some work
                
                //within a task (outerTask) you can start other
                //tasks, which are called inner or nested tasks
                Task innerTask1 = Task.Factory.StartNew(() =>
                {
                    SetText("inner task1 starting...", listBox1);
                    //have this task do some work
                    Thread.SpinWait(55000000);
                    SetText("inner task1 completing...", listBox1);
                });
                Task innerTask2 = Task.Factory.StartNew(() =>
                {
                    SetText("inner task2 starting...", listBox1);
                    //have this task do some work
                    Thread.SpinWait(55000000);
                    SetText("inner task2 completing...", listBox1);
                });
                //outer task do some work
                Thread.SpinWait(55000000);
                SetText("outerTask completing...", listBox1);
            });
            ///run the program and notice that the outerTask may complete and
            /// terminate before the inner tasks have terminated.
            /// the outerTask and innerTasks work independently
            /// 
            ///the outerTask is sometimes called the parent task
            /// and the innerTasks are called the children tasks
            /// in this example the children Tasks are called
            /// unattached child tasks, because the parent task does not
            /// wait for the child task to complete.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //example of attached child tasks
            listBox1.Items.Clear();
            //Start an outer task
            Task parentTask = Task.Factory.StartNew(() =>
            {
                SetText("parentTask starting...", listBox1);
                //have this task do start some work

                //within a task (outerTask) you can start other
                //tasks, which are called inner or nested tasks
                Task childTask1 = Task.Factory.StartNew(() =>
                {
                    SetText("child task1 starting...", listBox1);
                    //have this task do some work
                    Thread.SpinWait(55000000);
                    SetText("child task1 completing...", listBox1);
                }, TaskCreationOptions.AttachedToParent);
                //The TaskCreationOptions.AttachedToParent causes the parentTask
                //to wait until childTask1 completes (terminates)

                Task childTask2 = Task.Factory.StartNew(() =>
                {
                    SetText("child task2 starting...", listBox1);
                    //have this task do some work
                    Thread.SpinWait(55000000);
                    SetText("child task2 completing...", listBox1);
                }, TaskCreationOptions.AttachedToParent);
                //The TaskCreationOptions.AttachedToParent causes the parentTask
                //to wait until childTask2 completes (terminates)

                //outer task do some work
                Thread.SpinWait(55000000);
                //SetText("outerTask completing...", listBox1);
            });
                parentTask.ContinueWith(t=>
                {
                SetText("parentTask completed...", listBox1);
                });
        }
        //method to deal cross threading
        private void SetText(string text, ListBox listbox)
        {
            if (listbox.InvokeRequired)
            {
                //if cross threading
                //use a delegate type that has the same signature as the
                //SetText.  You can use the .Net Action delegate
                Action<string, ListBox> action = SetText;
                this.Invoke(action, text, listbox);
            }
            else
            {
                listbox.Items.Add(text);
                //listbox.Refresh();
                listbox.SelectedIndex = listbox.Items.Count - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaskScheduler ts = TaskScheduler.FromCurrentSynchronizationContext(); //use TaskScheduler for anything without a loop
            //have a parent task with 2 child tasks                               //ts will overload if taking loops or displaying
            //each child task is to return a value                                //more than a single value
            //the parent is to get the two values, compute the average and
            //display the average value
            Task<double> parent = Task.Factory.StartNew<double>(() =>
            {
                //start child1 task that returns a value
                Task<double> child1 = Task.Factory.StartNew<double>(() =>
                {
                    Random rand = new Random();
                    double total = 0;
                    for(int i = 1; i <= 1000000;i++)
                    {
                        total += rand.Next(1000000, 5000000);
                    }
                    return total;
                    //throw new InvalidOperationException(); used as a placeholder to not get an error
                });
                //start child2 task that returns a value
                Task<double> child2 = Task.Factory.StartNew<double>(() =>
                {
                    Random rand = new Random();
                    double total = 0;
                    for (int i = 1; i <= 10000000; i++)
                    {
                        total += rand.Next(1000000, 5000000);
                    }
                    return total;
                    //throw new InvalidOperationException();
                });

                //the parent to wait for the results from both child1 and
                //child2, compute and return the average value
                //throw new InvalidOperationException();
                double result1 = child1.Result; //this is blocking
                double result2 = child2.Result; //this is blocking
                //so getting the result of a child task, causes the 
                //parent to wait (by default)
                //the parent returns the average
                return (result1 + result2) / 2;
            });
            parent.ContinueWith(t =>
            {
                //having used the overload that takes a TaskScheduler
                //you can access the UI directly (the TaskScheduler
                //deals with cross threading
                //SetText("parentTask completed...", listBox1);
                MessageBox.Show("result from parent task: " + t.Result);
            },ts);

        }
    }
}
