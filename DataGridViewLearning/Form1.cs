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
        GPSData[] m_GPS = new GPSData[10];

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


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (var item in m_GPS)
            {
                //if (item!=null)
                //{
                //    textBox1.Text += item.Longtitude + " , ";
                //    textBox1.Text += item.Latitude + " , ";
                //    textBox1.Text += item.Velocity +Environment.NewLine;
                //}
                textBox1.Text += item.Longtitude + " , ";
                textBox1.Text += item.Latitude + " , ";
                textBox1.Text += item.Velocity + Environment.NewLine;
            }
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GPSData.ColumnNum curColumn = (GPSData.ColumnNum)dataGridView1.CurrentCell.ColumnIndex;
                int curRow = dataGridView1.CurrentCell.RowIndex;
                double curValue = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                //if (m_GPS[curRow]==null)
                //{
                //    m_GPS[curRow] = new GPSData();
                //}
                switch (curColumn)
                {
                    case GPSData.ColumnNum.Longtitude:
                        m_GPS[curRow].Longtitude = curValue;
                        break;
                    case GPSData.ColumnNum.Latitude:
                        m_GPS[curRow].Latitude = curValue;
                        break;
                    case GPSData.ColumnNum.Velocity:
                        m_GPS[curRow].Velocity = curValue;
                        break;
                    default:
                        //应该不可能访问到这
                        throw new ArgumentOutOfRangeException();
                        //break;
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
        }
    }
}
