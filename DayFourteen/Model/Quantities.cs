using System;

namespace DayFourteen.Model
{
    public struct Quantities : IEquatable<Quantities>
    {
        public long Consumed { get; set; }
        public long Remaining { get; set; }

        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Quantities)obj).GetHashCode();
        }

        public bool Equals(Quantities other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = 13; //(int) 2166136261
                const int HashingMultiplier = 7; //16777619

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Consumed.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Remaining.GetHashCode();

                return hash;
            }
        }

        public static bool operator ==(Quantities left, Quantities right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quantities left, Quantities right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Consumed: {Consumed}; Reamining: {Remaining}";
        }
    }
}
