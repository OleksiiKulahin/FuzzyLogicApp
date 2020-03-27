namespace ОНЛ_5
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOperationsWithIntervals = new System.Windows.Forms.Button();
            this.buttonOperationWithTriangleIntervals = new System.Windows.Forms.Button();
            this.buttonModelingOfFuzzyNumbersWithFunctions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOperationsWithIntervals
            // 
            this.buttonOperationsWithIntervals.Location = new System.Drawing.Point(13, 13);
            this.buttonOperationsWithIntervals.Name = "buttonOperationsWithIntervals";
            this.buttonOperationsWithIntervals.Size = new System.Drawing.Size(338, 23);
            this.buttonOperationsWithIntervals.TabIndex = 0;
            this.buttonOperationsWithIntervals.Text = "Операції з інтервалами";
            this.buttonOperationsWithIntervals.UseVisualStyleBackColor = true;
            this.buttonOperationsWithIntervals.Click += new System.EventHandler(this.buttonOperationsWithIntervals_Click);
            // 
            // buttonOperationWithTriangleIntervals
            // 
            this.buttonOperationWithTriangleIntervals.Location = new System.Drawing.Point(13, 43);
            this.buttonOperationWithTriangleIntervals.Name = "buttonOperationWithTriangleIntervals";
            this.buttonOperationWithTriangleIntervals.Size = new System.Drawing.Size(338, 23);
            this.buttonOperationWithTriangleIntervals.TabIndex = 1;
            this.buttonOperationWithTriangleIntervals.Text = "Операції з нечіткими числами трикутної форми";
            this.buttonOperationWithTriangleIntervals.UseVisualStyleBackColor = true;
            this.buttonOperationWithTriangleIntervals.Click += new System.EventHandler(this.buttonTriangleIntervalsAddition_Click);
            // 
            // buttonModelingOfFuzzyNumbersWithFunctions
            // 
            this.buttonModelingOfFuzzyNumbersWithFunctions.Location = new System.Drawing.Point(14, 72);
            this.buttonModelingOfFuzzyNumbersWithFunctions.Name = "buttonModelingOfFuzzyNumbersWithFunctions";
            this.buttonModelingOfFuzzyNumbersWithFunctions.Size = new System.Drawing.Size(338, 23);
            this.buttonModelingOfFuzzyNumbersWithFunctions.TabIndex = 2;
            this.buttonModelingOfFuzzyNumbersWithFunctions.Text = "Моделювання нечітких чисел із різними функціями належності";
            this.buttonModelingOfFuzzyNumbersWithFunctions.UseVisualStyleBackColor = true;
            this.buttonModelingOfFuzzyNumbersWithFunctions.Click += new System.EventHandler(this.buttonModelingOfFuzzyNumbersWithFunctions_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 107);
            this.Controls.Add(this.buttonModelingOfFuzzyNumbersWithFunctions);
            this.Controls.Add(this.buttonOperationWithTriangleIntervals);
            this.Controls.Add(this.buttonOperationsWithIntervals);
            this.Name = "MenuForm";
            this.Text = "Оберіть программу";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOperationsWithIntervals;
        private System.Windows.Forms.Button buttonOperationWithTriangleIntervals;
        private System.Windows.Forms.Button buttonModelingOfFuzzyNumbersWithFunctions;
    }
}