using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR281ASS1
{
    internal class Asymptote : Line
    {
        private double x;
        public char operand;
        private Co_ordinate maxIntercept;

        public Asymptote(double x, char operand)
        {
            this.x = x;
            this.operand = operand;
        }

        public bool Equals(Line l)
        {
            if (l is Asymptote && l.X_Intercept() == x)
                return true;
            else
                return false;
        }

        public Co_ordinate Intercept(Line l)
        {
            if (l is Asymptote)
                throw new ExecutionEngineException("These lines are parallel");
            else
                return new Co_ordinate(x, l.Y(x));
        }

        public double X_Intercept()
        {
            return x;
        }

        public double Y_Intercept()
        {
            throw new NotImplementedException();
        }

        public double X(double y)
        {
            return x;
        }

        public double Y(double x)
        {
            throw new NotImplementedException();
        }

        public void DetermineMaxIntercept(double maxX, double maxY)
        {
            if (x >= 0)
                maxIntercept = new Co_ordinate(x, maxY);
            //if the x value of the asymptote is smaller than 0 it's not in the first quadrant
        }

        public Co_ordinate MaxIntercept()
        {
            return maxIntercept;
        }

        public double Incline()
        {
            throw new NotImplementedException();
        }

        public char Operand()
        {
            return this.operand;
        }
    }
}
