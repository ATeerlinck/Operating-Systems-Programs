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
        int parent = -1;
        int firstChild, youngerSibling, olderSibling;
    }
}
