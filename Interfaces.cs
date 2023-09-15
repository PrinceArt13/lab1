using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface IDataList
    {
        public List<string> GetStringList();
    }

    interface IDataChanger
    {
        public void StudentDelete(string path, int recordNumber);
        public void StudentAdd(string path, StudentData student);
    }

    interface IDataLoader
    {
        public List<StudentData> LoadAll(string path);

        public StudentData SeparatelyLoad(string path, int number);
    }

    interface IDataConverter
    {
        public StudentData ConvertTextToStudent(string txtLine);
        public string ConvertStudentToText (StudentData student);
    }
}
