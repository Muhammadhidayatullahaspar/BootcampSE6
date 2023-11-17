using Calculation;
using Xunit;

namespace Calculation.Tests
{
	public class NumberCalculationTests
	{
		[Fact]
		public void Add_ShouldReturnCorrectResult()
		{
			// Arrange
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.Equal(22, result);
		}

		[Fact]
		public void Multiply_ShouldReturnCorrectResult()
		{
			// Arrange
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Multiply(a, b);

			// Assert
			Assert.Equal(120, result);
		}

		[Fact]
		public void Subtract_ShouldReturnCorrectResult()
		{
			// Arrange
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Subtract(a, b);

			// Assert
			Assert.Equal(-2, result);
		}

		[Fact]
		public void Divide_ShouldReturnCorrectResult()
		{
			// Arrange
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 2;

			// Act
			int result = numberCalc.Divide(a, b);

			// Assert
			Assert.Equal(5, result);
		}

		[Fact]
		public void Divide_ShouldThrowDivideByZeroException()
		{
			// Arrange
			NumberCalculation numberCalc = new();
			int a = 10;
			int b = 0;

			// Act and Assert
			Assert.Throws<DivideByZeroException>(() => numberCalc.Divide(a, b));
		}
	}
}
