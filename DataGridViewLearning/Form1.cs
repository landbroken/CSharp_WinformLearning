//参考博客https://www.cnblogs.com/hanke123/p/5405241.html
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //获取程序集自动增加的版本号和编译时间
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var GVersion = version.ToString();
            var GDateTime = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetCurrentCell();
            //SetCell(1, 2, "new value");
            
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
                textBox1.Text += item.Longitude + " , ";
                textBox1.Text += item.Latitude + " , ";
                textBox1.Text += item.Velocity + Environment.NewLine;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int len = m_GPS.Length;
            for (int i = 0; i < len; i++)
            {
                m_GPS[i] = new GPSData(i + 1.1, i + 2.2, i + 3.3);
                SetCell(0, i, m_GPS[i].Longitude);
                SetCell(1, i, m_GPS[i].Latitude);
                SetCell(2, i, m_GPS[i].Velocity);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_GPS = ResizeGPS(m_GPS);
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
                if (Column>dataGridView1.ColumnCount)
                {
                    //dataGridView1.CurrentCell will throw ArgumentOutOfRangeException
                }
                //add new row
                //only show the last one value，why？
                //if (Row >= dataGridView1.RowCount)
                //{
                //    dataGridView1.Rows.Add(Row - dataGridView1.RowCount + 1);
                //}
                //this work right
                if (Row + 1 >= dataGridView1.RowCount)
                {
                    dataGridView1.Rows.Add(Row - dataGridView1.RowCount + 2);
                }
                dataGridView1.CurrentCell = dataGridView1[Column, Row];
                dataGridView1.CurrentCell.Value = NewValue;
            }
            catch (ArgumentOutOfRangeException ex)
            {
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
                switch (curColumn)
                {
                    case GPSData.ColumnNum.Longitude:
                        m_GPS[curRow].Longitude = curValue;
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

        private GPSData[] ResizeGPS(GPSData[] GPSIn)
        {
            GPSData[] tmp = new GPSData[GPSIn.Length + 1000];
            for (int i = 0; i < GPSIn.Length; i++)
            {
                tmp[i] = GPSIn[i];
            }

            return tmp;
        }
    }
}
