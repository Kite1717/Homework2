using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace HomeWork2
{
    //Ref Links : 
    //Use process
    //https://stackoverflow.com/questions/1132422/open-a-folder-using-process-start
    //
    class University : IGenerate
    {
       public string name { get; }
        public List<Faculty> faculties { get; }
        public University(string name)
        {
            this.name = name;
            faculties = new List<Faculty>();
        }

        public University()
        {
        }


        /// <summary> 
        /// Add new faculty
        /// </summary>
        /// <param name="faculty"> new faculty </param>
        /// <returns> already existing or new  control </returns>
        public bool addFaculty(Faculty faculty)
        {
            foreach(Faculty item in faculties)
                if (item.name.Equals(faculty.name))
                    return false;

            faculties.Add(faculty);
            return true;
           
        }
        /// <summary>
        /// saved lesson 
        /// saved 1 = xml save as
        /// 2 = txt save as
        /// 
        /// </summary>
        /// <param name="name">name of lesson </param>
        /// <param name="saved">type of saved </param>
        public bool savedLesson(string name,int saved)
        {

           if(!Directory.Exists(@"c:\SavedLessonsAsTxt")) Directory.CreateDirectory(@"c:\SavedLessonsAsTxt");


            for (int i = 0; i < faculties.Count; i++)
            {
                for (int j = 0; j < faculties[i].departments.Count; j++)
                {
                    for (int k = 0; k < faculties[i].departments[j].lessons.Count; k++)
                    {
                        if (faculties[i].departments[j].lessons[k].name.Equals(name))
                        {
                            if (saved == 1) return xmlSaved(faculties[i].departments[j].lessons[k]);
                            else if (saved == 2)
                            {
                                txtSaved(faculties[i].departments[j].lessons[k]);
                                return true;

                            }
                            else return false;

                                

                        }
                    }

                }
            }
            return false;
        }
        /// <summary>
        ///  Xml saves as lesson
        /// </summary>
        /// <param name="item"> SAVED LESSON</param>
        /// <returns> SUCCESS CONTROL</returns>
        private bool xmlSaved(Lesson item )
        {
            List<string> branchesInfo = new List<string>();
            List<string> studentsInfo = new List<string>();
            List<string> lecturerInfo = new List<string>(99999999); // :)
          

            for (int m = 0; m < item.branches.Count; m++) branchesInfo.Add(item.branches[m].ToString());

            for (int m = 0; m < item.students.Count; m++) studentsInfo.Add(item.students[m].ToString());


            for (int m = 0; m < item.lecturers.Count; m++) lecturerInfo.Add(item.lecturers[m].ToString());
            try
            {
                SerializationLesson obj = new SerializationLesson(item.name, item.period, item.statusOfLesson, item.BranchNo, studentsInfo, lecturerInfo, branchesInfo);

                Stream stream = new FileStream("Serialization" + item.name + ".xml", FileMode.Create, FileAccess.Write, FileShare.Write);


                XmlSerializer xmlserializer = new XmlSerializer(typeof(SerializationLesson));
                xmlserializer.Serialize(stream, obj);

                //If it doesn't open, open the part with the set 
                Process.Start( Path.GetFullPath("Serialization" + item.name + ".xml"));

                stream.Close();
            }
            catch (ArgumentNullException e)
            {
                e.ToString();
                return false;
            }
            return true;


        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void txtSaved(Lesson item)
        {

           if(!File.Exists(@"c:\\SavedLessonsAsTxt\\" + item.name + ".txt")) File.Create(@"c:\\SavedLessonsAsTxt\" + item.name + ".txt").Close();
            File.WriteAllText(@"c:\\SavedLessonsAsTxt\\" + item.name + ".txt", item.ToString());
            
            Process.Start(@"c:\\SavedLessonsAsTxt\\");

        }



        public override string ToString()
        {
            string superString = null;
            superString = "\n\n------------------------------\n";
            superString += "\nUniversity Name : " + this.name + "\n";
            superString += "\n------------------------------\n";
            superString += "\n--------------------------------" +this.name.ToUpper() + " IN FACULITIES-------------------------------\n";
            foreach (Faculty item in this.faculties) superString += item.ToString();
            superString += "\n"; 
            return superString;

        }

        public void generateDemo()
        {
            ProxyUniversity proxy = new ProxyUniversity();
            proxy.generateDemo();
        }
    }
}
