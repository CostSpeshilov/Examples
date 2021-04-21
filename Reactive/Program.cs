using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Reactive
{
    class Program
    {
        /// <summary>
        /// Примеры взяты с сайта http://introtorx.com/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //SimpleImplementation();
            //UseOfSubject();
            // SubjectAsProxy();
            //WrongErrorHandling();
            //ErrorHandling();
            Unsubsribing();
            Console.ReadLine();
        }


        static void SimpleImplementation()
        {
            var numbers = new MySequenceOfNumbers();
            var observer = new MyConsoleObserver<int>();
            numbers.Subscribe(observer);
        }

        static void UseOfSubject()
        {
            var subject = new Subject<string>();
            WriteSequenceToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
            Console.ReadKey();
        }

        //Takes an IObservable<string> as its parameter. 
        //Subject<string> implements this interface.
        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            //The next two lines are equivalent.
            //sequence.Subscribe(value=>Console.WriteLine(value));
            sequence.Subscribe(Console.WriteLine);
        }


        static void SubjectAsProxy()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<long> subject = new Subject<long>();
            var subSource = source.Subscribe(subject);
            var subSubject1 = subject.Subscribe(
                                     x => Console.WriteLine("Value published to observer #1: {0}", x),
                                     () => Console.WriteLine("Observer #1. Sequence Completed."));
            var subSubject2 = subject.Subscribe(
                                     x => Console.WriteLine("Value published to observer #2: {0}", x),
                                     () => Console.WriteLine("Observer #2. Sequence Completed."));
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            subject.OnCompleted();
            subSubject1.Dispose();
            subSubject2.Dispose();
        }

        static void WrongErrorHandling()
        {
            var values = new Subject<int>();
            try
            {
                values.Subscribe(value => Console.WriteLine("1st subscription received {0}", value));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Won't catch anything here!");
            }
            values.OnNext(0);
            //Exception will be thrown here causing the app to fail.
            values.OnError(new Exception("Dummy exception"));
        }

        static void ErrorHandling()
        {
            var values = new Subject<int>();
            values.Subscribe(
            value => Console.WriteLine("1st subscription received {0}", value),
            ex => Console.WriteLine("Caught an exception : {0}", ex));
            values.OnNext(0);
            values.OnError(new Exception("Dummy exception"));
        }

        static void Unsubsribing()
        {
            var values = new Subject<int>();
            var firstSubscription = values.Subscribe(value =>
            Console.WriteLine("1st subscription received {0}", value));
            var secondSubscription = values.Subscribe(value =>
            Console.WriteLine("2nd subscription received {0}", value));
            values.OnNext(0);
            values.OnNext(1);
            values.OnNext(2);
            values.OnNext(3);
            firstSubscription.Dispose();
            Console.WriteLine("Disposed of 1st subscription");
            values.OnNext(4);
            values.OnNext(5);
        }


    }
}
