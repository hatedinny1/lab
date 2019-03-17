using System.Collections.Generic;
using Lab.Entities;

namespace Lab.EqualityComparer
{
     public class JoeySpecialEmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            return new { obj.FirstName, obj.LastName }.GetHashCode();
        }
    }
}