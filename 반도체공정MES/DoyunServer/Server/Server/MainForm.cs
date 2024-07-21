using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Diagnostics;

namespace Server
{

    public partial class MainForm : Form
    {
        class Send
        {
            public Send()
            { }
            public int index {  get; set; }//인덱스 0은 제품주문 1은 재료
            //인덱스0일시 보낼 자료
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Company { get; set; }

            //인덱스1일시 보낼 자료
            public int SI { get; set; }
            public int O2 { get; set; }
            public int H2O { get; set; }
            public int PH { get; set; }
            public int Mask { get; set; }
            public int OP { get; set; }
            public int AI { get; set; }
            public int P { get; set; }
            public int CU { get; set; }
            public int IGAS { get; set; }
            public int CE { get; set; }
        }
        private TcpListener server;
        private bool flag = true;
        OracleConnection conn;
        OracleDataReader rdr;
        OracleDataAdapter adapter;
        DataTable dataTable;
        string company;
        string product;
        string quantity;
        string ID;
        NetworkStream stream;
        public MainForm(string id)
        {
            InitializeComponent();
            ID = id;
        }
        public void Sendclass(string[] a)
        {
            Send send = new Send();
            send.index = 0;
            send.Name = a[0];
            send.Quantity = int.Parse(a[1]);
            send.Company = a[2];
            product = a[0];
            quantity = a[1];
            company = a[2];
            send.SI = 0;
            send.O2 = 0;
            send.H2O = 0;
            send.PH = 0;
            send.Mask = 0;
            send.OP = 0;
            send.AI = 0;
            send.P = 0;
            send.CU = 0;
            send.IGAS = 0;
            send.CE = 0;
            string s = System.Text.Json.JsonSerializer.Serialize(send);
            writestream(s);

        }
        public void Sendclass(int[] a)
        {
            Send send = new Send();
            send.index = 1;
            send.SI = a[0];
            send.O2 = a[1];
            send.H2O = a[2];
            send.PH = a[3];
            send.Mask = a[4];
            send.OP = a[5];
            send.AI = a[6];
            send.P = a[7];
            send.CU = a[8];
            send.IGAS = a[9];
            send.CE = a[10];

            string s = System.Text.Json.JsonSerializer.Serialize(send);
            writestream(s);
        }
        public void setcolor()
        {
            button5.BackColor = Color.Red;
            flag = false;
        }
        public string settext()
        {
            if (flag == true)
                return "현재 자동화 공정이 지시받은게 없어 동작하고 있지 않습니다";
            else
                return $"{company}회사의 {product} {quantity}개를 생산 중입니다...";
        }
    
    
        public void writestream(string s)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(s);
            stream.Write(responseBytes, 0, responseBytes.Length);
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // 포트 설정
            int port = 13000;
            // 서버 생성
            server = new TcpListener(localAddr, port);
            // 서버 시작
            server.Start();
            //Console.WriteLine("연결을 기다리는 중...");
            richTextBox1.AppendText("연결을 기다리는 중...\n");

            while (true)
            {
                // 클라이언트 연결 수락
                TcpClient client = await server.AcceptTcpClientAsync();
                // 클라이언트 요청 처리 시작
                Task task = Task.Run(() => HandleClient(client));
            }
        }
        private async Task HandleClient(TcpClient client)
        {
            AppendText("연결 성공!\n");

            using (stream = client.GetStream())
            {
                byte[] data = new byte[256];
                int bytes;

                while ((bytes = await stream.ReadAsync(data, 0, data.Length)) != 0)
                {
                    string receivedMessage = Encoding.UTF8.GetString(data, 0, bytes);
                    if(receivedMessage=="success")
                    {
                        successet();
                        richTextBox1.AppendText($"생산지시하셨던 {company}회사의 {product}제품 {quantity}개를 생산완료하였습니다. 납품완료 하였습니다!");
                        button5.BackColor = Color.PowderBlue;
                        flag = true;
                    }
                    else
                    AppendText("클라이언트로부터 수신: " + receivedMessage + "\n");
                    // 클라이언트에게 응답 메시지 보내기
                }
            }
        }
        private void successet()
        {
            DateTime nowdate = DateTime.Now;

            string command = $"UPDATE COM_TABLE SET COMPLETE = 'O',DATEC = '{nowdate.ToString()}' WHERE COMPLETE = 'X'";
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


            conn.Close();
        }
        private void AppendText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                richTextBox1.AppendText(text);
            }
        }
        public void SetText(string data)
        {
            richTextBox1.AppendText(data+"\n");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("자재");
            comboBox1.Items.Add("주문");
            comboBox1.Items.Add("납품");
            comboBox2.Items.Add("제품");
            comboBox2.Items.Add("자재");
            DateTime nowDate = DateTime.Now;
            string date = nowDate.ToString();
            richTextBox1.AppendText($"{ID}님으로 로그인하셨습니다.\n안녕하세요 ^^ 도윤전자(주) 관리 서버입니다. 오늘 날짜는 {date} 입니다.\n");
            richTextBox2.AppendText ("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠤⠖⠚⠉⠉⠀⠀⠀⠀⠉⠉⠙⠒⠤⣄⡀⠀⠀⣀⣠⣤⣀⡀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠖⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢯⡀⠀⠀⠀⠉⠳⣄⠀\r\n⠀⠀⣀⠤⠔⠒⠒⠒⠦⢤⣀⢀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣄⠀⠀⠀⠀⠀⣴⢶⣄⠀⠀⠀⠉⢢⡀⠀⠀⠀⠘⡆\r\n⢠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠈⢻⡀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡟⠀⢹⣧⠀⠀⠀⠀⣿⠀⢹⣇⠀⠀⠀⠀⠙⢦⠀⠀⠀⣧\r\n⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣦⣼⣿⡇⠀⠀⠀⢿⣿⣿⣿⡄⠀⠀⠀⠀⠈⢳⡀⢀⡟\r\n⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⡿⠿⠿⣿⠀⠀⠀⠘⣿⡛⣟⣧⠀⠀⠀⠀⠀⠀⢳⠞⠀\r\n⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⡄⢴⡿⠀⠀⠀⠀⠘⣿⣷⡏⠀⢀⡠⠤⣄⠀⠀⣇⠀\r\n⠀⢳⡀⠀⠀⠀⠀⠀⠀⢠⠏⠀⠀⠀⠀⠀⣠⠄⠀⠀⠀⠀⠀⠈⠛⠛⠁⣀⡤⠤⠤⠤⢌⣉⠀⠀⢠⡀⠀⠀⡱⠀⢸⡄\r\n⠀⠀⠙⠦⣀⠀⠀⠀⣰⠋⠀⠀⠀⠀⠀⠸⣅⠀⠀⢀⡀⠀⠀⠀⢀⠴⠋⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⠈⠉⠉⠀⠀⢘⣧\r\n⠀⠀⠀⠀⠈⠙⢲⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠁⠀⠀⠀⣰⣋⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠈⢧⠀⠀⠀⠀⠀⢐⣿\r\n⠀⠀⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⠁⠀⠀⠀⠀⠀⠉⠙⠒⢤⣀⠀⠀⠈⣇⠀⠀⠀⠀⠀⣿\r\n⠀⠀⠀⠀⠀⠀⠘⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⢸⠀⠀⠀⠀⢠⡏\r\n⠀⠀⠀⠀⠀⠀⠀⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡆⠘⣧⠀⠀⠀⣸⠀\r\n⠀⠀⠀⠀⠀⠀⠀⡟⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⢰⠏⠀⠀⢠⠇⠀\r\n⠀⠀⠀⠀⠀⠀⢸⠁⠘⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⣸⠀⠀⢀⠏⠀⠀\r\n⠀⠀⠀⠀⠀⠀⣿⠀⠀⠘⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⣣⠃⠀⣠⠏⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠘⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠞⡱⠋⢀⡴⠁⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠈⠣⣄⠀⠀⠀⠀⠀⠀⠀⠹⣄⠀⠀⠀⠀⢀⣀⡤⠖⢋⡠⠞⢁⡴⠋⡇⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠈⠙⠢⣄⡀⠀⠀⠀⠀⠈⠙⠯⠭⢉⠡⠤⠴⠒⣉⠴⠚⠁⠀⢰⠃⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⠖⠲⠤⠤⠤⠤⠤⠤⢶⡖⠚⠉⠀⠀⠀⠀⢀⡞⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀⡰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠲⠤⠤⠤⠤⠔⠋⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢤⡀⠀⠀⠀⠀⣠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠑⠒⠒⠋⠂⠐⠒⠀⠀⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n\n\n");
            richTextBox3.AppendText("\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⢰⣆⡽⣿⡾⣿⣿⣿⣿⢷⠻⣛⠠⠐⠀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠸⣦⡌⢿⣇⡻⣮⣾⣿⣿⡿⣿⣫⠖⣈⣀⠐⠂⣂⠄⢒⣩⢶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⢶⡀⢹⣇⠘⣿⣢⢿⣿⡽⣿⣿⣿⣿⣧⠒⠂⠀⠠⠒⠈⠤⢔⠭⢄⣩⠜⣣⡀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡄⠸⣆⠘⣷⣀⢻⣟⡘⣿⣎⣿⣿⣿⣿⣿⢟⡬⠔⠈⠀⠀⠁⠀⡀⠔⢚⡉⠶⣦⡬⠳⡀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣤⠈⣷⡀⢻⣆⠘⣿⡆⢻⣷⣜⣿⡿⣿⣿⣷⠛⣅⡀⠒⠁⣀⠀⠂⠁⢤⠨⠩⠿⣃⡡⠾⣫⡅⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⣠⠄⢻⡇⠸⣷⠀⢿⣦⠸⣿⣂⢿⣿⣼⣿⣟⣿⡟⠯⡀⠤⠀⠉⡀⠠⡈⠈⢀⠡⠖⠈⠩⣶⣮⣻⠿⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⡀⠸⣇⠈⣿⡀⢹⣯⡘⣿⡆⡹⣿⣏⣿⣿⣿⣿⣭⠚⠈⢁⠀⠐⠀⠀⡀⠄⠊⠁⣄⠈⢷⡄⠘⢉⣷⡖⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢘⣷⠐⢿⡀⠸⣷⡀⢿⣧⠸⣿⣵⣿⣿⣿⣿⣿⢅⡤⠤⠀⠁⢀⠀⠐⠀⠀⡢⠄⠈⠁⢁⡀⠼⢓⡉⠀⠇⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢀⠁⢟⡂⠸⣷⡀⢿⡎⠸⣿⡿⣻⣿⣶⣿⣿⡿⠟⠛⢀⠤⠔⠀⠁⣀⠀⠃⠀⠀⣠⠤⠂⠉⠀⡀⠠⠿⡞⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢰⠄⠸⣿⡀⢿⣦⠸⣿⣧⢹⣿⣏⣿⣿⡿⢿⣯⠜⠋⠁⠀⠀⠔⠀⠀⢀⠠⠂⠉⠀⢀⣦⠐⠈⠉⢀⣼⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢸⣧⠀⣿⡖⢸⣿⡦⢻⣯⣔⣿⣿⣿⡿⡿⠃⣀⡀⠘⠈⠁⠀⠀⠔⠈⠀⡀⡀⠼⠀⠁⠀⢰⣄⢔⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠈⢿⣀⢹⣶⠅⣿⣿⠟⣿⣭⣾⣿⣿⡹⠷⠂⠁⠀⣀⠀⠐⠁⠀⡀⠠⠀⠁⠀⠀⡠⠆⠂⢉⣵⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠘⡗⡈⣷⣗⣸⣿⣿⢸⣿⣵⢿⣋⠆⡐⠤⠀⠈⠀⢀⠀⠐⠀⠀⢀⢀⠠⠊⠁⠀⢀⣴⣿⣿⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⢂⢿⣗⢋⣿⣾⣏⣿⣟⠩⡛⠘⠀⠀⣀⠀⠀⠁⠀⢀⠠⠔⠈⠀⠀⢀⣠⣶⣿⣿⡿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠘⠻⣣⢺⣿⣵⡮⣿⠁⣸⠦⠂⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣴⣿⣿⣿⠿⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠫⠧⠟⣋⣀⣀⣀⣀⣀⣉⣠⣤⣴⣶⠾⠿⠟⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("server");

            foreach (Process process in processes)
            {
                process.Kill();
            }
            Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Select(comboBox1.SelectedIndex);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Form frm = new OrderProduct();
                frm.Show();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Form frm2 = new Ordermatter();
                frm2.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (flag == false)
                MessageBox.Show("현재 생산 작업이 진행중입니다 ! 끝나고 생산 부탁드립니다!");
            else
            {
                Builder frm = new Builder(this);
                frm.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Provide frm = new Provide(this);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TestName frm = new TestName(this);
            frm.Show(); 
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
