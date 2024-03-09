using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading; // for thread support

namespace Program2
{
    /* COMPSCI 424 Program 2
 * Name:
 * 
 * This is a template. Program2.cs *must* contain the main class
 * for this program. Otherwise, feel free to edit these files, even
 * these pre-written comments or my provided code. You can add any
 * classes, methods, and data structures that you need to solve the
 * problem and display your solution in the correct format.
 */

    public class Program2
    {
        /**
         * Main method for this program. The required steps have been copied
         * into the main method as comments. Feel free to add more comments to
         * help you understand your code, or for any other reason. Also feel
         * free to edit this comment to be more helpful for you.
         */
        public static void Main()
        {
            // Declare any class/instance variables that you need here.

            // 1. Ask the user to enter the three parameters described in the
            // Parameters section, then receive those parameters. Use a 
            // separate prompt message and a separate input call for each
            // parameter.


            // 2. Create the buffer and initialize each element to 0.


            // 3. To confirm that each element is initialized, display the
            // contents of the buffer on one long line. There should be one
            // 0 value for each buffer element. See the Program 2 page on
            // Canvas for the required format.


            // 4. Create and start the producer thread.


            // 5. Create and start the consumer thread.


            // 6. After 90 seconds, send a signal to the producer and consumer
            // threads to stop running. (Alternatively, you may have the
            // producer and consumer threads keep track of time and stop
            // themselves 90 seconds after they start running.)


            // 7. Display the values in the buffer. Use the format that is shown
            // on the Program 2 page on Canvas.


            // 8. Do any necessary "cleanup" work.

            Console.WriteLine("Program is finished.");
        }
    }
}