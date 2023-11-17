using NUnit.Framework;
using Calculation;
namespace Calculation.Tests
{
	[TestFixture]
	public class NumberCalculationTests
	{
		private NumberCalculation numberCalculation;

		[SetUp]
		public void Setup()
		{
			numberCalculation = new NumberCalculation();
		}

		[Test]
		public void Add_AdditionOfTwoNumber()
		{
			//Arrange
			int a = 10;
			int b = 12;
			int expected = 22;

			//Act
			int actual = numberCalculation.Add(a, b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Subtract_SubstractionOfTwoNumbers()
		{
			int a = 10;
			int b = 12;
			int expected = -2;

			int actual = numberCalculation.Subtract(a, b);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestMultiplication()
		{
			int a = 10;
			int b = 12;
			int expected = 120;

			int actual = numberCalculation.Multiply(a, b);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestDivision()
		{
			int a = 10;
			int b = 2;
			int expected = 3;

			int actual = numberCalculation.Divide(a, b);

			Assert.AreEqual(expected, actual, "Expected not met");
		}

		[Test]
		public void Divide_ShouldThrowDivideByZeroException_DivideByZero()
		{
			int a = 10;
			int b = 0;

			Assert.Throws<DivideByZeroException>(() => numberCalculation.Divide(a, b));
		}
	}
}
