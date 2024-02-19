using System.Diagnostics.CodeAnalysis;

namespace LongDateOnlyLib
{
    public partial struct LongDateOnly : 
        IEquatable<DateOnly>,
        IComparable<DateOnly>
    {
        private long _dayNumber;
        private const int MaxDateOnlyDayNumber = 3_652_058;

        public int Decamillenium;
        private DateOnly _internalDateOnly;

        public long DayNumber { get { return _dayNumber; } }

        public int Day { get { return _internalDateOnly.Day; } }

        public int Month { get { return _internalDateOnly.Month; } }

        public int Year { get { return _internalDateOnly.Year; } }

        public DayOfWeek DayOfWeek => _internalDateOnly.DayOfWeek;

        public int DayOfYear => _internalDateOnly.DayOfYear;

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

        private string InsertDecamilleniumIntoString(string input)
        {
            string returnString = string.Empty;
            if (Decamillenium > 0) {
                var split = input.Split('/');
                var q = _internalDateOnly.Year.ToString("0000");
                foreach (var item in split)
                {
                    if (item == q)
                    {
                        var newItem = $"{Decamillenium}{item}";
                        returnString += newItem + '/';

                    }
                    else
                    {
                        returnString += item + '/';
                    }
                }
                return returnString.TrimEnd('/');
            }
            return input;
            
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the formatting conventions of the current culture.
        /// The LongDateOnly object will be formatted in short form.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the current LongDateOnly object.</returns>
        public override string ToString()
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("d"));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent long date string representation.
        /// </summary>
        /// <returns>A string that contains the long date string representation of the current LongDateOnly object.</returns>
        public string ToLongDateString()
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("D"));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent short date string representation.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the current LongDateOnly object.</returns>
        public string ToShortDateString() {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString());
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified format and the formatting conventions of the current culture.
        /// </summary>
        /// <param name="format">A standard or custom date format string.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by format.</returns>
        public string ToString([StringSyntax(StringSyntaxAttribute.DateOnlyFormat)] string? format) {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString(format, null));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by provider.</returns>
        public string ToString(IFormatProvider? provider) {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString("d", provider));
        }

        /// <summary>
        /// Converts the value of the current LongDateOnly object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current LongDateOnly object as specified by format and provider.</returns>
        public string ToString([StringSyntax(StringSyntaxAttribute.DateOnlyFormat)] string? format, IFormatProvider? provider)
        {
            return InsertDecamilleniumIntoString(_internalDateOnly.ToString(format, provider));
        }

        public LongDateOnly AddDays(int value)
        {
            if (_internalDateOnly.DayNumber + value > MaxDateOnlyDayNumber)
            {
                var newDec = (int)Math.Floor((_internalDateOnly.DayNumber + (double)value) / MaxDateOnlyDayNumber);
                var remainingDays = (_internalDateOnly.DayNumber + value) - (newDec * MaxDateOnlyDayNumber);
                var newDate = DateOnly.MinValue.AddDays(remainingDays - 1);
                return new LongDateOnly(Decamillenium + newDec, newDate.Year, newDate.Month, newDate.Day);
            }
            else
            {
                return new LongDateOnly(Decamillenium, _internalDateOnly.AddDays(value));
            }
        }

        public LongDateOnly AddYears(int value)
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
                new LongDateOnly(Decamillenium + dec, DateOnly.MinValue.AddYears(value - 9999 - currentYear));
            }
            return new LongDateOnly(Decamillenium + dec, _internalDateOnly.AddYears(value));
        }

        public LongDateOnly AddDecamillenium(int value)
        {
            return new LongDateOnly(Decamillenium + value, _internalDateOnly);
        }

        public DateTime ToDateTime(TimeOnly time)
        {
            if (Decamillenium > 0)
            {
                throw new ArgumentOutOfRangeException("Cannot convert LongDateOnly value to DateTime with decamillenium value greater than 0.");
            }
            return _internalDateOnly.ToDateTime(time);
        }

        public DateTime ToDateTime(TimeOnly time, DateTimeKind kind)
        {
            if (Decamillenium > 0)
            {
                throw new ArgumentOutOfRangeException("Cannot convert LongDateOnly value to DateTime with decamillenium value greater than 0.");
            }
            return _internalDateOnly.ToDateTime(time, kind);
        }

        public static LongDateOnly FromDateTime(DateTime dateTime)
        {
            return new LongDateOnly(0, DateOnly.FromDateTime(dateTime));
        }
    }
}
