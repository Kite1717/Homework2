using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Faculty
    {
        public string name { get; }
        public List<Department> departments { get; }

        public Faculty(string name)
        {
            this.name = name;
            departments = new List<Department>();
        }

        /// <summary> 
        /// Add new department
        /// </summary>
        /// <param name="department"> new department </param>
        /// <returns> already existing or new  control </returns>
        public bool addDepartment(Department department)
        {
            foreach (Department item in departments)
                if (item.name.Equals(department.name))
                    return false;

            departments.Add(department);
            return true;

        }

        public override string ToString()
        {
            string superString = null;
            superString = "\n\n------------------------------\n";
            superString += "\nFaculty Name : " + this.name + "\n";
            superString += "\n------------------------------\n";
            superString += "\n--------------------------------" + this.name.ToUpper() + " IN DEPARTMENTS-------------------------------\n";
            if (this.departments.Count == 0) superString += "\n-----------Empty----------\n";
            foreach (Department item in this.departments) superString += item.ToString();
            superString += "\n\n\n";
            return superString;


        }
    }
}
