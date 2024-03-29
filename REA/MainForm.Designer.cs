﻿namespace REA
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.labelRooms = new System.Windows.Forms.Label();
            this.labelStudy = new System.Windows.Forms.Label();
            this.cbStudy = new System.Windows.Forms.ComboBox();
            this.labelStore = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbEstates = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCost = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLegal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to REA";
            // 
            // cbEstate
            // 
            this.cbEstate.FormattingEnabled = true;
            this.cbEstate.Location = new System.Drawing.Point(94, 59);
            this.cbEstate.Name = "cbEstate";
            this.cbEstate.Size = new System.Drawing.Size(121, 21);
            this.cbEstate.TabIndex = 1;
            this.cbEstate.SelectedIndexChanged += new System.EventHandler(this.cbEstate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type of Estate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type of Building";
            // 
            // cbBuilding
            // 
            this.cbBuilding.FormattingEnabled = true;
            this.cbBuilding.Location = new System.Drawing.Point(338, 59);
            this.cbBuilding.Name = "cbBuilding";
            this.cbBuilding.Size = new System.Drawing.Size(121, 21);
            this.cbBuilding.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(488, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(541, 59);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(247, 20);
            this.txtStreet.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(488, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Street";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Zip Code";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(541, 88);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(80, 20);
            this.txtZip.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(628, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(658, 88);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(130, 20);
            this.txtCity.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Country";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(541, 116);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 13;
            // 
            // txtRooms
            // 
            this.txtRooms.Location = new System.Drawing.Point(110, 139);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(55, 20);
            this.txtRooms.TabIndex = 14;
            // 
            // labelRooms
            // 
            this.labelRooms.AutoSize = true;
            this.labelRooms.Location = new System.Drawing.Point(12, 142);
            this.labelRooms.Name = "labelRooms";
            this.labelRooms.Size = new System.Drawing.Size(92, 13);
            this.labelRooms.TabIndex = 15;
            this.labelRooms.Text = "Number of Rooms";
            // 
            // labelStudy
            // 
            this.labelStudy.AutoSize = true;
            this.labelStudy.Location = new System.Drawing.Point(260, 142);
            this.labelStudy.Name = "labelStudy";
            this.labelStudy.Size = new System.Drawing.Size(71, 13);
            this.labelStudy.TabIndex = 16;
            this.labelStudy.Text = "Field of Study";
            // 
            // cbStudy
            // 
            this.cbStudy.FormattingEnabled = true;
            this.cbStudy.Location = new System.Drawing.Point(338, 137);
            this.cbStudy.Name = "cbStudy";
            this.cbStudy.Size = new System.Drawing.Size(121, 21);
            this.cbStudy.TabIndex = 17;
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Location = new System.Drawing.Point(276, 186);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(55, 13);
            this.labelStore.TabIndex = 18;
            this.labelStore.Text = "Shop type";
            // 
            // cbStore
            // 
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(338, 183);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(121, 21);
            this.cbStore.TabIndex = 19;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(43, 186);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(61, 13);
            this.labelSize.TabIndex = 20;
            this.labelSize.Text = "Size in m^2";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(110, 183);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(55, 20);
            this.txtSize.TabIndex = 21;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(658, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbEstates
            // 
            this.lbEstates.FormattingEnabled = true;
            this.lbEstates.Location = new System.Drawing.Point(15, 252);
            this.lbEstates.Name = "lbEstates";
            this.lbEstates.Size = new System.Drawing.Size(427, 173);
            this.lbEstates.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label13.Location = new System.Drawing.Point(12, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "List of Estates";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(488, 160);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(109, 13);
            this.labelError.TabIndex = 25;
            this.labelError.Text = "Please fill all the fields";
            this.labelError.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(449, 281);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(449, 310);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(449, 401);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 28;
            this.btnDeleteAll.Text = "Delete all";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(13, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Estate";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(541, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCost
            // 
            this.btnCost.Location = new System.Drawing.Point(449, 252);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(75, 23);
            this.btnCost.TabIndex = 31;
            this.btnCost.Text = "Cost";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Legal Form";
            // 
            // cbLegal
            // 
            this.cbLegal.FormattingEnabled = true;
            this.cbLegal.Location = new System.Drawing.Point(94, 91);
            this.cbLegal.Name = "cbLegal";
            this.cbLegal.Size = new System.Drawing.Size(121, 21);
            this.cbLegal.TabIndex = 33;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbLegal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCost);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbEstates);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.labelStore);
            this.Controls.Add(this.cbStudy);
            this.Controls.Add(this.labelStudy);
            this.Controls.Add(this.labelRooms);
            this.Controls.Add(this.txtRooms);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBuilding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEstate);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEstate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.Label labelRooms;
        private System.Windows.Forms.Label labelStudy;
        private System.Windows.Forms.ComboBox cbStudy;
        private System.Windows.Forms.Label labelStore;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbEstates;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLegal;
    }
}

