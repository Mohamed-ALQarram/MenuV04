using EmployeeData;
using System.Collections;

namespace MenuV04
{
    public class CompareByID : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee? emp1 = x as Employee;
            Employee? emp2 = y as Employee;
            if (emp1 != null)
            return emp1.ID.CompareTo(emp2?.ID);
            return -1;
        }
    }
    public class CompareByName : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee? emp1 = x as Employee;
            Employee? emp2 = y as Employee;
            if (emp1 != null)
                return emp1.Name.CompareTo(emp2?.Name);
            return -1;
        }
    }
    public class CompareByAge : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee? emp1 = x as Employee;
            Employee? emp2 = y as Employee;
            if (emp1 != null)
                return emp1.Age.CompareTo(emp2?.Age);
            return -1;
        }
    }


}
