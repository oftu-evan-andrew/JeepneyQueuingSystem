namespace JeepneyQueuingSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnUpdatePassengerCount = new Button();
            btnDepartJeepney = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(141, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnUpdatePassengerCount
            // 
            btnUpdatePassengerCount.Location = new Point(33, 212);
            btnUpdatePassengerCount.Name = "btnUpdatePassengerCount";
            btnUpdatePassengerCount.Size = new Size(75, 23);
            btnUpdatePassengerCount.TabIndex = 2;
            btnUpdatePassengerCount.Text = "Update Passenger";
            btnUpdatePassengerCount.UseVisualStyleBackColor = true;
            btnUpdatePassengerCount.Click += btnUpdatePassengerCount_Click;
            // 
            // btnDepartJeepney
            // 
            btnDepartJeepney.Location = new Point(411, 212);
            btnDepartJeepney.Name = "btnDepartJeepney";
            btnDepartJeepney.Size = new Size(75, 23);
            btnDepartJeepney.TabIndex = 3;
            btnDepartJeepney.Text = "Depart";
            btnDepartJeepney.UseVisualStyleBackColor = true;
            btnDepartJeepney.Click += btnDepartJeepney_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 282);
            Controls.Add(btnDepartJeepney);
            Controls.Add(btnUpdatePassengerCount);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnUpdatePassengerCount;
        private Button btnDepartJeepney;
    }
}
