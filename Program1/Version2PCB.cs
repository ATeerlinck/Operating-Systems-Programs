/* COMPSCI 424 Program 1
 * Name:
 */
namespace Program1
{
    /**
    * The process control block structure that is used to track a
    * process's parent, first child, younger sibling, and older sibling
    * (if they exist) in Version 2.
    */
    public class Version2PCB
    {
        public int parent {get; set;}
        public int firstChild {get; set;}
        public int youngerSibling {get; set;}
        public int olderSibling {get; set;}
        public int processID { get; set; }
        
        public Version2PCB(int p, int i)
        {
            parent = p;
            processID = i;
        }
    }
}
