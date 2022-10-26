using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LPR281ASS1
{
    public partial class Form1 : Form
    {
        private List<Co_ordinate> corners = new List<Co_ordinate>();
        private List<Line> parameters = new List<Line>();
        private LinearFunction isoProfitLine;
        private double maxX, maxY, optimalZ, objectiveCx, objectiveCy;
        private List<double> optimalXs, optimalYs;
        private int areaSeriesIndex;
        private string objectiveType;
        bool alternativeDisplayed;

        public Form1()
        {
            InitializeComponent();

            //parameters.Add(new LinearFunction(-0.5, 20, '<'));
            //parameters.Add(new LinearFunction(-3, 30,'>'));
            //parameters.Add(new LinearFunction(-4/3, 20, '>'));
            ////parameters.Add(new LinearFunction(0, 5, '>'));
            ////parameters.Add(new Asymptote(5, '>'));
            //isoProfitLine = new LinearFunction(-2, 0, '>');//for the objective
            //                                               //function > will function
            //                                               //as MAX and < as MIN
            //objectiveCx = 20;
            //objectiveCy = 10;
            //objectiveType = "min";
        }

        /// <summary>
        /// Calulates the point used for charting two linear functions
        /// </summary>
        /// <param name="function1"></param>
        /// <param name="function2"></param>
        /// <returns>a boolean value that indicate whether or not the cornerpoint 
        /// falls within the first quadrant</returns>
        private void CalculateMaxMin()
        {
            maxY = 0.00; maxX = 0.00;
            foreach (Line param in parameters)
            {
                if (param.X_Intercept() > maxX)
                    maxX = param.X_Intercept();
                try//Members of Type Asymptote have no y-intercept
                {
                    if (param.Y_Intercept() > maxY)
                        maxY = param.Y_Intercept();
                }
                catch (Exception)
                {
                    //no exception handling needed.  This line symply won't be considered in
                    //determing the largest y-intercept.
                }
            }
            foreach (Co_ordinate corner in corners)
            {
                if (corner.X > maxX)
                {
                    maxX = corner.X;
                }
                if (corner.Y > maxY)
                {
                    maxY = corner.Y;
                }
            }
        }

        private void CalculateCorners()
        {
            Line lfA, lfB;
            for (int i = 0; i < parameters.Count() - 1; i++)
            {
                lfA = parameters[i];
                for (int j = i + 1; j < parameters.Count(); j++)
                {
                    lfB = parameters[j];
                    try
                    {
                        corners.Add(lfA.Intercept(lfB));
                    }
                    catch (Exception e)
                    {
                        //not necessary to handle exception as there simply won't be a
                        //co-ordinate to add to the list.
                    }
                }
            }
        }

        /// <summary>
        /// To plot the given line within the minimum and maximum dimensions of the chart
        /// </summary>
        /// <param name="line"></param>
        /// <param name="lineName"></param>
        private void PlotLine(Line line, string lineName)
        {
            try
            {
                chr1.Series.Add(lineName);
            }
            catch (Exception e)
            {
                chr1.Series.Add("Alt " + lineName);
            }
            int k = chr1.Series.Count() - 1;
            chr1.Series[k].ChartType = SeriesChartType.Line;
            //employing a pointer as below spares us the tedious task of specifying
            //chr1.Series[i].Points over and over.
            using (var pointer = chr1.Series[k].Points)
            {
                //a vertical asymptoto will only intercept the x-axis and the horizontal
                //maximum of the graph.
                if (line is Asymptote)
                {
                    pointer.AddXY(line.X_Intercept(), 0);
                    //this point should be taken into consideration when determining the 
                    //feasible area
                    corners.Add(new Co_ordinate(line.X_Intercept(), 0));
                    pointer.AddXY(line.MaxIntercept().X, line.MaxIntercept().Y);
                }
                //if the line is horizontal, it can only intercept the y-axis and the 
                //vertical maximum of the graph.
                else if (line.Incline() == 0)
                {
                    pointer.AddXY(0, line.Y_Intercept());
                    corners.Add(new Co_ordinate(0, line.Y_Intercept()));
                    pointer.AddXY(line.MaxIntercept().X, line.MaxIntercept().Y);
                }
                //if a function's x-intercept is (0;0) it's y-intercept is the same.
                //if it is ascending as well, it is bound to intercept the
                //vertical maximum perimeter of the of the graph in the 1st quadrant
                else if (line.X_Intercept() == 0 && line.Incline() > 0)
                {
                    pointer.AddXY(0, 0);
                    pointer.AddXY(line.MaxIntercept().X, line.MaxIntercept().Y);
                }
                //if both x and y intercepts are greater than the origin, they both fall
                //within the graph's boundaries
                else if (line.X_Intercept() > 0 && line.Y_Intercept() > 0)
                {
                    pointer.AddXY(line.X_Intercept(), 0);
                    corners.Add(new Co_ordinate(line.X_Intercept(), 0));
                    pointer.AddXY(0, line.Y_Intercept());
                    corners.Add(new Co_ordinate(0, line.Y_Intercept()));
                }
                //check for any other two points within the graph's parameters
                else if (line.MaxIntercept().InQuadrant(1) && line.X_Intercept() > 0 &&
                    line.X_Intercept() < maxX)
                {
                    pointer.AddXY(line.MaxIntercept().X, line.MaxIntercept().Y);
                    pointer.AddXY(line.X_Intercept(), 0);
                    corners.Add(new Co_ordinate(line.X_Intercept(), 0));
                }
                //check for any other two points within the graph's parameters
                else if (line.MaxIntercept().InQuadrant(1) && line.Y_Intercept() > 0 &&
                    line.Y_Intercept() < maxY)
                {
                    pointer.AddXY(line.MaxIntercept().X, line.MaxIntercept().Y);
                    pointer.AddXY(0, line.Y_Intercept());
                    corners.Add(new Co_ordinate(0, line.Y_Intercept()));
                }
                //if none of the above criteria is met, the paramater doesn't have 2
                //points to plot in the graph area.
            }
        }

        private void PlotLines()
        {
            chr1.Series.Clear();
            chr1.ChartAreas[0].AxisX.Minimum = 0;
            chr1.ChartAreas[0].AxisY.Minimum = 0;
            chr1.ChartAreas[0].AxisX.Maximum = maxX;
            chr1.ChartAreas[0].AxisY.Maximum = maxY;
            string paramName;

            int i = 0;
            int j = 1;
            foreach (Line param in parameters)
            {
                if (param is Asymptote  && param.X_Intercept() == 0)
                {
                    if (param.Operand() == '<')
                        paramName = "X<0";
                    else
                        paramName = "X>0";
                }
                else if (param.Incline() == 0 && param.Y_Intercept() == 0)
                {
                    if (param.Operand() == '<')
                        paramName = "Y<0";
                    else
                        paramName = "Y>0";
                }
                else
                {
                    paramName = "Constraint " + (j);
                    j++;
                }
                PlotLine(param, paramName);
                i++;
            }
            
            chr1.Series.Add("Corners");
            chr1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.
                SeriesChartType.Point;
            lblPoints.Text = "Corners";
            dgvPoints.Rows.Clear();
            foreach (Co_ordinate corner in corners)
            {
                chr1.Series[i].Points.AddXY(corner.X, corner.Y);
                dgvPoints.Rows.Add();
                dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[0].Value = corner.X;
                dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[1].Value = corner.Y;
            }
        }

        private void PlotArea()
        {
            chr1.Series.Add("Feasible Area");
            areaSeriesIndex = chr1.Series.Count() - 1;
            chr1.Series[areaSeriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.
                SeriesChartType.Range;
            //to create a set of all the unique x values in the collection.
            HashSet<double> uniqueXs = new HashSet<double>();
            foreach (Co_ordinate corner in corners)
                uniqueXs.Add(corner.X);

            //this is a neat trick to sort a hashSet.  Our x values will need to be in order for the
            //feasible area to display correctly.
            double[] xArr = uniqueXs.ToArray();
            Array.Sort(xArr);
            uniqueXs.Clear();
            uniqueXs.UnionWith(xArr);

            //to find the higest value permissible under the maximum parameters
            //and the lowest value permissible above the minimum parameters
            //at every (x) point on the graph where lines cross.
            double topY, bottomY;
            lblPoints.Text = "Feasible Points";
            dgvPoints.Rows.Clear();
            foreach (double x in uniqueXs)
            {
                topY = double.MaxValue;
                bottomY = double.MinValue;
                foreach (Line param in parameters)
                {
                    if (param is Asymptote) 
                    { //a vertical asymptote doesn't have a specific Y value
                      //but can instread be used to determine the x values that make up the feasible 
                      //area
                        if (param.Operand() == '<' && x > param.X(0))//the y-value substituted into
                                                                     //the function doesn't mater because they all return the same X value
                            uniqueXs.Remove(x);
                        else if (param.Operand() == '>' && x < param.X(0))
                            uniqueXs.Remove(x);
                        else if (param.Operand() == '=' && x != param.X(0))
                            uniqueXs.Remove(x);
                    }        
                    else
                    {
                        if (param.Operand() == '<' && topY > param.Y(x))
                            topY = param.Y(x);
                        else if (param.Operand() == '>' && bottomY < param.Y(x))
                            bottomY = param.Y(x);
                        else if (param.Operand() == '=' && (topY > param.Y(x) || bottomY < param.Y(x)))
                        {
                            topY = param.Y(x);
                            bottomY = topY;
                        }
                    }
                }

                // if the minimum parameters do not push the maximum parameters at this (x)point
                // the range between these parameters at this point can be added to the feasible
                // area
                if (topY >= bottomY) {
                    chr1.Series[areaSeriesIndex].Points.AddXY(x, bottomY, topY);
                    dgvPoints.Rows.Add();
                    dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[0].Value = x;
                    dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[1].Value = bottomY;
                    if (topY > bottomY)
                    {
                        dgvPoints.Rows.Add();
                        dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[0].Value = x;
                        dgvPoints.Rows[dgvPoints.RowCount - 1].Cells[1].Value = topY;
                    }                    
                }
            }
        }

        private void CalculateMaxIntercepts()
        {
            foreach (Line param in parameters)
            {
                param.DetermineMaxIntercept(maxX, maxY);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            corners = new List<Co_ordinate>();
            parameters = new List<Line>();
            chr1.Series.Clear();
            LoadLPFromFile();
            foreach (Line param in parameters)
            {
                if (param is LinearFunction)
                    rtx1.AppendText(string.Format("x{0} y{1} sign{2}\n", param.X_Intercept(), param.Y_Intercept(), param.Operand()));
                else
                    rtx1.AppendText(string.Format("x{0} sign{1}\n", param.X_Intercept(), param.Operand()));
            }
            btnLoad.Enabled = false;
            btnConstraints.Enabled = true;
            btnRefactor.Enabled = false;
            nudC1.Enabled = false;
            nudC2.Enabled = false;
            labC1.Visible = false;
            labC2.Visible = false;
            labOptimal.Visible = false;
            labType.Visible = false;
            labY.Visible = false;
            labZ.Visible = false;
            LabX.Visible = false;
            alternativeDisplayed = false;
        }

        /// <summary>
        /// To get the file path and formulate the lines for the graphical solution
        /// based on the formulation in the file.
        /// </summary>
        private void LoadLPFromFile()
        {
            string filePath;
            MyFileReader fr = null;
            OpenFileDialog fd = new OpenFileDialog();
            double x, m, c, y, rhs;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filePath = fd.FileName;
                fr = new MyFileReader(filePath);
            }
            try
            {
                //the values in the demo files are separated by spaces
                string[] wordsArr = fr.Lines[0].Split(' ');
                //the first argument int the first line (objective function ) will indicate whether this is a max or min problem
                objectiveType = wordsArr[0].ToLower();
                lblMinMax.Text = objectiveType.ToUpper();
                //the second argument will be the x coefficient
                objectiveCx = double.Parse(wordsArr[1]);
                lblCx.Text = objectiveCx.ToString();
                //the third argument will be the  y coefficient
                objectiveCy = double.Parse(wordsArr[2]);
                lblCy.Text = objectiveCy.ToString();
                //calculate start ISO profit line
                m = -(objectiveCx / objectiveCy);
                isoProfitLine = new LinearFunction(m, 0, '=');

                //the sign restrictions are in the last line of the file
                wordsArr = fr.Lines.Last().Split(' ');
                //the sign restriction for x will be in the first listed
                if (wordsArr[0] == "+")
                    //add an asymptote for x>=0
                    parameters.Add(new Asymptote(0, '>'));
                else if (wordsArr[1] == "-")
                    //add an asymptote for x<=0
                    parameters.Add(new Asymptote(0, '<'));
                //the only other falid option is URS for which no asymptotes need be added

                //the next sign restriction is for y
                if (wordsArr[1] == "+")
                    //horizontal asymptotes act like functions because they return a y value for every unique x value
                    parameters.Add(new LinearFunction(0, 0, '>'));
                else if (wordsArr[1] == "-")
                    parameters.Add(new LinearFunction(0, 0, '<'));

                for (int i = 1; i < fr.Lines.Count() - 1; i++)
                //this will only loop through the lines between the fist and last lines
                {
                    wordsArr = fr.Lines[i].Split(' ');
                    x = double.Parse(wordsArr[0]);
                    y = double.Parse(wordsArr[1]);
                    string sign = wordsArr[2];
                    rhs = double.Parse(wordsArr[3]);
                    dgvConstraints.Rows.Add();
                    dgvConstraints.Rows[i - 1].Cells[0].Value = x;
                    dgvConstraints.Rows[i - 1].Cells[1].Value = y;
                    dgvConstraints.Rows[i - 1].Cells[2].Value = sign;
                    dgvConstraints.Rows[i - 1].Cells[3].Value = rhs;

                    if (y == 0)
                    {
                        if (sign == "<=")
                            parameters.Add(new Asymptote(x, '<'));
                        else if (sign == ">=")
                            parameters.Add(new Asymptote(x, '>'));
                        else
                            parameters.Add(new Asymptote(x, '='));
                    }
                    else if (x == 0)
                    {
                        //horizontal asymptotes still function like linear functions with 0 incline
                        if (sign == "<=")
                            parameters.Add(new LinearFunction(0, x, '<'));
                        else if (sign == ">=")
                            parameters.Add(new LinearFunction(0, x, '>'));
                        else
                            parameters.Add(new LinearFunction(0, x, '='));
                    }
                    else
                    {
                        //isolate y to make a linear function
                        c = rhs / y;
                        m = -(x / y);
                        if (sign == "<=")
                            parameters.Add(new LinearFunction(m, c, '<'));
                        else if (sign == ">=")
                            parameters.Add(new LinearFunction(m, c, '>'));
                        else
                            parameters.Add(new LinearFunction(m, c, '='));
                    }
                dgvConstraints.Refresh();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("The LP couldn't be sucessfully loaded.  The following error was encountered: " + error.Message +
                    ". Please ensure that your file is in the correct format.", "File Error Encountered");
            }
}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRefactor_Click(object sender, EventArgs e)
        {
            objectiveCx = decimal.ToDouble(nudC1.Value);
            objectiveCy = decimal.ToDouble(nudC2.Value);
            double m = -(objectiveCx / objectiveCy);
            isoProfitLine = new LinearFunction(m, 0, '=');
            if (alternativeDisplayed)
            {
                //if an alternative ISO is already displayed, remove it sothat the new alternative
                //can be displayed.
                chr1.Series.RemoveAt(chr1.Series.Count() - 1);
            }
            PlotISOProfitLine();
            labC1.Visible = true;
            labC1.Text = objectiveCx.ToString();
            labC2.Text = objectiveCy.ToString();
            labC2.Visible = true;
            labOptimal.Visible = true;
            labOptimal.Text = optimalZ.ToString();
            labType.Visible = true;
            labType.Text = lblMinMax.Text;
            labY.Visible = true;
            labZ.Visible = true;
            LabX.Visible = true;
            alternativeDisplayed = true;
        }

        /// <summary>
        /// To calculate what the value of the objective function would be at a specific point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double ZAt(double x, double y)
        {
            return x * objectiveCx + y * objectiveCy;
        }

        private void PlotISOProfitLine()
        {
            optimalXs = new List<double>();
            optimalYs = new List<double>();
            double x, y;
            //to assign the first point in the feasible area to the optimal solution
            optimalXs.Add(chr1.Series[areaSeriesIndex].Points[0].XValue);
            optimalYs.Add(chr1.Series[areaSeriesIndex].Points[0].YValues[0]);
            optimalZ = ZAt(optimalXs[0], optimalYs[0]);
            for (int i = 1; i < chr1.Series[areaSeriesIndex].Points.Count(); i++)
            {
                x = chr1.Series[areaSeriesIndex].Points[i].XValue;
                if (objectiveType == "min")
                {
                    //the smallest y value for that part of the range is stored in the first position
                    y = chr1.Series[areaSeriesIndex].Points[i].YValues[0];
                    //if the value at the new point is smaller than the MinZ at the last point, update to new point
                    if (ZAt(x, y) < optimalZ)
                    {
                        optimalZ = ZAt(x, y);
                        optimalXs[0] = x;
                        optimalYs[0] = y;
                    }
                    //if the values are equal, the new point gets added to the collections of opitmal points
                    else if (ZAt(x, y) == optimalZ)
                    {
                        optimalXs.Add(x);
                        optimalYs.Add(y);
                    }
                }
                else
                {
                    y = chr1.Series[areaSeriesIndex].Points[i].YValues[1];
                    if (ZAt(x, y) > optimalZ)
                    {
                        optimalZ = ZAt(x, y);
                        optimalXs[0] = x;
                        optimalYs[0] = y;
                    }
                    else if (ZAt(x, y) == optimalZ)
                    {
                        optimalXs.Add(x);
                        optimalYs.Add(y);
                    }
                }
            }
            //only if there is more than one optimal point listed
            if (optimalYs.Count() > 1)
            {
                int i = optimalYs.Count() - 1;
                do
                {
                    //the largest/smallest Z will be stored in this variable
                    //depending whether the objective function is min/max
                    //any other value will be sub-optimal and its coresponding point can be removed
                    if (ZAt(optimalXs[i], optimalYs[i]) != optimalZ)
                    {
                        optimalYs.RemoveAt(i);
                        optimalYs.RemoveAt(i);
                    }
                    i--;
                } while (i > 0);
            }
            lblPoints.Text = "Optimal Points";
            dgvPoints.Rows.Clear();
            for (int i = 0; i < optimalYs.Count(); i++)
            {
                dgvPoints.Rows.Add();
                dgvPoints.Rows[i].Cells[0].Value = optimalXs[i];
                dgvPoints.Rows[i].Cells[1].Value = optimalYs[i];
            }
            //this determines the Y value at which the ISO will be for the optimal x value before adjusting it to 
            //cut the optimal point
            double deltaY, ogY = isoProfitLine.Y(optimalXs[0]);
            //to calculate by how much the height of the ISO profit line must be adjusted to meet cut the optimal point
            deltaY = optimalYs[0] - ogY;
            //create new adjusted ISO profit line
            isoProfitLine = new LinearFunction(isoProfitLine.Incline(), deltaY, isoProfitLine.Operand());
            rtx1.AppendText(String.Format("iso x:{0} y:{1} m:{2}", isoProfitLine.X_Intercept(), isoProfitLine.
                Y_Intercept(), isoProfitLine.Incline()));
            PlotLine(isoProfitLine, "ISO");
            ////to give the ISO profit line a dashed appearance.
            chr1.Series.Last().BorderDashStyle = ChartDashStyle.Dash;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlotArea();
            if (chr1.Series[areaSeriesIndex].Points.Count() == 0)
            {
                MessageBox.Show("This LP has no feasible area and is therefore infeasible.");
                btnLoad.Enabled = true;
            }
            else
                btnSolve.Enabled = true;
            btnArea.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlotISOProfitLine();
            lblOptimalZ.Text = optimalZ.ToString();
            btnSolve.Enabled = false;
            btnLoad.Enabled = true;
            btnRefactor.Enabled = true;
            nudC1.Enabled = true;
            nudC1.Value = decimal.Parse(objectiveCx.ToString());
            nudC2.Enabled = true;
            nudC2.Value = decimal.Parse(objectiveCy.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateCorners();
            CalculateMaxMin();
            CalculateMaxIntercepts();
            PlotLines();
            btnConstraints.Enabled = false;
            btnArea.Enabled = true;
        }
    }
}
