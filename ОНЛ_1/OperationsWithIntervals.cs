using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ОНЛ_5
{
    public partial class OperationsWithIntervalForm : Form
    {
        public OperationsWithIntervalForm()
        {
            InitializeComponent();
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        List<List<double>> arrIntervals = new List<List<double>>();    //динамический двумерный массив
        List<double> row = new List<double>();                //строка массива
        double A1, A2, B1, B2, C1, C2, K;
        int counterMain, counterForInsert = 0;
        bool NumericInputA1, NumericInputA2, NumericInputB1, NumericInputB2, NumericInputMultiplyLeft, NumericInputMultiplyRight, NumericInputConstNumber = false;
        bool NumericInputCounter=false;
        Color LightGreen = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
        Color LightRed = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
        Color DefaultBoxColor = Color.White;
        Color DefaultGroupColor = SystemColors.Control;

        public void DischargeAdditionalFields()
        {
            radioButtonIntervalB.Enabled = false;
            radioButtonIntervalA.Enabled = false;
            radioButtonIntervalA.Checked = false;
            radioButtonIntervalB.Checked = false;
            textBoxConstNumber.Enabled = false;
            textBoxMultiplyLeft.Enabled = false;
            textBoxMultiplyRight.Enabled = false;
            buttonIntervalsOK.Enabled = false;
            textBoxCounter.Enabled = false;
            buttonCounterOK.Enabled = false;
        }
        public void AllFieldsGreen()
        {
            textBoxA1.BackColor = LightGreen;
            textBoxA2.BackColor = LightGreen;
            textBoxB1.BackColor = LightGreen;
            textBoxB2.BackColor = LightGreen;
            textBoxCounter.BackColor = LightGreen;
            textBoxMultiplyLeft.BackColor = LightGreen;
            textBoxMultiplyRight.BackColor = LightGreen;
            textBoxConstNumber.BackColor = LightGreen;
            groupBoxOperations.BackColor = LightGreen;
            groupBoxAB.BackColor = LightGreen;
        }
        public void DischargeAllFields()
        {
            A1 = A2 = B1 = B2 = C1 = C2 = K = counterMain = counterForInsert = 0;
            this.textBoxA1.Text = "";
            this.textBoxA2.Text = "";
            this.textBoxB1.Text = "";
            this.textBoxB2.Text = "";
            this.textBoxConstNumber.Text = "";
            this.textBoxResult.Text = "";
            this.textBoxCounter.Text = "";
            this.textBoxMultiplyLeft.Text = "";
            this.textBoxMultiplyRight.Text = "";
            radioButtonBin1.Checked = false;
            radioButtonBin2.Checked = false;
            radioButtonBin3.Checked = false;
            radioButtonBin4.Checked = false;
            radioButtonBin5.Checked = false;
            radioButtonUnary1.Checked = false;
            radioButtonBin6.Checked = false;
            radioButtonUnary3.Checked = false;
            radioButtonUnary4.Checked = false;
            radioButtonUnary5.Checked = false;
            radioButtonUnary6.Checked = false;
            radioButtonBin8.Checked = false;
            radioButtonUnary2.Checked = false;
            radioButtonBin7.Checked = false;
            radioButtonIntervalA.Checked = false;
            radioButtonIntervalB.Checked = false;
            radioButtonIntervalB.Enabled = false;
            radioButtonIntervalA.Enabled = false;
            textBoxConstNumber.Enabled = false;
            textBoxCounter.Enabled = false;
            textBoxMultiplyLeft.Enabled = false;
            textBoxMultiplyRight.Enabled = false;
            buttonIntervalsOK.Enabled = false;
            buttonCounterOK.Enabled = false;
            radioButtonBin1.Enabled = true;
            radioButtonBin2.Enabled = true;
            radioButtonBin3.Enabled = true;
            radioButtonBin4.Enabled = true;
            radioButtonBin5.Enabled = true;
            radioButtonBin6.Enabled = true;
            radioButtonBin7.Enabled = true;
            radioButtonUnary1.Enabled = true;
            radioButtonUnary2.Enabled = true;
            radioButtonUnary3.Enabled = true;
            radioButtonUnary4.Enabled = true;
            radioButtonUnary5.Enabled = true;
            radioButtonUnary6.Enabled = true;
            buttonCalculate.Enabled = true;
            textBoxA1.Enabled = true;
            textBoxA2.Enabled = true;
            textBoxB1.Enabled = true;
            textBoxB2.Enabled = true;
            this.textBoxA1.BackColor = DefaultBoxColor;
            this.textBoxA2.BackColor = DefaultBoxColor;
            this.textBoxB1.BackColor = DefaultBoxColor;
            this.textBoxB2.BackColor = DefaultBoxColor;
            this.textBoxConstNumber.BackColor = DefaultGroupColor;
            this.textBoxResult.BackColor = DefaultBoxColor;
            this.groupBoxOperations.BackColor = DefaultGroupColor;
            this.groupBoxAB.BackColor = DefaultGroupColor;
            this.textBoxCounter.BackColor = DefaultGroupColor;
            this.textBoxMultiplyLeft.BackColor = DefaultGroupColor;
            this.textBoxMultiplyRight.BackColor = DefaultGroupColor;
            this.buttonCounterOK.BackColor = DefaultGroupColor;
            arrIntervals.Clear();
            row.Clear();
            Graphics graphicDischarge = pictureBoxGraphic.CreateGraphics();
            graphicDischarge.Clear(Color.White);
            buttonIntervalsOK.Text = "Додати інтервал";
            labelIntervals.Text = "Інтервал _:";
            richTextBoxLog.Text += "Умова скинута" + Environment.NewLine;
        }

        private void textBoxA1_TextChanged(object sender, EventArgs e)
        {
            NumericInputA1 = double.TryParse(textBoxA1.Text, out double result);
        }
        private void textBoxA2_TextChanged(object sender, EventArgs e)
        {
            NumericInputA2 = double.TryParse(textBoxA2.Text, out double result);
        }
        private void textBoxB1_TextChanged(object sender, EventArgs e)
        {
            NumericInputB1 = double.TryParse(textBoxB1.Text, out double result);
        }
        private void textBoxB2_TextChanged(object sender, EventArgs e)
        {
            NumericInputB2 = double.TryParse(textBoxB2.Text, out double result);
        }
        private void textBoxCounter_TextChanged(object sender, EventArgs e)
        {
            NumericInputCounter = int.TryParse(textBoxCounter.Text, out int result);
        }
        private void textBoxMultiplyLeft_TextChanged(object sender, EventArgs e)
        {
            NumericInputMultiplyLeft = double.TryParse(textBoxMultiplyLeft.Text, out double result);
        }
        private void textBoxMultiplyRight_TextChanged(object sender, EventArgs e)
        {
            NumericInputMultiplyRight = double.TryParse(textBoxMultiplyRight.Text, out double result);
        }
        private void textBoxConstNumber_TextChanged(object sender, EventArgs e)
        {
            NumericInputConstNumber = double.TryParse(textBoxB2.Text, out double result);
        }
        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        private void radioButtonBin1_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin2_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin3_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin4_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin5_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin6_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin7_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
        }
        private void radioButtonBin8_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            textBoxCounter.Enabled = true;
            buttonCounterOK.Enabled = true;
        }
        private void radioButtonUnary1_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
        }
        private void radioButtonUnary2_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
        }
        private void radioButtonUnary3_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
            textBoxConstNumber.Enabled = true;
        }
        private void radioButtonUnary4_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
            textBoxConstNumber.Enabled = true;
        }
        private void radioButtonUnary5_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
            textBoxConstNumber.Enabled = true;
        }
        private void radioButtonUnary6_CheckedChanged(object sender, EventArgs e)
        {
            DischargeAdditionalFields();
            radioButtonIntervalB.Enabled = true;
            radioButtonIntervalA.Enabled = true;
            textBoxConstNumber.Enabled = true;
            buttonCalculate.Enabled = true;
        }

        private double findMin(double A1, double A2, double B1, double B2)
        {
            if (radioButtonBin3.Checked || radioButtonBin8.Checked )
            {
                double temp_min = A1 * B1;
                double[,] arr = new double[,] { { A1, A2 }, { B1, B2 } };
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (arr[0, i] * arr[1, j] <= temp_min)
                        {
                            temp_min = arr[0, i] * arr[1, j];
                        }
                    }
                }
                return temp_min;
            }
            if (radioButtonBin5.Checked)
            {
                double temp_min = A1 / B1;
                double[,] arr = new double[,] { { A1, A2 }, { B1, B2 } };
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (arr[0, i] / arr[1, j] <= temp_min)
                        {
                            temp_min = arr[0, i] / arr[1, j];
                        }
                    }
                }
                return temp_min;
            }
            else return 0;
            
        }
        private double findMax(double A1, double A2, double B1, double B2)
        {
            if (radioButtonBin3.Checked || radioButtonBin8.Checked )
            {
                double temp_max = A1 * B1;
                double[,] arr = new double[,] { { A1, A2 }, { B1, B2 } };
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (arr[0, i] * arr[1, j] >= temp_max)
                        {
                            temp_max = arr[0, i] * arr[1, j];
                        }
                    }
                }
                return temp_max;
            }
            if (radioButtonBin5.Checked)
            {
                double temp_max = A1 / B1;
                double[,] arr = new double[,] { { A1, A2 }, { B1, B2 } };
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (arr[0, i] / arr[1, j] >= temp_max)
                        {
                            temp_max = arr[0, i] / arr[1, j];
                        }
                    }
                }
                return temp_max;
            }
            else return 0;
        }
        public void Calculations(double A1, double A2, double B1, double B2)
        {
            //
            //Binary operations
            //
            if(radioButtonBin1.Checked)
            {
                C1 = A1 + B1;
                C2 = A2 + B2;
            }
            if (radioButtonBin2.Checked)
            {
                C1 = A1 - B2;
                C2 = A2 - B1;
            }
            if (radioButtonBin3.Checked)
            {
                C1 = findMin(A1, A2, B1, B2);
                C2 = findMax(A1, A2, B1, B2);
            }
            if (radioButtonBin4.Checked)
            {
                C1 = A1 / B2;
                C2 = A2 / B1;
            }
            if (radioButtonBin5.Checked)
            {
                C1 = findMin(A1, A2, B1, B2);
                C2 = findMax(A1, A2, B1, B2);
            }
            if (radioButtonBin6.Checked)
            {

                if (A1 >= B1)
                {
                    C1 = A1;
                }
                else
                {
                    C1 = B1;
                }
                if (A2 >= B2)
                {
                    C2 = A2;
                }
                else
                {
                    C2 = B2;
                }
            }
            if (radioButtonBin7.Checked)
            {
                if (A1 <= B1)
                {
                    C1 = A1;
                }
                else
                {
                    C1 = B1;
                }
                if (A2 <= B2)
                {
                    C2 = A2;
                }
                else
                {
                    C2 = B2;
                }
            }
            if (radioButtonBin8.Checked)
            {
                C1 = findMin(A1, A2, B1, B2);
                C2 = findMax(A1, A2, B1, B2);

            }
            //
            //Unary operation
            //
            if (radioButtonUnary1.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = A2 * (-1);
                    C2 = A1 * (-1);
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = B2 * (-1);
                    C2 = B1 * (-1);
                }
            }
            if (radioButtonUnary2.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = 1 / A2;
                    C2 = 1 / A1;
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = 1 / B2;
                    C2 = 1 / B1;
                }
            }
            if (radioButtonUnary3.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = A1 + K;
                    C2 = A2 + K;
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = B1 + K;
                    C2 = B2 + K;
                }
            }
            if (radioButtonUnary4.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = A1-K;
                    C2 = A2-K;
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = B1-K;
                    C2 = B2-K;
                }
            }
            if (radioButtonUnary5.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = A1 * K;
                    C2 = A2* K;
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = B1 * K;
                    C2 = B2 * K;
                }
            }
            if (radioButtonUnary6.Checked)
            {
                if (radioButtonIntervalA.Checked)
                {
                    C1 = A1 / K;
                    C2 = A2 / K;
                }
                if (radioButtonIntervalB.Checked)
                {
                    C1 = B1 / K;
                    C2 = B2/ K;
                }
            }
        }

        private void buttonResultInA_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && textBoxResult.Text != "Неможливо порахувати")
            {
                A1 = C1;
                A2 = C2;
                this.textBoxA1.Text = C1.ToString();
                this.textBoxA2.Text = C2.ToString();
                richTextBoxLog.Text += "Інтервал C перенесено до А" + Environment.NewLine;
            }
            else
            {
                richTextBoxLog.Text += "Помилка: Інтервал відсутній" + Environment.NewLine;
                textBoxResult.BackColor = LightRed;
            }
        }
        private void buttonResultInB_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && textBoxResult.Text != "Неможливо порахувати")
            {
                B1 = C1;
                B2 = C2;
                this.textBoxB1.Text = C1.ToString();
                this.textBoxB2.Text = C2.ToString();
                richTextBoxLog.Text += "Інтервал C перенесено до B" + Environment.NewLine;
            }
            else
            {
                richTextBoxLog.Text += "Помилка: Інтервал відсутній" + Environment.NewLine;
                textBoxResult.BackColor = LightRed;
            }
        }
        private void buttonCounterOK_Click(object sender, EventArgs e)
        {
            radioButtonBin1.Enabled = false;
            radioButtonBin2.Enabled = false;
            radioButtonBin3.Enabled = false;
            radioButtonBin4.Enabled = false;
            radioButtonBin5.Enabled = false;
            radioButtonBin6.Enabled = false;
            radioButtonBin7.Enabled = false;
            radioButtonUnary1.Enabled = false;
            radioButtonUnary2.Enabled = false;
            radioButtonUnary3.Enabled = false;
            radioButtonUnary4.Enabled = false;
            radioButtonUnary5.Enabled = false;
            radioButtonUnary6.Enabled = false;
            buttonCalculate.Enabled = false;
            textBoxA1.Enabled = false;
            textBoxA2.Enabled = false;
            textBoxB1.Enabled = false;
            textBoxB2.Enabled = false;
            this.buttonCounterOK.BackColor = DefaultBoxColor;
            this.textBoxA1.BackColor = LightGreen;
            this.textBoxA2.BackColor = LightGreen;
            this.textBoxB1.BackColor = LightGreen;
            this.textBoxB2.BackColor = LightGreen;
            this.textBoxConstNumber.BackColor = LightGreen;
            this.groupBoxOperations.BackColor = LightGreen;
            this.groupBoxAB.BackColor = LightGreen;
            this.textBoxCounter.BackColor = LightGreen;
            this.textBoxMultiplyLeft.BackColor = DefaultBoxColor;
            this.textBoxMultiplyRight.BackColor = DefaultBoxColor;
            buttonIntervalsOK.Text = "Додати інтервал";
            labelIntervals.Text = "Інтервал " + 1 + ":";
            if (!NumericInputCounter)
            {
                if (textBoxCounter.Text == "")
                {
                    richTextBoxLog.Text += "Помилка: У textBoxCounter пусто" + Environment.NewLine;
                    textBoxCounter.BackColor = LightRed;
                }
                else 
                {
                    richTextBoxLog.Text += "Помилка: У textBoxCounter введено не ціле число" + Environment.NewLine;
                    textBoxCounter.BackColor = LightRed;
                }
            }
            else
            {
                counterMain = Convert.ToInt32(textBoxCounter.Text);
                counterForInsert = counterMain;

                if (counterMain<2)
                {
                    richTextBoxLog.Text += "Помилка: У textBoxCounter введено число < 2" + Environment.NewLine;
                    textBoxCounter.BackColor = LightRed;
                }
                else
                {
                    richTextBoxLog.Text += "\tМноження декількох інтервалів:" + Environment.NewLine;
                    richTextBoxLog.Text += "Додайте інтервали" + Environment.NewLine;
                    textBoxMultiplyLeft.Enabled = true;
                    textBoxMultiplyRight.Enabled = true;
                    buttonIntervalsOK.Enabled = true;
                    buttonCounterOK.Enabled = false;
                    textBoxCounter.Enabled = false;
                }
            }
        }
        private void buttonIntervalsOK_Click(object sender, EventArgs e)
        {
            int numerator = counterMain - counterForInsert+2;
            if (counterForInsert != 0)
            {
                if (!NumericInputMultiplyLeft)
                {
                    if (textBoxMultiplyLeft.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У лівій границі пусто" + Environment.NewLine;
                        textBoxMultiplyLeft.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У лівій границі введено не число" + Environment.NewLine;
                        textBoxMultiplyLeft.BackColor = LightRed;
                    }
                }
                else
                {
                    B1 = Convert.ToDouble(textBoxMultiplyLeft.Text);
                    textBoxMultiplyLeft.BackColor = DefaultBoxColor;
                }
                if (!NumericInputMultiplyRight)
                {
                    if (textBoxMultiplyRight.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У правій границі пусто" + Environment.NewLine;
                        textBoxMultiplyRight.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У правій границі введено не число" + Environment.NewLine;
                        textBoxMultiplyRight.BackColor = LightRed;
                    }
                }
                else
                {
                    B2 = Convert.ToDouble(textBoxMultiplyRight.Text);
                    textBoxMultiplyRight.BackColor = DefaultBoxColor;
                }
                if (
                    NumericInputMultiplyLeft &&
                    NumericInputMultiplyRight &&
                    B1 > B2)
                {
                    richTextBoxLog.Text += "Помилка: Граничне значення лівої границі > правої границі" + Environment.NewLine;
                    textBoxMultiplyLeft.BackColor = LightRed;
                    textBoxMultiplyRight.BackColor = LightRed;
                }

                if (textBoxMultiplyLeft.BackColor != LightRed &&
                    textBoxMultiplyRight.BackColor != LightRed)
                {
                    row = new List<double>();
                    row.Add(B1);
                    row.Add(B2);
                    arrIntervals.Add(row);                               //строка добавляется в массив
                    richTextBoxLog.Text += "Інтервал [ "+B1+", "+B2+" ] додано до масиву" + Environment.NewLine;
                    textBoxMultiplyLeft.Text = "";
                    textBoxMultiplyRight.Text = "";
                    labelIntervals.Text = "Інтервал " + numerator + ":";
                    counterForInsert--;
                }
            }
            if (counterForInsert==1)
            {
                buttonIntervalsOK.Text = "Обрахувати";
            }
            if (counterForInsert == 0)
            {
                richTextBoxLog.Text += "Масив заповнений" + Environment.NewLine;
                textBoxMultiplyLeft.Enabled = false;
                textBoxMultiplyRight.Enabled = false;
                textBoxCounter.Enabled = false;
                buttonCounterOK.Enabled = false;
                buttonIntervalsOK.Enabled = false;
                textBoxMultiplyLeft.Text = "";
                textBoxMultiplyRight.Text = "";
                textBoxCounter.Text = "";
                labelIntervals.Text = "Інтервал _:";
                textBoxMultiplyRight.BackColor = LightGreen;
                textBoxMultiplyLeft.BackColor = LightGreen;

                for (int i = 0; i < counterMain; i++)                     //вывод массива
                {
                    for (int j = 0; j < 2; j++)
                    {
                        richTextBoxLog.Text += arrIntervals[i][j].ToString() + " ";
                    }
                    richTextBoxLog.Text += Environment.NewLine;
                }
                //УМНОЖЕНИЕ !!!!!!!!!!!!!!1 УРААААА
                for (int i = 0; i < counterMain-1; i++)
                {
                    A1 = arrIntervals[i][0];
                    A2 = arrIntervals[i][1];
                    B1 = arrIntervals[i + 1][0];
                    B2 = arrIntervals[i + 1][1];
                    Calculations(A1,A2,B1,B2);
                    richTextBoxLog.Text += "Множення " + (i + 1).ToString() + ": [ "
                                            + A1.ToString() + " , " + A2.ToString() + " ] та [ "
                                            + B1.ToString() + " , " + B2.ToString() + " ]"+ Environment.NewLine;
                    richTextBoxLog.Text += "Проміжний інтервал: [ " + C1.ToString() + " , " + C2.ToString() + " ]" + Environment.NewLine;
                    arrIntervals[i + 1][0] = C1;
                    arrIntervals[i + 1][1] = C2;
                    if (i== counterMain - 2)
                    {
                        richTextBoxLog.Text += "ВІДПОВІДЬ:\tІнтервал С [ " + C1.ToString() + " , " + C2.ToString() + " ]" +Environment.NewLine;
                        textBoxResult.Text = "[" + C1.ToString() + ", " + C2.ToString() + "]";
                        textBoxResult.BackColor = LightGreen;
                    }
                }
            }
        }
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            AllFieldsGreen();
            if (!radioButtonIntervalB.Checked
                && !radioButtonBin8.Checked)
            {
                if (!NumericInputA1)
                {
                    if (textBoxA1.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У А1 пусто" + Environment.NewLine;
                        textBoxA1.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У А1 введено не число" + Environment.NewLine;
                        textBoxA1.BackColor = LightRed;
                    }
                }
                else
                {
                    A1 = Convert.ToDouble(textBoxA1.Text);
                }
                if (!NumericInputA2)
                {
                    if (textBoxA2.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У А2 пусто" + Environment.NewLine;
                        textBoxA2.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У А2 введено не число" + Environment.NewLine;
                        textBoxA2.BackColor = LightRed;
                    }
                }
                else
                {
                    A2 = Convert.ToDouble(textBoxA2.Text);
                }
            }
            
            if (!radioButtonIntervalA.Checked
                && !radioButtonBin8.Checked)
            {
                if (!NumericInputB1)
                {
                    if (textBoxB1.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У B1 пусто" + Environment.NewLine;
                        textBoxB1.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У В1 введено не число" + Environment.NewLine;
                        textBoxB1.BackColor = LightRed;
                    }
                }
                else
                {
                    B1 = Convert.ToDouble(textBoxB1.Text);
                }
                if (!NumericInputB2)
                {
                    if (textBoxB2.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У B2 пусто" + Environment.NewLine;
                        textBoxB2.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У В2 введено не число" + Environment.NewLine;
                        textBoxB2.BackColor = LightRed;
                    }
                }
                else
                {
                    B2 = Convert.ToDouble(textBoxB2.Text);
                }
            }
            
            if (A1>A2)
            {
                richTextBoxLog.Text += "Помилка: Граничне значення А1 > A2" + Environment.NewLine;
                textBoxA1.BackColor = LightRed;
                textBoxA2.BackColor = LightRed;
            }

            if (B1>B2)
            {
                richTextBoxLog.Text += "Помилка: Граничне значення B1 > B2" + Environment.NewLine;
                textBoxB1.BackColor = LightRed;
                textBoxB2.BackColor = LightRed;
            }

            if (radioButtonBin1.Checked||
                radioButtonBin2.Checked ||
                radioButtonBin3.Checked ||
                radioButtonBin4.Checked ||
                radioButtonBin5.Checked ||
                radioButtonBin6.Checked ||
                radioButtonBin7.Checked ||
                radioButtonBin8.Checked )
            {
                radioButtonIntervalB.Enabled = false;
                radioButtonIntervalA.Enabled = false;
                textBoxConstNumber.Enabled = false;
            }
            else
            {
                radioButtonIntervalB.Enabled = true;
                radioButtonIntervalA.Enabled = true;
                textBoxConstNumber.Enabled = true;
            }

            //
            //Перевірка для радіокнопок
            //
            if (!radioButtonBin1.Checked &&
                !radioButtonBin2.Checked &&
                !radioButtonBin3.Checked &&
                !radioButtonBin4.Checked &&
                !radioButtonBin5.Checked &&
                !radioButtonUnary1.Checked &&
                !radioButtonBin6.Checked &&
                !radioButtonUnary3.Checked &&
                !radioButtonUnary4.Checked &&
                !radioButtonUnary5.Checked &&
                !radioButtonUnary6.Checked &&
                !radioButtonBin8.Checked &&
                !radioButtonUnary2.Checked &&
                !radioButtonBin7.Checked)
            {
                richTextBoxLog.Text += "Помилка: Не обрана операція" + Environment.NewLine;
                groupBoxOperations.BackColor = LightRed;
                groupBoxAB.BackColor = LightRed;
                textBoxConstNumber.BackColor = LightRed;
                textBoxCounter.BackColor = LightRed;
                textBoxMultiplyLeft.BackColor = LightRed;
                textBoxMultiplyRight.BackColor = LightRed;
                textBoxConstNumber.Enabled = false;
                radioButtonIntervalA.Enabled = false;
                radioButtonIntervalB.Enabled = false;
            }
            //
            //Перевірки для радіокнопок бінарних операцій
            //
            else if (radioButtonBin4.Checked)
            {
                if (B1 == 0 || B2 == 0)
                {
                    richTextBoxLog.Text += "Помилка: Ділення на нуль неможливе" + Environment.NewLine;
                    textBoxB1.BackColor = LightRed;
                    textBoxB2.BackColor = LightRed;
                }
                if (A1 < 0 || A2 < 0 || B1 < 0 || B2 < 0)
                {
                    richTextBoxLog.Text += "Помилка: Інтервали мають бути не невід'ємними (A,B Є R+)" + Environment.NewLine;
                    textBoxA1.BackColor = LightRed;
                    textBoxA2.BackColor = LightRed;
                    textBoxB1.BackColor = LightRed;
                    textBoxB2.BackColor = LightRed;
                }

            }
            else if (radioButtonBin5.Checked)
            {
                if (B1 == 0 || B2 == 0)
                {
                    richTextBoxLog.Text += "Помилка: Ділення на нуль неможливе" + Environment.NewLine;
                    textBoxB1.BackColor = LightRed;
                    textBoxB2.BackColor = LightRed;
                }
            }
            else if (radioButtonBin8.Checked)
            {
                textBoxA1.BackColor = LightGreen;
                textBoxA2.BackColor = LightGreen;
                textBoxB1.BackColor = LightGreen;
                textBoxB2.BackColor = LightGreen;
                if (!NumericInputCounter)
                {
                    if (textBoxCounter.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: У textBoxCounter пусто" + Environment.NewLine;
                        textBoxCounter.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Помилка: У textBoxCounter введено не ціле число" + Environment.NewLine;
                        textBoxCounter.BackColor = LightRed;
                    }
                }
                else
                {
                    counterMain = Convert.ToInt32(textBoxCounter.Text);
                    if (counterMain < 2)
                    {
                        richTextBoxLog.Text += "Помилка: У textBoxCounter введено число < 2" + Environment.NewLine;
                        textBoxCounter.BackColor = LightRed;
                    }
                    else
                    {
                        richTextBoxLog.Text += "Натисніть ОК, щоб продовжити" + Environment.NewLine;
                        buttonCounterOK.BackColor = LightRed;
                    }
                }
                
            }
            //
            //Перевірки для радіокнопок унарних операцій
            //
            else if (radioButtonUnary1.Checked ||
                    radioButtonUnary2.Checked ||
                    radioButtonUnary3.Checked ||
                    radioButtonUnary4.Checked ||
                    radioButtonUnary5.Checked ||
                    radioButtonUnary6.Checked)
            {
                radioButtonIntervalA.Enabled = true;
                radioButtonIntervalB.Enabled = true;
                if (!radioButtonIntervalA.Checked &&
                    !radioButtonIntervalB.Checked)
                {
                    richTextBoxLog.Text += "Помилка: Не обраний інтервал для унарної операції" + Environment.NewLine;
                    groupBoxAB.BackColor = LightRed;
                }
                else
                {
                    if (radioButtonIntervalA.Checked)
                    {
                        textBoxB1.BackColor = LightGreen;
                        textBoxB2.BackColor = LightGreen;
                    }
                    if (radioButtonIntervalB.Checked)
                    {
                        textBoxA1.BackColor = LightGreen;
                        textBoxA2.BackColor = LightGreen;
                    }
                }

                if (radioButtonUnary2.Checked)
                {
                    if (radioButtonIntervalA.Checked)
                    {
                        if (A1==0)
                        {
                            richTextBoxLog.Text += "Помилка: A1 не може дорівнювати нулю" + Environment.NewLine;
                            textBoxA1.BackColor = LightRed;
                        }
                        if (A2 == 0)
                        {
                            richTextBoxLog.Text += "Помилка: A2 не може дорівнювати нулю" + Environment.NewLine;
                            textBoxA2.BackColor = LightRed;
                        }
                        if ((A1>0 && A2<0) || (A1<0 && A2>0))
                        {
                            richTextBoxLog.Text += "Помилка: Границі інтервалу А мають різні знаки" + Environment.NewLine;
                            textBoxA1.BackColor = LightRed;
                            textBoxA2.BackColor = LightRed;
                        }
                    }
                    if (radioButtonIntervalB.Checked)
                    {
                        if (B1 == 0)
                        {
                            richTextBoxLog.Text += "Помилка: B1 не може дорівнювати нулю" + Environment.NewLine;
                            textBoxB1.BackColor = LightRed;
                        }
                        if (B2 == 0)
                        {
                            richTextBoxLog.Text += "Помилка: B2 не може дорівнювати нулю" + Environment.NewLine;
                            textBoxB2.BackColor = LightRed;
                        }
                        if ((B1 > 0 && B2 < 0) || (B1 < 0 && B2 > 0))
                        {
                            richTextBoxLog.Text += "Помилка: Границі інтервалу B мають різні знаки" + Environment.NewLine;
                            textBoxB1.BackColor = LightRed;
                            textBoxB2.BackColor = LightRed;
                        }
                    }
                }
                else
                {
                    //radioButtonIntervalA.Enabled = false;
                    //radioButtonIntervalB.Enabled = false;
                }

                if (radioButtonUnary3.Checked ||
                        radioButtonUnary4.Checked ||
                        radioButtonUnary5.Checked ||
                        radioButtonUnary6.Checked)
                {
                    if (textBoxConstNumber.Text == "")
                    {
                        richTextBoxLog.Text += "Помилка: Чітке число k не введене" + Environment.NewLine;
                        textBoxConstNumber.BackColor = LightRed;
                    }
                    else if (!double.TryParse(textBoxConstNumber.Text, out double result))
                    {
                        richTextBoxLog.Text += "Помилка: Введене чітке число k не є число" + Environment.NewLine;
                        textBoxConstNumber.BackColor = LightRed;
                    }
                    else
                    {
                        if (radioButtonUnary6.Checked)
                        {
                            if (K==0)
                            {
                                richTextBoxLog.Text += "Помилка: Ділення на нуль неможливе" + Environment.NewLine;
                                textBoxConstNumber.BackColor = LightRed;
                            }
                        }
                        else
                        {
                            K = Convert.ToDouble(textBoxConstNumber.Text);
                        }
                    }
                }
            }

            if (radioButtonUnary3.Checked ||
                radioButtonUnary4.Checked ||
                radioButtonUnary5.Checked ||
                radioButtonUnary6.Checked)
            {
                textBoxConstNumber.Enabled = true;
            }
            else
            {
                textBoxConstNumber.Enabled = false;
            }

            if (textBoxA1.BackColor != LightRed &&
               textBoxA2.BackColor != LightRed &&
               textBoxB1.BackColor != LightRed &&
               textBoxB2.BackColor != LightRed &&
               groupBoxOperations.BackColor != LightRed &&
               textBoxConstNumber.BackColor != LightRed &&
               groupBoxAB.BackColor != LightRed &&
               textBoxCounter.BackColor !=LightRed &&
               textBoxMultiplyLeft.BackColor != LightRed &&
               textBoxMultiplyRight.BackColor !=LightRed&&
               buttonCounterOK.BackColor!=LightRed)
            {
                Calculations(A1, A2, B1, B2);

                //Выбираем перо "myPen" черного цвета Black
                //толщиной в 1 пиксель:
                Pen penCountur = new Pen(Color.Black, 1);
                Pen penAInterval = new Pen(Color.Blue, 3);
                Pen penBInterval = new Pen(Color.Red, 3);
                Pen penCInterval = new Pen(Color.Green, 3);
                //Объявляем объект "g" класса Graphics и предоставляем
                //ему возможность рисования на pictureBox1:
                Graphics graphicMain = pictureBoxGraphic.CreateGraphics();
                graphicMain.Clear(Color.White);
                // Создаем объекты для закрашивания фигур
                SolidBrush xCoord = new SolidBrush(Color.Black);
                SolidBrush yCoord = new SolidBrush(Color.Black);
                int x = 200;//x=0
                int y = 200;//y=0 +інверсія!!!
                graphicMain.DrawLine(penCountur, new Point(x, y - 180), new Point(x, y + 180));//координата y
                graphicMain.DrawLine(penCountur, new Point(x - 180, y - 100), new Point(x + 180, y - 100));//координата x1
                graphicMain.DrawLine(penCountur, new Point(x - 180, y), new Point(x + 180, y));//координата x2
                graphicMain.DrawLine(penCountur, new Point(x - 180, y + 100), new Point(x + 180, y + 100));//координата x3

                graphicMain.DrawLine(penCountur, new Point(x, y - 180), new Point(x + 5, y - 170));//стрелочки
                graphicMain.DrawLine(penCountur, new Point(x, y - 180), new Point(x - 5, y - 170));
                graphicMain.DrawLine(penCountur, new Point(x + 180, y - 100), new Point(x + 170, y - 95));//стрелочки
                graphicMain.DrawLine(penCountur, new Point(x + 180, y - 100), new Point(x + 170, y - 105));
                graphicMain.DrawLine(penCountur, new Point(x + 180, y), new Point(x + 170, y + 5));//стрелочки
                graphicMain.DrawLine(penCountur, new Point(x + 180, y), new Point(x + 170, y - 5));
                graphicMain.DrawLine(penCountur, new Point(x + 180, y + 100), new Point(x + 170, y + 95));//стрелочки
                graphicMain.DrawLine(penCountur, new Point(x + 180, y + 100), new Point(x + 170, y + 105));

                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                string drawStringA = "A:";
                string drawStringB = "B:";
                string drawStringC = "Результат С:";
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                int A1draw = (int)A1;
                int A2draw = (int)A2;
                int B1draw = (int)B1;
                int B2draw = (int)B2;
                int C1draw = (int)C1;
                int C2draw = (int)C2;

                graphicMain.DrawString(drawStringC, drawFont, drawBrush, x-180, y+75, drawFormat);
                graphicMain.DrawString(drawStringB, drawFont, drawBrush, x - 180, y - 25, drawFormat);
                graphicMain.DrawString(drawStringA, drawFont, drawBrush, x - 180, y - 125, drawFormat);
                graphicMain.DrawString("0", drawFont, drawBrush, x-15, y + 85, drawFormat);
                graphicMain.DrawString("0", drawFont, drawBrush, x-15, y - 15, drawFormat);
                graphicMain.DrawString("0", drawFont, drawBrush, x-15, y -115, drawFormat);

                graphicMain.DrawLine(penAInterval, new Point(x+ A1draw, y - 100), new Point(x+ A2draw, y - 100));//A
                graphicMain.DrawLine(penAInterval, new Point(x + A1draw, y - 95), new Point(x + A1draw, y - 105));//A
                graphicMain.DrawLine(penAInterval, new Point(x + A2draw, y - 95), new Point(x + A2draw, y - 105));//A
                graphicMain.DrawLine(penBInterval, new Point(x+B1draw, y), new Point(x+B2draw, y));//B
                graphicMain.DrawLine(penBInterval, new Point(x + B1draw, y-5), new Point(x + B1draw, y+5));//B
                graphicMain.DrawLine(penBInterval, new Point(x + B2draw, y-5), new Point(x + B2draw, y+5));//B
                graphicMain.DrawLine(penCInterval, new Point(x+C1draw, y + 100), new Point(x+ C2draw, y + 100));//C
                graphicMain.DrawLine(penCInterval, new Point(x + C1draw, y + 95), new Point(x + C1draw, y + 105));//C
                graphicMain.DrawLine(penCInterval, new Point(x + C2draw, y + 95), new Point(x + C2draw, y + 105));//C

                textBoxResult.BackColor = LightGreen;
                textBoxResult.Text = "[" + C1.ToString() + ", " + C2.ToString() + "]";
                if (radioButtonUnary1.Checked ||
                    radioButtonUnary2.Checked ||
                    radioButtonUnary3.Checked ||
                    radioButtonUnary4.Checked ||
                    radioButtonUnary5.Checked ||
                    radioButtonUnary6.Checked)
                {
                    if (radioButtonUnary1.Checked)
                    {
                        richTextBoxLog.Text += "\tВідображення:" + Environment.NewLine;
                    }
                    if (radioButtonUnary2.Checked)
                    {
                        richTextBoxLog.Text += "\tІнверсія:" + Environment.NewLine;
                    }
                    if (radioButtonUnary3.Checked)
                    {
                        richTextBoxLog.Text += "\tДодавання на k:" + Environment.NewLine;
                    }
                    if (radioButtonUnary4.Checked)
                    {
                        richTextBoxLog.Text += "\tВіднімання на k:" + Environment.NewLine;
                    }
                    if (radioButtonUnary5.Checked)
                    {
                        richTextBoxLog.Text += "\tМноження на k:" + Environment.NewLine;
                    }
                    if (radioButtonUnary6.Checked)
                    {
                        richTextBoxLog.Text += "\tДілення на k:" + Environment.NewLine;
                    }

                    if (radioButtonIntervalA.Checked)
                    {
                        richTextBoxLog.Text += "Умова:\t\tІнтервал A [ " + A1.ToString() + " , " + A2.ToString() + " ]" + Environment.NewLine;
                        richTextBoxLog.Text += "ВІДПОВІДЬ:\tІнтервал С [ " + C1.ToString() + " , " + C2.ToString() + " ]" + Environment.NewLine + Environment.NewLine;
                    }
                    if (radioButtonIntervalB.Checked)
                    {
                        richTextBoxLog.Text += "Умова:\t\tІнтервал B [ " + B1.ToString() + " , " + B2.ToString() + " ]" + Environment.NewLine;
                        richTextBoxLog.Text += "ВІДПОВІДЬ:\tІнтервал С [ " + C1.ToString() + " , " + C2.ToString() + " ]" + Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    if (radioButtonBin1.Checked)
                    {
                        richTextBoxLog.Text += "\tДодавання:" + Environment.NewLine;
                    }
                    if (radioButtonBin2.Checked)
                    {
                        richTextBoxLog.Text += "\tВіднімання:" + Environment.NewLine;
                    }
                    if (radioButtonBin3.Checked)
                    {
                        richTextBoxLog.Text += "\tМноження:" + Environment.NewLine;
                    }
                    if (radioButtonBin4.Checked)
                    {
                        richTextBoxLog.Text += "\tДілення:" + Environment.NewLine;
                    }
                    if (radioButtonBin5.Checked)
                    {
                        richTextBoxLog.Text += "\tДілення (гіпотеза):" + Environment.NewLine;
                    }
                    if (radioButtonBin6.Checked)
                    {
                        richTextBoxLog.Text += "\tМаксимум:" + Environment.NewLine;
                    }
                    if (radioButtonBin7.Checked)
                    {
                        richTextBoxLog.Text += "\tМінімум:" + Environment.NewLine;
                    }

                    richTextBoxLog.Text += "Умова:\t\tІнтервал A [ " + A1.ToString() + " , " + A2.ToString() + " ]" + Environment.NewLine;
                    richTextBoxLog.Text += "\t\tІнтервал B [ " + B1.ToString() + " , " + B2.ToString() + " ]" + Environment.NewLine;
                    richTextBoxLog.Text += "ВІДПОВІДЬ:\tІнтервал С [ " + C1.ToString() + " , " + C2.ToString() + " ]" + Environment.NewLine + Environment.NewLine;
                }
                
            }
            else
            {
                textBoxResult.Text = "Неможливо порахувати";
                textBoxResult.BackColor = LightRed;
            }

        }
        private void buttonDischarge_Click(object sender, EventArgs e)
        {
            DischargeAllFields();
        }
        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OperationsWithIntervalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
