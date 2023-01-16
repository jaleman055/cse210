using System;

namespace Learning03
{
    class Fraction
    {
        private int top;
        private int bottom;

        public Fraction()
        {
            top = 1;
            bottom = 1;
        }

        public Fraction(int top)
        {
            this.top = top;
            bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            this.top = top;
            this.bottom = bottom;
        }

        public int GetTop()
        {
            return top;
        }

        public int GetBottom()
        {
            return bottom;
        }
    
        public string GetFractionString()
        {
            return top + "/" + bottom;
        }

        public double GetDecimalValue()
        {
            return (double)top / bottom;
        }
    }
}

