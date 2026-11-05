using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace App_511_SWAPI
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        //void Update(IObserver observer);    // Single notify.
        void Update();                      //  Multiple notify.

        string DataToRecive();
    }

    public interface IObserver
    {
        void Notify(ISubject subject);
        int Age();
    }

    /*
    public interface IObserver
    {
        void Notify(IData dataToNotify);
    }
    */

    public class Post : ISubject
    {
        private string data = string.Empty;

        private List<IObserver> observers = new();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Update()
        {
            foreach(var item in observers)
            {
                if (item.Age() > 18) // option to separate IObservers
                {
                    item.Notify(this); // !!!
                }
            }    
        }

        public string DataToRecive() => data;

        public void SendData(string data)
        {
            this.data = data;
        }
    }

    public class Person : IObserver
    {
        public void Notify(ISubject subject)
        {
            if (subject.DataToRecive().Contains("123"))
            {
                return;
            }

            Debug.WriteLine("Some data from ISubject");
        }

        public int Age() => 20;
    }

    internal class TestPattern
    {
        public void Test()
        {
            var post = new Post();

            var person1 = new Person();
            var person2 = new Person();

            post.Attach(person1);
            post.Attach(person2);

            post.SendData("Some info");
            post.Update();

            post.Detach(person2);

            post.SendData("123");
            post.Update();
        }
    }
}
