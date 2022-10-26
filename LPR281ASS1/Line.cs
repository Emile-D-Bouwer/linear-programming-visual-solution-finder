using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR281ASS1
{
    interface Line
    {
        Co_ordinate Intercept(Line l);

        bool Equals(Line l);

        double X_Intercept();
        double Y_Intercept();

        double X(double y);
        double Y(double x);
        void DetermineMaxIntercept(double maxX, double maxY);
        Co_ordinate MaxIntercept();
        double Incline();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>return = for equality operators, > for >=, < for <= </returns>
        char Operand();
    }
}
