/* COMPSCI 424 Program 3
 * Name:
 * 
 * This is a template. Program3.java *must* contain the main class
 * for this program. 
 * 
 * You will need to add other classes to complete the program, but
 * there's more than one way to do this. Create a class structure
 * that works for you. Add any classes, methods, and data structures
 * that you need to solve the problem and display your solution in the
 * correct format.
 */


using System;
using System.IO;

/**
 * Main class for this program. To help you get started, the major
 * steps for the main program are shown as comments in the main
 * method. Feel free to add more comments to help you understand
 * your code, or for any reason. Also feel free to edit this
 * comment to be more helpful.
 */
public class Program3
{
    // Declare any class/instance variables that you need here.

    /**
     * @param args Command-line arguments. 
     * 
     * args[0] should be a string, either "manual" or "auto". 
     * 
     * args[1] should be another string: the path to the setup file
     * that will be used to initialize your program's data structures. 
     * To avoid having to use full paths, put your setup files in the
     * top-level directory of this repository.
     * - For Test Case 1, use "424-p3-test1.txt". 
     * - For Test Case 2, use "424-p3-test2.txt".
     * Alternatively, you can use a variable called file to hold onto the file name for testing. BE SURE TO RETURN ALL OF THE ARGS WHEN YOU ARE DONE IF YOU DO THIS.
     */

    static void Main(string[] args)
    {
        // Code to test command-line argument processing.
        // You can keep, modify, or remove this. It's not required.
        if (args.Length < 2)
        {
            Console.WriteLine("Not enough command-line arguments provided, exiting.");
            return;
        }
        Console.WriteLine("Selected mode: " + args[0]);
        Console.WriteLine("Setup file location: " + args[1]);

        // 1. Open the setup file using the path in args[1]
        StreamReader setupFileReader;

        string currentLine;
        try
        {
            setupFileReader = new StreamReader(args[1]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot find setup file at " + args[1] + ", exiting.");
            return;
        }

        // 2. Get the number of resources and processes from the setup
        // file, and use this WriteLine to create the Banker's Algorithm
        // data structures
        int numResources;
        int numProcesses;

        // For simplicity's sake, we'll use one try block to handle
        // possible exceptions for all code that reads the setup file.
        try
        {
            // Get number of resources
            currentLine = setupFileReader.ReadLine();
            if (currentLine == null)
            {
                Console.WriteLine("Cannot find number of resources, exiting.");
                setupFileReader.Close();
                return;
            }
            else
            {
                numResources = int.Parse(currentLine.Split(" ")[0]);
                Console.WriteLine(numResources + " resources");
            }

            // Get number of processes
            currentLine = setupFileReader.ReadLine();
            if (currentLine == null)
            {
                Console.WriteLine("Cannot find number of processes, exiting.");
                setupFileReader.Close();
                return;
            }
            else
            {
                numProcesses = int.Parse(currentLine.Split(" ")[0]);
                Console.WriteLine(numProcesses + " resources");
            }

            // Create the Banker's Algorithm data structures, in any
            // way you like as long as they have the correct size
            int[] available = new int[numResources];
            int[,] max = new int[numProcesses, numResources];
            int[,] allocation = new int[numProcesses, numResources];
            int[,] request = new int[numProcesses, numResources];
            // 3. Use the rest of the setup file to initialize the
            // data structures
            string[] line = setupFileReader.ReadLine().Split(" ");
            for (int i = 0; i < available.Length; i++)
            {
                available[i] = int.Parse(line[i]);
            };
            if (setupFileReader.ReadLine() == "Max")
            {
                for (int i = 0; i < numProcesses; i++)
                {
                    line = setupFileReader.ReadLine().Split(" ");
                    for (int j = 0; j < numResources; j++)
                    {
                        max[i, j] = int.Parse(line[j]);
                    }
                };
            }
            if (setupFileReader.ReadLine() == "Allocation")
            {
                for (int i = 0; i < numProcesses; i++)
                {
                    line = setupFileReader.ReadLine().Split(" ");
                    for (int j = 0; j < numResources; j++)
                    {
                        allocation[i, j] = int.Parse(line[j]);
                    }
                };
            }

            setupFileReader.Close(); // done reading the file, so close it
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while reading setup file "
            + args[1] + ". Stack trace follows. Exiting.");
            Console.WriteLine("Stack Trace: {0}", e.StackTrace);
            Console.WriteLine("Exiting.");
            return;
        }

        // 4. Check initial conditions to ensure that the system is 
        // beginning in a safe state: see "Check initial conditions"
        // in the Program 3 instructions
        
        // 5. Go into either manual or automatic mode, depending on
        // the value of args[0]; you could implement these two modes
        // as separate methods within this class, as separate classes
        // with their own main methods, or as additional code within
        // this main method.


    }
}