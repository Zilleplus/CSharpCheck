using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace Check
{
    public class SimpleTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void Given_Number_Check_Sum(
            string testName,
            double a,
            double b,
            Expression<Predicate<double>> expr)
        {
            Debug.Write(testName);

            var c = a + b;

            expr.Check(c);
        }

        public static TheoryData<string, double, double, Expression<Predicate<double>>> GetData()
        {
            return new TheoryData<string, double, double, Expression<Predicate<double>>>
            {
                {
                    "test1",
                    1,
                    2,
                    (x)=>x==4
                },
                //{
                //    "test2",
                //    1,
                //    2,
                //    (x)=>x.Equals(3)
                //}
            };
        }
    }
}
