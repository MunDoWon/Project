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
    public partial class OrderProduct : Form
    {
        OracleConnection conn;
        OracleDataReader rdr;
        OracleDataAdapter adapter;
        DataTable dataTable;


        public OrderProduct()
        {
            InitializeComponent();
            oracle();
        }
        private void oracle()
        {
            string strConn = "Data Source=(DESCRIPTION=" +
              "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
              "(HOST=localhost)(PORT=1521)))" +
              "(CONNECT_DATA=(SERVER=DEDICATED)" +
              "(SERVICE_NAME=xe)));" +
              "User Id=hr;Password=hr;";
            //1.연결 객체 만들기 - Client
            conn = new OracleConnection(strConn);

            adapter = new OracleDataAdapter("SELECT * FROM EX_ORDER", conn);

            // Initialize data table
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
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SuperChip-2000");
            comboBox1.Items.Add("PowerTech-100A");
            comboBox1.Items.Add("NanoSensor-5000");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = $"insert into ex_order values('{comboBox1.Text}',{textBox1.Text},'{textBox2.Text}')";
            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";
            //1.연결 객체 만들기 - Client
            conn = new OracleConnection(strConn);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            MessageBox.Show("정상적으로 행이 삽입되었습니다 !");
            oracle();
           
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
