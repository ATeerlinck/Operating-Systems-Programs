using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
/* COMPSCI 424 Program 1
 * Name:
 * 
 * This is a template. Program1.cs *must* contain the main class
 * for this program. Otherwise, feel free to edit these files, even
 * these pre-written comments or my provided code. You can add any
 * classes, methods, and data structures that you need to solve the
 * problem and display your solution in the correct format.
 */

/**
 * Main class for this program. The required steps have been copied
 * into the main method as comments. Feel free to add more comments to
 * help you understand your code, or for any other reason. Also feel
 * free to edit this comment to be more helpful for you.
 */
namespace Program1
{

    class Program
    {

        /**
        * @param args command-line arguments, which can be ignored
        */

        static void Main(string[] args)
        {
            // Declare any class/instance variables that you need here.
            string choice = "";
            List<string> input = new List<string>();
            string[] split = new string[2];
            // 1. Ask the user to enter commands of the form "create N",
            //    "destroy N", or "end", where N is an integer between 0 
            //    and 15.
            // 2. While the user has not typed "end", continue accepting
            //    commands. Add each command to a list of actions to take 
            //    while you run the simulation.
            // 3. When the user types "end" (or optionally any word that 
            //    is not "create" or "destroy"), stop accepting commands 
            //    and complete the following steps.
            // Hint: Steps 2 and 3 refer to the same loop. ;-)
            while (true)
            {
                Console.WriteLine("PCB Program. Use create N, destroy N, or end, where N is a value between 0 or 15 inclusive. typing anything else will propmt you again");
                choice = Console.ReadLine();
                split = choice.Split(" ");
                if (split[0].ToLower() == "end") break;
                else
                {
                    switch (split[0].ToLower())
                    {
                        case "create":
                        case "destroy":
                            input.Add(choice);
                            break;
                        default:
                            Console.WriteLine("WARNING: Invalid command. Command is not being");
                            break;
                    }
                }
            }

            // 4. Create an object of the Version 1 class and an object of
            //    the Version 2 class.
            Version1 V1 = new Version1();
            Version2 V2 = new Version2();


            // 5. Run the command sequence once with the Version 1 object, 
            //    calling its showProcessTree method after each command to
            //    show the changes in the tree after each command.
            foreach (string s in input)
            {
                split = s.Split(" ");
                int n = int.Parse(split[1]);
                switch (split[0].ToLower())
                {
                    case "create":
                        V1.create(n);
                        break;
                    case "destroy":
                        V1.destroy(n);
                        break;
                    default:
                        break;
                }
                V1.showProcessInfo();
            }
            // 6. Repeat step 5, but with the Version 2 object.
            foreach (string s in input)
            {
                split = s.Split(" ");
                int n = int.Parse(split[1]);
                switch (split[0].ToLower())
                {
                    case "create":
                        V2.create(n);
                        break;
                    case "destroy":
                        V2.destroy(n);
                        break;
                    default:
                        break;
                }
                V2.showProcessInfo();
            }

            // 7. Store the current system time in a variable
            DateTime before = DateTime.Now;
            // ... then run the command sequence 200 times with Version 1.
            for (int i = 0; i < 200; i++)
            {
                foreach (string s in input)
                {
                    split = s.Split(" ");
                    int n = int.Parse(split[1]);
                    switch (split[0].ToLower())
                    {
                        case "create":
                            V1.create(n);
                            break;
                        case "destroy":
                            V1.destroy(n);
                            break;
                        default:
                            break;
                    }
                }
            }
            // ... After this, store the new current system time in a
            //     second variable. Subtract the start time from the end 
            //     time to get the Version 1 running time, then display 
            //     the Version 1 running time.
            DateTime after = DateTime.Now;
            TimeSpan V1RunTime = after-before;
            // 8. Repeat step 7, but with the Version 2 object.
            before = DateTime.Now;
            for (int i = 0; i < 200; i++)
            {
                foreach (string s in input)
                {
                    split = s.Split(" ");
                    int n = int.Parse(split[1]);
                    switch (split[0].ToLower())
                    {
                        case "create":
                            V2.create(n);
                            break;
                        case "destroy":
                            V2.destroy(n);
                            break;
                        default:
                            break;
                    }
                }
            }
            after = DateTime.Now;
            TimeSpan V2RunTime = after-before;
            Console.WriteLine("Version 1 Runtime {0}ms",V1RunTime.TotalMilliseconds);
            Console.WriteLine("Version 2 Runtime {0}ms",V2RunTime.TotalMilliseconds);
            // This line is here just to test the Gradle build procedure.
            // You can delete it.
            Console.WriteLine("Builds without errors and runs to completion.");
        }
    }
}
