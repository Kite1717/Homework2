using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
   abstract  class Student
    {
        //general student field
        protected string name { get; }
        protected string surname { get; }
        protected int no { get; }
        protected int age { get; }

        protected Student(string name, string surname, int no, int age)
        {
            this.name = name;
            this.surname = surname;
            if (no > 0)
                this.no = no;
            else this.no = -1 * no;
            if (age > 0)
                this.age = age;
            else this.age = -1 * age;
        }

        public override string ToString()
        {
            return "\nName : " + name + "\nSurname :" + surname + "\nAge : " + age + "\nNo : " + no + "\nRank : " + this.GetType().Name + "\n";
        }
        public int getNo()
        { return this.no; }
        public string getName()
        {
            return this.name;
        }

        public string getSurName()
        {
            return this.surname;
        }
        public int getAge()
        {
            return this.age;
        }
    }
}
