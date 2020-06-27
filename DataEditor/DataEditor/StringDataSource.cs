using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace WpfApp3
{
    public class Student
    {
        public Student() { }
        
        public Student(string name,string group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }
        public string Group {get; set;}
    }

public class Group
    {
    
    public int Number { get; set; }
    public int Cource { get; set; }
    public string Track { get; set; }
    }
    [Serializable]
    public class StringDataSource
    {
        public ObservableCollection<Student> data = new ObservableCollection<Student>();
    }
}
