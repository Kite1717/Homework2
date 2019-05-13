using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Lesson
    {

        public string name { get; }
        public string period { get; }

        public string statusOfLesson { get; } // for bsc or for phd or for msc 
        public List<Branch> branches { get; }
        public List<Student> students { get; }
        private int branchNo = 1;
        public List<Lecturer> lecturers { get; }

        
        /// <summary>
        /// Create a lesson and default branch
        /// name = name of lesson
        /// statusOfLesson =  1 - bsc
        ///                   2 - msc
        ///                   3 - phd
        ///                   default - bsc
        ///  period  =  1 - Spring Period
        ///             2 - Autumn Period
        ///             default - Autumn Period
        /// </summary>
        /// <param name="name">name of lesson </param>
        /// <param name="statusOfLesson"> rank of lesson </param>
        /// <param name="period">period of lesson </param>
        public Lesson(string name, string statusOfLesson ,string period)
        {
           
            this.name = name;
            if (statusOfLesson.ToLower().Equals("msc") || statusOfLesson.ToLower().Equals("bsc") || statusOfLesson.ToLower().Equals("phd"))
            {
                this.statusOfLesson = statusOfLesson;

            }
            else this.statusOfLesson = "bsc"; // default value

            if (period.ToLower().Equals("autumn period") || period.ToLower().Equals("spring period"))
            {
                this.period = period;
            }
            else this.period = "Autumn Period"; // default value

            branches = new List<Branch>();
            students = new List<Student>();
            lecturers = new List<Lecturer>();
            Branch defVal = new Branch(branchNo +". Branch"); // default branch
            branches.Add(defVal);

           

        }

        public int  BranchNo
            {
            get{
                return this.branchNo;
            }
             }

/// <summary>
///  Both in lesson and students are recording the appropriate branch
/// </summary>
/// <param name="name"> name of student </param>
/// <param name="surname"> surname of student </param>
/// <param name="no"> number of student </param>
/// <returns>already existing or new control </returns>
public bool addStudent(string name ,string surname ,int no,int age)
        {
            //students registering for the lesson is here
            foreach (Student item in students)
                if (item.getNo() == no)
                    return false;

            try
            {
                students.Add(StudentFactory.getStudent(statusOfLesson, name, surname, no, age));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // his function is checking to see if you got in the current branch
           // if not, opening of new branches added to that branch and students
            bool flag = false; 
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].students.Count == 5)
                {
                    flag = true;            
                }
                else
                {
                    branches[i].addStudent(students.Last());
                    flag = false;
                    break;
                }
            }

            if(flag) //if all branches are full of
            {
                branchNo++;
                branches.Add(new Branch(branchNo + ". Branch"));
                branches.Last().addStudent(students.Last());
            }

            return true; 
        }
        /// <summary>
        /// Delete the student according to the number
        /// </summary>
        /// <param name="no"> number of student </param>
        /// <returns> Shows the status of whether the deletion is successful </returns>

        public bool deleteStudent(int no)
        {
            bool flag = false;
            for (int i = 0; i < students.Count; i++)
            {
                if(students[i].getNo() == no)
                {
                    students.RemoveAt(i);
                    flag = true;
                    break;
                
                }
            }

            if(flag)
            for (int i = 0; i < branches.Count; i++)
            {
                    for (int j = 0; j < branches[i].students.Count; j++)
                    {
                        if(branches[i].students[j].getNo() == no)
                        {
                            branches[i].students.RemoveAt(j);
                            break;
                        }
                    }
            }
            if (flag)
            {
                for (int i = 0; i < branches.Count - 1; i++)
                {
                    if (branches[i].students.Count < 5)
                    {
                        int k = 0;
                        while (branches[i].students.Count < 5)
                        {
                            branches[i].students.Add(branches[i + 1].students[k]);
                            branches[i + 1].students.RemoveAt(k);
                        }
                    }
                }

                for (int i = 1; i < branches.Count; i++)
                {
                    if (branches[i].students.Count == 0)
                    {
                        branches.RemoveAt(i);
                        this.branchNo--;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        ///  Delete a student by name 
        /// </summary>
        /// <param name="name">name of student </param>
        /// <returns></returns>
        public bool deleteStudent(string name)
        {
            bool flag = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].getName().Equals(name))
                {
                    students.RemoveAt(i);
                    flag = true;
                    break;
                  
                }
            }

            if (flag)
                for (int i = 0; i < branches.Count; i++)
                {
                    for (int j = 0; j < branches[i].students.Count; j++)
                    {
                        if (branches[i].students[j].getName().Equals(name))
                        {
                            branches[i].students.RemoveAt(j);
                           
                            break;
                        }
                    }
                }    
            return flag;
        }
        /// <summary>
        /// a lecturer assigns to the empty branch
        /// </summary>
        /// <param name="lecturer"></param>
        /// <returns></returns>
        public bool lecturerAssignment(Lecturer lecturer)
        {
            
            //already existing lecturer control
            for (int i = 0; i < lecturers.Count; i++)
            {
                if(lecturers[i].id == lecturer.id)
                {
                    return false;
                }
            }

            // a lecturer for each branch 
            if (branchNo > lecturers.Count)
            {
                lecturers.Add(lecturer);
                for (int i = 0; i < branches.Count; i++)
                {
                    if(branches[i].Lecturer == null)
                    {
                        branches[i].Lecturer = lecturer;
                        return true;
                    }
                }
                
            }
            return false;

        }
        /// <summary>
        /// change to lecturer
        /// </summary>
        /// <param name="oldLecturer"> existing lecturer</param>
        /// <param name="newLecturer"> new lecturer</param>
        /// <returns>find control</returns>
        public bool changeLecturer(Lecturer oldLecturer,Lecturer newLecturer)
        {

            bool flag = false;
            if(this.lecturers.Contains(oldLecturer) && this.lecturers.Contains(newLecturer))
            {
                int indexOld = 0, indexNew = 0;
                for (int i = 0; i < branches.Count; i++)
                {
                    if(branches[i].Lecturer.id == oldLecturer.id) indexOld = i;
                    if (branches[i].Lecturer.id == newLecturer.id) indexNew = i;                   
                }
                branches[indexOld].Lecturer = newLecturer;
                branches[indexNew].Lecturer = oldLecturer;
                return true;
               
            }

            for (int i = 0; i < lecturers.Count; i++)
            {
                if(lecturers[i].id == oldLecturer.id)
                {
                    lecturers[i] = newLecturer;
                    flag = true;
                    break;
                }
            }

            if(flag)
            {
                for (int i = 0; i < branches.Count; i++)
                {
                    if(branches[i].Lecturer.id == oldLecturer.id)
                    {
                        branches[i].Lecturer = newLecturer;
                        return flag;
                    }
                }    
            }
            return flag;

        }

       
        public override string ToString()
        {
            string superString = null;
            superString = "\n\n------------------------------\n";
            superString += "\n*Lesson Name : " + this.name + "*\n*Lesson Period : " + this.period + "*\n*Status Of Lesson : " + this.statusOfLesson + "*";
            superString += "\n------------------------------\n";

            superString += "\n*All students in Lesson*\n";
            if (this.students.Count == 0) superString += "\n-----------Empty----------\n";
            foreach (Student item in this.students) superString += item.ToString();

            superString += "\n*Lecturers*\n";
            if (this.lecturers.Count == 0) superString += "\n-----------Empty----------\n";
            foreach (Lecturer item in this.lecturers) superString += item.ToString();

            superString += "\n*Available Branch Count : " + this.branchNo + "*\n\n";
            superString += "\n*Branches and branch according to the distribution of students and lecturers*\n";

            for (int i = 0; i < this.branches.Count; i++)
            {
                superString += "\n-----------------\n";
                superString += "\n*" + (i + 1) + ". Branch*\tClass lecture for : " +branches[i].classNo + "\n";
                if (branches[i].Lecturer != null)  superString += "\n*Lecturer:*\t" + branches[i].Lecturer.ToString();
                else superString += "\n*Lecturer:*\n\n-----------Empty----------\n";


                superString += "\n*Students:*\n";
                if(this.branches[i].students.Count == 0 ) superString += "\n-----------Empty----------\n";

                for (int j = 0; j < this.branches[i].students.Count; j++) superString += this.branches[i].students[j].ToString();
                superString += "\n-----------------\n";
            }
          
            superString += "\n\n\n";
            return superString;


        }

        // inner class
        // one branch max capacity  is 5 student
        // A branch has only one teacher
        public class Branch
        {
            private static List<string> classNumbers = new List<string>();

            public string classNo { get; set; }
            private string name;
            public List<Student> students { get; }
            public Lecturer Lecturer { get; set; }
            public Branch(string name)
            {
                createLessonNo();
                this.name = name;
                students = new List<Student>();

            }
            /// <summary>
            /// add new student in current branch
            /// </summary>
            /// <param name="student"> created student </param>
            /// <returns> already existing or new control</returns>

            public bool addStudent(Student student)
            {
                foreach(Student item in students)
                    if (item.getNo() == student.getNo())
                        return false;
                students.Add(student);
                return true;
            }

            /// <summary>
            /// determines the class for lecture
            /// </summary>
            private void createLessonNo()
            {

                Random random = new Random(DateTime.Now.Millisecond);

                bool quit = false;

                while (!quit)
                {
                    int letter = random.Next(0, 4);// 0 = A 1 = B 2 = C 3 = D
                    switch (letter)
                    {
                        case 0:
                            {
                                this.classNo += "A";
                                break;
                            }
                        case 1:
                            {
                                this.classNo += "B";

                                break;
                            }
                        case 2:
                            {
                                this.classNo += "C";

                                break;
                            }
                        case 3:
                            {
                                this.classNo += "D";

                                break;
                            }
                    }
                    this.classNo += random.Next(100, 401);
                    foreach (string item in classNumbers)
                    {
                        if (item.Equals(this.classNo))
                        {
                            this.classNo = null;
                            break;

                        }

                    }
                    if (this.classNo != null)
                    {
                        classNumbers.Add(this.classNo);
                        quit = true;

                    }

                }
            }
            public override string ToString()
            {
                string superString = null;
                superString = "***Branch Name : " + this.name + "\nClass No : " + this.classNo + "\n[Lecturer : ";

                superString += (this.Lecturer != null) ? this.Lecturer.ToString() : "";
                superString += "]";

                superString += "\n------->>Students Number : \n";

                if (this.students.Count != 0)
                    foreach (Student item in this.students) superString += item.getNo() + " , ";
                else superString += "EMPTY";
                return superString;
            }

        }

       

    }
}
