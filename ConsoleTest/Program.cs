namespace ConsoleTest
{
    using System;
    using EventsObserver;

    public class Program
    {
        public static void Main(string[] args)
        {
            TimeNotifier notifier = new TimeNotifier();
            AbstractObserver[] observers = new AbstractObserver[3];

            observers[0] = new FirstObserver();
            observers[0].Register(notifier);
            observers[1] = new SecondObserver();
            observers[1].Register(notifier);
            observers[2] = new ThirdObserver();
            observers[2].Register(notifier);

            notifier.SetTimer(5000);

            foreach (var observer in observers)
            {
                foreach (var item in observer.GetTriggers())
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("--------------------");

            observers[1].Unregister(notifier);

            notifier.SetTimer(5000);

            foreach (var observer in observers)
            {
                foreach (var item in observer.GetTriggers())
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }
    }
}
