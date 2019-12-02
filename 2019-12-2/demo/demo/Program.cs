using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo
{
    /// <summary>
    /// 多态的不同实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1.不同子类继承同一个父类，实现多态
            People p1 = new People();
            People p2 = new Student();

            //2.方法的重载就是一种多态
            Student s1 = new Student();
            s1.Show("aoligay");
            s1.Show("",17);
            s1.Show("aoligay", "Male");

            //3.利用默认参数实现方法多态（利用命名参数实现方法的重载，即方法的多态）
            People s2 = new Student();
            s2.Play();

            //4.运行时的多态（里氏替换原则，声明父类对象，调用虚方法，在子类覆写或不覆写的情况下，分别调用子类方法或父类方法）
            //（只有在运行时才知道）
            People s3 = new Student();
            s3.Work();
        }
    }

    class People
    {
        public string name { get; set; }
        public int age { get; set; }
        public string sex { get; set; }

        public void Play()
        {
            Console.WriteLine("这是People类的Play方法");
        }


        /// <summary>
        /// 虚方法的定义（virtual关键字）
        /// </summary>
        public virtual void Work()
        {
            Console.WriteLine("这是People类的Work虚方法");
        }
    }

    class Student:People
    {

        /// <summary>
        /// 方法的重载实现多态
        /// </summary>
        /// <param name="name"></param>
        public void Show(string name)
        {
            Console.WriteLine("name="+name);
        }
        public void Show(string name,int age)
        {
            Console.WriteLine("name={0},age={1}", name,age);
        }
        public void Show(string name,string sex)
        {
            Console.WriteLine("name={0},sex={1}",name,sex);
        }


        /// <summary>
        /// 利用默认参数实现多态（和重载同理）
        /// </summary>
        /// <param name="name"></param>
        public void Play(string name=null)
        {
            Console.WriteLine("这是Student类的Play方法，参数有：name={0}",name);
        }

        /// <summary>
        /// 覆写虚方法（override关键字）
        /// </summary>
        public override void Work()
        {
            //base.Work();
            Console.WriteLine("这是对Work虚方法的覆写");
        }
    }
}
