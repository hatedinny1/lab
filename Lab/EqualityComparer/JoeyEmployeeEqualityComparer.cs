using System.Collections.Generic;
using Lab.Entities;

namespace Lab.EqualityComparer
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
}