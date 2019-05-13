using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{

    /// <summary>
    /// Ref Link : 
    /// https://dzone.com/articles/factory-method-design-pattern
    /// </summary>
    static class  StudentFactory
    {
        /// <summary>
        /// Factory design pattern was used to create the new student
        /// </summary>
        /// <param name="rank">status of student</param>
        /// <param name="name">name of student</param>
        /// <param name="surname">surname of student</param>
        /// <param name="no">number of student</param>
        /// <returns>the type of student the student selected</returns>
        public static Student getStudent(string rank, string name, string surname, int no,int age )
        {
            switch (rank)
            {
                case "bsc":
                    { return new BSc(name, surname, no, age ); }
                case "msc":
                    { return new MSc(name, surname, no , age); }

                case "phd":
                    { return new PhD(name, surname, no , age); }
                default:
                    { throw new Exception("Undefined rank of student"); }

            }
        }
    }
}
