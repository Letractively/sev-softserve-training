using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItemSearch
{
    public partial class ItemSearchWin : Form
    {
        public ItemSearchWin()
        {
            InitializeComponent();
            comboBox_SearchDropList.SelectedIndex = 0;
            comboBox_DimDroplist.SelectedIndex = 0;
            testDG();
            textBox_Quantity.Text = "1";
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            label_Item.Text = "";
            label_Price.Text = "";
            textBox_Quantity.Text = "1";
            comboBox_DimDroplist.SelectedIndex = 0;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

            label_Item.Text = dataGridView1.Rows[(dataGridView1.CurrentRow.Index)].Cells[0].Value.ToString();
            label_Price.Text = dataGridView1.Rows[(dataGridView1.CurrentRow.Index)].Cells[2].Value.ToString();
            textBox_Quantity.Text = "1";
            comboBox_DimDroplist.SelectedIndex = 0;
            
            
        }

        private void testDG() 
        {
            dataGridView1.Rows.Add("it1", "111", 50);
            dataGridView1.Rows.Add("it2", "2222", 215);
            dataGridView1.Rows.Add("it3", "3322", 303);
            dataGridView1.Rows.Add("it4", "44322", 4);
        }

        private void textBox_Quantity_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
