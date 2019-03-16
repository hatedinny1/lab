using System.Collections.Generic;

namespace Lab.Entities
{
    public class JoeyEmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            var firstNameHashCode = obj.FirstName.GetHashCode();
            var secondNameHashCode = obj.LastName.GetHashCode();
            return new { firstNameHashCode, secondNameHashCode }.GetHashCode();
        }
    }

    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Role Role { get; set; }
    }
}