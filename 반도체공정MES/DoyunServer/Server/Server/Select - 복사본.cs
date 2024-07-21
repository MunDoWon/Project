using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Select : Form
    {
        OracleConnection conn;
        OracleDataReader rdr;
        OracleDataAdapter adapter;
        DataTable dataTable;
        public Select(int number)
        {
            InitializeComponent();
            string strConn = "Data Source=(DESCRIPTION=" +
               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
               "(HOST=localhost)(PORT=1521)))" +
               "(CONNECT_DATA=(SERVER=DEDICATED)" +
               "(SERVICE_NAME=xe)));" +
               "User Id=hr;Password=hr;";
            //1.연결 객체 만들기 - Client
            conn = new OracleConnection(strConn);
            if (number == 0)
                adapter = new OracleDataAdapter("SELECT * FROM MAT_TABLE", conn);
            if (number == 1)
                adapter = new OracleDataAdapter("SELECT * FROM EX_ORDER", conn);
            if (number == 2)
                adapter = new OracleDataAdapter("SELECT * FROM COM_TABLE ORDER BY COMPLETE DESC, DATEC ASC", conn);

            dataTable = new DataTable();
            try
            {
                // Open the connection
                conn.Open();

                // Fill the data table with data from the database
                adapter.Fill(dataTable);

                // Display data in DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }


        }

       

        private void Select_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}