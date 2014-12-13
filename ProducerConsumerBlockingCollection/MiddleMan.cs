using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerBlockingCollection
{
    public class MiddleMan
    {
        private readonly BlockingCollection<int> _ingoingBuffer;
        private readonly BlockingCollection<int> _outgoingBuffer;

        public MiddleMan(BlockingCollection<int> ingoingBuffer, BlockingCollection<int> outgoingBuffer)
        {
            _ingoingBuffer = ingoingBuffer;
            _outgoingBuffer = outgoingBuffer;
        }

           public void Run()
        {
            while (!_ingoingBuffer.IsCompleted)
            {
                try
                {
                    int element = _ingoingBuffer.Take();
                    _outgoingBuffer.Add(element);
                    Console.WriteLine("MiddleMan handled: {0}", element);
                }
                catch (InvalidOperationException) { /* ignored */ }
            }
            _outgoingBuffer.CompleteAdding();
        }
        



    }
}
