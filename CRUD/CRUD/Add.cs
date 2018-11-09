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
    public partial class Add : Form
    {
        public delegate void Msg(List<NewsInfo> newsInfo);
        public Add()
        {
            InitializeComponent();
        }
        public Msg msg;
        public Add(Msg msg)
        {
            this.msg = msg;
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            NewsTypeDal newsTypeDal = new NewsTypeDal();
            //List<int> list = new List<int>();
            //foreach (TypeInfo typeInfo in newsTypeDal.GetNewsList())
            //{
            //    list.Add(typeInfo.TypeId);
            //}
            comboBox1.DataSource = newsTypeDal.GetNewsList();
            comboBox1.DisplayMember = "TypeConent";
            comboBox1.ValueMember = "TypeId";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NewsInfoDal newInfoDal = new NewsInfoDal();
            NewsInfo newsInfo = new NewsInfo();
            newsInfo.NewsConent = textBox1.Text;
            newsInfo.RegTime = DateTime.Now;
            newsInfo.TypeId =Convert.ToInt32(comboBox1.SelectedValue);
            newInfoDal.InsertNews(newsInfo);
        }
    }
}
