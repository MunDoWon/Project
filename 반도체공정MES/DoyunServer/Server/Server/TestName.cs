using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class TestName : Form
    {
        private MainForm frm1;
        public TestName(object frm)
        {
            InitializeComponent();
            frm1 = (MainForm)frm;
            textBox1.Text = frm1.settext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }



        private const int StepValue = 2; // 숫자 낮으면 속도도 느려짐
        private async void TestName_Load(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, "data.txt");
            string[] deletedCompanies = File.ReadAllLines(fileName);

            foreach (string company in deletedCompanies)
            {
                textBox1.AppendText("지금 " + company + " 회사는 작업 중.." + Environment.NewLine);
            }
            await FillProgressBar();

        }
        private async Task FillProgressBar()
        {


            await Task.Run(() =>
            {
                // ProgressBar를 Minimum에서 Maximum까지 채우는 예시 코드
                for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i += StepValue)
                {
                    // UI 스레드에서 UI 업데이트를 하기 위해 Invoke 사용
                    progressBar1.Invoke(new Action(() => progressBar1.Value = i));
                    System.Threading.Thread.Sleep(30); // 원하는 속도로 조절 가능
                }
            });
        }
    }

}