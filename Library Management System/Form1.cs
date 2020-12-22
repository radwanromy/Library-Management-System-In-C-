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
        public Form1()
        {
            InitializeComponent();
            var books = GetAllBooks();
            dataGridView1.DataSource = books;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
                books c = new books();
                c.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                c.BookName = reader.GetString(reader.GetOrdinal("Name"));
                c.AuthorName = reader.GetString(reader.GetOrdinal("Author"));
                c.Edition = reader.GetString(reader.GetOrdinal("Edition"));
                books.Add(c);
            }
            conn.Close();
            return books;
        }
    }
}
