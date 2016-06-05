using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNET_HW2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HW2.mdf;Integrated Security=True;Connect Timeout=30";

        public Form1() {InitializeComponent();}

        private void FillSQLDataToGrid(string sqlCommand)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);
                connection.Open();

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;

                connection.Close();

            }
            catch (Exception ex){MessageBox.Show("Can't connect to DB. Please verify connection string... {0}", ex.Message);}

        }

        private void ExecuteSQLCommand(string sqlQuery)
        {
            try { 
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            } catch (Exception ex) { MessageBox.Show("There was an error. {0}", ex.Message); }
        }

        private void buttonDialog_Click(object sender, EventArgs e)
        {
            // Dialog
            Dialog dialog = new Dialog();
            dialog.MainDataGridView = dataGridView1;
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog(this);
            buttonDeleteStud.Enabled = !dialog.isMainGridChanged;
        }

        private void buttonDeleteStud_Click(object sender, EventArgs e)
        {
            // Delete Sudents
            if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("You need to select row to delete");

            string ids = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            for (int i = 1; i < dataGridView1.SelectedRows.Count; i++)
            {
                ids += "," + dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
            }

            ExecuteSQLCommand("DELETE FROM TblStudents WHERE Id in (" + ids + ")");
            FillSQLDataToGrid("SELECT * FROM TblStudents");

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Escape) {FillSQLDataToGrid("SELECT * FROM TblStudents"); buttonDeleteStud.Enabled = true; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(buttonDeleteStud, "Delete Student from DataBase");
            toolTip.SetToolTip(buttonDialog, "Open MitiOption dialog");
            FillSQLDataToGrid("SELECT * FROM TblStudents");
        }
    }
}
