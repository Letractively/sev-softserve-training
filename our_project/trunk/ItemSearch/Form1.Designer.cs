namespace ItemSearch
{
    partial class ItemSearchWin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox_SearchDropList = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Done = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Quantity = new System.Windows.Forms.TextBox();
            this.label_Price = new System.Windows.Forms.Label();
            this.label_Item = new System.Windows.Forms.Label();
            this.comboBox_DimDroplist = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_SearchDropList
            // 
            this.comboBox_SearchDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SearchDropList.FormattingEnabled = true;
            this.comboBox_SearchDropList.Items.AddRange(new object[] {
            "Item Name",
            "Item Description"});
            this.comboBox_SearchDropList.Location = new System.Drawing.Point(145, 13);
            this.comboBox_SearchDropList.Name = "comboBox_SearchDropList";
            this.comboBox_SearchDropList.Size = new System.Drawing.Size(107, 21);
            this.comboBox_SearchDropList.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button_Search
            // 
            this.button_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Search.Location = new System.Drawing.Point(491, 10);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search for item by";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(491, 498);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Done
            // 
            this.button_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Done.Location = new System.Drawing.Point(396, 498);
            this.button_Done.Name = "button_Done";
            this.button_Done.Size = new System.Drawing.Size(75, 23);
            this.button_Done.TabIndex = 5;
            this.button_Done.Text = "Done";
            this.button_Done.UseVisualStyleBackColor = true;
            // 
            // button_Remove
            // 
            this.button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Remove.Location = new System.Drawing.Point(301, 498);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 6;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Quantity);
            this.groupBox1.Controls.Add(this.label_Price);
            this.groupBox1.Controls.Add(this.label_Item);
            this.groupBox1.Controls.Add(this.comboBox_DimDroplist);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // textBox_Quantity
            // 
            this.textBox_Quantity.Location = new System.Drawing.Point(208, 84);
            this.textBox_Quantity.Name = "textBox_Quantity";
            this.textBox_Quantity.Size = new System.Drawing.Size(84, 20);
            this.textBox_Quantity.TabIndex = 7;
            this.textBox_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Quantity.TextChanged += new System.EventHandler(this.textBox_Quantity_TextChanged);
            // 
            // label_Price
            // 
            this.label_Price.AutoSize = true;
            this.label_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Price.Location = new System.Drawing.Point(208, 55);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(0, 16);
            this.label_Price.TabIndex = 6;
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Item.Location = new System.Drawing.Point(208, 24);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(0, 16);
            this.label_Item.TabIndex = 5;
            // 
            // comboBox_DimDroplist
            // 
            this.comboBox_DimDroplist.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_DimDroplist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DimDroplist.FormattingEnabled = true;
            this.comboBox_DimDroplist.Items.AddRange(new object[] {
            "Item",
            "Box",
            "Package"});
            this.comboBox_DimDroplist.Location = new System.Drawing.Point(208, 115);
            this.comboBox_DimDroplist.Name = "comboBox_DimDroplist";
            this.comboBox_DimDroplist.Size = new System.Drawing.Size(84, 21);
            this.comboBox_DimDroplist.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(63, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Dimension";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(63, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(63, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(63, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemView,
            this.DescriptionView,
            this.PriceView});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(21, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(545, 190);
            this.dataGridView1.TabIndex = 8;
            // 
            // ItemView
            // 
            this.ItemView.HeaderText = "Item name";
            this.ItemView.Name = "ItemView";
            this.ItemView.ReadOnly = true;
            this.ItemView.Width = 150;
            // 
            // DescriptionView
            // 
            this.DescriptionView.HeaderText = "Description";
            this.DescriptionView.Name = "DescriptionView";
            this.DescriptionView.ReadOnly = true;
            this.DescriptionView.Width = 350;
            // 
            // PriceView
            // 
            this.PriceView.HeaderText = "Price";
            this.PriceView.Name = "PriceView";
            this.PriceView.ReadOnly = true;
            this.PriceView.Visible = false;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(490, 281);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 9;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // ItemSearchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 543);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Done);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox_SearchDropList);
            this.Name = "ItemSearchWin";
            this.Text = "Item search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_SearchDropList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Done;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_DimDroplist;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.TextBox textBox_Quantity;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceView;
    }
}

