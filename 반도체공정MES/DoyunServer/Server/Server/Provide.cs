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
    public partial class Provide : Form
    {
        OracleConnection conn;
        OracleDataReader rdr;
        OracleDataAdapter adapter;
        DataTable dataTable;
        private MainForm frm1;
        
        public Provide(object form)
        {
            InitializeComponent();
            oracle();
            frm1=(MainForm)form;
           
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

            adapter = new OracleDataAdapter("SELECT * FROM mat_table", conn);

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
        private void Provide_Load(object sender, EventArgs e)
        {
           
        }

        private void button_Click(object sender, EventArgs e)
        {
            int[] ints = new int[11];
            ints[0] = int.Parse(SI.Text);
            ints[1] = int.Parse(O2.Text);
            ints[2] = int.Parse(H2O.Text);
            ints[3] = int.Parse(PH.Text);
            ints[4] = int.Parse(Mask.Text);
            ints[5] = int.Parse(OP.Text);
            ints[6] = int.Parse(AI.Text);
            ints[7] = int.Parse(P.Text);
            ints[8] = int.Parse(CU.Text);
            ints[9] = int.Parse(IGAS.Text);
            ints[10] = int.Parse(CE.Text);
            frm1.Sendclass(ints);
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
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {SI.Text} WHERE NAME ='SI'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $" UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {O2.Text} WHERE NAME ='O2'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {H2O.Text} WHERE NAME ='H2O'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {PH.Text} WHERE NAME ='PH'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {Mask.Text} WHERE NAME ='Mask'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {OP.Text} WHERE NAME ='OP'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {AI.Text} WHERE NAME ='AI'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {P.Text} WHERE NAME ='P'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {CU.Text} WHERE NAME ='CU'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {IGAS.Text} WHERE NAME ='IGAS'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE MAT_TABLE SET QUANTITY = QUANTITY - {CE.Text} WHERE NAME ='CE'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("정상적으로 공급이 완료되었습니다!");
            Dispose();
            conn.Close();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
