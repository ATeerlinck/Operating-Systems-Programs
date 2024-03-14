/* COMPSCI 424 Program 2
 * Name:
 */
using System.Diagnostics;

namespace Program2
{
    /**
     * A class for the producer thread.
     */
    public class Producer
    {
        // Declare any class/instance variables that you need here.
        private int next_in;
        public Thread pThread;

        /**
         * Default constructor. Use this to do any allocation and
         * initialization that is needed. If you need more constructors
         * than this, feel free to add other constructors.
         */
        public Producer()
        {
            next_in = 0;
        }

        /**
         * Essentially the "main method" for this thread. Call this 
		 * method (or another method) when you start the producer 
         * thread. May accept arguments; must return void.
         */
        public void Run(int n, int k, int t, int[] buffer, SemaphoreSlim sem, CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested) return;
                else
                {
                    sem.WaitAsync(token);
                    Random rand = new Random();
                    int k1 = rand.Next(1, k + 1);
                    for (int i = 0; i < k1; i++)
                    {
                        if (buffer[(next_in + i) % n] != 0)
                        {
                            Console.WriteLine("p: " + string.Join("", buffer));
                            k1 = i;
                            Thread.Sleep(2000);
                        }
                        else buffer[(next_in + i) % n] += 1;
                    }

                    next_in = (next_in + k1) % n;
                    int t1 = rand.Next(1, t + 1);
                    Thread.Sleep(t1 * 1000);
                    sem.Release();
                }
            }
        }

        /* If you need or want more methods, feel free to add them. */
    }
}