using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork2
{
    class Department
    {
        public string name { get; }
        private List<Student> students; // all student in department
        public List<Lesson> lessons { get; }
        private static List<Department> departments = new List<Department>();
        public List<Lecturer> lecturers { get; }

        public Department(string name)
        {
            this.name = name;
           lessons = new List<Lesson>();
            students = new List<Student>();
            lecturers = new List<Lecturer>();
            departments.Add(this);
        }

        /// <summary> 
        /// Add new Lesson
        /// </summary>
        /// <param name="lesson"> new lesson </param>
        /// <returns> already existing or new  control </returns>
        public bool addLesson(Lesson lesson)
        {
            foreach (Lesson item in lessons)
                if (item.name.Equals(lesson.name))
                    return false;

            lessons.Add(lesson);
            return true;

        }
        /// <summary>
        /// delete lesson by name
        /// </summary>
        /// <param name="name">name of lesson</param>
        /// <returns>find control</returns>
        public bool deleteLesson(string name)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                if(lessons[i].name.Equals(name))
                {
                    lessons.RemoveAt(i);
                    return true;
                }
            }
            return false;


        }
        /// <summary>
        /// add student
        /// </summary>
        /// <param name="student">student instance</param>
        /// <returns>already existing or new control</returns>
        public bool addStudent(Student student)
        {
            foreach(Student item in students)
            {
                if (item.getName().Equals(student.getName()))
                    return false;
            }
            students.Add(student);
            return true;
        }
        /// <summary>
        /// delete by name
        /// </summary>
        /// <param name="name">name of student</param>
        /// <returns>find control </returns>
        public bool deleteStudent(string name,string surname)
        {
            
            for (int i = 0; i < this.students.Count; i++)
            {
                if(this.students[i].getName().Equals(name) && this.students[i].getSurName().Equals(surname))
                {
                    for (int j = 0; j < lessons.Count; j++)
                    {
                        for (int k = 0; k < lessons[j].students.Count; k++)
                        {
                            if (lessons[j].students[k].getName().Equals(name) && lessons[j].students[k].getSurName().Equals(surname))

                                deleteStudentInLesson(lessons[j].name, lessons[j].students[k].getNo());
                        }
                    }
                    students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// delete by number
        /// </summary>
        /// <param name="no">number of student</param>
        /// <returns>find control</returns>
        public bool deleteStudent(int no)
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (this.students[i].getNo() == no)
                {
                   
                    for (int j = 0; j < lessons.Count; j++)
                    {
                        for (int k = 0; k < lessons[j].students.Count; k++)
                        {
                            if (lessons[j].students[k].getNo() == no)

                                deleteStudentInLesson(lessons[j].name, no);
                        }
                    }
                    students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///  Add current lesson given the name of the student
        /// </summary>
        /// <param name="nameOfLesson"></param>
        /// <param name="numberOfStudent"></param>
        /// <returns>already existing or new control</returns>
        public bool addStudentInLesson(string nameOfLesson,int numberOfStudent)
        {
            if (numberOfStudent < 0) numberOfStudent *= -1;

            for (int i = 0; i < students.Count; i++)
            {
                if(students[i].getNo() == numberOfStudent )
                {
                    for (int j = 0; j < lessons.Count; j++)
                    {
                        if(lessons[j].name.Equals(nameOfLesson) &&
                            //the rank is also enough if you can take that lesson
                            lessons[j].statusOfLesson.Equals(students[i].GetType().Name.ToLower()))
                        {
                           return lessons[j].addStudent(students[i].getName(), students[i].getSurName(), students[i].getNo(), students[i].getAge());
                           
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Delete student in the lesson
        /// </summary>
        /// <param name="nameOfLesson"> </param>
        /// <param name="no">number of student </param>
        /// <returns>find control</returns>
        public bool deleteStudentInLesson(string nameOfLesson , int no)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                if(lessons[i].name.Equals(nameOfLesson))
                {
                    return lessons[i].deleteStudent(no);
                }
            }
            return false;
        }

        
        /// <summary>
        /// Department lecturer adds
        /// </summary>
        /// <param name="lecturer"> The lecturer to be added</param>
        /// <returns>already existing or new control </returns>
        public bool addLecturer(Lecturer lecturer)
        {
           
            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < departments[i].lecturers.Count; j++)
                {
                    if(departments[i].lecturers[j].id == lecturer.id)
                        
                    {
                        return false;
                    }
                }
            }
            lecturers.Add(lecturer);
            return true;
        }
        /// <summary>
        /// Delete by id
        /// remove the branch ,lesson and department
        /// </summary>
        /// <param name="id">id of lecturer </param>
        /// <returns>find control </returns>
        public bool deleteLecturer(int id )
        {
            for (int i = 0; i < lecturers.Count; i++)
            {
                if(lecturers[i].id == id )
                {
                    for (int j = 0; j < lessons.Count; j++)
                    {
                        for (int k = 0; k < lessons[j].branches.Count; k++)
                        {
                            if (lessons[j].branches[k].Lecturer != null && lessons[j].branches[k].Lecturer.id == id)
                            {
                                lessons[j].lecturers.Remove(lessons[j].branches[k].Lecturer);
                                lessons[j].branches[k].Lecturer = null;
                            }
                        }
                    }

                    lecturers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Delete by name and surname deletes the assigned lesson
        /// remove the branch ,lesson and department
        /// </summary>
        /// <param name="name">name of lecturer</param>
        /// <param name="surname">surname of lecturer</param>
        /// <returns>find control</returns>
        public bool deleteLecturer(string name,string surname)
        {
            for (int i = 0; i < lecturers.Count; i++)
            {
                if (lecturers[i].name.Equals(name) && lecturers[i].surname.Equals(surname))
                {

                    for (int j = 0; j < lessons.Count; j++)
                    {
                        for (int k = 0; k < lessons[j].branches.Count; k++)
                        {
                            if(lessons[j].branches[k].Lecturer != null && lessons[j].branches[k].Lecturer.name.Equals(name) && lessons[j].branches[k].Lecturer.surname.Equals(surname))
                            {
                                lessons[j].lecturers.Remove(lessons[j].branches[k].Lecturer);
                                lessons[j].branches[k].Lecturer = null;
                            }
                        }
                    }

                    lecturers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// the lesson the lecturer makes the assignment
        /// </summary>
        /// <param name="id">id of Lecturer</param>
        /// <param name="name">name of Lesson</param>
        /// <returns>find control</returns>
        public bool assignmentLecturer(int id , string nameOfLesson)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                if(lessons[i].name.Equals(nameOfLesson))
                {
                    for (int j = 0; j < lecturers.Count; j++)
                    {
                        if(lecturers[j].id == id)
                        {
                           return  lessons[i].lecturerAssignment(lecturers[j]);
                          

                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// modifies existing lesson assignments to department members 
        /// </summary>
        /// <param name="oldId"> ıd of old lecturer</param>
        /// <param name="newId">  ıd of new assingment lecturer</param>
        /// <param name="nameOfLesson"> lesson name </param>
        /// <returns>success control</returns>
        public bool changeAssignmentLecturer(int oldId , int newId,string nameOfLesson)
        {  
            bool flag = false;
            int o=0, n=0;
            for (int i = 0; i < lecturers.Count; i++)
            {
                if(lecturers[i].id == oldId)
                {
                    o = i;
                    flag = true;
                    break;
                }
                    
            }
            if (flag)
            {
                flag = false;
                for (int i = 0; i < lecturers.Count; i++)
                {
                    if (lecturers[i].id == newId)
                    {
                        n = i;
                        flag = true;
                        break;
                    }

                }

            }
            if(flag)
            {
                for (int i = 0; i < lessons.Count; i++)
                {
                    if(lessons[i].name.Equals(nameOfLesson))
                    {
                      return  lessons[i].changeLecturer(lecturers[o], lecturers[n]);
                    }
                }
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// you get all informations in  department
        /// </summary>
        /// <returns> informations string </returns>
        public override string ToString()
        {
            string superString = null;
            superString = "\n------------------------------\n";
            superString += "\n**Deparment Name : " + this.name + "**\n";
            superString += "\n------------------------------\n";
            
            superString += "\n**All Students in department**\n";
            if (this.students.Count == 0) superString += "\n-----------Empty----------\n";
            foreach (Student item in this.students) superString += item.ToString();
            

          
            superString += "\n**All Lecturer in department**\n";
            if (this.lecturers.Count == 0) superString += "\n-----------Empty----------\n";
            foreach (Lecturer item in this.lecturers) superString += item.ToString();

            superString += "\n--------------------------------" + this.name.ToUpper()  + " IN LESSONS-------------------------------\n";
            //I'm going to use to get to Iterator degin pattern lessons
            LessonAggregate aggregate = new LessonAggregate();

            if(lessons.Count == 0) superString += "\n-----------Empty----------\n"; 

            foreach (Lesson item in lessons) aggregate.Add(item);

            IIterator iterator = aggregate.CreateIterator();
           
            while (iterator.HasItem())
            {
                superString += iterator.CurrentItem().ToString();
                iterator.NextItem();
            }
            superString += "\n\n\n";
            return superString;
        }
    }
}
