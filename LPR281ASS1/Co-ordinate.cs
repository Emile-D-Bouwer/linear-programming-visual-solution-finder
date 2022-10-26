using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR281ASS1
{
    internal class Co_ordinate
    {
        private double x;
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public Co_ordinate(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Co_ordinate co)
        {
            if (this.x == co.x && this.y == co.y)
                return true;
            else
                return false;
        }

        public bool Equals(double x, double y)
        {
            if (this.x == x && this.y == y)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the co-ordinate falls in the specified quadrant
        /// </summary>
        /// <param name="quadrant">integer responding to number of quadrant in question</param>
        /// <returns>if number of quadrant N/A (outside 1-4) returns false by defautl</returns>
        public bool InQuadrant(int quadrant)
        {
            switch (quadrant)
            {
                case 1:
                    if (x >= 0 && y >= 0)
                        return true;
                    break;
                case 2:
                    if (x <= 0 && y >= 0)
                        return true;
                    break;
                case 3:
                    if (x <= 0 && y <= 0)
                        return true;
                    break;
                case 4:
                    if (x >= 0 && y <= 0)
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

    }
}
