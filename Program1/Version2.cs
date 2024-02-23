/* COMPSCI 424 Program 1
 * Name:
 */

using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    //IMPORTANT: the number "-1" is used to denote two things, depending on the field it is in. In the parent field, the process is a parentless process. In any other pcb field, it is empty/unallocated.
    public class Version2
    {
        // Declare any class/instance variables that you need here.
        LinkedList<Version2PCB> pcbArray;
        int pcbCount = 0;
        /**
        * Default constructor. Use this to allocate (if needed) and
        * initialize the PCB array, create the PCB for process 0, and do
        * any other initialization that is needed. 
        */
        public Version2()
        {
            pcbArray = new LinkedList<Version2PCB>();
            create(-1);
        }


        /// <summary>Creates a new child process of the process with ID parentPid.</summary>
        /// <param name="parentPid">the PID of the new process's parent</summary>
        /// <returns>return 0 if successful, not 0 if unsuccessful</return>

        public int create(int parentPid)
        {
            // If parentPid is not in the process hierarchy, do nothing; 
            // your code may return an error code or message in this case,
            // but it should not halt
            if (pcbArray.Count == 0)
            {
                Version2PCB newPCB = new Version2PCB(parentPid, pcbCount);
                pcbArray.AddLast(newPCB);
                pcbCount++;
            }
            else
            {
                if (!pcbArray.Where(p => p.processID == parentPid).Any() && parentPid > 0)
                {
                    return 1;
                }
                // Assuming you've found the PCB for parentPid in the PCB array:
                // 1. Allocate and initialize a free PCB object from the array
                //    of PCB objects
                Version2PCB newPCB = new Version2PCB(parentPid, pcbArray.Any(p => p.processID == -1) ? firstNull() : pcbCount);

                // 2. Connect the new PCB object to its parent, its older
                //    sibling (if any), and its younger sibling (if any)
                if (pcbArray.ElementAt(parentPid).firstChild == -1) pcbArray.ElementAt(parentPid).firstChild = newPCB.processID;
                else
                {
                    Version2PCB sibling = pcbArray.ElementAt(pcbArray.ElementAt(parentPid).firstChild);
                    while (!pcbArray.ElementAt(sibling.processID).youngerSibling.Equals(-1)) sibling = pcbArray.ElementAt(sibling.youngerSibling);
                    sibling.youngerSibling = newPCB.processID;
                    newPCB.olderSibling = sibling.processID;
                }
                if (pcbArray.Any(p => p.processID == -1))
                {
                    pcbArray.Find(pcbArray.Where(p => p.processID == -1).First()).Value = newPCB;
                }
                else
                {
                    pcbArray.AddLast(newPCB);
                    pcbCount++;
                }

            }
            // You can decide what the return value(s), if any, should be.
            // If you change the return type/value(s), update the XML.
            return 0; // often means "success" or "terminated normally"
        }

        /// <summary>Recursively destroys the process with ID parentPid and all of its
        /// descendant processes (child, grandchild, etc.).</summary>
        /// <param name="targetPid">the PID of the process to be destroyed</summary>
        /// <returns>return 0 if successful, not 0 if unsuccessful</return>
        public int destroy(int targetPid)
        {
            // If targetPid is not in the process hierarchy, do nothing; 
            // your code may return an error code or message in this case,
            // but it should not halt
            if (!pcbArray.Any(p => p.processID == targetPid))
            {
                return 1;
            }
            // Assuming you've found the PCB for targetPid in the PCB array:
            // 1. Recursively destroy all descendants of targetPid, if it
            //    has any, and mark their PCBs as "free" in the PCB array 
            //    (i.e., deallocate them)
            Version2PCB targetPcb = pcbArray.Where(p => p.processID == targetPid).First();
            // 2. Remove targetPid from its parent's list of children
            if (targetPcb.olderSibling >= 0) pcbArray.ElementAt(targetPcb.olderSibling).youngerSibling = targetPcb.youngerSibling;
            if (targetPcb.youngerSibling >= 0){ pcbArray.ElementAt(targetPcb.youngerSibling).olderSibling = targetPcb.olderSibling;
            pcbArray.ElementAt(targetPcb.firstChild).olderSibling = targetPcb.youngerSibling;
            pcbArray.ElementAt(targetPcb.youngerSibling).youngerSibling = targetPcb.firstChild;
            }
            foreach (Version2PCB p in pcbArray)
            {
                if (p.parent == targetPcb.processID) p.parent = targetPcb.parent;
            }
            if (pcbArray.ElementAt(targetPcb.parent).firstChild == targetPcb.processID) pcbArray.ElementAt(targetPcb.parent).firstChild = targetPcb.youngerSibling > 0 ? targetPcb.youngerSibling : targetPcb.firstChild;

            // 3. Deallocate targetPid's PCB and mark its PCB array entry
            //    as "free"
            pcbArray.ElementAt(targetPid).processID = -1;
            pcbArray.ElementAt(targetPid).firstChild = -1;
            pcbArray.ElementAt(targetPid).olderSibling = -1;
            pcbArray.ElementAt(targetPid).youngerSibling = -1;
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
        public void showProcessInfo()
        {
            string children = "";
            foreach (Version2PCB p in pcbArray)
            {
                if (p.firstChild != -1)
                {
                    children = "" + p.firstChild;
                    Version2PCB sibling = pcbArray.ElementAt(p.firstChild);
                    while (sibling.youngerSibling != -1)
                    {
                        children += ", " + sibling.youngerSibling;
                        sibling = pcbArray.ElementAt(sibling.youngerSibling);
                    }
                }
                Console.Write(p.processID > -1 ? "Process " + p.processID + ": parent is " + p.parent + " and " + ((p.firstChild != -1) ? "children are " + children + "\n" : "has no children\n") : "");
            }
        }

        int firstNull()
        {
            int index = 0;
            while (index < pcbArray.Count)
            {
                if (pcbArray.ElementAt(index).processID == -1) break;
                index++;
            }
            return index;
        }

        /* If you need or want more methods, feel free to add them. */
    }
}
