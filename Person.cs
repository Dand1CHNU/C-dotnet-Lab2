﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2

{
    internal class Person : IDateAndCopy
    {
        protected string _name;
        protected string _surname;
        protected DateOnly _birthday;

        public Person(string name, string surname, DateOnly birthday)
        {
            Name = name;
            Surname = surname;
            Date= birthday;
        }
        public Person() : this(name: "Alex", surname: "Kuplinov", birthday: new DateOnly(2002, 8, 10))
        {
        }
        public string Name
        {
            get
            {
                return _name;
            }

            init
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }

            init
            {
                _surname = value;
            }
        }
        public DateOnly Date
        {
            get
            {
                return _birthday;
            }

            init
            {
                _birthday = value;
            }
        }
        public int Year
        {
            get
            {
                return Date.Year;
            }

            init
            {

                Date = new DateOnly(Date.Year + value, Date.Month, Date.Day);
            }
        }
        public override string ToString()
        {
            return $"Name:{Name}\nSurname: {Surname}\nBirthday: {Date}\n";
        }
        public string ToShortString()
        {
            return $"Name: {Name}\nSurname: {Surname}\n";
        }
        object IDateAndCopy.DeepCopy()
        {
            return MemberwiseClone();
        }
        public virtual object DeepCopy()
        {
            return new Person();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Person person = (Person)obj;
            return person.Name == Name && person.Surname == Surname && person.Date == Date;
        }
        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }
        public static bool operator !=(Person person1, Person person2) 
        {
            return !(person1==person2);        
        }
        public override int GetHashCode()
        {
            return (Name.GetHashCode()+Surname.GetHashCode())*17+Date.GetHashCode()*19;
        }
    }
}
