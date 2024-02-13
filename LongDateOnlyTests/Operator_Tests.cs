namespace LongDateOnlyTests
{
    public class Operator_Tests
    {
        [Fact]
        public void EqualsToDateOnly_True()
        {
            LongDateOnly date1 = new(0, 2023, 2, 5);
            DateOnly date2 = new(2023, 2, 5);
            Assert.True(date1.Equals(date2));
            Assert.True(date1 == date2);
        }

        [Fact]
        public void EqualsToDateOnly_False()
        {
            LongDateOnly date1 = new(0, 2024, 2, 5);
            DateOnly date2 = new(2023, 2, 5);
            Assert.False(date1.Equals(date2));
            Assert.False(date1 == date2);
        }

        [Fact]
        public void LongDateOnly_DayNumbers()
        {
            LongDateOnly date1 = new(0, 2023, 2, 5);
            DateOnly date2 = new(2023, 2, 5);
            Assert.Equal(date1.DayNumber, date2.DayNumber);
        }
    }
}