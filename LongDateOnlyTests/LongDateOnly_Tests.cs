using System.Globalization;

namespace LongDateOnlyTests
{
    public class LongDateOnly_Tests
    {

        #region Days
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
            Assert.Equal("01/01/10001", date.ToString());
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
        #endregion Days

        #region Years
        [Fact]
        public void LongDateOnly_AddYears_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);
            var daysBefore = date.DayNumber;

            // Act
            date = date.AddYears(1);
            var daysAfter = date.DayNumber;

            // Assert
            Assert.Equal(daysBefore + 365, daysAfter);
        }

        [Fact]
        public void LongDateOnly_AddManyYears_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 1, 1, 1);

            // Act
            date = date.AddYears(50005);

            // Assert
            Assert.Equal(5, date.Decamillenium);
            Assert.Equal(1, date.Day);
        }

        #endregion

        #region Decamillenium
        [Fact]
        public void LongDateOnly_AddDecamillenium_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);

            // Act
            date = date.AddDecamillenium(1);

            // Assert
            Assert.Equal(1, date.Decamillenium);
        }

        [Fact]
        public void LongDateOnly_AddNegativeDecamillenium_ThrowsException()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);

            // Assert
            Assert.Throws<ArgumentException>(() => date.AddDecamillenium(-2024));
        }

        [Fact]
        public void LongDateOnly_AddManyDecamillenium_OutputIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);

            // Act
            date = date.AddDecamillenium(11234);

            // Assert
            Assert.Equal(11234, date.Decamillenium);
        }
        #endregion

        #region ToString tests

        [Fact]
        public void LongDateOnly_AddDecamillenium_ToStringIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);

            // Act
            date = date.AddDecamillenium(34);

            // Assert
            Assert.Equal("05/02/342023", date.ToString());
        }

        [Fact]
        public void LongDateOnly_AddDecamillenium_SetCulture_ToStringIsCorrect()
        {
            // Arrange
            LongDateOnly date = new(0, 2023, 2, 5);

            // Act
            date = date.AddDecamillenium(34);

            // Assert
            Assert.Equal("05/02/342023", date.ToString());
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
        [InlineData("ar-SA")]
        [InlineData("cs-CZ")]
        [InlineData("da-DK")]
        [InlineData("el-GR")]
        [InlineData("fi-FI")]
        [InlineData("he-IL")]
        [InlineData("hi-IN")]
        [InlineData("hu-HU")]
        [InlineData("id-ID")]
        [InlineData("ms-MY")]
        [InlineData("nb-NO")]
        [InlineData("nl-NL")]
        [InlineData("pl-PL")]
        [InlineData("ro-RO")]
        [InlineData("sk-SK")]
        [InlineData("sv-SE")]
        [InlineData("th-TH")]
        [InlineData("tr-TR")]
        [InlineData("uk-UA")]
        [InlineData("vi-VN")]
        [InlineData("bg-BG")]
        [InlineData("hr-HR")]
        [InlineData("lt-LT")]
        [InlineData("lv-LV")]
        [InlineData("et-EE")]
        [InlineData("sl-SI")]
        [InlineData("sr-SP")]
        [InlineData("is-IS")]
        [InlineData("mt-MT")]
        [InlineData("ga-IE")]
        [InlineData("cy-GB")]
        [InlineData("sq-AL")]
        [InlineData("mk-MK")]
        [InlineData("bs-BA")]
        [InlineData("az-Latn-AZ")]
        [InlineData("eu-ES")]
        [InlineData("gl-ES")]
        [InlineData("ca-ES")]
        [InlineData("af-ZA")]
        [InlineData("sw-KE")]
        [InlineData("zu-ZA")]
        [InlineData("xh-ZA")]
        [InlineData("tn-BW")]
        [InlineData("st-ZA")]
        [InlineData("ts-ZA")]
        [InlineData("ve-ZA")]
        [InlineData("nr-ZA")]
        public void LongDateOnly_ToString_WithCulture_SupportsLargeDecamilleniums(string culture)
        {
            // Arrange
            LongDateOnly longDateOnly = new(50, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Act
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            var dateOnlyString = dateOnly.ToString(cultureInfo);
            //replace 2023 with the new decamillenium-led year
            dateOnlyString = dateOnlyString.Replace("2023", "502023");
            var longDateOnlyString = longDateOnly.ToString(cultureInfo);

            //Assert
            Assert.Equal(dateOnlyString, longDateOnlyString);
        }

        [Theory]
        [InlineData("dd MM yyyy")]
        [InlineData("yyyy MM dd")]
        [InlineData("MM yyyy dd")]
        [InlineData("MM dd yyyy")]
        [InlineData("yyyy dd MM")]
        [InlineData("dd yyyy MM")]
        [InlineData("dd.MM.yyyy")]
        [InlineData("yyyy.MM.dd")]
        [InlineData("MM.yyyy.dd")]
        [InlineData("MM.dd.yyyy")]
        [InlineData("yyyy.dd.MM")]
        [InlineData("dd.yyyy.MM")]
        [InlineData("dd/MM/yyyy")]
        [InlineData("yyyy/MM/dd")]
        [InlineData("MM/yyyy/dd")]
        [InlineData("MM/dd/yyyy")]
        [InlineData("yyyy/dd/MM")]
        [InlineData("dd/yyyy/MM")]
        [InlineData("dd-MM-yyyy")]
        [InlineData("yyyy-MM-dd")]
        [InlineData("MM-yyyy-dd")]
        [InlineData("MM-dd-yyyy")]
        [InlineData("yyyy-dd-MM")]
        [InlineData("dd-yyyy-MM")]
        [InlineData("dd MMM yyyy")]
        [InlineData("yyyy MMM dd")]
        [InlineData("MMM yyyy dd")]
        [InlineData("MMM dd yyyy")]
        [InlineData("yyyy dd MMM")]
        [InlineData("dd yyyy MMM")]
        [InlineData("dd.MMM.yyyy")]
        [InlineData("yyyy.MMM.dd")]
        [InlineData("MMM.yyyy.dd")]
        [InlineData("MMM.dd.yyyy")]
        [InlineData("yyyy.dd.MMM")]
        [InlineData("dd.yyyy.MMM")]
        [InlineData("dd/MMM/yyyy")]
        [InlineData("yyyy/MMM/dd")]
        [InlineData("MMM/yyyy/dd")]
        [InlineData("MMM/dd/yyyy")]
        [InlineData("yyyy/dd/MMM")]
        [InlineData("dd/yyyy/MMM")]
        [InlineData("dd-MMM-yyyy")]
        [InlineData("yyyy-MMM-dd")]
        [InlineData("MMM-yyyy-dd")]
        [InlineData("MMM-dd-yyyy")]
        [InlineData("yyyy-dd-MMM")]
        [InlineData("dd-yyyy-MMM")]
        public void LongDateOnly_ToString_StringFormats_SupportsLargeDecamilleniums(string format)
        {
            // Arrange
            LongDateOnly longDateOnly = new(50, 2023, 2, 5);
            DateOnly dateOnly = new(2023, 2, 5);

            // Act
            var dateOnlyString = dateOnly.ToString(format, CultureInfo.InvariantCulture);
            dateOnlyString = dateOnlyString.Replace("2023", "502023");

            var longDateOnlyString = longDateOnly.ToString(format, CultureInfo.InvariantCulture);

            //Assert
            Assert.Equal(dateOnlyString, longDateOnlyString);
        }

        #endregion
    }
}