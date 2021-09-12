using CompositePattern1;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompositePattern1
{
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

    class Program
	{
        static void Main(string[] args)
		{
            
            var singleValue = new SingleValue { Value = 1 };
			var manyValues = new ManyValues { 2, 3, 4 };

            var valueContainers = new List<IValueContainer> {singleValue, manyValues};
			Console.WriteLine($"Result is \"{ExtensionMethods.Sum(valueContainers)}\"");
		}
	}
}

namespace Coding.Exercise.Tests
{
    [TestFixture]
    public class TestSuite
    {
        [Test]
        public void Test()
        {
            var singleValue = new SingleValue { Value = 11 };
            var otherValues = new ManyValues();
            otherValues.Add(22);
            otherValues.Add(33);
            Assert.That(new List<IValueContainer> { singleValue, otherValues }.Sum(),
              Is.EqualTo(66));
        }
    }
}
