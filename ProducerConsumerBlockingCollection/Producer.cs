using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerBlockingCollection
{
    public class Producer
    {
        BlockingCollection<int> _buffer = new BlockingCollection<int>();
        private int _howmany;

        public Producer(BlockingCollection<int> buffer, int howmany )
        {
            if (buffer == null) {throw new ArgumentException("buffer");}
            if (howmany <= 0) { throw new ArgumentException("howMany"); }
            _buffer = buffer;
            _howmany = howmany;
        }


        public void Run()
        {
            for (int i = 0; i < _howmany; i++)
            {
                _buffer.Add(i);
                Console.WriteLine("Producer added {0}", i);
            }
            _buffer.CompleteAdding();
        }


    }
}
