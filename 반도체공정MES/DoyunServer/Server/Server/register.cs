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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//윈도우테두리제거방법
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == null || textBox1.Text == null||textBox3.Text==null)
            {
                MessageBox.Show("항목을 입력해주세요!!");
            }
            else
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
                cmd.CommandText = $"INSERT INTO PROFILE VALUES('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("회원가입이 완료되었습니다!");
                Dispose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
