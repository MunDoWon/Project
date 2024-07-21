using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
namespace MiniProjectClient01
{
    public partial class Form1 : Form
    {
        class Send
        {
            public int index { get; set; }//인덱스 0은 제품주문 1은 재료
            //인덱스0일시 받을 자료
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Company { get; set; }

            //인덱스1일시 받을 자료
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
        bool build;
        //재료재고
        int SI=0;
        int O2=0;
        int H2O=0;
        int PH = 0;
        int Mask = 0;
        int OP = 0;
        int AI = 0;
        int P = 0;
        int CU = 0;
        int IGAS = 0;
        int CE = 0;
        string company;
        int quantity;
        string product;
        TcpClient client;
        NetworkStream stream;


        public Form1()
        {
            InitializeComponent();
            btn1.BackColor = Color.Red;
        }
        private async void btn2_Click(object sender, EventArgs e)
        {
            string serverIp = "127.0.0.1";
            int port = 13000;
            client = new TcpClient(serverIp, port);
            stream = client.GetStream();

            richTextBox1.AppendText("서버에 연결되었습니다.\n");

            byte[] data = new byte[256];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = await stream.ReadAsync(data, 0, data.Length);
                    if (bytesRead == 0)
                    {
                        richTextBox1.AppendText("서버와 연결이 끊어졌습니다.\n");
                        break;
                    }

                    string receivedMessage = Encoding.UTF8.GetString(data, 0, bytesRead);
                   Send Recive = System.Text.Json.JsonSerializer.Deserialize<Send>(receivedMessage);
                   if(Recive.index==0)
                    {
                        richTextBox1.AppendText($"{Recive.Company}회사에서 {Recive.Name}제품을 {Recive.Quantity}" +
                            $"개 주문을 받았습니다! 생산 버튼을 누르면 작업을 실행합니다!\n");
                        MessageBox.Show($"{Recive.Company}회사에서 {Recive.Name}제품을 {Recive.Quantity}" +
                            $"개 주문을 받았습니다! 생산 버튼을 누르면 작업을 실행합니다!\n");
                        build = true;
                        btn1.BackColor = Color.Green;
                        company = Recive.Company;
                        product = Recive.Name;
                        quantity = Recive.Quantity;

                    }
                   if(Recive.index==1)
                    {
                        richTextBox1.AppendText($"재료 재고를 받았습니다. SI : {Recive.SI} O2 : {Recive.O2} " +
                            $"H2O : {Recive.H2O} PH : {Recive.PH} Mask : {Recive.Mask} OP : {Recive.OP} AI : {Recive.AI}" +
                            $" P : {Recive.P} CU : Recive{Recive.CU} IGAS : {Recive.IGAS} CE : {Recive.IGAS}\n");
                        SI += Recive.SI;
                        O2 += Recive.O2;
                        H2O += Recive.H2O;
                        PH += Recive.PH;
                        Mask += Recive.Mask;
                        OP += Recive.OP;
                        AI += Recive.AI;
                        P += Recive.P;
                        CU += Recive.CU;
                        IGAS += Recive.IGAS;
                        CE += Recive.CE;

                    }

                    // 여기에 수신된 요청을 처리하는 로직을 추가하세요.
                    // 예: 요청에 따라 다른 응답을 생성하고 클라이언트에게 보낼 수 있음.

                        // 응답 메시지 생성

                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText("오류 발생: " + ex.Message + "\n");
                    break;
                }
            }

        }
        public void sendler(string s)
        {
            byte[] data = Encoding.UTF8.GetBytes(s);
            stream.Write(data, 0, data.Length);
        }
        private void Form1_Load(object sender, EventArgs e)
        {   
            
            //클라이언트 종료
            
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;

        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        

        private  void btn1_Click(object sender, EventArgs e)
        {
            if (build == true)
            {
                if (SI - quantity < 0 || O2 - quantity < 0 || H2O - quantity < 0 || PH - quantity < 0 || Mask - quantity < 0 || OP - quantity < 0
                    || AI - quantity < 0 || P - quantity < 0 || CU - quantity < 0 || IGAS - quantity < 0 || CE - quantity < 0)
                    MessageBox.Show("재고가 없습니다 ! 서버에서 재고를 요청해 주세요!!!!");
                else
                {
                    SI -= quantity;
                    O2 -= quantity;
                    H2O -= quantity;
                    PH -= quantity;
                    Mask -= quantity;
                    OP -= quantity; AI -= quantity;
                    P -= quantity; CU -= quantity;
                    IGAS -= quantity; CE -= quantity;

                    richTextBox1.AppendText($"{company}회사주문인 {product} 제품을 {quantity}개 생산중입니다...\n");

                    stop1();
                    pictureBox19.Visible = true;
                    Button_on_off_1();
                    Delay(1600);
                    pictureBox19.Visible = false;
                    pictureBox20.Visible = true;
                    Button_on_off_2();
                    Delay(1600);

                    pictureBox21.Visible = true;
                    pictureBox20.Visible = false;
                    Button_on_off_3();
                    Delay(1600);

                    pictureBox22.Visible = true;
                    pictureBox21.Visible = false;
                    Button_on_off_4();
                    Delay(1600);

                    pictureBox23.Visible = true;
                    pictureBox22.Visible = false;
                    Button_on_off_5();
                    Delay(1600);

                    pictureBox24.Visible = true;
                    pictureBox23.Visible = false;
                    Button_on_off_6();
                    Delay(1600);

                    pictureBox25.Visible = true;
                    pictureBox24.Visible = false;
                    Button_on_off_7();
                    Delay(1600);

                    pictureBox26.Visible = true;
                    pictureBox25.Visible = false;
                    Button_on_off_8();
                    Delay(1600);

                    pictureBox27.Visible = true;
                    pictureBox26.Visible = false;
                    Button_on_off_9();

                    Delay(1600);
                    stop1();
                    stop();
                    build = false;
                    btn1.BackColor = Color.Red;
                    richTextBox1.AppendText($"{company}회사주문인 {product} 제품을 {quantity}개 생산완료하였습니다!\n완성된 제품들을 납품 하였습니다!\n");
                    sendler("success");

                }
            }
            else
                MessageBox.Show("주문 받은게 없습니다 !!!");
            
            

        }
       
        public void stop1()
        {
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
        }
        public void Button_on_off_1()
        {
            for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i += 5)
            {
                progressBar1.Value = i;
                i += 5;
                Application.DoEvents(); // 프로그레스바를 실시간으로 업데이트하기 위해 UI 갱신을 처리합니다.
                System.Threading.Thread.Sleep(100); // 각 단계마다 잠시 멈춥니다. 원하는 속도로 조절하세요.


                pictureBox1.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox1.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox1.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_2()
        {
            for (int i = progressBar2.Minimum; i <= progressBar2.Maximum; i += 5)
            {
                progressBar2.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox2.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox2.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox2.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_3()
        {
            for (int i = progressBar3.Minimum; i <= progressBar3.Maximum; i += 5)
            {
                progressBar3.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox3.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox3.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox3.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_4()
        {
            for (int i = progressBar4.Minimum; i <= progressBar4.Maximum; i += 5)
            {
                progressBar4.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox4.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox4.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox4.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_5()
        {
            for (int i = progressBar5.Minimum; i <= progressBar5.Maximum; i += 5)
            {
                progressBar5.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox5.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox5.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox5.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_6()
        {
            for (int i = progressBar6.Minimum; i <= progressBar6.Maximum; i += 5)
            {
                progressBar6.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox6.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox6.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox6.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_7()
        {
            for (int i = progressBar7.Minimum; i <= progressBar7.Maximum; i += 5)
            {
                progressBar7.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox7.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox7.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox7.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_8()
        {
            for (int i = progressBar8.Minimum; i <= progressBar8.Maximum; i += 5)
            {
                progressBar8.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox8.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox8.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox8.Load(@"C:\Temp\mnpj\On.png");
        }
        public void Button_on_off_9()
        {
            for (int i = progressBar9.Minimum; i <= progressBar9.Maximum; i += 5)
            {
                progressBar9.Value = i;
                i += 5;
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);

                pictureBox9.Load(@"C:\Temp\mnpj\On.png");
                Delay(100);
                pictureBox9.Load(@"C:\Temp\mnpj\Off.png");
                Delay(100);
            }
            pictureBox9.Load(@"C:\Temp\mnpj\On.png");

        }
    

        public void stop()
        {
            pictureBox1.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox2.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox3.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox4.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox5.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox6.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox7.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox8.Load(@"C:\Temp\mnpj\Off.png");
            pictureBox9.Load(@"C:\Temp\mnpj\Off.png");

            btn1.Enabled = true;  // "시작" 버튼 활성화
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;
            progressBar6.Value = 0;
            progressBar7.Value = 0;
            progressBar8.Value = 0;
            progressBar9.Value = 0;

        }

        

        private void btn3_Click(object sender, EventArgs e)
        {
            Form form = new Form2(this);
            form.ShowDialog();

        }

        private void bnt4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"SI : {SI}개 O2 : {O2}개 H2O : {H2O}개 PH : {PH}개\n" +
                $"Mask : {Mask}개 OP : {OP}개 AI : {AI}개 P : {P}개\n" +
                $"CU : {CU}개 IGAS : {IGAS}개 CE : {CE}개");
        }

        private void process1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }
    }
}
