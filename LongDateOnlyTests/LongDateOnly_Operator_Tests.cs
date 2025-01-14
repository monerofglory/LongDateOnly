namespace LongDateOnlyTests
{
    public class LongDateOnly_Operator_Tests
    {

        [Fact]
        public void Operator_Equal_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 29);
            Assert.True(longDateOnly == dateOnly);
        }

        [Fact]
        public void Operator_NotEqual_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2023, 1, 2);
            Assert.True(longDateOnly != dateOnly);
        }

        [Fact]
        public void Operator_GreaterThan_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_001);
            var dateOnly = new DateOnly(2023, 1, 1);
            Assert.True(longDateOnly > dateOnly);
        }

        [Fact]
        public void Operator_GreaterThanOrEqual_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2023, 1, 1);
            Assert.True(longDateOnly >= dateOnly);
        }

        [Fact]
        public void Operator_LessThan_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 30);
            Assert.True(longDateOnly < dateOnly);
        }

        [Fact]
        public void Operator_LessThanOrEqual_LongDateOnly_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 29);
            Assert.True(longDateOnly <= dateOnly);
        }

        [Fact]
        public void Operator_Subtract_LongDateOnly_DateOnly_ReturnsCorrectResult()
        {
            var longDateOnly = new LongDateOnly(1_000_001);
            var dateOnly = new DateOnly(2738, 11, 29);
            var result = longDateOnly - dateOnly;
            Assert.Equal(new LongDateOnly(1), result);
        }

        [Fact]
        public void Operator_Add_LongDateOnly_DateOnly_ReturnsCorrectResult()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 29);
            var result = longDateOnly + dateOnly;
            Assert.Equal(new LongDateOnly(2_000_000), result);
        }

        [Fact]
        public void CompareTo_DateOnly_ReturnsCorrectResult()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 29);
            Assert.Equal(0, longDateOnly.CompareTo(dateOnly));
        }

        [Fact]
        public void Equals_DateOnly_ReturnsTrue()
        {
            var longDateOnly = new LongDateOnly(1_000_000);
            var dateOnly = new DateOnly(2738, 11, 29);
            Assert.True(longDateOnly.Equals(dateOnly));
        }

        [Fact]
        public void EqualsToDateOnly_True()
        {
            LongDateOnly date1 = new(0, 2023, 2, 5);
            LongDateOnly date2 = new(0, 2023, 2, 5);
            Assert.True(date1.Equals(date2));
            Assert.True(date1 == date2);
        }

        [Fact]
        public void EqualsToDateOnly_False()
        {
            LongDateOnly date1 = new(0, 2024, 2, 5);
            LongDateOnly date2 = new(0, 2023, 2, 5);
            Assert.False(date1.Equals(date2));
            Assert.False(date1 == date2);
        }

        [Fact]
        public void LongDateOnly_DayNumbers()
        {
            LongDateOnly date1 = new(0, 2023, 2, 5);
            LongDateOnly date2 = new(0, 2023, 2, 5);
            Assert.Equal(date1.DayNumber, date2.DayNumber);
        }

        [Fact]
        public void GreaterThan_True()
        {
            LongDateOnly date1 = new(0, 2023, 3, 5);
            LongDateOnly date2 = new(0, 2023, 2, 5);
            Assert.True(date1 > date2);
            Assert.True(date1 >= date2);
        }

        [Fact]
        public void GreaterThan_False()
        {
            LongDateOnly date1 = new(0, 2023, 2, 5);
            LongDateOnly date2 = new(0, 2023, 3, 5);
            Assert.False(date1 > date2);
            Assert.False(date1 >= date2);
        }

        public void Operator_Subtract_LongDateOnlyAndDateOnly_ReturnsCorrectResult()
        {
            // Arrange
            var longDateOnly = new LongDateOnly(1, 2023, 10, 10);
            var dateOnly = new DateOnly(2023, 10, 5);
            var expected = new LongDateOnly(longDateOnly.DayNumber - dateOnly.DayNumber);

            // Act
            var result = longDateOnly - dateOnly;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Operator_Add_LongDateOnlyAndDateOnly_ReturnsCorrectResult()
        {
            // Arrange
            var longDateOnly = new LongDateOnly(1, 2023, 10, 10);
            var dateOnly = new DateOnly(2023, 10, 5);
            var expected = new LongDateOnly(longDateOnly.DayNumber + dateOnly.DayNumber);

            // Act
            var result = longDateOnly + dateOnly;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Operator_Equal_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            Assert.True(left == right);
        }

        [Fact]
        public void Operator_NotEqual_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_001);
            Assert.True(left != right);
        }

        [Fact]
        public void Operator_GreaterThan_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_001);
            var right = new LongDateOnly(1_000_000);
            Assert.True(left > right);
        }

        [Fact]
        public void Operator_GreaterThanOrEqual_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            Assert.True(left >= right);
        }

        [Fact]
        public void Operator_LessThan_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_001);
            Assert.True(left < right);
        }

        [Fact]
        public void Operator_LessThanOrEqual_LongDateOnly_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            Assert.True(left <= right);
        }

        [Fact]
        public void Operator_Subtract_LongDateOnly_LongDateOnly_ReturnsCorrectResult()
        {
            var left = new LongDateOnly(1_000_001);
            var right = new LongDateOnly(1_000_000);
            var result = left - right;
            Assert.Equal(new LongDateOnly(1), result);
        }

        [Fact]
        public void Operator_Add_LongDateOnly_LongDateOnly_ReturnsCorrectResult()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            var result = left + right;
            Assert.Equal(new LongDateOnly(2_000_000), result);
        }

        [Fact]
        public void CompareTo_LongDateOnly_ReturnsCorrectResult()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            Assert.Equal(0, left.CompareTo(right));
        }

        [Fact]
        public void Equals_LongDateOnly_ReturnsTrue()
        {
            var left = new LongDateOnly(1_000_000);
            var right = new LongDateOnly(1_000_000);
            Assert.True(left.Equals(right));
        }
    }
}