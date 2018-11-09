using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        //private delegate void Msg(List<NewsInfo> newsInfo);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NewsInfoDal newsInfoDal = new NewsInfoDal();
            dataGridView1.DataSource = newsInfoDal.GetNewsList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add(ShowMsg);
            add.Show();
        }

      
        private void ShowMsg(List<NewsInfo> newsInfo)
        {
            dataGridView1.DataSource = newsInfo;
        }
    }
}
