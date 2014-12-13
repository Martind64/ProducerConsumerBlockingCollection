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
    class Program
    {
        static void Main(string[] args)
        {
       
            //OneProducerOneConsumer();
            //OneProducerTwoConsumers();
            MiddleMan();
            

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

        public static void MiddleMan()
        {

            BlockingCollection<int> _ingoingbuffer = new BlockingCollection<int>(3);
            BlockingCollection<int> _outgoingbuffer = new BlockingCollection<int>(4);
            Producer producer = new Producer(_ingoingbuffer, 10);
            MiddleMan middleman = new MiddleMan(_ingoingbuffer, _outgoingbuffer);
            Consumer consumer = new Consumer(_outgoingbuffer);
            Parallel.Invoke(producer.Run, middleman.Run, consumer.Run);

        }
        //private static void WriteToLogUsingObjectMethods()
        //{
        //    string machineName = "."; // this computer
        //    using (EventLog log = new EventLog(sLog, machineName, Source))
        //    {
        //        log.WriteEntry("Hello");
        //        log.WriteEntry("Hello again", EventLogEntryType.Information);
        //        log.WriteEntry("Hello again again", EventLogEntryType.Information, 14593);
        //    }
        //}
        

    }
}
