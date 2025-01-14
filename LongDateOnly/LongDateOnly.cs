using System.Diagnostics.CodeAnalysis;

namespace LongDateOnlyLib
{
    /// <summary>
    /// Represents dates with values ranging from January 1, 0001 Anno Domini (Common Era) with capacity for representing dates over the year 9999.
    /// </summary>
    public partial struct LongDateOnly : 
        IEquatable<DateOnly>,
        IComparable<DateOnly>
    {
        private long _dayNumber;

        // Maps to December 31 year 9999.
        private const int MaxDateOnlyDayNumber = 3_652_058;

        public int Decamillenium;
        private DateOnly _internalDateOnly;

        public readonly long DayNumber => _dayNumber;

        public readonly int Day => _internalDateOnly.Day;

        public readonly int Month => _internalDateOnly.Month;

        public readonly int Year => _internalDateOnly.Year;

        public readonly DayOfWeek DayOfWeek => _internalDateOnly.DayOfWeek;

        public readonly int DayOfYear => _internalDateOnly.DayOfYear;

        /// <summary>
        /// Gets the earliest possible date that can be created.
        /// </summary>
        public static LongDateOnly MinValue => new LongDateOnly(0, DateOnly.MinValue);

        /// <summary>
        /// Gets the latest possible date that can be created.
        /// </summary>
        public static LongDateOnly MaxValue => new LongDateOnly(int.MaxValue, DateOnly.MaxValue);

        /// <summary>
        /// Creates a new instance of the LongDateOnly structure to the specified decamillenium, year, month, and day.
        /// </summary>
        /// <param name="decamillenium">The year (0 through <see cref="Int32.MaxValue">MaxValue</see>).</param>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in <paramref name="month" />).</param>
        public LongDateOnly(int decamillenium, int year, int month, int day)
        {
            if (decamillenium < 0) throw new ArgumentException("Decamillenium value cannot be less than 0");
            Decamillenium = decamillenium;
            _internalDateOnly = new DateOnly(year, month, day);

            _dayNumber = (Decamillenium * MaxDateOnlyDayNumber) + _internalDateOnly.DayNumber;
        }

        private LongDateOnly(int decamillenium, DateOnly internalDate)
        {
            if (decamillenium < 0) throw new ArgumentException("Decamillenium value cannot be less than 0");
            Decamillenium = decamillenium;
            _internalDateOnly = internalDate;

            _dayNumber = (Decamillenium * MaxDateOnlyDayNumber) + _internalDateOnly.DayNumber;
        }

        private readonly string InsertDecamilleniumIntoString(string input)
        {
            if (Decamillenium > 0)
            {
                var yearString = _internalDateOnly.Year.ToString("0000");
                return input.Replace(yearString, $"{Decamillenium}{yearString}");
            }
            return input;
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the formatting conventions of the current culture.
        /// The LongDateOnly object will be formatted in short form.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the current LongDateOnly object.</returns>
        public override readonly string ToString()
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("d"));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent long date string representation.
        /// </summary>
        /// <returns>A string that contains the long date string representation of the current LongDateOnly object.</returns>
        public readonly string ToLongDateString()
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("D"));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent short date string representation.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the current LongDateOnly object.</returns>
        public readonly string ToShortDateString() {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString());
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified format and the formatting conventions of the current culture.
        /// </summary>
        /// <param name="format">A standard or custom date format string.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by format.</returns>
        public readonly string ToString([StringSyntax(StringSyntaxAttribute.DateOnlyFormat)] string? format) {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString(format, null));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by provider.</returns>
        public readonly string ToString(IFormatProvider? provider) {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("d", provider));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by format and provider.</returns>
        public readonly string ToString([StringSyntax(StringSyntaxAttribute.DateOnlyFormat)] string? format, IFormatProvider? provider)
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString(format, provider));
        }

        /// <summary>
        /// Adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="value">The number of days to add. To subtract days, specify a negative number.</param>
        /// <returns>An instance whose value is the sum of the date represented by this instance and the number of days represented by value.</returns>
        public readonly LongDateOnly AddDays(int value)
        {
            if (_internalDateOnly.DayNumber + value > MaxDateOnlyDayNumber)
            {
                var newDec = (int)Math.Floor((_internalDateOnly.DayNumber + (double)value) / MaxDateOnlyDayNumber);
                var remainingDays = _internalDateOnly.DayNumber + value - (newDec * MaxDateOnlyDayNumber);
                var newDate = DateOnly.MinValue.AddDays(remainingDays - 1);
                return new LongDateOnly(Decamillenium + newDec, newDate.Year, newDate.Month, newDate.Day);
            }
            else
            {
                return new LongDateOnly(Decamillenium, _internalDateOnly.AddDays(value));
            }
        }

        /// <summary>
        /// Adds the specified number of years to the value of this instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date represented by this instance and the number of years represented by value.</returns>
        public readonly LongDateOnly AddYears(int value)
        {
            var dec = 0;
            while (value >= 10000)
            {
                dec++;
                value -= 10000;
            }

            var currentYear = _internalDateOnly.Year;
            if (currentYear + value > 9999)
            {
                return new LongDateOnly(Decamillenium + dec, DateOnly.MinValue.AddYears(value - 9999 - currentYear));
            }
            return new LongDateOnly(Decamillenium + dec, _internalDateOnly.AddYears(value));
        }

        /// <summary>
        /// Adds the specified number of decamilleniums to the value of this instance.
        /// </summary>
        /// <param name="value">A number of decamilleniums. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date represented by this instance and the number of decamilleniums represented by value.</returns>
        public readonly LongDateOnly AddDecamillenium(int value)
        {
            if (Decamillenium + value < 0) { throw new ArgumentException("Cannot set decamillenium to be negative"); }
            return new LongDateOnly(Decamillenium + value, _internalDateOnly);
        }

        /// <summary>
        /// Returns a DateTime that is set to the date of this LongDateOnly instance and the time of specified input time.
        /// </summary>
        /// <param name="time">The time of the day.</param>
        /// <returns>The DateTime instance composed of the date of the current LongDateOnly instance and the time specified by the input time.</returns>
        public readonly DateTime ToDateTime(TimeOnly time)
        {
            if (Decamillenium > 0)
            {
                throw new ArgumentOutOfRangeException(time.ToString(), "Cannot convert LongDateOnly value to DateTime with decamillenium value greater than 0.");
            }
            return _internalDateOnly.ToDateTime(time);
        }

        /// <summary>
        /// Returns a DateTime instance with the specified input kind that is set to the date of this LongDateOnly instance and the time of specified input time.
        /// </summary>
        /// <param name="time">The time of the day.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time, Coordinated Universal Time (UTC), or neither.</param>
        /// <returns>The DateTime instance composed of the date of the current LongDateOnly instance and the time specified by the input time.</returns>
        public readonly DateTime ToDateTime(TimeOnly time, DateTimeKind kind)
        {
            if (Decamillenium > 0)
            {
            if (Decamillenium > 0)
                throw new ArgumentOutOfRangeException(Decamillenium.ToString(), "Cannot convert LongDateOnly value to DateTime with decamillenium value greater than 0.");
            }
            return _internalDateOnly.ToDateTime(time, kind);
        }

        /// <summary>
        /// Returns a LongDateOnly instance that is set to the date part of the specified dateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime instance.</param>
        /// <returns>The LongDateOnly instance composed of the date part of the specified input time dateTime instance.</returns>
        public static LongDateOnly FromDateTime(DateTime dateTime)
        {
            return new LongDateOnly(0, DateOnly.FromDateTime(dateTime));
        }
    }
}
