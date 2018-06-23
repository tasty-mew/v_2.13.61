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

namespace Task_Cancellation
{
   
    public partial class Form1 : Form
    {
        CancellationTokenSource cts = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.  Create cancellationTokenSource cts
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            //start a task
            Task task1 = Task.Factory.StartNew(() =>
            {
                for(int n = 1000000; n <= 1100000; n++)
                {
                    if (token.IsCancellationRequested)
                    {
                        //clean up resources
                        //you can either use the break;
                        //or
                        //throw a cancellation exception
                        //which causes the task to terminate
                        token.ThrowIfCancellationRequested();

                        //if you don't have any clean up to do
                        //then you use throw the execption
                        //without using the if statement
                    }
                    if (n % 3 == 0 || n % 7 == 0)
                        SetText(n.ToString(),listBox1);
                }
            }, token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //request task cancellation
            //use the cts cancel method
            if(cts != null)
            {
                cts.Cancel();
            }
        }
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
        //a method that checks whether an integer is prime
        private bool IsPrime(int n)
        {
            if (n == 2 || n == -2) return true;
            if (n % 2 == 0) return false;

            int max = (int)Math.Sqrt(n);
            for(int d=2;d<= max; d++)
            {
                if (n % d == 0)
                    return false;
            }
            return true;
        }
    }
}
