using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------二、接口的使用和特点-----------");
            //1.面向接口编程
            Console.WriteLine("------------ 1.面向接口编程 ----------------");
            IExtend s1 = new Student();
            s1.Game();
            IPay s2 = new Student();
            s2.Play();
            //2.正常编程
            Console.WriteLine("-------------- 2.正常编程 ---------------");
            Student s3 = new Student();
            s3.Play();
            s3.Game();
        }
    }

    interface IExtend
    {
        void Game();
    }
    interface IPay
    {
        void Play();
    }

    public class Student : IExtend, IPay
    {
        public void Game()
        {
            Console.WriteLine("这是子类显式实现了接口中的Play方法");
        }

        public void Play()
        {
            Console.WriteLine("这是子类显式实现了接口中的Game方法");
        }
    }
}
