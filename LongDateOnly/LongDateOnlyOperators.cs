namespace LongDateOnlyLib
{
    public partial struct LongDateOnly : 
        IEquatable<DateOnly>,
        IComparable<DateOnly>
    {

        #region LongDateOnly to DateOnly operators
        public static bool operator ==(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return longDateOnly.Equals(dateOnly);
        }

        public static bool operator !=(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return !longDateOnly.Equals(dateOnly);
        }

        public static bool operator >(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return longDateOnly._dayNumber > dateOnly.DayNumber;
        }

        public static bool operator >=(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return longDateOnly._dayNumber >= dateOnly.DayNumber;
        }

        public static bool operator <(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return longDateOnly._dayNumber < dateOnly.DayNumber;
        }

        public static bool operator <=(LongDateOnly longDateOnly, DateOnly dateOnly)
        {
            return longDateOnly._dayNumber <= dateOnly.DayNumber;
        }

        public int CompareTo(DateOnly other)
        {
            return _dayNumber.CompareTo(other.DayNumber);
        }

        public bool Equals(DateOnly dateOnly)
        {
            return dateOnly.DayNumber == _dayNumber;
        }

        #endregion

        #region LongDateOnly to LongDateOnly operators
        public static bool operator ==(LongDateOnly left, LongDateOnly right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LongDateOnly left, LongDateOnly right)
        {
            return !left.Equals(right);
        }

        public static bool operator >(LongDateOnly left, LongDateOnly right)
        {
            return left._dayNumber > right.DayNumber;
        }

        public static bool operator >=(LongDateOnly left, LongDateOnly right)
        {
            return left._dayNumber >= right.DayNumber;
        }

        public static bool operator <(LongDateOnly left, LongDateOnly right)
        {
            return left._dayNumber < right.DayNumber;
        }

        public static bool operator <=(LongDateOnly left, LongDateOnly right)
        {
            return left._dayNumber <= right.DayNumber;
        }

        public bool Equals(LongDateOnly longDateOnly)
        {
            return longDateOnly.DayNumber == _dayNumber;
        }

        public int CompareTo(LongDateOnly other)
        {
            return _dayNumber.CompareTo(other.DayNumber);
        }

        #endregion
    }
}
