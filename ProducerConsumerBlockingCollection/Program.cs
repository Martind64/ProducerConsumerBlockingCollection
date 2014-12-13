using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerBlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            OneProducerOneConsumer();

        }

        public static void OneProducerOneConsumer()
        {
            BlockingCollection<int> _buffer = new BlockingCollection<int>();

            Producer producer = new Producer(_buffer, 10);
            Consumer consumer = new Consumer(_buffer);


            Parallel.Invoke(producer.Run, consumer.Run);
        }


        public static void OneProducerTwoConsumers()
        {
            BlockingCollection<int> _buffer = new BlockingCollection<int>();

            Producer producer = new Producer(_buffer, 10);
            Consumer consumer1 = new Consumer(_buffer);
            Consumer consumer2 = new Consumer(_buffer);

            Parallel.Invoke(producer.Run, consumer1.Run, consumer2.Run);
        }

        public static void ConcurrentBag()
        {
            ConcurrentBag<int> _buffer = new ConcurrentBag<int>();

            Producer producer = new Producer(_buffer, 10);

        }

        

    }
}
