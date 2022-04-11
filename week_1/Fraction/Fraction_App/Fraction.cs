using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction_App
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override int GetHashCode()
        {
            return Numerator / Denominator;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Fraction))
                return false;
            else
                return Numerator / Denominator == ((Fraction)obj).Numerator / ((Fraction)obj).Denominator;
        }

        public int Sum(int secondNumerator, int secondDenominator)
        {
            return Numerator / Denominator + secondNumerator / secondDenominator;
        }

        public int Difference(int secondNumerator, int secondDenominator)
        {
            return Numerator / Denominator - secondNumerator / secondDenominator;
        }

        public int Multiply(int secondNumerator, int secondDenominator)
        {
            return Numerator / Denominator * secondNumerator / secondDenominator;
        }

        public int Division(int secondNumerator, int secondDenominator)
        {
            return (Numerator / Denominator) / (secondNumerator / secondDenominator);
        }

        public double ConvertIntToDouble()
        {
            return Numerator / Denominator;
        }
    }
}
