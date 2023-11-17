using Calculation;
using Xunit;

namespace Calculation.Tests
{
	public class NumberCalculationTests
	{
		private NumberCalculation numberCalc;

		public NumberCalculationTests() 
		{
			numberCalc = new NumberCalculation();
		}
		
		[Fact]
		public void Add_ShouldReturnCorrectResult()
		{
			// Arrange
			//NumberCalculation numberCalc = new();
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
			//NumberCalculation numberCalc = new();
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
			//NumberCalculation numberCalc = new();
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
			//NumberCalculation numberCalc = new();
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
			//NumberCalculation numberCalc = new();
			int a = 10;
			int b = 0;

			// Act and Assert
			Assert.Throws<DivideByZeroException>(() => numberCalc.Divide(a, b));
		}

		[Theory]
		[InlineData(3, 5, 8)]
		[InlineData(0, 0, 0)]
		[InlineData(-10, 10, 0)]
		public void Add_ShouldReturnCorrectResult_InlineData(int a, int b, int expected)
		{
			// Arrange
			NumberCalculation numberCalc = new();

			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.Equal(expected, result);
		}

	}
}
