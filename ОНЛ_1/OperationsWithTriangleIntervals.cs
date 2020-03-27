using System;
using System.Drawing;
using System.Windows.Forms;
using ОНЛ_5.TriangleIntervalsFiles;

namespace ОНЛ_5
{
    public partial class OperationsWithTriangleIntervals : Form
    {
        public OperationsWithTriangleIntervals()
        {
            InitializeComponent();
        }

        IntervalPoint A1 = new IntervalPoint(0, 0);
        IntervalPoint A2 = new IntervalPoint(0, 1);
        IntervalPoint A3 = new IntervalPoint(0, 0);
        IntervalPoint B1 = new IntervalPoint(0, 0);
        IntervalPoint B2 = new IntervalPoint(0, 1);
        IntervalPoint B3 = new IntervalPoint(0, 0);
        IntervalPoint C1 = new IntervalPoint();
        IntervalPoint C2 = new IntervalPoint();
        IntervalPoint C3 = new IntervalPoint();
        double X;
        bool XisSet, resutlConflictSituasion = false;
        Color LightGreen = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
        Color LightRed = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
        Color DefaultBoxColor = Color.White;
        Color DefaultGroupColor = SystemColors.Control;
        string endl = Environment.NewLine;
        int maxBunkering = 100000;
        string drawStringA, drawStringB, drawStringC, drawStringX;
        int shiftLegend;
        int counterBunkering = 1;
        IntervalPoint point1ForBunkering = new IntervalPoint(0, 0);
        IntervalPoint point2ForBunkering = new IntervalPoint(0, 0);
        IntervalPoint point3ForBunkering = new IntervalPoint(0, 0);

        private double FindVerity(double X, IntervalPoint point1, IntervalPoint point2, IntervalPoint point3)
        {
            double tempVerity = 0;
            if (X < point1.x) tempVerity = 0;
            if (X == point1.x) tempVerity = point1.verity;
            if (X > point1.x && X < point2.x) tempVerity = (point2.x * point1.verity - point1.x * point2.verity - X * (point1.verity - point2.verity)) / (point2.x - point1.x);
            if (X == point2.x) tempVerity = point2.verity;
            if (X > point2.x && X < point3.x) tempVerity = (point3.x * point2.verity - point2.x * point3.verity - X * (point2.verity - point3.verity)) / (point3.x - point2.x);
            if (X == point3.x) tempVerity = point3.verity;
            if (X > point3.x) tempVerity = 0;
            return tempVerity;
        }
        private void FindX()
        {
            bool resultIsDouble = false;
            if (double.TryParse(textBoxInputX.Text, out double resultX))
            {
                X = Convert.ToDouble(textBoxInputX.Text);
                resultIsDouble = XisSet = true;
                textBoxInputX.BackColor = LightGreen;
            }
            else
            {
                textBoxInputX.BackColor = LightRed;
                richTextBoxLog.Text += "Помилка: Невірно заданий Х" + endl;
            }

            if (resultIsDouble)
            {
                double XfromA = FindVerity(X, A1, A2, A3);
                double XfromB = FindVerity(X, B1, B2, B3);
                double XfromC = FindVerity(X, C1, C2, C3);
                textBoxXfromA.BackColor = textBoxXfromB.BackColor = textBoxXfromC.BackColor = LightGreen;
                textBoxXfromA.Text = XfromA.ToString();
                textBoxXfromB.Text = XfromB.ToString();
                textBoxXfromC.Text = XfromC.ToString();
                PrintGraphic();
            }
        }
        private void Calculations(IntervalPoint A1, IntervalPoint A2, IntervalPoint A3, IntervalPoint B1, IntervalPoint B2, IntervalPoint B3)
        {
            if (comboBoxOperations.SelectedIndex == 0)
            {
                C1.x = A1.x + B1.x;
                C2.x = A2.x + B2.x;
                C3.x = A3.x + B3.x;
                C1.verity = C3.verity = 0;
                C2.verity = 1;
                PrintResult(C1, C2, C3);
                PrintGraphic();
                PrintModel('A', A1, A2, A3);
                PrintModel('B', B1, B2, B3);
                PrintModel('C', C1, C2, C3);
            }
            if (comboBoxOperations.SelectedIndex == 1)
            {
                C1.x = A1.x - B3.x;
                C2.x = A2.x - B2.x;
                C3.x = A3.x - B1.x;
                C1.verity = C3.verity = 0;
                C2.verity = 1;
                PrintResult(C1, C2, C3);
                if (checkBoxBunkering.Checked) PrintResultLog(C1, C2, C3);
                PrintGraphic();
                PrintModel('A', A1, A2, A3);
                PrintModel('B', B1, B2, B3);
                PrintModel('C', C1, C2, C3);
            }
        }
        private void PrintResult(IntervalPoint C1, IntervalPoint C2, IntervalPoint C3)
        {
            textBoxResult.Text = "[" + C1.x.ToString() + ", " + C2.x.ToString() + ", " + C3.x.ToString() + "]";
        }
        private void PrintResultLog(IntervalPoint C1, IntervalPoint C2, IntervalPoint C3)//только для бункерування
        {
            if ((point1ForBunkering.x != C1.x) || (point2ForBunkering.x != C2.x) || (point3ForBunkering.x != C3.x))
            {
                richTextBoxLog.Text += "\tБункерування " + counterBunkering + " :" + endl + "Вантажомісткість [ " + A1.x.ToString() + " , " + A2.x.ToString() + " , " + A3.x.ToString() + " ]" + endl;
                richTextBoxLog.Text += "Замовлення порту [ " + B1.x.ToString() + " , " + B2.x.ToString() + " , " + B2.x.ToString() + " ]" + endl;
                richTextBoxLog.Text += "Залишок місця [ " + C1.x.ToString() + " , " + C2.x.ToString() + " , " + C2.x.ToString() + " ]" + endl + endl;
                point1ForBunkering.x = C1.x;
                point2ForBunkering.x = C2.x;
                point3ForBunkering.x = C3.x;
                counterBunkering++;
            }

        }
        private void PrintGraphic()
        {
            //кисти
            Pen penA = new Pen(Color.Blue, 3);
            Pen penB = new Pen(Color.Green, 3);
            Pen penC = new Pen(Color.Red, 3);
            Pen penX = new Pen(Color.Pink, 3);
            Pen penCountur = new Pen(Color.Black, 2);
            Pen penDotted = new Pen(Color.Black, 1);
            penDotted.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Graphics graphicMain = pictureBoxGraphic.CreateGraphics();
            graphicMain.Clear(Color.White);
            //размеры picturebox
            //~750 ~270 picturebox size
            int graphicWidth = pictureBoxGraphic.Size.Width;
            int graphicHeight = pictureBoxGraphic.Size.Height;
            //сдвиг для рамки
            int shiftX = 10;
            int shiftY = 10;
            //сдвиг оХ (вверх-вниз)
            int shift0x = 2 * graphicHeight / 3;
            //умовні позначення
            System.Drawing.Font drawFontValue = new System.Drawing.Font("Arial", 10);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            void GrahpicMainDrawLegend(string drawString, int positionY, Pen pen)
            {
                graphicMain.DrawString(drawString, drawFontValue, drawBrush, graphicWidth - shiftLegend + 55, positionY, drawFormat);
                graphicMain.DrawLine(pen, new Point(graphicWidth - shiftLegend + 5, positionY + 7), new Point(graphicWidth - shiftLegend + 50, positionY + 7));
            }
            GrahpicMainDrawLegend(drawStringA, 20, penA);
            GrahpicMainDrawLegend(drawStringB, 40, penB);
            GrahpicMainDrawLegend(drawStringC, 60, penC);
            GrahpicMainDrawLegend(drawStringX, 80, penX);

            //значення для масштабу
            double maxX = A3.x;
            if (maxX < B3.x) maxX = B3.x;
            if (maxX < C3.x) maxX = C3.x;
            double minX = A1.x;
            if (minX > B1.x) minX = B1.x;
            if (minX > C1.x) minX = C1.x;
            double minXto0 = Math.Abs(minX);
            double diffX = 0;
            if (minX < 0) diffX = maxX - minX;
            else diffX = maxX;

            int diffXpixels = graphicWidth - shiftLegend - shiftX;//~660 pixels (реальная рабочая ширина)
            int diffYpixels = shift0x - shiftY;//125 pixels (реальная рабочая высота)
            double scaleX = diffXpixels / diffX;//определение масштаба по длине
            double scaleY = diffYpixels / 1;//определение масшаба по высоте 
            //определение позиции начала координат
            int zeroPosition = 0;
            if (minX < 0) zeroPosition = (int)(minXto0 * scaleX);
            else zeroPosition = 0;
            graphicMain.DrawString("0", drawFontValue, drawBrush, zeroPosition + shiftX, shift0x + 3, drawFormat);
            graphicMain.DrawString("1", drawFontValue, drawBrush, zeroPosition + shiftX, shiftY, drawFormat);
            if (zeroPosition != 0) graphicMain.DrawString(minX.ToString(), drawFontValue, drawBrush, shiftX, shift0x + 3, drawFormat);
            //лінія х
            graphicMain.DrawLine(penDotted, new Point(shiftX, shiftY), new Point(graphicWidth - shiftLegend, shiftY));
            graphicMain.DrawLine(penCountur, new Point(shiftX, shift0x), new Point(graphicWidth - shiftLegend, shift0x));
            //лінія y (verity)
            graphicMain.DrawLine(penCountur, new Point(zeroPosition + shiftX, shift0x), new Point(zeroPosition + shiftX, shiftY));
            //нечеткие числа
            void GraphicMainDrawTriangle(IntervalPoint point1, IntervalPoint point2, IntervalPoint point3, Pen pen)
            {
                //числа обозначающие границы интервалов
                Random randomNumber = new Random();
                graphicMain.DrawString(Math.Round(point1.x, 2).ToString(), drawFontValue, drawBrush, zeroPosition + shiftX + (int)(point1.x * scaleX), randomNumber.Next(shift0x + 3, graphicHeight - drawFontValue.Height), drawFormat);
                graphicMain.DrawString(Math.Round(point2.x, 2).ToString(), drawFontValue, drawBrush, zeroPosition + shiftX + (int)(point2.x * scaleX), randomNumber.Next(shift0x + 3, graphicHeight - drawFontValue.Height), drawFormat);
                graphicMain.DrawString(Math.Round(point3.x, 2).ToString(), drawFontValue, drawBrush, zeroPosition + shiftX + (int)(point3.x * scaleX), randomNumber.Next(shift0x + 3, graphicHeight - drawFontValue.Height), drawFormat);
                //левая и правая ветка нечеткого числа
                graphicMain.DrawLine(pen, new Point((int)(point1.x * scaleX) + shiftX + zeroPosition, (shift0x) - (int)(point1.verity * scaleY)), new Point((int)(point2.x * scaleX) + shiftX + zeroPosition, (shift0x) - (int)(point2.verity * scaleY)));
                graphicMain.DrawLine(pen, new Point((int)(point2.x * scaleX) + shiftX + zeroPosition, (shift0x) - (int)(point2.verity * scaleY)), new Point((int)(point3.x * scaleX) + shiftX + zeroPosition, (shift0x) - (int)(point3.verity * scaleY)));
                //пунктирные вертикальные линии для точек
                graphicMain.DrawLine(penDotted, new Point((int)(point1.x * scaleX) + shiftX + zeroPosition, shift0x), new Point((int)(point1.x * scaleX) + shiftX + zeroPosition, shift0x + graphicHeight));
                graphicMain.DrawLine(penDotted, new Point((int)(point2.x * scaleX) + shiftX + zeroPosition, shift0x - (int)(point2.verity * scaleY)), new Point((int)(point2.x * scaleX) + shiftX + zeroPosition, shift0x + graphicHeight));
                graphicMain.DrawLine(penDotted, new Point((int)(point3.x * scaleX) + shiftX + zeroPosition, shift0x), new Point((int)(point3.x * scaleX) + shiftX + zeroPosition, shift0x + graphicHeight));
            }
            if (resutlConflictSituasion)
            {
                GraphicMainDrawTriangle(A1, A2, A3, penA);//A
                GraphicMainDrawTriangle(B1, B2, B3, penB);//B
            }
            else
            {
                GraphicMainDrawTriangle(A1, A2, A3, penA);//A
                GraphicMainDrawTriangle(B1, B2, B3, penB);//B
                GraphicMainDrawTriangle(C1, C2, C3, penC);//C
            }
            if (XisSet)//X
            {
                graphicMain.DrawString(Math.Round(X, 2).ToString(), drawFontValue, drawBrush, zeroPosition + shiftX + (int)(X * scaleX), shift0x + 20, drawFormat);
                graphicMain.DrawLine(penX, new Point((int)(X * scaleX) + shiftX + zeroPosition, graphicHeight), new Point((int)(X * scaleX) + shiftX + zeroPosition, shiftY));
            }
        }
        private void PrintModel(char tempNumber, IntervalPoint number1, IntervalPoint number2, IntervalPoint number3)
        {
            String tempLabelFullNumber = "no data";
            String tempLabelAlpha = "no data";
            tempLabelFullNumber = "mA(x) = 0, при х <= " + Math.Round(number1.x, 2).ToString() + endl +
              "            (" + Math.Round(number1.x, 2).ToString() + " + x) / " + Math.Round(number2.x - number1.x, 2).ToString() +
              ", при " + Math.Round(number1.x, 2).ToString() + " <= x <= " + Math.Round(number2.x, 2).ToString() + endl +
              "            (" + Math.Round(number3.x, 2).ToString() + " - x) / " + Math.Round(number3.x - number2.x, 2).ToString() +
              ", при " + Math.Round(number2.x, 2).ToString() + " <= x <= " + Math.Round(number3.x, 2).ToString() + endl +
              "            0, при х >= " + Math.Round(number3.x, 2).ToString();
            tempLabelAlpha = "A alpha = [" + Math.Round(number1.x, 2).ToString() +
                " + " + Math.Round(number2.x - number1.x, 2).ToString() + "al, " +
                Math.Round(number3.x, 2).ToString() + " - " + Math.Round(number3.x - number2.x, 2).ToString() + "al]";

            if (tempNumber == 'A')
            {
                labelFullNumberA.Text = tempLabelFullNumber;
                labelAalpha.Text = tempLabelAlpha;
            }
            if (tempNumber == 'B')
            {
                labelFullNumberB.Text = tempLabelFullNumber;
                labelBalpha.Text = tempLabelAlpha;
            }
            if (tempNumber == 'C')
            {
                labelFullNumberC.Text = tempLabelFullNumber;
                labelCalpha.Text = tempLabelAlpha;
            }
        }
        private void ModeDefault()
        {
            labelNumberA.Text = "Нечітке число А:";
            labelNumberB.Text = "Нечітке число В:";
            labelNumberC.Text = "Нечітке число С:";
            drawStringA = "А";
            drawStringB = "B";
            drawStringC = "С";
            drawStringX = "X";
            shiftLegend = 80;
            counterBunkering = 1;
        }
        private void ModeBunkering()
        {
            labelNumberA.Text = "A (Вантажомісткість):";
            labelNumberB.Text = "B (Замовлення порту):";
            labelNumberC.Text = "C (Залишок):";
            drawStringA = "Вантажомісткість";
            drawStringB = "Замовлення порту";
            drawStringC = "Залишок";
            drawStringX = "X";
            shiftLegend = 180;
            counterBunkering = 1;
        }
        private double GetRandomNumber(int minimum, int maximum)
        {
            Random randomHumber = new Random();
            return randomHumber.Next(minimum, maximum);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            bool resultIsDouble, resultRightBunkeringInequality;
            resultIsDouble = resultRightBunkeringInequality = true;
            bool resultRightInequality = false;
            resutlConflictSituasion = false;

            if (double.TryParse(textBoxA1.Text, out double resultA1) && double.TryParse(textBoxA2.Text, out double resultA2)
                && double.TryParse(textBoxA3.Text, out double resultA3) && double.TryParse(textBoxB1.Text, out double resultB1)
                && double.TryParse(textBoxB2.Text, out double resultB2) && double.TryParse(textBoxB3.Text, out double resultB3))
            {
                A1.x = Convert.ToDouble(textBoxA1.Text);
                A2.x = Convert.ToDouble(textBoxA2.Text);
                A3.x = Convert.ToDouble(textBoxA3.Text);
                B1.x = Convert.ToDouble(textBoxB1.Text);
                B2.x = Convert.ToDouble(textBoxB2.Text);
                B3.x = Convert.ToDouble(textBoxB3.Text);
            }
            else
            {
                resultIsDouble = false;
                richTextBoxLog.Text += "Помилка: Невірно задані дані" + endl;
                textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor = textBoxB1.BackColor = textBoxB2.BackColor = textBoxB3.BackColor = LightRed;
            }

            if (resultIsDouble)
            {
                if (resultIsDouble && (A1.x <= A2.x && A2.x <= A3.x && A1.x <= A3.x)
                                && (B1.x <= B2.x && B2.x <= B3.x && B1.x <= B3.x))
                {
                    resultRightInequality = true;
                    //if bunkering
                    if (checkBoxBunkering.Checked == true)
                    {
                        if (A1.x < 0 || A3.x > maxBunkering)
                        {
                            resultRightBunkeringInequality = false;
                            richTextBoxLog.Text += "Помилка: Вантажомісткість має бути [0, maxBunkering]" + endl;
                            textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor = LightRed;
                        }
                        else
                        {
                            if (B1.x < 50)
                            {
                                resultRightBunkeringInequality = false;
                                richTextBoxLog.Text += "Помилка: Замовлення порту має бути не менше 50" + endl;
                                textBoxB1.BackColor = LightRed;
                            }
                            else
                            {
                                if (B1.x > A3.x)
                                {
                                    resultRightBunkeringInequality = false;
                                    richTextBoxLog.Text += "Помилка: Немає вільного місця на судні" + endl;
                                    textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor = LightRed;
                                }
                                else
                                {
                                    if (B3.x > A1.x)
                                    {
                                        resultRightBunkeringInequality = true;
                                        resutlConflictSituasion = true;
                                        richTextBoxLog.Text += "Помилка: Конфліктна ситуація (максимальне замовлення > мінімальної вантажомісткості)" + endl;
                                    }
                                    //else resultRightBunkeringInequality = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    richTextBoxLog.Text += "Помилка: Відсутня нерівність А1<=A2<=A3 або B1<=B2<=B3" + endl;
                    textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor = textBoxB1.BackColor = textBoxB2.BackColor = textBoxB3.BackColor = LightRed;
                }
            }
            //если все ок
            if (resultIsDouble && resultRightInequality && resultRightBunkeringInequality)
            {
                if (resutlConflictSituasion)
                {
                    textBoxResult.BackColor = DefaultBoxColor;
                    textBoxResult.Text = "";
                    C1 = new IntervalPoint();
                    C2 = new IntervalPoint();
                    C3 = new IntervalPoint();
                    textBoxInputX.Enabled = buttonFindX.Enabled = XisSet = false;
                    PrintGraphic();
                }
                else
                {
                    textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor = textBoxB1.BackColor = textBoxB2.BackColor = textBoxB3.BackColor = textBoxResult.BackColor = LightGreen;
                    textBoxInputX.Enabled = buttonFindX.Enabled = true;
                    if (textBoxInputX.Text != "") FindX();
                    else Calculations(A1, A2, A3, B1, B2, B3);
                }
            }
        }
        private void buttonResultInA_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && textBoxResult.Text != "Неможливо порахувати")
            {
                A1.x = C1.x;
                A2.x = C2.x;
                A3.x = C3.x;
                A1.verity = C1.verity;
                A2.verity = C2.verity;
                A3.verity = C3.verity;
                textBoxA1.Text = C1.x.ToString();
                textBoxA2.Text = C2.x.ToString();
                textBoxA3.Text = C3.x.ToString();
                richTextBoxLog.Text += "Нечітке число C перенесено до А" + endl;
            }
            else
            {
                richTextBoxLog.Text += "Помилка: Нечітке число відсутне" + endl;
                textBoxResult.BackColor = LightRed;
            }
        }
        private void buttonResultInB_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && textBoxResult.Text != "Неможливо порахувати")
            {
                B1.x = C1.x;
                B2.x = C2.x;
                B3.x = C3.x;
                B1.verity = C1.verity;
                B2.verity = C2.verity;
                B3.verity = C3.verity;
                textBoxB1.Text = C1.x.ToString();
                textBoxB2.Text = C2.x.ToString();
                textBoxB3.Text = C3.x.ToString();
                richTextBoxLog.Text += "Нечітке число C перенесено до B" + endl;
            }
            else
            {
                richTextBoxLog.Text += "Помилка: Нечітке число відсутнє" + endl;
                textBoxResult.BackColor = LightRed;
            }
        }
        private void buttonRandomA_Click(object sender, EventArgs e)
        {
            if (checkBoxBunkering.Checked == true)
            {
                textBoxA1.Text = GetRandomNumber(0, maxBunkering).ToString();
                textBoxA2.Text = GetRandomNumber(Convert.ToInt32(textBoxA1.Text), maxBunkering).ToString();
                textBoxA3.Text = GetRandomNumber(Convert.ToInt32(textBoxA2.Text), maxBunkering).ToString();
            }
            else
            {
                textBoxA1.Text = GetRandomNumber(Int32.MinValue, Int32.MaxValue).ToString();
                textBoxA2.Text = GetRandomNumber(Convert.ToInt32(textBoxA1.Text), Int32.MaxValue).ToString();
                textBoxA3.Text = GetRandomNumber(Convert.ToInt32(textBoxA2.Text), Int32.MaxValue).ToString();
            }

        }
        private void buttonRandomB_Click(object sender, EventArgs e)
        {
            if (checkBoxBunkering.Checked == true)
            {
                textBoxB1.Text = GetRandomNumber(50, maxBunkering).ToString();
                textBoxB2.Text = GetRandomNumber(Convert.ToInt32(textBoxB1.Text), maxBunkering).ToString();
                textBoxB3.Text = GetRandomNumber(Convert.ToInt32(textBoxB2.Text), maxBunkering).ToString();
            }
            else
            {
                textBoxB1.Text = GetRandomNumber(Int32.MinValue, Int32.MaxValue).ToString();
                textBoxB2.Text = GetRandomNumber(Convert.ToInt32(textBoxB1.Text), Int32.MaxValue).ToString();
                textBoxB3.Text = GetRandomNumber(Convert.ToInt32(textBoxB2.Text), Int32.MaxValue).ToString();
            }
        }
        private void buttonFindX_Click(object sender, EventArgs e)
        {
            FindX();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }
        private void buttonDispose_Click(object sender, EventArgs e)
        {
            A1 = new IntervalPoint(0, 0);
            A2 = new IntervalPoint(0, 1);
            A3 = new IntervalPoint(0, 0);
            B1 = new IntervalPoint(0, 0);
            B2 = new IntervalPoint(0, 1);
            B3 = new IntervalPoint(0, 0);
            C1 = new IntervalPoint();
            C2 = new IntervalPoint();
            C3 = new IntervalPoint();
            textBoxInputX.Enabled = buttonFindX.Enabled = XisSet = false;
            textBoxA1.BackColor = textBoxA2.BackColor = textBoxA3.BackColor =
            textBoxB1.BackColor = textBoxB2.BackColor = textBoxB3.BackColor =
            textBoxResult.BackColor = textBoxXfromA.BackColor = textBoxXfromB.BackColor =
            textBoxXfromC.BackColor = textBoxInputX.BackColor = DefaultBoxColor;
            textBoxA1.Text = textBoxA2.Text = textBoxA3.Text = textBoxB1.Text =
            textBoxB2.Text = textBoxB3.Text = textBoxResult.Text = textBoxInputX.Text =
            textBoxXfromA.Text = textBoxXfromB.Text = textBoxXfromC.Text = "";
            Graphics graphicDischarge = pictureBoxGraphic.CreateGraphics();
            graphicDischarge.Clear(Color.White);
            labelFullNumberA.Text = "мА(х) = ";
            labelFullNumberB.Text = "мB(х) = ";
            labelFullNumberC.Text = "мC(х) = ";
            labelAalpha.Text = "A alpha =";
            labelBalpha.Text = "B alpha =";
            labelCalpha.Text = "C alpha =";
            richTextBoxLog.Text += "Умова скинута" + endl;
            counterBunkering = 1;
        }

        private void TriangleIntervalsAddition_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }
        private void TriangleIntervalsAddition_ResizeEnd(object sender, EventArgs e)
        {
            groupBoxGraphic.Size = new Size(Size.Width - groupBoxOperands.Size.Width - 50, groupBoxGraphic.Size.Height);
            pictureBoxGraphic.Size = new Size(Size.Width - groupBoxOperands.Size.Width - 65, pictureBoxGraphic.Size.Height);
            if (textBoxResult.Text != "") PrintGraphic();
            groupBoxLog.Size = new Size(Size.Width - groupBoxModels.Size.Width - 50, groupBoxLog.Size.Height);
            richTextBoxLog.Size = new Size(Size.Width - groupBoxModels.Size.Width - 65, richTextBoxLog.Size.Height);
        }
        private void TriangleIntervalsAddition_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(970, 470);
            this.comboBoxOperations.SelectedIndex = 0;
        }
        private void comboBoxOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperations.SelectedIndex == 0)
            {
                checkBoxBunkering.Visible = checkBoxBunkering.Checked = false;
                ModeDefault();
            }

            if (comboBoxOperations.SelectedIndex == 1)
            {
                checkBoxBunkering.Visible = true;
                ModeDefault();
            }
        }
        private void checkBoxBunkering_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBunkering.Checked == false) ModeDefault();
            else ModeBunkering();
        }
        private void checkBoxBunkering_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutomaticDelay = 1000;
            toolTip1.SetToolTip(this.checkBoxBunkering, "Умова:" + endl + "Вантажомісткість Є [0," + maxBunkering + "]" + endl
                + "Замовлення порту >50" + endl + "Максимальне замовлення < Мінімальної вантажомісткості");
        }
    }
}