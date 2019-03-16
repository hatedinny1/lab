using ExpectedObjects;
using Lab;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = employees.JoeyFirstOrDefault();

            Assert.IsNull(actual);
        }

        [Test]
        public void get_first_element_when_employees_has_elements()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Joey",
                    LastName = "Chen",
                    Role = Role.Engineer
                },
                new Employee()
                {
                    FirstName = "Brian",
                    LastName = "Zheng",
                    Role = Role.Engineer
                },
            };

            var actual = employees.JoeyFirstOrDefault();

            var expected = new Employee()
            {
                FirstName = "Joey",
                LastName = "Chen",
                Role = Role.Engineer
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_default_int_when_is_empty()
        {
            var numbers = new List<int>();

            var actual = numbers.JoeyFirstOrDefault();

            var expected = 0;
            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}