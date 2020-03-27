using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОНЛ_5
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        private void buttonOperationsWithIntervals_Click(object sender, EventArgs e)
        {
            OperationsWithIntervalForm operationsWithIntervalForm = new OperationsWithIntervalForm();
            operationsWithIntervalForm.Show();
            this.Hide();
        }

        private void buttonTriangleIntervalsAddition_Click(object sender, EventArgs e)
        {
            OperationsWithTriangleIntervals operationWithTriangleIntervals = new OperationsWithTriangleIntervals();
            operationWithTriangleIntervals.Show();
            this.Hide();
        }

        private void buttonModelingOfFuzzyNumbersWithFunctions_Click(object sender, EventArgs e)
        {
            ModelingOfFuzzyNumbersWithFunctions modelingOfFuzzyNumbers = new ModelingOfFuzzyNumbersWithFunctions();
            modelingOfFuzzyNumbers.Show();
            this.Hide();
        }
    }
}
