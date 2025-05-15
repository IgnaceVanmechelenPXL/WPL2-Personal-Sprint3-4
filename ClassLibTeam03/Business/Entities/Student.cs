using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Business.Entities
{
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private static int _idCounter = 1;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _firstName = "John";
                } else
                {
                    _firstName = value;
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _lastName = "Doe";
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        public int ID { get; set; }

        public Student()
        {
            ID = _idCounter++;
            FirstName = "John";
            LastName = "Doe";
        }

        public Student(string firstName, string lastName)
        {
            ID = _idCounter++;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
