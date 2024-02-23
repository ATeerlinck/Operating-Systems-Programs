/* COMPSCI 424 Program 1
 * Name:
 */
namespace Program1
{
    /**
    * The process control block structure that is used to track a
    * process's parent and children (if any) in Version 1.
    */
    public class Version1PCB
    {
        public int parent { get; set; }
        public int processID { get; set; }
        LinkedList<int> children;

        public Version1PCB(int p, int i)
        {
            parent = p;
            processID = i;
            children = new LinkedList<int>();
        }

        public void AddChild(int cID)
        {
            children.AddLast(cID);
        }

        public LinkedList<int> ListChildren()
        {
            return children;
        }

        public void RemoveChild(int targetId)
        {
            children.Remove(targetId);
        }

    }
}
