using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork2
{
    //Proxy Desing Pattern
    //Ref Link : 
    //https://sourcemaking.com/design_patterns/proxy
    public class  ProxyUniversity : IGenerate
    {
        /// <summary>
        ///  Universities and departments and includes experiments that I created myself 
        /// </summary>

        public  void generateDemo()
        {
            //create university faulty and department
            University deu = new University("deu");
            Faculty fen = new Faculty("Fen Fakultesi");
            Department csc = new Department("Bilgisayar Bilimleri");
            Department sta = new Department("Statistic");
            fen.addDepartment(sta);
            //add Lesson and delete lesson
            Lesson nesne = new Lesson("Nesneye Yonelik Programlama", "bsc", "asdad");
            Lesson bbg = new Lesson("Bilgisayar Bilimelerine Giris1", "bsc", "99494994-*7592");
            Lesson mp = new Lesson("Matematiksel Programlama", "9as4dasd6", "Spring Period");
            Lesson inyp = new Lesson("Ileri Nesneye Yonelik Programlama", "msc", "Autumn Period");
            Lesson godLesson = new Lesson("God Lesson", "phd", "SpRiNG pErIod");

            csc.addLesson(nesne);
            csc.addLesson(bbg);
            csc.addLesson(mp);
            csc.addLesson(inyp);
            csc.addLesson(godLesson);
            csc.deleteLesson("God Lesson");
            csc.deleteLesson("ugqdguqdwgu");

            //add lecturer and delete lecturer
            csc.addLecturer(new Lecturer("mustafa", "yilmaz", 20192008, 1, 45)); //successfuly
            //cause Only an Lecturer can be found in one deparment
            sta.addLecturer(new Lecturer("mustafa", "yilmaz", 20192008, 1, 45)); // fail

            sta.addLecturer(new Lecturer("qweqweqwe", "asdsad", 449496496, 1, 53));//successfuly

            csc.addLecturer(new Lecturer("elif", "sad", 20192009, 3, 45));
            csc.addLecturer(new Lecturer("ahmet", "nas", 20192010, 2, 22));


            //same id control
            csc.addLecturer(new Lecturer("ahmet", "gel", -20082011, -8, 34));
            csc.addLecturer(new Lecturer("mehmet", "git", 20082011, 2, 28));

            csc.addLecturer(new Lecturer("ali", "veli", 20192150, -99, 42));

            csc.deleteLecturer(20192150); //successfuly
            csc.deleteLecturer(99);//fail
            csc.deleteLecturer("ahmet", "gel");  //successfuly
            csc.deleteLecturer("adasd", "assdasdsad");  //fail

            //add student and delete student in department
            try
            {
                csc.addStudent(StudentFactory.getStudent("phd", "asda", "adasasd", -201555555, 28));
                csc.addStudent(StudentFactory.getStudent("msc", "qewqeqw", "yuıyuı", 49949916, 22));
                csc.addStudent(StudentFactory.getStudent("bsc", "bn", "ıop", 1, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "cv", "kjk", 2, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "rt", "hj", 3, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "gh", "sad", 4, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "fg", "xc", 5, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "yu", "dfgd", 6, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "xc", "nr", 7, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "op", "rn", 8, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "pl", "fnfr", 9, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "qs", "vr", 10, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "zf", "ewr", 11, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "ym", "ewrew", 12, 25));
                csc.addStudent(StudentFactory.getStudent("bsc", "ıp", "yuyı", 13, 25));

                //same no control
                csc.addStudent(StudentFactory.getStudent("bsc", "asfgfghgfhda", "yuıyu", 57278287, 28)); //successfuly
                csc.addStudent(StudentFactory.getStudent("bsc", "mustafa ", "qwqwrwqr", 57278287, 32)); // fail
                //adding failed because it has unkown rank
                csc.addStudent(StudentFactory.getStudent("asfsaf", "asfghgfhgfda", "gjkhgk", 27822827, 23));
            }
            catch (Exception e)
            {

            }
            csc.deleteStudent(49949916);//successfuly
            csc.deleteStudent(-94994494); //fail

            //add and delete student in lesson

            //not adding because they are not same  status
            //status of lesson = bsc 
            //student rank = msc
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 49949916); //fail
            //same student and negative stundet number control
            csc.addStudentInLesson("Nesneye Yonelik Programlama", -49626161);//fail
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 49626161);//fail
            csc.addStudentInLesson("sdfsdfsdf", 1);//fail
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 1);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 2);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 3);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 4);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 5);
            //new branch open
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 6);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 7);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 8);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 9);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 10);
            //new branch open
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 11);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 12);
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 13);

            //A student from a lesson if the quota is regulated by the balance of the five branches is deleted.
            csc.deleteStudentInLesson("Nesneye Yonelik Programlama", 2);//successfuly
            csc.deleteStudentInLesson("Nesneye Yonelik Programlama", 8);//successfuly
            csc.deleteStudentInLesson("Nesneye Yonelik Programlama", 3);//successfuly
            csc.deleteStudentInLesson("Nesneye Yonelik Programlama", 11);//successfuly
            //not found student
            csc.deleteStudentInLesson("Nesneye Yonelik Programlama", 17);//fail

            //again I have added
            csc.addStudentInLesson("Nesneye Yonelik Programlama", 2);


            //asignmentLecturer and change assignment lecturer in lesson
            //Add it to the first branch with the lecturer does
            csc.assignmentLecturer(20192009, "Nesneye Yonelik Programlama");//successfuly
            csc.assignmentLecturer(20192008, "Nesneye Yonelik Programlama");//successfuly
            //it have not empty branch
            csc.assignmentLecturer(20192010, "Nesneye Yonelik Programlama");//fail

            //is not assigned to one of assigned to one of
            csc.changeAssignmentLecturer(20192008, 20192010, "Nesneye Yonelik Programlama"); //successfuly

            // both are assigned and changed only if it is to be branches
            csc.changeAssignmentLecturer(20192010, 20192009, "Nesneye Yonelik Programlama");

            //remove the branch ,lesson and department
            csc.deleteLecturer(20192009);
            csc.deleteLecturer("ahmet", "nas");

            csc.deleteStudent(5);//succesfuly
            csc.deleteStudent("xc", "nr");//succesfuly
            csc.deleteStudent(-99);//fail
            csc.deleteStudent("sddfdsf", "sdfdsfuıdshufds");//fail
            //added two new lecturer
            csc.addLecturer(new Lecturer("ahmet", "nas", 20192010, 2, 22));
            csc.addLecturer(new Lecturer("elif", "sad", 20192009, 3, 45));
            //added lesson one no student
            csc.addStudentInLesson("Matematiksel Programlama", 1);
            //assingmented lecturer
            csc.assignmentLecturer(20192009, "Matematiksel Programlama"); // succesfuly
            //fail because lesson reached lecturer capacity
            // branch number = lecturer
            csc.assignmentLecturer(20192010, "Matematiksel Programlama");
            //delete lesson
            csc.deleteLesson("Bilgisayar Bilimelerine Giris2");
            csc.addLesson(new Lesson("Bilgisayar Bilimelerine Giris2", "bsc", "spring period"));

            //csc.deleteLesson("Bilgisayar Bilimelerine Giris2");
            //add  and asignmented lecturer
            csc.addLecturer(new Lecturer("mustafa firat ", "yilmaz", 124124124, 78, 25));
            csc.assignmentLecturer(124124124, "Nesneye Yonelik Programlama");


                fen.addDepartment(csc);
            deu.addFaculty(fen);

           

            //-------------------------------------------------------------------------------------
            //ADD  NEW FAULCTY
           Faculty eng = new Faculty("engineer");
           Department comeng = new Department("computer engineer");


            eng.addDepartment(comeng);
            deu.addFaculty(eng);
            //--------------------------------------------------------------------------------------

            //xml Serialize  save
            deu.savedLesson("Nesneye Yonelik Programlama", 1);

            //txt save
            //open WordPad NotePad++ Internet Explorer  not open NotePad
            deu.savedLesson("Nesneye Yonelik Programlama", 2);
            deu.savedLesson("Matematiksel Programlama", 2);
            Console.WriteLine(deu.ToString());

        }

    }
}
