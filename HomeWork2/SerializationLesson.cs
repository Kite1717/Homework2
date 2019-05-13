using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork2
//Ref link 
// http://www.kazimcesur.com/c-xml-serialization/
{
    [Serializable]
  public  class SerializationLesson 
    {
        [XmlElement(ElementName = "NameOfLesson")]
        public string name { get; set; }

        [XmlElement(ElementName = "PeriodOfLesson")]
        public string period { get; set; }

        [XmlElement(ElementName = "StatusOfLesson")]
        public string statusOfLesson { get; set; }

        [XmlElement(ElementName = "AvailableBranchCount")]
        public int branchNo { get; set; }

        [XmlArray("AllStudents")]
        [XmlArrayItem("student")]
        public List<string> studentsInfo { get; set; }

        [XmlArray("AllLecturers")]
        [XmlArrayItem("lecturer")]
        public List<string> lecturersInfo { get; set; }

        [XmlArray("AllBranches")]
        [XmlArrayItem("branch")]
        public List<string> branchesInfo { get; set; }
       
       
       
       
        public SerializationLesson()
        {
        }

        public SerializationLesson(string name, string period, string statusOfLesson, int branchNo, List<string> studentsInfo, List<string> lecturersInfo, List<string> branchesInfo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.period = period ?? throw new ArgumentNullException(nameof(period));
            this.statusOfLesson = statusOfLesson ?? throw new ArgumentNullException(nameof(statusOfLesson));
            this.branchNo = branchNo;
            this.studentsInfo = studentsInfo ?? throw new ArgumentNullException(nameof(studentsInfo));
            this.lecturersInfo = lecturersInfo ?? throw new ArgumentNullException(nameof(lecturersInfo));
            this.branchesInfo = branchesInfo ?? throw new ArgumentNullException(nameof(branchesInfo));
        }
    }
}
