using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Cal_Sah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool start = true;
        int lastrand, lastcol, timp = 0, casute = 1, sec = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            grid.ColumnCount = 8;
            grid.RowCount = 8;
            foreach (DataGridViewColumn c in grid.Columns)
                c.Width = grid.Width / 8;
            foreach(DataGridViewRow c in grid.Rows)
                c.Height = grid.Height/ 8;
            grid.Height++;
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    grid[i, j].Style.ForeColor = Color.DarkGray;
                    grid[i, j].Style.BackColor = Color.LightGray;
                }
            }
            restartbut.Visible = false;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            grid.ClearSelection();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rand = e.RowIndex,colo = e.ColumnIndex;
            if (start)
            {
                cal(colo, rand);
                start = false;
                lastcol = colo;
                lastrand = rand;
                grid[colo, rand].Style.BackColor = Color.Blue;
            }
            else
            {
                if(grid[colo,rand].Style.BackColor!=Color.Yellow)
                {
                    MessageBox.Show("Casuta invalida");
                }
                else
                {
                    recal(lastcol, lastrand);
                    lastcol = colo;
                    lastrand = rand;
                    if (cal(colo, rand) == false)
                    {
                        grid[colo, rand].Style.BackColor = Color.Red;
                        MessageBox.Show("Ai pierdut");
                        timer2.Enabled = false;
                        restartbut.Visible = true;
                    }
                    else {
                        grid[colo, rand].Style.BackColor = Color.Blue;
                        casute++;
                            }
                    if (casute == 64)
                    {
                        MessageBox.Show("Bravooo!");
                        MessageBox.Show("UR the BEST!!");
                        MessageBox.Show("Te pupa smecheru barosan");
                        timer2.Enabled = false;
                        restartbut.Visible = true;
                    }
                }
            }
        }

        private void restartbut_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            label1.Text ="Timp: " + (sec / 60).ToString() + " min " + (sec % 60).ToString() + " s ";
            
        }

        private bool cal(int i,int j)
        {
            bool liber = false;
            try
            {
                if (grid[i + 1, j + 2].Style.BackColor != Color.Blue)
                {
                    grid[i + 1, j + 2].Style.BackColor = Color.Yellow;
                    liber = true;
                }
            }
            catch { }
            try
            {
                if (grid[i - 1, j + 2].Style.BackColor != Color.Blue)
                {
                    grid[i - 1, j + 2].Style.BackColor = Color.Yellow;
                    liber = true;
                }
            }
            catch { }
            try
            {
                if (grid[i + 2, j + 1].Style.BackColor != Color.Blue)
                {
                    grid[i + 2, j + 1].Style.BackColor = Color.Yellow;
                    liber = true;
                }
            }
            catch { }
            try
            {
                if (grid[i + 2, j - 1].Style.BackColor != Color.Blue)
                {
                    grid[i + 2, j - 1].Style.BackColor = Color.Yellow;
                    liber = true;
                }
            }
            catch { }
            try
            {
                if (grid[i + 1, j - 2].Style.BackColor != Color.Blue)
                {
                    grid[i + 1, j - 2].Style.BackColor = Color.Yellow;
                    liber = true;
                }
            }
            catch { }
            try
            {
                if (grid[i - 1, j - 2].Style.BackColor != Color.Blue)
                {
                    grid[i - 1, j - 2].Style.BackColor = Color.Yellow;
                    liber = true;
                }
                }
            catch { }
            try
            {
                if (grid[i - 2, j + 1].Style.BackColor != Color.Blue)
                {
                    grid[i - 2, j + 1].Style.BackColor = Color.Yellow;
                    liber = true;
                }
                }
            catch { }
            try
            {
                if (grid[i - 2, j - 1].Style.BackColor != Color.Blue)
                {
                    grid[i - 2, j - 1].Style.BackColor = Color.Yellow;
                    liber = true;
                }
                }
            catch { }
            return liber;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timp++;
            if(timp==1)
                MessageBox.Show("Alege un punct de incepere");

        }

        private void recal(int i,int j)
        {
            try
            {
                if (grid[i + 1, j + 2].Style.BackColor != Color.Blue)
                    grid[i + 1, j + 2].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i - 1, j + 2].Style.BackColor != Color.Blue)
                    grid[i - 1, j + 2].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i + 2, j + 1].Style.BackColor != Color.Blue)
                    grid[i + 2, j + 1].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i + 2, j - 1].Style.BackColor != Color.Blue)
                    grid[i + 2, j - 1].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i + 1, j - 2].Style.BackColor != Color.Blue)
                    grid[i + 1, j - 2].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i - 1, j - 2].Style.BackColor != Color.Blue)
                    grid[i - 1, j - 2].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i - 2, j + 1].Style.BackColor != Color.Blue)
                    grid[i - 2, j + 1].Style.BackColor = Color.LightGray;
            }
            catch { }
            try
            {
                if (grid[i - 2, j - 1].Style.BackColor != Color.Blue)
                    grid[i - 2, j - 1].Style.BackColor = Color.LightGray;
            }
            catch { }
        }
    }
}
