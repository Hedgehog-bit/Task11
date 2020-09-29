using System;
using System.Windows.Forms;

namespace WF11
{
    public partial class Form1 : Form
    {
        double[,] DoubelArray;
        int n, m;      
        int scalar = 0;
        public int Scalar
        {
            set { scalar = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void SetStricture(int x, int y)
        {
            dataGridView1.ColumnCount = x;
            dataGridView1.RowCount = y;
            n = x;
            m = y;
            DoubelArray = new double[x, y];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && isValid(textBox1.Text))
            {
                SetStricture(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text));
            }
        }
        private bool isValid(String str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (!(chArr[i] >= '0' && chArr[i] <= '9') && chArr[i] != ',')
                {
                    return false;
                }
            }
            return true;
        }

        private void getDataForTwoDimArray()
        {
            for (int rows = 0; rows < dataGridView1.Columns.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows.Count; col++) 
                {

                    DoubelArray[rows, col] = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            int count = Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox3.Text);
            textBox4.Text = Convert.ToString(count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            Sort();
            Output(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text));
        }
        public void Sort()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    for (int r = 0; r < m - j; r++)
                    {
                        if (DoubelArray[i, r] < DoubelArray[i, r + 1])
                        {
                            double tmp = DoubelArray[i, r];
                            DoubelArray[i, r] = DoubelArray[i, r + 1];
                            DoubelArray[i, r + 1] = tmp;
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dataGridView1.Rows[i].Cells[k].Value = DoubelArray[i, k] + 1;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dataGridView1.Rows[i].Cells[k].Value = DoubelArray[i, k] - 1;
                    dataGridView1.Refresh();
                }
            }
        }

        public void Output(int x, int y)
        {
            dataGridView3.ColumnCount = x;
            dataGridView3.RowCount = y;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = DoubelArray[i, j];
                }
            }
        }
    }
}
