namespace LongDateOnlyTests
{
    public class AddTime_Tests
    {
        [Fact]
        public void LongDateOnly_AddDays_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);
            var daysBefore = date.DayNumber;
            var addDayAmount = 1;

            // Act
            date = date.AddDays(addDayAmount);
            var daysAfter = date.DayNumber;

            // Assert
            Assert.Equal(daysBefore + addDayAmount, daysAfter);
        }

        [Fact]
        public void LongDateOnly_AddDays_ToNewDecamillenium_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 9999, 12, 25);

            // Act
            date = date.AddDays(7);

            // Assert
            Assert.Equal(1, date.Decamillenium);
            Assert.Equal("10001/1/1", date.ToString());
        }

        [Fact]
        public void LongDateOnly_AddMaxIntDays_ToNewDecamillenium_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 1, 1, 1);

            // Act
            date = date.AddDays(int.MaxValue);

            // Assert
            Assert.Equal(588, date.Decamillenium);
        }

        #region Months
        [Fact]
        public void LongDateOnly_AddMonths_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);
            var daysBefore = date.DayNumber;

            // Act
            //date.AddMonths(1);
            var daysAfter = date.DayNumber; 
            // Assert
            Assert.Equal(daysBefore + 7, daysAfter);
        }
        #endregion

        #region Years
        [Fact]
        public void LongDateOnly_AddYears_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);
            var daysBefore = date.DayNumber;

            // Act
            date.AddYears(1);
            var daysAfter = date.DayNumber;

            // Assert
            Assert.Equal(daysBefore + 365, daysAfter);
        }
        #endregion
    }
}