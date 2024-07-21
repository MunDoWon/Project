using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjectClient01
{
    public partial class Form2 : Form
    {
        private Form1 frm1;
        public Form2(object form)
        {
            InitializeComponent();
            frm1 = (Form1)form;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string s = $"{label2.Text}  {SI.Text}개 {label3.Text} {O2.Text}개" +
                $"\n {label4.Text} {H2O.Text} 개 {label5.Text} {PH.Text}개" +
                $"\n {label6.Text} {Mask.Text}개 {label7.Text} {OP.Text}개" +
                $"\n {label8.Text} {AI.Text} 개 {label9.Text} {P.Text}개" +
                $"\n {label10.Text} {CU.Text}개 {label11.Text} {IGAS.Text}개 " +
                $"\n {label12.Text} {CE.Text}개 공급요청바랍니다.\n";
            MessageBox.Show("공급 요청을 완료하였습니다!");
            frm1.sendler(s);
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = $"모든 재료 {textBox1.Text}개 공급요청바랍니다.\n";
            MessageBox.Show("공급 요청을 완료하였습니다!");
            frm1.sendler(s);
            Dispose();
        }
    }
}
