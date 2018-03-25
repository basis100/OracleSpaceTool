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
    public partial class Form_mod : Form
    {
        

        public Form_mod(string s)
        {
            InitializeComponent();

            

            myhostsEntities db = new myhostsEntities();

            var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select c).FirstOrDefault();

              zname.Text = one.DESCRIPTION;
              zip.Text = one.IP;
              zuser.Text = one.USERNAME;
              zpass.Text = mytools.DecryptDES(one.PASSWORD,"56eg56eg");
              zsid.Text = one.SID;
              zport.Text = one.PORT;
              zother.Text = one.OTHER;
        }



        //修改按钮
        public void button1_Click(object sender, EventArgs e)
        {

            try
            {
                myhostsEntities db = new myhostsEntities();

                var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(zname.Text) select c).FirstOrDefault();

                one.DESCRIPTION = zname.Text;
                one.IP = zip.Text;
                one.USERNAME = zuser.Text;
                one.PASSWORD = mytools.EncryptDES(zpass.Text, "56eg56eg");
                one.SID = zsid.Text;
                one.PORT = zport.Text;
                one.OTHER= zother.Text;
         
                db.SaveChanges();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

           


        }





        

    }






}
