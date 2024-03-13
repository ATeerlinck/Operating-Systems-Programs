/* COMPSCI 424 Program 2
 * Name:
 */
using System.Formats.Tar;

namespace Program2
{
    /**
     * A class for the consumer thread.
     */
    public class Consumer
    {
        // Declare any class/instance variables that you need here.
        private int next_out;
        public AutoResetEvent bufferEmpty = new AutoResetEvent(false);

        /**
         * Default constructor. Use this to do any allocation and
         * initialization that is needed. If you need more constructors
         * than this, feel free to add other constructors.
         */
        public Consumer()
        {
            next_out = 0;
        }
        /**
         * Essentially the "main method" for this thread. Call this 
		 * method (or another method) when you start the producer 
         * thread. May accept arguments; must return void.
         */
        public void Run(int n, int k, int t, int[] buffer,CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                Random rand = new Random();
                int t2 = rand.Next(1, t + 1);
                Thread.Sleep(t2 * 1000);
                int k2 = rand.Next(1, k + 1);
                for (int i = 0; i < k2; i++)
                {
                    int data = buffer[(next_out + i) % n];
                    if (data == 0)
                    {
                        Console.WriteLine(string.Join("",buffer));
                        WaitHandle.WaitAll([bufferEmpty]);
                    }
                    buffer[(next_out + i) % n] = 0;
                }
                next_out = (next_out + k2) % n;
            }
        }

        /* If you need or want more methods, feel free to add them. */
    }
}