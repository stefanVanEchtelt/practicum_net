using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace practicum2
{
    class LambdaRunner
    {
        public static String RunAllMethods(int num1, int num2, int num3)
        {
            StringBuilder output = new StringBuilder();

            // methode TimesThree herschreven als lambda-expressie
            Func<int, int> timesThree = x => 3 * x;
            Func<int, int, int, int> add = (x, y, z) => x + y + z;
            Func<int, bool> isEven = x => (x % 2) == 0;
            Func<int, string> num2String = x => (x < 9 && x >= 0) ? new string[]{"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}[x] : "undefined";
            Func<int, int, int, bool> isBetween = (x, y, z) => (x < y && y < z) || (z < y && y < x);
            Func<Person, string> resetName = (x) => x.name = null;

            output.AppendFormat("TimesThree({0}) = {1}\n", num1, timesThree(num1));
            output.AppendFormat("AddNumbers({0},{1},{2}) = {3}\n", num1, num2, num3, add(num1, num2, num3));
            output.AppendFormat("IsEven({0}) = {1}\n", num1, isEven(num1));
            output.AppendFormat("Num2String({0}) = {1}\n", num1, num2String(num1));
            output.AppendFormat("InBetween({0},{1},{2}) = {3}\n", num1, num2, num3, isBetween(num1, num2, num3));

            Person p = new Person { name = "Mark" };
            resetName(p);
            output.AppendFormat("ResetName, daarna (Name == null) = {0}\n", p.name == null);

            return output.ToString();
        }

    }
}
