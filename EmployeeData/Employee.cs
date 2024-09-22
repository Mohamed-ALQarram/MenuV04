namespace EmployeeData
{
    public class Employee :Human
    {
        static int id;
        decimal salary;
        
        public string Name { get { return name; } set { name = value; } }
        public int Age { get {return age; } set { age = value; }}
        public int ID { get; private set;}
        public decimal Salary {set { salary = value; } get { return salary; } }
        public Gender Gender { get {return gender;} }

         static Employee()
        {
            id = 0;
        }
        public Employee() : this(string.Empty,0,0,0 ) { }
        public Employee(string name, decimal salary, int age, Gender gender):base(name , age , gender)
        {
            id++;
            ID = id;
            this.salary = salary;
        }

        public override string ToString()
        {
            return base.ToString()+$"ID: {ID}\nSalary: {salary}\n";
        }
    }
    public enum Gender
    {
        Male,Female
    }
}
