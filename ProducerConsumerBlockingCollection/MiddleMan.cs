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
        BlockingCollection<int> _ingoingBuffer = new BlockingCollection<int>();
        BlockingCollection<int> _outGoingBuffer = new BlockingCollection<int>(); 





    }
}
