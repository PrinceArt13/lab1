﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Controller
    {
        public string Path { get; set; }

        public DataHandler dataHandler { get; set; }

        public Controller()
        {
            dataHandler = new DataHandler();
        }

        public bool SetAndCheckPath(string path)
        {
            if (File.Exists(path) && System.IO.Path.GetExtension(path) == ".csv")
            {
                Path = path;
                return true;
            }
            else return false;
        }

        public string GetString(List<string> records, int pos)
        {
            string result = pos.ToString() + " | ";
            foreach (string rec in records)
                result += rec + " | ";
            return result;
        }

        public List<string> GetAllRecords()
        {
            var data = dataHandler.LoadAll(Path);
            var outputRecords = new List<string>();
            int num = 1;
            foreach (var student in data)
            {
                outputRecords.Add(GetString(student.GetStringList(), num));
                num++;
            }
            return outputRecords;
        }

        public List<string> GetSepRecord(int number)
        {
            var data = dataHandler.SeparatelyLoad(Path, number - 1);
            List<string> outputRecord = new();
            outputRecord.Add(GetString(data.GetStringList(), number));
            return outputRecord;
        }

        public void DeleteRecord(int number)
        {
            dataHandler.StudentDelete(Path, number);
        }

        public void AddRecord(string str)
        {
            var record = dataHandler.ConvertTextToStudent(str);
            dataHandler.StudentAdd(Path, record);
        }
    }
}
