/* COMPSCI 424 Program 1
 * Name:
 */

namespace Program1
{
    /** 
     * Implements the process creation hierarchy for Version 1, which uses
     * linked lists.
     * 
     * This is a template. Program1.cs *must* contain the main class
     * for this program. Otherwise, feel free to edit these files, even
     * these pre-written comments or my provided code. You can add any
     * classes, methods, and data structures that you need to solve the
     * problem and display your solution in the correct format.
     */
    public class Version2
    {
        // Declare any class/instance variables that you need here.

        /**
        * Default constructor. Use this to allocate (if needed) and
        * initialize the PCB array, create the PCB for process 0, and do
        * any other initialization that is needed. 
        */
        public Version2()
        {

        }


        /// <summary>Creates a new child process of the process with ID parentPid.</summary>
        /// <param name="parentPid">the PID of the new process's parent</summary>
        /// <returns>return 0 if successful, not 0 if unsuccessful</return>

        int create(int parentPid)
        {
            // If parentPid is not in the process hierarchy, do nothing; 
            // your code may return an error code or message in this case,
            // but it should not halt

            // Assuming you've found the PCB for parentPid in the PCB array:
            // 1. Allocate and initialize a free PCB object from the array
            //    of PCB objects

            // 2. Connect the new PCB object to its parent, its older
            //    sibling (if any), and its younger sibling (if any)

            // You can decide what the return value(s), if any, should be.
            // If you change the return type/value(s), update the XML.
            return 0; // often means "success" or "terminated normally"
        }

        /// <summary>Recursively destroys the process with ID parentPid and all of its
        /// descendant processes (child, grandchild, etc.).</summary>
        /// <param name="targetPid">the PID of the process to be destroyed</summary>
        /// <returns>return 0 if successful, not 0 if unsuccessful</return>
        int destroy(int targetPid)
        {
            // If targetPid is not in the process hierarchy, do nothing; 
            // your code may return an error code or message in this case,
            // but it should not halt

            // Assuming you've found the PCB for targetPid in the PCB array:
            // 1. Recursively destroy all descendants of targetPid, if it
            //    has any, and mark their PCBs as "free" in the PCB array 
            //    (i.e., deallocate them)

            // 2. Remove targetPid from its parent's list of children

            // 3. Deallocate targetPid's PCB and mark its PCB array entry
            //    as "free"

            // You can decide what the return value(s), if any, should be.
            // If you change the return type/value(s), update the XML.
            return 0; // often means "success" or "terminated normally"
        }

        /**
        * Traverse the process creation hierarchy graph, printing
        * information about each process as you go. See Canvas for the
        * *required* output format. 
        *         
        * You can directly use "System.out.println" statements (or
        * similar) to send the required output to stdout, or you can
        * change the return type of this function to return the text to
        * the main program for printing. It's your choice. 
        */
        void showProcessInfo()
        {

        }

        /* If you need or want more methods, feel free to add them. */
    }
}