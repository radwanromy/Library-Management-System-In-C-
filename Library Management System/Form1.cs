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

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        Database dss = new Database();
        String query;
        int id;
        public Form1()
        {
            InitializeComponent();
            var books = GetAllBooks();
           // dataGridView1.DataSource = books;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "select ID,Name from books where Name = '"+txtBName.Text+"'";
            //var books = GetAllBooks();
            DataSet ds = dss.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private ArrayList GetAllBooks()
        {
            var conn = Database.ConnectDB();
            conn.Open();
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ArrayList books = new ArrayList();
            while (reader.Read())
            {
                books b = new books();
              b.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                b.BookName = reader.GetString(reader.GetOrdinal("Name"));
               b.AuthorName = reader.GetString(reader.GetOrdinal("Author"));
              b.Edition = reader.GetString(reader.GetOrdinal("Edition"));
                books.Add(b);
            }
            conn.Close();
            return books;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //txtBName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                query = "select * from books where Name = '" + txtBName.Text + "'";
                DataSet ds = dss.getData(query);
                dataGridView2.DataSource = ds.Tables[0];
                label1.Visible = false;
                txtBName.Visible = false;
                btnSearch.Visible = false;
                label2.Visible = false;
                dataGridView1.Visible = false;
                button1.Visible = true;
                label3.Visible = true;
                dataGridView2.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            txtBName.Visible = true;
            btnSearch.Visible = true;
            label2.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = false;
            label3.Visible = false;
            dataGridView2.Visible = false;
        }
    }
}
