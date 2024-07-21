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
    public partial class Login : Form
    {
        OracleConnection conn;
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        string id = "admin";
        string password = "1234";
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
              "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
              "(HOST=localhost)(PORT=1521)))" +
              "(CONNECT_DATA=(SERVER=DEDICATED)" +
              "(SERVICE_NAME=xe)));" +
              "User Id=hr;Password=hr;";

            try
            {
                // 1. 연결 객체 만들기 - OracleConnection 사용
                conn = new OracleConnection(strConn);
                await conn.OpenAsync(); // 데이터베이스 연결

                string Id = textBox2.Text;
                string password = textBox1.Text;


                // 2. 실제 데이터베이스 인증 로직 수행
                string sql = "SELECT COUNT(*) FROM Profile WHERE ID = :id AND PASSWORD = :password";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add("id", Id);
                cmd.Parameters.Add("password", password);

                int result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                if (result > 0)
                {
                    MessageBox.Show("로그인에 성공했습니다.", "LOGIN");
                    MainForm mainForm = new MainForm(Id);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("로그인에 실패했습니다.", "ERROR");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message, "ERROR");
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close(); // 연결 종료
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register form = new register();
            form.ShowDialog();
        }
    }
}
