using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    /// <summary>
    /// Only an Lecturer can be found in one deparment
    /// </summary>
    class Lecturer
    {
        public string name { get; }
        public string surname { get; }
        private int age { get; }
        private string degree { get; }
        public int id { get; }

        /// <summary>
        /// create new Lecturer
        ///       chooseDegree          1 Professor
        ///                             2 Assistant Professor
        ///                             3 Instructor
        ///                 Other Numbers Research Assistant
        /// </summary>
        /// <param name="name"> name of lecturer</param>
        /// <param name="surname"> surname of lecturer</param>
        /// <param name="id"> id of lecturer</param>
        /// <param name="chooseDegree">degree of lecturer
        ///</param>
        public Lecturer(string name, string surname, int id ,int chooseDegree,int age)
        {
            this.name = name;
            this.age = age;
            this.surname = surname;
            if (id > 0)
                this.id = id;
            else this.id = -1 * id;
            switch(chooseDegree)
            {
                case 1:
                    {
                        this.degree = "Professor";
                        break;
                    }
                case 2:
                    {
                        this.degree = "Assistant Professor";
                        break;
                    }
                case 3:
                    {
                        this.degree = "Instructor";
                        break;
                    }
                default:
                    {
                        this.degree = "Research Assistant";
                        break;
                    }



            }

        }

        public override string ToString()
        {
            return "\nName : " + name + "\nSurname : " + surname +
                   "\nId : " + id +"\nDegree : " + degree + "\nStatus : " + this.GetType().Name + "\n"; 
        }
    }
}
