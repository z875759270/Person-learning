using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------抽象类的使用和特点----------");
            Person s1 = new Student();  //里氏替换原则
            //四个抽象方法
            s1.Hair();
            s1.Hand();
            s1.Eye();
            s1.Do<Student>();

            //Person中的两个方法
            s1.Show();          //调用的是父类（Person）中的方法
            s1.VirtualShow();   //调用的是子类覆写后的方法
            //调用子类特有的方法（无法调用）
            //s1.Study();
        }
    }

    abstract class Person
    {
        //抽象类是一个类，可以包含类的一切东西：

        //1.属性
        public string name { get; set; }
        public string work { get; set; }
        //2.字段
        public string username = "sss";
        //3.委托
        public delegate void DoNothing();

        //4.抽象方法
        public abstract void Hair();
        public abstract void Eye();
        public abstract void Hand();

        //5.方法  继承此抽象类的子类不能对普通方法进行覆写，但可以重写
        public void Show()
        {
            Console.WriteLine("这是Person类的Show方法");
        }

        //6.虚方法 可以被任何继承的子类所覆写
        public virtual void VirtualShow()
        {
            Console.WriteLine("这是Person类的VirtualShow方法");
        }

        //7.抽象泛型方法
        public abstract void Do<T>();
    }

    class Student : Person
    {
        //对抽象方法的实现
        public override void Eye()
        {
            Console.WriteLine("这是Student类的eye方法");
        }

        public override void Hair()
        {
            Console.WriteLine("这是Student类的Hair方法");
        }

        public override void Hand()
        {
            Console.WriteLine("这是Student类的Hand方法");
        }

        public override void Do<T>()
        {
            Console.WriteLine("这是Student类的Do方法");
        }

        //对虚方法的覆写
        public override void VirtualShow()
        {
            //base.VirtualShow();
            Console.WriteLine("这是Student类覆写的VirtualShow方法");
        }

        //对普通方法的重写
        public new void Show()
        {
            Console.WriteLine("这是Student类重写的Show方法");
        }

        public void Study()
        {
            Console.WriteLine("这是Student类的Study方法");
        }
    }

}
