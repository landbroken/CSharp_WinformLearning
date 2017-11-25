//参考博客https://www.cnblogs.com/hanke123/p/5405241.html
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strOut = "";
            try
            {
                dataGridView1.CurrentCell = dataGridView1[1, 1];
                int curColumn = dataGridView1.CurrentCell.ColumnIndex;
                int curRow = dataGridView1.CurrentCell.RowIndex;
                strOut += "curColumn: " + curColumn.ToString() + Environment.NewLine;
                strOut += "curRow: " + curRow.ToString() + Environment.NewLine;
                strOut += "dataGridView1.CurrentCell.Value: " + (string)dataGridView1.CurrentCell.Value + Environment.NewLine;
                dataGridView1.CurrentCell.Value = "new value";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //越界异常
                string strErr = ex.Message;
                MessageBox.Show("No such cell,out of range!");
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
            textBox1.Text = strOut;
        }
    }
}
