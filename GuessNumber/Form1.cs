using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class FormGuessNumber : Form
    {
        private String result=null;
        private int guessCount = 0;
        
        public FormGuessNumber()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<Char> shuzi =new List<Char>();
            shuzi.Add('0');
            shuzi.Add('1');
            shuzi.Add('2');
            shuzi.Add('3');
            shuzi.Add('4');
            shuzi.Add('5');
            shuzi.Add('6');
            shuzi.Add('7');
            shuzi.Add('8');
            shuzi.Add('9');
            
            Random random=new Random();
            StringBuilder sb=new StringBuilder();
            for(int i=0;i<4;i++){
                int re=random.Next(shuzi.Count);
                sb.Append(shuzi[re]);
                shuzi.RemoveAt(re);
            }
            result = sb.ToString();
            guessCount = 0;
            textBoxGuess.Text = "";
            buttonStart.Enabled = false;
            buttonOK.Enabled = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int acount = 0;
            int bcount = 0;
            String guess = textBoxGuess.Text;
            if (guess.Length != 4)
            {
                MessageBox.Show("输入数字个数错误");
            }
            else
            {
                Dictionary<char, int> dic = new Dictionary<char, int>();
                int k=0;
                for (k = 0; k < guess.Length; k++)
                {
                    if (dic.ContainsKey(guess[k]))
                    {
                        dic[guess[k]]+=1;
                        break;
                    }
                    else 
                    {
                        dic.Add(guess[k],1);
                    }
                }
                if (k < guess.Length)
                {
                    MessageBox.Show("您输入了重复的数字！");
                }
                else
                { 
                    for (int i = 0; i < result.Length; i++)
                    {
                        for (int j = 0; j < guess.Length; j++)
                        {
                            if (guess[j] == result[i])
                            {
                                bcount++;
                                if (j == i)
                                {
                                    acount++;
                                }
                            }
                        }
                    }
                    bcount -= acount;
                    labelResult.Text = "您猜的结果是:" + acount + "A" + bcount + "B";
                    guessCount++;
                    if (acount == 4)
                    {
                        labelResult.Text += "\n您猜对了，恭喜！答案是:" + result + "\n共猜了：" + guessCount + "次";
                        buttonOK.Enabled = false;
                        buttonStart.Enabled = true;
                    }
                }
            }
            
        }
    }
}
