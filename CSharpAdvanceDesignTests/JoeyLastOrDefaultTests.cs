using ExpectedObjects;
using Lab;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyLastOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();
            var actual = employees.JoeyLastOrDefault();
            Assert.IsNull(actual);
        }

        [Test]
        public void get_last_employees()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Role = Role.Engineer,
                    LastName = "Zheng",
                    FirstName = "Brian"
                },
                new Employee()
                {
                    Role = Role.Engineer,
                    LastName = "Cash",
                    FirstName = "Chen"
                },
            };
            var actual = employees.JoeyLastOrDefault();
            var expected = new Employee()
            {
                Role = Role.Engineer,
                LastName = "Cash",
                FirstName = "Chen"
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}