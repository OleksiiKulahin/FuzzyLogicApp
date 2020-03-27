using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ОНЛ_5
{
    public partial class ModelingOfFuzzyNumbersWithFunctions : Form
    {
        public ModelingOfFuzzyNumbersWithFunctions()
        {
            InitializeComponent();
        }

        double parameter1, parameter2, parameter3, parameter4;
        string endl = Environment.NewLine;
        Color LightGreen = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
        Color LightRed = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
        Color DefaultBoxColor = Color.White;
        Color DefaultGroupColor = SystemColors.Control;
        int offsetX = 30;
        int offsetY = 30;
        double coefficient = 1;
        bool graphicIsPrinted = false;

        private void CloseAdditionalFields()
        {
            textBoxParameter1.Visible = textBoxParameter2.Visible = textBoxParameter3.Visible= textBoxParameter4.Visible =buttonRecommendations.Visible= false;
            labelParameter1.Visible = labelParameter2.Visible = labelParameter3.Visible= labelParameter4.Visible =false;
            textBoxInputX.Enabled = textBoxResultX.Enabled = buttonFindY.Enabled =numericUpDownScale.Enabled= false;
            textBoxInputX.BackColor = textBoxResultX.BackColor = DefaultBoxColor;
            textBoxParameter1.Text = textBoxParameter2.Text = textBoxParameter3.Text = textBoxParameter4.Text =textBoxResultX.Text="";
        }
        private bool ParametersAreRight(string _parameter1, string _parameter2, string _parameter3, string _parameter4)
        {
            bool result = true;
            if (!(double.TryParse(_parameter1, out double resultParameter1)
                && double.TryParse(_parameter2, out double resultParameter2)
                && double.TryParse(_parameter3, out double resultParameter3)
                && double.TryParse(_parameter4, out double resultParameter4)))
            {
                result = false;
                richTextBoxLog.Text += "Помилка: Невірно задані дані" + endl;
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor =LightRed;
            }
            else
            {
                parameter1 = Convert.ToDouble(_parameter1);
                parameter2 = Convert.ToDouble(_parameter2);
                parameter3 = Convert.ToDouble(_parameter3);
                parameter4 = Convert.ToDouble(_parameter4);
                if (comboBoxFunctions.SelectedIndex ==2)
                {
                    if (parameter2<=0)
                    {
                        result = false;
                        richTextBoxLog.Text += "Помилка: d<=0" + endl;
                        textBoxParameter2.BackColor = LightRed;
                    }
                }
                if (comboBoxFunctions.SelectedIndex == 3)
                {
                    if (parameter1 <= 0)
                    {
                        result = false;
                        richTextBoxLog.Text += "Помилка: b<=0" + endl;
                        textBoxParameter1.BackColor = LightRed;
                    }
                }
            }
            return result;
        }
        private void PrintGraphic()
        {
            graphicIsPrinted = true;
            Graphics graphicMain = pictureBoxGraphic.CreateGraphics();
            graphicMain.Clear(Color.White);
            Pen penCountur = new Pen(Color.Black, 3);
            Pen penAdditional = new Pen(Color.Gray, 1);
            Pen penDotted = new Pen(Color.Gray, 1);
            penDotted.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            int graphicWidth = pictureBoxGraphic.Size.Width;
            int graphicHeight = pictureBoxGraphic.Size.Height;
            int diffX = graphicWidth - offsetX * 2;
            int diffY = graphicHeight - offsetY * 2;
            Font drawFontValue = new Font("Arial", 10);
            Font drawFontValueBold = new Font("Arial", 10,FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            PrintLegend(penCountur, penDotted, penAdditional,graphicMain, drawFontValue,drawFontValueBold, drawBrush, drawFormat);
            PrintFunction(penCountur, penDotted, graphicMain, drawFontValueBold, drawBrush, drawFormat,diffX, diffY);
            if (double.TryParse(textBoxInputX.Text, out double resultParameter1))
            {
                buttonFindY_Click(new object(), new EventArgs());
            }
        }
        private int FindY(double x, double parameter1, double parameter2, double parameter3, double parameter4, int diffX,int diffY,double scale)
        {
            int y = 0;
            if (comboBoxFunctions.SelectedIndex == 0) y = Convert.ToInt32(Math.Round(1 / (1 + Math.Exp((-parameter1 / scale) * (x - (scale * parameter2) - diffX / 2))), 15) * diffY);
            if (comboBoxFunctions.SelectedIndex == 1) y = Convert.ToInt32(Math.Round(((1 / (1 + Math.Exp((-parameter1 / scale) * (x - (scale * parameter3) - diffX / 2)))) - (1 / (1 + Math.Exp((-parameter2 / scale) * (x - (scale * parameter4) - diffX / 2))))), 15) * diffY);
            if (comboBoxFunctions.SelectedIndex == 2) y = Convert.ToInt32(Math.Round(Math.Exp(-1 * ((Math.Abs(x - parameter1 * scale - diffX / 2)) / (parameter2 * scale))), 15) * diffY);
            if (comboBoxFunctions.SelectedIndex == 3) y = Convert.ToInt32(Math.Round(Math.Exp(-1 * ((Math.Pow((x - parameter2*scale - diffX/2), 2)) / (2 * Math.Pow(parameter1*scale, 2)))), 15) * diffY);

            return y;
        }
        private void PrintFunction(Pen penCountur,Pen penDotted, Graphics graphicMain, Font drawFontValueBold, SolidBrush drawBrush, StringFormat drawFormat,int diffX, int diffY)
        {
            int x = 0;
            Point[] points = new Point[diffX];
            double scaleX = diffX / (coefficient * 10);
            double parameter1, parameter2, parameter3, parameter4;
            if (comboBoxFunctions.SelectedIndex == 0)
            {
                parameter1 = Convert.ToDouble(textBoxParameter1.Text);//a parameter1
                parameter2 = Convert.ToDouble(textBoxParameter2.Text);//c parameter2
                for (x = 0; x < diffX; x++)
                {
                    points[x] = new Point(x + offsetX, diffY - FindY(Convert.ToDouble(x), parameter1, parameter2,0,0, diffX,diffY,scaleX) + offsetY);
                }
            }
            if (comboBoxFunctions.SelectedIndex == 1)
            {
                parameter1 = Convert.ToDouble(textBoxParameter1.Text);//a1 parameter1
                parameter2 = Convert.ToDouble(textBoxParameter2.Text);//a2 parameter2
                parameter3 = Convert.ToDouble(textBoxParameter3.Text);//c1 parameter3
                parameter4 = Convert.ToDouble(textBoxParameter4.Text);//c2 parameter4
                for (x = 0; x < diffX; x++)
                {
                    if(parameter3<= parameter4) points[x] = new Point(x + offsetX, diffY - FindY(Convert.ToDouble(x), parameter1, parameter2, parameter3, parameter4, diffX, diffY, scaleX) + offsetY);
                    if (parameter3 > parameter4) points[x] = new Point(x + offsetX, diffY - FindY(Convert.ToDouble(x), parameter2, parameter1, parameter4, parameter3, diffX, diffY, scaleX) + offsetY);
                }
                if (!(parameter3 <= parameter4)) richTextBoxLog.Text += "Увага. Параметр с1 > c2. Програма поміняла місцями а1 та а2, с1 та с2"+endl;
                if (parameter1<=0 || parameter2<=0) richTextBoxLog.Text += "Увага. Параметр а1<=0 або а2<=0. Можливі огріхи"+endl;
            }
            if (comboBoxFunctions.SelectedIndex == 2)
            {
                parameter1 = Convert.ToDouble(textBoxParameter1.Text);//b parameter1
                parameter2 = Convert.ToDouble(textBoxParameter2.Text); //d parameter2
                for (x = 0; x < diffX; x++)
                {
                    points[x] = new Point(x + offsetX, diffY - FindY(Convert.ToDouble(x), parameter1, parameter2, 0, 0, diffX, diffY, scaleX) + offsetY);
                }
                graphicMain.DrawLine(penDotted, new Point(Convert.ToInt32(parameter1 * scaleX + diffX / 2 + offsetX), offsetY + diffY + 10), new Point(Convert.ToInt32(parameter1 * scaleX + diffX / 2 + offsetX), offsetY));
                graphicMain.DrawString("b", drawFontValueBold, drawBrush, Convert.ToInt32(parameter1 * scaleX + diffX / 2 + offsetX - 4), offsetY + diffY + 16, drawFormat);
            }
            if (comboBoxFunctions.SelectedIndex == 3)
            {
                parameter1 = Convert.ToDouble(textBoxParameter1.Text);//b parameter1
                parameter2 = Convert.ToDouble(textBoxParameter2.Text); //c parameter2
                for (x = 0; x < diffX; x++)
                {
                    points[x] = new Point(x + offsetX, diffY - FindY(Convert.ToDouble(x), parameter1, parameter2, 0, 0, diffX, diffY, scaleX) + offsetY);
                }
                graphicMain.DrawLine(penDotted, new Point(Convert.ToInt32(parameter2 * scaleX + diffX / 2 + offsetX), offsetY + diffY + 10), new Point(Convert.ToInt32(parameter2 * scaleX + diffX / 2 + offsetX), offsetY));
                graphicMain.DrawString("c", drawFontValueBold, drawBrush, Convert.ToInt32(parameter2 * scaleX + diffX / 2 + offsetX - 4), offsetY + diffY + 16, drawFormat);
            }
            graphicMain.DrawCurve(penCountur, points);

        }
        private void PrintLegend(Pen penCountur, Pen penDotted, Pen penAdditional, Graphics graphicMain, Font drawFontValue,Font drawFontValueBold, SolidBrush drawBrush, StringFormat drawFormat)
        {
            int graphicWidth = pictureBoxGraphic.Size.Width;
            int graphicHeight = pictureBoxGraphic.Size.Height;
            int diffX = graphicWidth - offsetX * 2;
            int diffY = graphicHeight - offsetY * 2;
            double markerIntervalX = Convert.ToDouble(diffX) / 10;
            double markerIntervalY = Convert.ToDouble(diffY) / 10;
            for (int i = -5, j = 0; i < 11; i++, j++)
            {
                graphicMain.DrawString((i * coefficient).ToString(), drawFontValue, drawBrush, offsetX - 5 + Convert.ToInt32(j * markerIntervalX), graphicHeight - offsetY + 5, drawFormat);
                graphicMain.DrawLine(penAdditional, new Point(offsetX + Convert.ToInt32(j * markerIntervalX), graphicHeight - offsetY - 5), new Point(offsetX + Convert.ToInt32(j * markerIntervalX), graphicHeight - offsetY + 5));
            }
            for (int i = 1; i <= 9; i++)
            {
                //graphicMain.DrawString((Convert.ToDouble(i) / 10).ToString(), drawFontValue, drawBrush, offsetX - 30 + diffX/2, graphicHeight-offsetY-7 - Convert.ToInt32(i * markerIntervalY), drawFormat);
                graphicMain.DrawLine(penAdditional, new Point(offsetX - 5 + diffX / 2, offsetY + Convert.ToInt32(i * markerIntervalY)), new Point(offsetX + 5 + diffX / 2, offsetY + Convert.ToInt32(i * markerIntervalY)));
            }
            graphicMain.DrawString("0,1", drawFontValue, drawBrush, offsetX - 30 + diffX / 2, graphicHeight - offsetY - 7 - Convert.ToInt32(1 * markerIntervalY), drawFormat);
            graphicMain.DrawString("μ(x)  1", drawFontValueBold, drawBrush, offsetX - 37 + diffX / 2, offsetY - 15, drawFormat);
            graphicMain.DrawString("x", drawFontValueBold, drawBrush, offsetX + diffX + 2, offsetY + diffY - 10, drawFormat);

            graphicMain.DrawLine(penAdditional, new Point(offsetX, graphicHeight - offsetY), new Point(graphicWidth - offsetX, graphicHeight - offsetY));
            graphicMain.DrawLine(penAdditional, new Point(offsetX + diffX / 2, graphicHeight - offsetY), new Point(offsetX + diffX / 2, offsetY));
            graphicMain.DrawLine(penDotted, new Point(offsetX, offsetY), new Point(graphicWidth - offsetX, offsetY));
            graphicMain.DrawLine(penDotted, new Point(offsetX, offsetY + diffY / 2), new Point(graphicWidth - offsetX, offsetY + diffY / 2));
        }
        private void PrintY(double x, double y,int diffX,int diffY,double scaleX)
        {
            textBoxResultX.Text = y.ToString();
            textBoxResultX.BackColor = LightGreen;
            Graphics graphicMain = pictureBoxGraphic.CreateGraphics();
            Pen penX = new Pen(Color.DeepPink, 3);

            graphicMain.Clear(Color.White);
            Pen penCountur = new Pen(Color.Black, 3);
            Pen penAdditional = new Pen(Color.Gray, 1);
            Pen penDotted = new Pen(Color.Gray, 1);
            penDotted.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            int graphicWidth = pictureBoxGraphic.Size.Width;
            int graphicHeight = pictureBoxGraphic.Size.Height;
            Font drawFontValue = new Font("Arial", 10);
            Font drawFontValueBold = new Font("Arial", 10, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            PrintFunction(penCountur, penDotted, graphicMain, drawFontValueBold, drawBrush, drawFormat, diffX, diffY);
            PrintLegend(penCountur, penDotted, penAdditional, graphicMain, drawFontValue, drawFontValueBold, drawBrush, drawFormat);
            graphicMain.DrawLine(penX, new Point(offsetX+Convert.ToInt32(x),offsetY),new Point(offsetX +  Convert.ToInt32(x),offsetY+diffY));
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (comboBoxFunctions.SelectedIndex ==0)
            {
                result = ParametersAreRight(textBoxParameter1.Text, textBoxParameter2.Text, "0","0");
            }
            if (comboBoxFunctions.SelectedIndex == 1)
            {
                result = ParametersAreRight(textBoxParameter1.Text, textBoxParameter2.Text, textBoxParameter3.Text, textBoxParameter4.Text);
            }
            if (comboBoxFunctions.SelectedIndex == 2)
            {
                result = ParametersAreRight(textBoxParameter1.Text, textBoxParameter2.Text, "0", "0");
            }
            if (comboBoxFunctions.SelectedIndex == 3)
            {
                result = ParametersAreRight(textBoxParameter1.Text, textBoxParameter2.Text, "0", "0");
            }
            //если все ок - рисуем
            if (result)
            {
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor = LightGreen;
                textBoxInputX.Enabled =buttonFindY.Enabled= textBoxResultX.Enabled= numericUpDownScale.Enabled=true;
                PrintGraphic();
            }
        }
        private void buttonRecommendations_Click(object sender, EventArgs e)
        {
            if (comboBoxFunctions.SelectedIndex ==0)
            {
                textBoxParameter1.Text = "1";
                textBoxParameter2.Text = "0";
            }
            if (comboBoxFunctions.SelectedIndex == 1)
            {
                textBoxParameter1.Text = "6";
                textBoxParameter2.Text = "3";
                textBoxParameter3.Text = "-2";
                textBoxParameter4.Text = "2";
            }
            if (comboBoxFunctions.SelectedIndex == 2)
            {
                textBoxParameter1.Text = "0";
                textBoxParameter2.Text = "1";
            }
            if (comboBoxFunctions.SelectedIndex == 3)
            {
                textBoxParameter1.Text = "1";
                textBoxParameter2.Text = "0";
            }
        }
        private void buttonFindY_Click(object sender, EventArgs e)
        {
            if (!(double.TryParse(textBoxInputX.Text, out double resultX)))
            {
                richTextBoxLog.Text += "Помилка: Невірно заданий х" + endl;
                textBoxInputX.BackColor = LightRed;
            }
            else
            {
                int diffX = pictureBoxGraphic.Size.Width - offsetX * 2;
                int diffY = pictureBoxGraphic.Size.Height - offsetY * 2;
                double scaleX = diffX / (coefficient * 10);
                double scaleY = diffY / 1;
                double x = Convert.ToDouble(textBoxInputX.Text) * scaleX +diffX/2;
                double y;
                if (comboBoxFunctions.SelectedIndex == 0)
                {
                    y = FindY(x, Convert.ToDouble(textBoxParameter1.Text), Convert.ToDouble(textBoxParameter2.Text), 0, 0, diffX, diffY, scaleX);
                    PrintY(x,y/ scaleY, diffX,diffY, scaleX);
                }
                if (comboBoxFunctions.SelectedIndex == 1)
                {
                    y = FindY(x, Convert.ToDouble(textBoxParameter1.Text), Convert.ToDouble(textBoxParameter2.Text), Convert.ToDouble(textBoxParameter3.Text), Convert.ToDouble(textBoxParameter4.Text), diffX, diffY, scaleX);
                    PrintY(x,y / scaleY, diffX, diffY, scaleX);
                }
                if (comboBoxFunctions.SelectedIndex == 2)
                {
                    y = FindY(x, Convert.ToDouble(textBoxParameter1.Text), Convert.ToDouble(textBoxParameter2.Text), 0, 0, diffX, diffY, scaleX);
                    PrintY(x,y / scaleY, diffX, diffY, scaleX);
                }
                if (comboBoxFunctions.SelectedIndex == 3)
                {
                    y = FindY(x, Convert.ToDouble(textBoxParameter1.Text), Convert.ToDouble(textBoxParameter2.Text), 0, 0, diffX, diffY, scaleX);
                    PrintY(x,y / scaleY, diffX, diffY, scaleX);
                }

                textBoxInputX.BackColor = LightGreen;

            }
        }
        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }
        private void buttonDispose_Click(object sender, EventArgs e)
        {
            graphicIsPrinted = false;
            CloseAdditionalFields();
            Graphics graphicMain = pictureBoxGraphic.CreateGraphics();
            graphicMain.Clear(Color.White);
            textBoxParameter1.Text = textBoxParameter2.Text = textBoxParameter3.Text = textBoxParameter4.Text
                = textBoxInputX.Text = textBoxResultX.Text = "";
            richTextBoxLog.Text += "Умова скинута"+endl;
            textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor 
                = textBoxParameter4.BackColor = textBoxInputX.BackColor 
                = textBoxResultX.BackColor = DefaultBoxColor;
            
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ModelingOfFuzzyNumbersWithFunctions_Load(object sender, EventArgs e)
        {
            this.comboBoxFunctions.SelectedIndex = 0;
            this.MinimumSize = new Size(820, 545);
        }
        private void numericUpDownScale_ValueChanged(object sender, EventArgs e)
        {
            coefficient = Convert.ToDouble(numericUpDownScale.Value);
            PrintGraphic();
        }
        private void ModelingOfFuzzyNumbersWithFunctions_ResizeEnd(object sender, EventArgs e)
        {
            groupBoxGraphic.Size = new Size(Size.Width - groupBoxFunctions.Size.Width - 50, groupBoxGraphic.Size.Height);
            pictureBoxGraphic.Size = new Size(Size.Width - groupBoxFunctions.Size.Width - 65, pictureBoxGraphic.Size.Height);
            if (graphicIsPrinted) PrintGraphic();
        }
        private void ModelingOfFuzzyNumbersWithFunctions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void comboBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFunctions.SelectedIndex == 0)
            {
                CloseAdditionalFields();
                labelParameter1.Visible = labelParameter2.Visible = textBoxParameter1.Visible = textBoxParameter2.Visible = buttonRecommendations.Visible= true;
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor = DefaultBoxColor;
                labelParameter1.Text = "a:";
                labelParameter2.Text = "c:";
                pictureBoxFunctionTemplate.Image = Properties.Resources.Сигмоїдна_функція_належності;
                pictureBoxFunctionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
                
            }
            if (comboBoxFunctions.SelectedIndex == 1)
            {
                CloseAdditionalFields();
                labelParameter1.Visible = labelParameter2.Visible = labelParameter3.Visible = labelParameter4.Visible= buttonRecommendations.Visible=true;
                textBoxParameter1.Visible = textBoxParameter2.Visible = textBoxParameter3.Visible = textBoxParameter4.Visible = true;
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor = DefaultBoxColor;
                labelParameter1.Text = "a1:";
                labelParameter2.Text = "a2:";
                labelParameter3.Text = "c1:";
                labelParameter4.Text = "c2:";
                pictureBoxFunctionTemplate.Image = Properties.Resources.Різниця_між_сигмоїдними_функціями_належності;
                pictureBoxFunctionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (comboBoxFunctions.SelectedIndex == 2)
            {
                CloseAdditionalFields();
                labelParameter1.Visible = labelParameter2.Visible = textBoxParameter1.Visible = textBoxParameter2.Visible= buttonRecommendations.Visible = true;
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor = DefaultBoxColor;
                labelParameter1.Text = "b:";
                labelParameter2.Text = "d:";
                pictureBoxFunctionTemplate.Image = Properties.Resources.Лапласівська_функція_належності;
                pictureBoxFunctionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (comboBoxFunctions.SelectedIndex == 3)
            {
                CloseAdditionalFields();
                labelParameter1.Visible = labelParameter2.Visible = textBoxParameter1.Visible = textBoxParameter2.Visible= buttonRecommendations.Visible = true;
                textBoxParameter1.BackColor = textBoxParameter2.BackColor = textBoxParameter3.BackColor = textBoxParameter4.BackColor = DefaultBoxColor;
                labelParameter1.Text = "b:";
                labelParameter2.Text = "с:";
                pictureBoxFunctionTemplate.Image = Properties.Resources.Симетрична_гаусівська_функція_належності;
                pictureBoxFunctionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

    }
}
