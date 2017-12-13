using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda運算式平行運算應用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BlockingCollection<string> bc = new BlockingCollection<string>();
        //平行運算專用泛型集合BlockingCollection

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() => GetOdd(), () => GetEven());
            //Parallel平算運行，同時運算(GetOdd & GetEven)

            listBox1.DataSource = bc.ToArray();
        }

        string GetOdd()
        {
            for(int i=0; i<=1000;i++)
            {
                if(i % 2==1)
                {
                    bc.Add($"{i} 奇數");
                }
            }
            return "GetOdd結束 !";
        }


        string GetEven()
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 2 == 0)
                {
                    bc.Add($"{i} 偶數");
                }
            }
            return "GetEven結束 !";
        }
    }
}
