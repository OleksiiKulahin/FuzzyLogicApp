namespace ОНЛ_5
{
    partial class ModelingOfFuzzyNumbersWithFunctions
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
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.pictureBoxFunctionTemplate = new System.Windows.Forms.PictureBox();
            this.comboBoxFunctions = new System.Windows.Forms.ComboBox();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.buttonRecommendations = new System.Windows.Forms.Button();
            this.labelParameter3 = new System.Windows.Forms.Label();
            this.textBoxParameter4 = new System.Windows.Forms.TextBox();
            this.labelParameter2 = new System.Windows.Forms.Label();
            this.textBoxParameter3 = new System.Windows.Forms.TextBox();
            this.labelParameter4 = new System.Windows.Forms.Label();
            this.textBoxParameter2 = new System.Windows.Forms.TextBox();
            this.labelParameter1 = new System.Windows.Forms.Label();
            this.textBoxParameter1 = new System.Windows.Forms.TextBox();
            this.groupBoxInputX = new System.Windows.Forms.GroupBox();
            this.labelResultX = new System.Windows.Forms.Label();
            this.labelInputX = new System.Windows.Forms.Label();
            this.textBoxResultX = new System.Windows.Forms.TextBox();
            this.buttonFindY = new System.Windows.Forms.Button();
            this.textBoxInputX = new System.Windows.Forms.TextBox();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxGraphic = new System.Windows.Forms.GroupBox();
            this.pictureBoxGraphic = new System.Windows.Forms.PictureBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonDispose = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.numericUpDownScale = new System.Windows.Forms.NumericUpDown();
            this.labelScale = new System.Windows.Forms.Label();
            this.groupBoxFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunctionTemplate)).BeginInit();
            this.groupBoxParameters.SuspendLayout();
            this.groupBoxInputX.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.pictureBoxFunctionTemplate);
            this.groupBoxFunctions.Controls.Add(this.comboBoxFunctions);
            this.groupBoxFunctions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(240, 126);
            this.groupBoxFunctions.TabIndex = 0;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Оберіть функцію належності";
            // 
            // pictureBoxFunctionTemplate
            // 
            this.pictureBoxFunctionTemplate.InitialImage = global::ОНЛ_5.Properties.Resources.Сигмоїдна_функція_належності;
            this.pictureBoxFunctionTemplate.Location = new System.Drawing.Point(63, 47);
            this.pictureBoxFunctionTemplate.Name = "pictureBoxFunctionTemplate";
            this.pictureBoxFunctionTemplate.Size = new System.Drawing.Size(116, 73);
            this.pictureBoxFunctionTemplate.TabIndex = 1;
            this.pictureBoxFunctionTemplate.TabStop = false;
            // 
            // comboBoxFunctions
            // 
            this.comboBoxFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctions.FormattingEnabled = true;
            this.comboBoxFunctions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxFunctions.Items.AddRange(new object[] {
            "Сигмоїдна функція належності",
            "Різниця між сигмоїдними функціями належності",
            "Лапласівська функція належності",
            "Симетрична Гаусівська фунція належності"});
            this.comboBoxFunctions.Location = new System.Drawing.Point(7, 20);
            this.comboBoxFunctions.Name = "comboBoxFunctions";
            this.comboBoxFunctions.Size = new System.Drawing.Size(227, 21);
            this.comboBoxFunctions.TabIndex = 0;
            this.comboBoxFunctions.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunctions_SelectedIndexChanged);
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.buttonRecommendations);
            this.groupBoxParameters.Controls.Add(this.labelParameter3);
            this.groupBoxParameters.Controls.Add(this.textBoxParameter4);
            this.groupBoxParameters.Controls.Add(this.labelParameter2);
            this.groupBoxParameters.Controls.Add(this.textBoxParameter3);
            this.groupBoxParameters.Controls.Add(this.labelParameter4);
            this.groupBoxParameters.Controls.Add(this.textBoxParameter2);
            this.groupBoxParameters.Controls.Add(this.labelParameter1);
            this.groupBoxParameters.Controls.Add(this.textBoxParameter1);
            this.groupBoxParameters.Location = new System.Drawing.Point(12, 144);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(240, 103);
            this.groupBoxParameters.TabIndex = 1;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Уведіть параметри функції належності";
            // 
            // buttonRecommendations
            // 
            this.buttonRecommendations.Location = new System.Drawing.Point(10, 19);
            this.buttonRecommendations.Name = "buttonRecommendations";
            this.buttonRecommendations.Size = new System.Drawing.Size(224, 23);
            this.buttonRecommendations.TabIndex = 4;
            this.buttonRecommendations.Text = "Рекомендовані параметри";
            this.buttonRecommendations.UseVisualStyleBackColor = true;
            this.buttonRecommendations.Visible = false;
            this.buttonRecommendations.Click += new System.EventHandler(this.buttonRecommendations_Click);
            // 
            // labelParameter3
            // 
            this.labelParameter3.AutoSize = true;
            this.labelParameter3.Location = new System.Drawing.Point(7, 80);
            this.labelParameter3.Name = "labelParameter3";
            this.labelParameter3.Size = new System.Drawing.Size(35, 13);
            this.labelParameter3.TabIndex = 2;
            this.labelParameter3.Text = "label3";
            this.labelParameter3.Visible = false;
            // 
            // textBoxParameter4
            // 
            this.textBoxParameter4.Location = new System.Drawing.Point(174, 77);
            this.textBoxParameter4.Name = "textBoxParameter4";
            this.textBoxParameter4.Size = new System.Drawing.Size(60, 20);
            this.textBoxParameter4.TabIndex = 3;
            this.textBoxParameter4.Visible = false;
            // 
            // labelParameter2
            // 
            this.labelParameter2.AutoSize = true;
            this.labelParameter2.Location = new System.Drawing.Point(135, 54);
            this.labelParameter2.Name = "labelParameter2";
            this.labelParameter2.Size = new System.Drawing.Size(35, 13);
            this.labelParameter2.TabIndex = 1;
            this.labelParameter2.Text = "label2";
            this.labelParameter2.Visible = false;
            // 
            // textBoxParameter3
            // 
            this.textBoxParameter3.Location = new System.Drawing.Point(48, 77);
            this.textBoxParameter3.Name = "textBoxParameter3";
            this.textBoxParameter3.Size = new System.Drawing.Size(60, 20);
            this.textBoxParameter3.TabIndex = 2;
            this.textBoxParameter3.Visible = false;
            // 
            // labelParameter4
            // 
            this.labelParameter4.AutoSize = true;
            this.labelParameter4.Location = new System.Drawing.Point(135, 80);
            this.labelParameter4.Name = "labelParameter4";
            this.labelParameter4.Size = new System.Drawing.Size(35, 13);
            this.labelParameter4.TabIndex = 0;
            this.labelParameter4.Text = "label4";
            this.labelParameter4.Visible = false;
            // 
            // textBoxParameter2
            // 
            this.textBoxParameter2.Location = new System.Drawing.Point(174, 51);
            this.textBoxParameter2.Name = "textBoxParameter2";
            this.textBoxParameter2.Size = new System.Drawing.Size(60, 20);
            this.textBoxParameter2.TabIndex = 1;
            this.textBoxParameter2.Visible = false;
            // 
            // labelParameter1
            // 
            this.labelParameter1.AutoSize = true;
            this.labelParameter1.Location = new System.Drawing.Point(7, 54);
            this.labelParameter1.Name = "labelParameter1";
            this.labelParameter1.Size = new System.Drawing.Size(35, 13);
            this.labelParameter1.TabIndex = 0;
            this.labelParameter1.Text = "label1";
            this.labelParameter1.Visible = false;
            // 
            // textBoxParameter1
            // 
            this.textBoxParameter1.Location = new System.Drawing.Point(48, 51);
            this.textBoxParameter1.Name = "textBoxParameter1";
            this.textBoxParameter1.Size = new System.Drawing.Size(60, 20);
            this.textBoxParameter1.TabIndex = 0;
            this.textBoxParameter1.Visible = false;
            // 
            // groupBoxInputX
            // 
            this.groupBoxInputX.Controls.Add(this.labelResultX);
            this.groupBoxInputX.Controls.Add(this.labelInputX);
            this.groupBoxInputX.Controls.Add(this.textBoxResultX);
            this.groupBoxInputX.Controls.Add(this.buttonFindY);
            this.groupBoxInputX.Controls.Add(this.textBoxInputX);
            this.groupBoxInputX.Location = new System.Drawing.Point(12, 253);
            this.groupBoxInputX.Name = "groupBoxInputX";
            this.groupBoxInputX.Size = new System.Drawing.Size(240, 79);
            this.groupBoxInputX.TabIndex = 2;
            this.groupBoxInputX.TabStop = false;
            this.groupBoxInputX.Text = "Уведіть х для значення функції належності";
            // 
            // labelResultX
            // 
            this.labelResultX.AutoSize = true;
            this.labelResultX.Location = new System.Drawing.Point(6, 48);
            this.labelResultX.Name = "labelResultX";
            this.labelResultX.Size = new System.Drawing.Size(72, 13);
            this.labelResultX.TabIndex = 4;
            this.labelResultX.Text = "Значення f(x)";
            // 
            // labelInputX
            // 
            this.labelInputX.AutoSize = true;
            this.labelInputX.Location = new System.Drawing.Point(22, 22);
            this.labelInputX.Name = "labelInputX";
            this.labelInputX.Size = new System.Drawing.Size(56, 13);
            this.labelInputX.TabIndex = 3;
            this.labelInputX.Text = "Введіть х:";
            // 
            // textBoxResultX
            // 
            this.textBoxResultX.Enabled = false;
            this.textBoxResultX.Location = new System.Drawing.Point(84, 45);
            this.textBoxResultX.Name = "textBoxResultX";
            this.textBoxResultX.ReadOnly = true;
            this.textBoxResultX.Size = new System.Drawing.Size(149, 20);
            this.textBoxResultX.TabIndex = 2;
            // 
            // buttonFindY
            // 
            this.buttonFindY.Enabled = false;
            this.buttonFindY.Location = new System.Drawing.Point(173, 17);
            this.buttonFindY.Name = "buttonFindY";
            this.buttonFindY.Size = new System.Drawing.Size(60, 23);
            this.buttonFindY.TabIndex = 1;
            this.buttonFindY.Text = "Знайти";
            this.buttonFindY.UseVisualStyleBackColor = true;
            this.buttonFindY.Click += new System.EventHandler(this.buttonFindY_Click);
            // 
            // textBoxInputX
            // 
            this.textBoxInputX.Enabled = false;
            this.textBoxInputX.Location = new System.Drawing.Point(84, 19);
            this.textBoxInputX.Name = "textBoxInputX";
            this.textBoxInputX.Size = new System.Drawing.Size(83, 20);
            this.textBoxInputX.TabIndex = 0;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.richTextBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 338);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(240, 126);
            this.groupBoxLog.TabIndex = 3;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Лог";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(7, 20);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(226, 100);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // groupBoxGraphic
            // 
            this.groupBoxGraphic.Controls.Add(this.pictureBoxGraphic);
            this.groupBoxGraphic.Location = new System.Drawing.Point(259, 13);
            this.groupBoxGraphic.Name = "groupBoxGraphic";
            this.groupBoxGraphic.Size = new System.Drawing.Size(535, 451);
            this.groupBoxGraphic.TabIndex = 4;
            this.groupBoxGraphic.TabStop = false;
            this.groupBoxGraphic.Text = "Графічне представлення";
            // 
            // pictureBoxGraphic
            // 
            this.pictureBoxGraphic.Location = new System.Drawing.Point(7, 19);
            this.pictureBoxGraphic.Name = "pictureBoxGraphic";
            this.pictureBoxGraphic.Size = new System.Drawing.Size(522, 426);
            this.pictureBoxGraphic.TabIndex = 0;
            this.pictureBoxGraphic.TabStop = false;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(381, 470);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 30);
            this.buttonCalculate.TabIndex = 5;
            this.buttonCalculate.Text = "Обрахувати";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonDispose
            // 
            this.buttonDispose.Location = new System.Drawing.Point(487, 470);
            this.buttonDispose.Name = "buttonDispose";
            this.buttonDispose.Size = new System.Drawing.Size(100, 30);
            this.buttonDispose.TabIndex = 6;
            this.buttonDispose.Text = "Скинути";
            this.buttonDispose.UseVisualStyleBackColor = true;
            this.buttonDispose.Click += new System.EventHandler(this.buttonDispose_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(593, 470);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(100, 30);
            this.buttonClearLog.TabIndex = 7;
            this.buttonClearLog.Text = "Відчистити лог";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(699, 470);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // numericUpDownScale
            // 
            this.numericUpDownScale.DecimalPlaces = 4;
            this.numericUpDownScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownScale.Location = new System.Drawing.Point(317, 477);
            this.numericUpDownScale.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownScale.Name = "numericUpDownScale";
            this.numericUpDownScale.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownScale.TabIndex = 1;
            this.numericUpDownScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScale.ValueChanged += new System.EventHandler(this.numericUpDownScale_ValueChanged);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(255, 479);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(56, 13);
            this.labelScale.TabIndex = 2;
            this.labelScale.Text = "Масштаб:";
            // 
            // ModelingOfFuzzyNumbersWithFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 506);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.buttonDispose);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.groupBoxGraphic);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxInputX);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.groupBoxFunctions);
            this.Name = "ModelingOfFuzzyNumbersWithFunctions";
            this.Text = "Моделювання нечітких чисел із різними функціями належності";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModelingOfFuzzyNumbersWithFunctions_FormClosed);
            this.Load += new System.EventHandler(this.ModelingOfFuzzyNumbersWithFunctions_Load);
            this.ResizeEnd += new System.EventHandler(this.ModelingOfFuzzyNumbersWithFunctions_ResizeEnd);
            this.groupBoxFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunctionTemplate)).EndInit();
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            this.groupBoxInputX.ResumeLayout(false);
            this.groupBoxInputX.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxGraphic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.PictureBox pictureBoxFunctionTemplate;
        private System.Windows.Forms.ComboBox comboBoxFunctions;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.Label labelParameter3;
        private System.Windows.Forms.TextBox textBoxParameter4;
        private System.Windows.Forms.Label labelParameter2;
        private System.Windows.Forms.TextBox textBoxParameter3;
        private System.Windows.Forms.Label labelParameter4;
        private System.Windows.Forms.TextBox textBoxParameter2;
        private System.Windows.Forms.Label labelParameter1;
        private System.Windows.Forms.TextBox textBoxParameter1;
        private System.Windows.Forms.GroupBox groupBoxInputX;
        private System.Windows.Forms.Label labelResultX;
        private System.Windows.Forms.Label labelInputX;
        private System.Windows.Forms.TextBox textBoxResultX;
        private System.Windows.Forms.Button buttonFindY;
        private System.Windows.Forms.TextBox textBoxInputX;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.GroupBox groupBoxGraphic;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonDispose;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxGraphic;
        private System.Windows.Forms.Button buttonRecommendations;
        private System.Windows.Forms.NumericUpDown numericUpDownScale;
        private System.Windows.Forms.Label labelScale;
    }
}