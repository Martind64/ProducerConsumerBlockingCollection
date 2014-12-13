using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerBlockingCollection
{
    public class Consumer
    {
        private BlockingCollection<int> _buffer = new BlockingCollection<int>();

        public Consumer(BlockingCollection<int> blockingCollection)
        {
            _buffer = blockingCollection;
        }



        public void Run()
        {

            try
            {
                while (!_buffer.IsCompleted)
                {
                
                    int element = _buffer.Take();
                    //EventLog eventlog = new EventLog();
                    //eventlog.WriteEntry("Consumer took element {0}", EventLogEntryType.Information, element);
                    Console.WriteLine("Consumer took element: {0}", element);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }

    }
}
