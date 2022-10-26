using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR281ASS1
{
    internal class LinearFunction : Line
    {
        private double m;
        private double c;
        private double x_intercept;
        private double y_intercept;
        private Co_ordinate maxIntercept;
        private char operand;

        public char IsMax
        {
            get { return operand; }
            set { operand = value; }
        }

        public double Y_Intercept()
        {
            return y_intercept;
        }

        public double X_Intercept()
        {
            return x_intercept;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="c"></param>
        /// <param name="operand">= for equality, > for >=, < for <= </param>
        public LinearFunction(double m, double c, char operand)
        {
            this.m = m;
            this.c = c;
            this.operand = operand;
            this.y_intercept = this.Y(0);
            if (m != 0)
                this.x_intercept = this.X(0);
            //x_ and y-intercepts calculated once uppon creation for performance and
            //convenience as these co-ordinates will be frequently referrenced.
        }

        /// <summary>
        /// Returns the y output of the function for the given x value
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Y(double x)
        {
            return x * this.m + this.c;
        }

        /// <summary>
        /// Returns the x value of the function that would yield the supplied y output
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public double X(double y)
        {
            if (m == 0)
                throw new Exception("this line is horizontal");
            else
                return (y - c) / m;
        }

        /// <summary>
        /// Returns the x value at which the functions intercept
        /// </summary>
        /// <param name="lf"></param>
        /// <returns></returns>
        public Co_ordinate Intercept(Line l)
        {
            if (l is Asymptote)
                return new Co_ordinate(l.X_Intercept(), Y(l.X_Intercept()));
            else if (this.Equals(l))
                throw new Exception("These functions are parallel.");
            else
            {
                LinearFunction lf = (LinearFunction)l;
                double x, y, n = lf.m;
                double d = lf.c;
                x = (c - d) / (n - m);
                y = this.Y(x);
                return new Co_ordinate(x, y);
            }
        }

        public bool Equals(Line l)
        {
            if (l is Asymptote)
                return false;
            else
            {
                LinearFunction lf = (LinearFunction)l;
                if (this.m == lf.m && this.c == lf.c)
                    return true;
                else
                    return false;
            }
        }

        public void DetermineMaxIntercept(double maxX, double maxY)
        {
            if (Y(maxX) <= maxY && Y(maxX) >= 0)
                maxIntercept = new Co_ordinate(maxX, Y(maxX));
            else if (X(maxY) <= maxX && X(maxY) >= 0)
                maxIntercept = new Co_ordinate(X(maxY), maxY);
            //if neither criteria is met, the parameter doesn't intercept with the outer
            //boundaries of the graph within the first quadrant.
        }

        public Co_ordinate MaxIntercept()
        {
            return maxIntercept;
        }

        public double Incline()
        {
            return this.m;
        }

        public char Operand()
        {
            return this.operand;
        }
    }
}
