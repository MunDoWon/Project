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
    public partial class Builder : Form
    {
      
        OracleConnection conn;
        OracleDataReader rdr;
        OracleDataAdapter adapter;
        DataTable dataTable;
        private MainForm frm1;
      
        class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Company { get; set; }
        }
        public Builder(object form)
        {
            InitializeComponent();
            oracle();
            frm1 = (MainForm)form;

        
        }

        private void Builder_Load(object sender, EventArgs e)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);
            //2.데이터베이스 접속을 위한 연결
            conn.Open();
            //명령객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM EX_ORDER";
            OracleDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string name = rdr["NAME"] as string;
                int quantity = int.Parse(rdr["QUANTITY"].ToString());
                string company = rdr["COMPANY"] as string;
                combobox.Items.Add($"{company}");
            }
            conn.Close();

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
                dataGrid.DataSource = dataTable;
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("생산 작업을 실행합니다!");
            frm1.SetText(combobox.Text + " 작업이 실행 중 입니다. ");
            string strConn = "Data Source=(DESCRIPTION=" +
                 "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                 "(HOST=localhost)(PORT=1521)))" +
                 "(CONNECT_DATA=(SERVER=DEDICATED)" +
                 "(SERVICE_NAME=xe)));" +
                 "User Id=hr;Password=hr;";
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);
            //2.데이터베이스 접속을 위한 연결
            conn.Open();
            //명령객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM EX_ORDER WHERE COMPANY = '{combobox.Text}'";
            OracleDataReader rdr = cmd.ExecuteReader();
            string[] s = new string[3];
            while (rdr.Read())
            {
                s[0]= rdr["NAME"] as string;
                s[1] = rdr["QUANTITY"].ToString();
                s[2] = rdr["COMPANY"] as string;
            }

            using (OracleCommand insertCmd = new OracleCommand())
            {
                insertCmd.Connection = conn;
                insertCmd.CommandText = $"INSERT INTO COM_table (NAME, QUANTITY, COMPANY, COMPLETE) " +
                                        $"VALUES ('{s[0]}', {s[1]}, '{s[2]}', 'X')";
                insertCmd.ExecuteNonQuery();
            }

            cmd.CommandText = $"DELETE FROM EX_ORDER WHERE COMPANY ='{combobox.Text}'";
            cmd.ExecuteNonQuery();
            oracle();
            frm1.Sendclass(s);
            
            frm1.setcolor();
            conn.Close();
            Dispose();


        }
    }
}
