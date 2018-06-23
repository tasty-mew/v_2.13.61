using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_That_Return_a_Value
{
    /*
    so far we dealt with the Task class. Task uses the Action delegate
    that means it deals with methods that don't return a value.

        if you need to run a method, that returns a value, in a Task
        you need to use the Task<TResult> or
        Task.Factory.StartNew<TResult>


    */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Define a method that simulate a long process, but this
        //method is going to return a value when it is done
        private double ComputeTotal()
        {
            //computes the total of a list of random integers
            Random rand = new Random();
            double total = 0;
            for(int i=1;i<=80000000; i++)
            {
                total += rand.Next(80000000);
            }
            return total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //call the method ComputeTotal asynchronously
            //because the computeTotal returns a value, you need to
            //use
            //Task<TResult> or
            //Task.Factory.StartNew<TResult>
            //since the method return a double, then TResult is double

                    //Another way to do it
            //Func<double> function = () => ComputeTotal();
            //Task<double> task1 = Task.Factory.StartNew<double>(function);
                //easier way to go about it.
            Task<double> task1 = Task.Factory.StartNew<double>(()=> ComputeTotal());

            //capture the retun value in a task when task1 has completed
            //in general the return value is read in a ContinueWith task
            Task task2 = task1.ContinueWith(t =>
            {
                //parameter t represents task1
                //use the property Result of the Task to get the
                //return value from the method
                double total = t.Result;
                //display it
                richTextBox1.AppendText("Result from computeTotal = \n" + total);
            },TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
