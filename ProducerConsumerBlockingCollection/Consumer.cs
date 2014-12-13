using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerBlockingCollection
{
    public class Consumer
    {
        BlockingCollection<int> _buffer = new BlockingCollection<int>();

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
                    Console.WriteLine("Consumer took element: {0}", element);
                }            
            }
            catch (Exception)
            {
                throw new ArgumentException("Consumer can't take elements from an empty buffer");
            }
        }

    }
}
