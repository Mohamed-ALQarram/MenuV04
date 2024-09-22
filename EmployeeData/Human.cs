using System;
using System.Collections;

namespace EmployeeData
{
    public class Human
    {
        protected string name;
        protected int age;
        protected readonly Gender gender;

        public Human():this("" , 0 , Gender.Male) { }
        public Human(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}\nGender: {gender}\n";
        }

    }
}
