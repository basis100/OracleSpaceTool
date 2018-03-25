using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;


namespace ORACLEspace
{
    public partial class Form_new : Form
    {
        

        public Form_new()
        {
            InitializeComponent();
        }



        //保存按钮
        public void button1_Click(object sender, EventArgs e)
        {

            try
            {
                myhostsEntities db = new myhostsEntities();

                HOSTS one = new HOSTS();

                one.DESCRIPTION = zname.Text;
                one.IP = zip.Text;
                one.USERNAME = zuser.Text;
                one.PASSWORD = mytools.EncryptDES(zpass.Text, "56eg56eg");
                one.SID = zsid.Text;
                one.PORT = zport.Text;
                one.OTHER = zother.Text;

                db.HOSTS.AddObject(one);
                db.SaveChanges();
                MessageBox.Show("新增成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }



     

        

    }
}
