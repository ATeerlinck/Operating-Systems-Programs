/* COMPSCI 424 Program 1
 * Name:
 */
using System.Collections.Generic;
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
    public class Version1
    {
        // Declare any class/instance variables that you need here.
        LinkedList<Version1PCB> pcbArray;
        int pcbCount = 0;
        /**
        * Default constructor. Use this to allocate (if needed) and
        * initialize the PCB array, create the PCB for process 0, and do
        * any other initialization that is needed. 
        */
        public Version1()
        {
            pcbArray = new LinkedList<Version1PCB>();
            create(-1);
        }


        /// <summary>Creates a new child process of the process with ID parentPid.</summary>
        /// <param name="parentPid">the PID of the new process's parent</summary>
        /// <returns>return 0 if successful, not 0 if unsuccessful</return>

        int create(int parentPid)
        {
            // If parentPid is not in the process hierarchy, do nothing; 
            // your code may return an error code or message in this case,
            // but it should not halt
            if(!pcbArray.Any(p => p.processID == parentPid) && parentPid > 0){
                return 1;
            }
            // Assuming you've found the PCB for parentPid in the PCB array:
            // 1. Allocate and initialize a free PCB object from the array
            //    of PCB objects
            Version1PCB newPCB = new Version1PCB(parentPid, pcbArray.Any(p => p.processID == -1) ? firstNull() : pcbCount);
            if(pcbArray.Any(p => p.processID == -1)) pcbArray.Find(pcbArray.Where(p => p.processID == -1).First()).Value = newPCB;
            else pcbArray.AddLast(newPCB);
            // 2. Insert the newly allocated PCB object into parentPid's
            //    list of children
            pcbArray.ElementAt(parentPid+1).AddChild(newPCB.processID);
            pcbCount++;
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
            if(!pcbArray.Where(p => p.processID == targetPid).Any()){
                return 1;
            }
            Version1PCB targetPcb = pcbArray.Where(p => p.processID == targetPid).First();
            // Assuming you've found the PCB for targetPid in the PCB array:
            // 1. Recursively destroy all descendants of targetPid, if it
            //    has any, and mark their PCBs as "free" in the PCB array 
            //    (i.e., deallocate them)
            foreach (int v in targetPcb.ListChildren())
            {
                destroy(v);
                targetPcb.RemoveChild(v);
            }
            // 2. Adjust connections within the hierarchy graph as needed to
            //    re-connect the graph
            /* What am I supposed to do about this? */
            // 3. Deallocate targetPid's PCB and mark its PCB array entry
            //    as "free"
            pcbArray.Find(targetPcb).Value = new Version1PCB(-1,-1);
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
            foreach(Version1PCB p in pcbArray){
                Console.Write(p.processID > -1 ? "Process " + p.processID + ": parent is " + p.parent + " and " + ((p.ListChildren().Count > 0) ? "children are " + p.ListChildren().ToString() : "has no children\n"): ""); 
            }
        }

        int firstNull(){
            int index = 0;
            while(index < pcbArray.Count){
                if(pcbArray.ElementAt(index).Equals(null)) break;
                index++;
            }
            return index;
        }

        /* If you need or want more methods, feel free to add them. */
    }
}
