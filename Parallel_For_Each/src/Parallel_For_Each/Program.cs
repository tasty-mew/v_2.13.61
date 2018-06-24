using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Text;

namespace Parallel_For_Each
{
    public class Program
    {
        static Random rand = new Random();

        static List<char> charList;
        static List<string> nameList = new List<string>();

        public static void Main(string[] args)
        {
            InitializeCharList();
            InitializeNameList();
            char randomChar = charList[rand.Next(charList.Count)];

            Console.WriteLine("\n" + "#2: Press any Key to apply the Parallel.For to display all the names");
            Console.ReadLine();

            Parallel.For(0, nameList.Count, i =>
            {
                Console.WriteLine(
                    "TaskID: {0} \t Name: {1}", Task.CurrentId, nameList[i]);
            });

            Console.WriteLine("\n" + "#3: Press any Key to apply the Parallel.ForEach to display all the names");
            Console.ReadLine();

            Parallel.ForEach(nameList, name =>
            {
                Console.WriteLine(
                    "TaskID: {0} \t Name: {1}", Task.CurrentId, name);
            });

            Console.WriteLine("\n" + "#4 Press any Key to apply the Parallel.ForEach to display all the names whose length is between 5 and 7");
            Console.ReadLine();

            Parallel.ForEach(nameList.Where(name => (name.Length >= 5 && name.Length <= 7)), name =>
            {
                Console.WriteLine(
                           "TaskID: {0} \t Name: {1} \t Length: {2}", Task.CurrentId, name, name.Length);
            });

            Console.WriteLine("\n" + "#5 Press any Key to apply the Parallel.ForEach to display the names of those that starts with given character '{0}'", randomChar);
            Console.ReadLine();

            Parallel.ForEach(nameList.Where(i => i.StartsWith(randomChar.ToString())), name =>
            {
                Console.WriteLine(
                    "TaskID: {0} \t Name: {1}", Task.CurrentId, name);
            });

            Console.WriteLine("\n" + "END OF ASSIGNMENT. PRESS ANY KEY TO TERMINATE PROGRAM.");
            Console.ReadLine();
        }

        static void InitializeNameList()
        {
            nameList = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"\\Names.txt").ToList();
        }

        static void InitializeCharList()
        {
            charList = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
        }
    }
}

        
    

