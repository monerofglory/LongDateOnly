using System;
using System.Globalization;

namespace LongDateOnlyTests
{
    public class DateOnlyAbTests
    {
        [Fact]
        public void AbTest_LotsOfChanges_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Act
            for (int i = 0; i <= 100; i++)
            {
                var r = new Random();
                var j = r.Next(-50, 50);
                if (r.NextDouble() <= 0.5) 
                {
                    longDateOnly.AddDays(j);
                    dateOnly.AddDays(j);
                }
                else
                {
                    longDateOnly.AddYears(j);
                    dateOnly.AddYears(j);
                }
            }

            // Assert
            Assert.Equal(dateOnly.Year, longDateOnly.Year);
            Assert.Equal(dateOnly.Month, longDateOnly.Month);
            Assert.Equal(dateOnly.Day, longDateOnly.Day);
        }

        [Theory]
        [InlineData(-50)]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(1000)]
        [InlineData(5000)]
        public void AbTest_AddDays_OutputIsSame(int days)
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Act
            longDateOnly = longDateOnly.AddDays(days);
            dateOnly = dateOnly.AddDays(days);

            // Assert
            Assert.Equal(dateOnly.Year, longDateOnly.Year);
            Assert.Equal(dateOnly.Month, longDateOnly.Month);
            Assert.Equal(dateOnly.Day, longDateOnly.Day);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(7000)]
        public void AbTest_AddYears_OutputIsSame(int years)
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Act
            longDateOnly = longDateOnly.AddYears(years);
            dateOnly = dateOnly.AddYears(years);

            // Assert
            Assert.Equal(dateOnly.Year, longDateOnly.Year);
            Assert.Equal(dateOnly.Month, longDateOnly.Month);
            Assert.Equal(dateOnly.Day, longDateOnly.Day);
        }

        [Fact]
        public void AbTest_DayOf_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Assert
            Assert.Equal(dateOnly.DayOfYear, longDateOnly.DayOfYear);
            Assert.Equal(dateOnly.DayOfWeek, longDateOnly.DayOfWeek);
        }

        [Fact]
        public void AbTest_FromDateTime_OutputIsSame()
        {
            // Arrange
            DateTime dateTime = DateTime.Now;
            LongDateOnly longDateOnly = LongDateOnly.FromDateTime(dateTime);
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);

            // Assert
            Assert.True(longDateOnly.Equals(dateOnly));
            Assert.True(longDateOnly == dateOnly);
        }

        [Fact]
        public void AbTest_ToDateTime_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);
            TimeOnly timeOnly = new TimeOnly(5, 3, 6);

            //Act
            DateTime d1 = longDateOnly.ToDateTime(timeOnly);
            DateTime d2 = dateOnly.ToDateTime(timeOnly);

            // Assert
            Assert.Equal(d1, d2);
        }

        [Fact]
        public void AbTest_ToDateTimeWithDateTimeKind_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);
            TimeOnly timeOnly = new TimeOnly(5, 3, 6);
            DateTimeKind dateTimeKind = DateTimeKind.Utc;

            //Act
            DateTime d1 = longDateOnly.ToDateTime(timeOnly, dateTimeKind);
            DateTime d2 = dateOnly.ToDateTime(timeOnly, dateTimeKind);

            // Assert
            Assert.Equal(d1, d2);
        }

        [Fact]
        public void AbTest_ToDateTime_ThrowsException()
        {
            // Arrange
            LongDateOnly longDateOnly = new(1, 2023, 2, 5);
            TimeOnly timeOnly = new TimeOnly(5, 3, 6);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => longDateOnly.ToDateTime(timeOnly));
        }

        [Fact]
        public void AbTest_ToDateTimeW22ithDateTimeKind_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(1, 2023, 2, 5);
            TimeOnly timeOnly = new TimeOnly(5, 3, 6);
            DateTimeKind dateTimeKind = DateTimeKind.Utc;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => longDateOnly.ToDateTime(timeOnly, dateTimeKind));
        }

        #region ToString
        [Fact]
        public void AbTest_ToString_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            //Assert
            Assert.Equal(dateOnly.ToString(), longDateOnly.ToString());
        }

        [Fact]
        public void AbTest_ToShortDateString_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            //Assert
            Assert.Equal(dateOnly.ToShortDateString(), longDateOnly.ToShortDateString());
        }

        [Fact]
        public void AbTest_ToLongDateString_OutputIsSame()
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            //Assert
            Assert.Equal(dateOnly.ToLongDateString(), longDateOnly.ToLongDateString());
        }

        [Theory]
        [InlineData("dd MM yyyy")]
        [InlineData("YYYY MM dd")]
        [InlineData("MM YYYY dd")]
        [InlineData("MM dd YYYY")]
        [InlineData("YYYY dd MM")]
        [InlineData("dd YYYY MM")]
        public void AbTest_ToString_WithFormat_OutputIsSame(string format)
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            //Assert
            Assert.Equal(dateOnly.ToString(format, CultureInfo.InvariantCulture), longDateOnly.ToString(format, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("fr-FR")]
        [InlineData("en-US")]
        [InlineData("de-DE")]
        [InlineData("es-ES")]
        [InlineData("ja-JP")]
        [InlineData("zh-CN")]
        [InlineData("ru-RU")]
        [InlineData("it-IT")]
        [InlineData("pt-BR")]
        [InlineData("ko-KR")]
        public void AbTest_ToString_WithCulture_OutputIsSame(string culture)
        {
            // Arrange
            LongDateOnly longDateOnly = new(0, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            var cultureInfo = CultureInfo.GetCultureInfo(culture);

            //Assert
            Assert.Equal(dateOnly.ToString(cultureInfo), longDateOnly.ToString(cultureInfo));
        }
        #endregion
    }
}