using System;
using System.Threading;
using static System.Math;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public double Modulus => Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);

        public override string ToString() => this.Imaginary > 0 ? "" + this.Real + " +" + this.Imaginary + "i" : "" + this.Real + " " + this.Imaginary + "i";

        private bool Equals(Complex other) => Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            
            return Equals((Complex) obj);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public Complex Plus(Complex other) => new Complex(this.Real + other.Real, this.Imaginary + other.Imaginary);

        public Complex Minus(Complex other) => new Complex(this.Real - other.Real, this.Imaginary - other.Imaginary);

        public Complex Complement() => new Complex(this.Real, -this.Imaginary);
        
        public double Phase
        {
            get
            {
                if (Real.Equals(0))
                {
                    if (Imaginary.Equals(0))
                    {
                        return 0;
                    }
                    
                    if (Imaginary > 0)
                    {
                        return PI / 2;
                    }
                
                    return 3 * PI / 2;
                }

                if (Real > 0)
                {
                    if (Imaginary >= 0)
                    {
                        return Atan(Imaginary / Real);
                    }
                    
                    return Atan(Imaginary / Real) + 2 * PI;
                }

                return Atan(Imaginary / Real) + PI;
            }
        }
    }
}