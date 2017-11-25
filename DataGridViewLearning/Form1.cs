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
            GetCurrentCell();
            SetCell(1, 2, "new value");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectNextColumnCell(0);
        }

        private void GetCurrentCell()
        {
            string strOut = "";
            try
            {
                int curColumn = dataGridView1.CurrentCell.ColumnIndex;
                int curRow = dataGridView1.CurrentCell.RowIndex;
                strOut += "curColumn: " + curColumn.ToString() + Environment.NewLine;
                strOut += "curRow: " + curRow.ToString() + Environment.NewLine;
                strOut += "dataGridView1.CurrentCell.Value: " + (string)dataGridView1.CurrentCell.Value + Environment.NewLine;
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
            textBox1.Text = strOut;
        }

        private void SetCell(int Column,int Row,object NewValue)
        {
            string strOut = "";
            try
            {
                dataGridView1.CurrentCell = dataGridView1[Column, Row];
                dataGridView1.CurrentCell.Value = NewValue;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //越界异常
                string strErr = ex.Message;
                MessageBox.Show("No such cell,out of range!");
            }
            textBox1.Text = strOut;
        }

        private void SelectNextRowCell(int Column)
        {
            int row = this.dataGridView1.CurrentRow.Index + 1;
            if (row > this.dataGridView1.RowCount - 1)
                row = 0;
            this.dataGridView1.CurrentCell = this.dataGridView1[Column, row];
        }

        private void SelectNextColumnCell(int Row)
        {
            int column = this.dataGridView1.CurrentCellAddress.X + 1;
            if (column > this.dataGridView1.ColumnCount - 1)
                column = 0;
            this.dataGridView1.CurrentCell = this.dataGridView1[column, Row];
        }
    }
}
