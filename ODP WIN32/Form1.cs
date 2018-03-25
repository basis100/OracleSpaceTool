using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Net.Sockets;
using System.Net;
using System.Data.SqlClient;
using System.Threading.Tasks; 

using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;

using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace ORACLEspace
{
    public partial class Form1 : Form
    {

        public static List<TABLESPACE> tablespacelist = new List<TABLESPACE>();

        public static int DBS,DBOK;

        public Form1()
        {
            InitializeComponent();

            list_init();
     
            list2_show();

            

            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                string value = ConfigurationManager.AppSettings[key];

                listBox1.Items.Add(value);
            }

            //10秒一次操作线程
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread m1Thread = new Thread(new ThreadStart(m1));
            m1Thread.IsBackground = true;
            m1Thread.Start();


        }


        private void m1()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);

                string now = System.DateTime.Now.ToShortTimeString();     //得到现在的时间 

                foreach (var tp in listBox1.Items)  //时间点 1:12
                {
                    if (now.Equals(tp.ToString()))
                    {
                        toolStripButton4.PerformClick();
                        Thread.Sleep(1000 * 60);//延迟一分钟，避免一分钟内发多次
                    }
                }
            }
        }



   public  void list_init()
    {
    
            //list2
            listView2.View = View.Details;      
            listView2.GridLines = true;
            listView2.Clear();            
            listView2.Columns.Add("Describe      ");
            listView2.Columns.Add("IP            ");
            listView2.Columns.Add("username      ");       
            listView2.Columns.Add("SID    ");
            listView2.Columns.Add("Port");
          
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //list1
            listView1.View = View.Details;         
            listView1.GridLines = true;
            listView1.Clear();
            listView1.Columns.Add("Tablespace name");
            listView1.Columns.Add("size（MB）    ");
            listView1.Columns.Add("Used（MB）");
            listView1.Columns.Add("Free（MB）");
            listView1.Columns.Add("User%    ");
            listView1.Columns.Add("Free%    ");
            listView1.Columns.Add("other    ");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //list3
            listView3.View = View.Details;
            listView3.GridLines = true;
            listView3.Clear();
            listView3.Columns.Add("Tablespace name");
            listView3.Columns.Add("size（MB）    ");
            listView3.Columns.Add("Used（MB）");
            listView3.Columns.Add("Free（MB）");
            listView3.Columns.Add("User%    ");
            listView3.Columns.Add("Free%    ");
            listView3.Columns.Add("other    ");
            listView3.Columns.Add("Time Point");
            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            history_init();
    }


    ////////////////////
    ////历史记录TAB////
    //////////////////
   //history1 添加数据库名称
   public void history_init()
   {

       comboBox1.Items.Clear(); //history
       comboBox3.Items.Clear(); //Chart

       myhostsEntities db = new myhostsEntities();

       foreach (var one in db.HOSTS.OrderBy(a => a.DESCRIPTION))
            {          
                comboBox1.Items.Add(one.DESCRIPTION);
                comboBox3.Items.Add(one.DESCRIPTION); 
            } 

   }



   private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
   {
      
       string s = comboBox3.SelectedItem.ToString(); //得到选数据库名称

       myhostsEntities db = new myhostsEntities();

       //得到全部的时间点    
       List<string> lx = new List<string>();
       List<string> ly = new List<string>();

       try
       {

           var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select new { c.ID }).FirstOrDefault();

            var alltime = (from a in db.TABLESPACE where a.HOSTID == one.ID select new { a.SAVETIME }).Distinct();

           foreach (var t in alltime)
           {
              lx.Add(t.SAVETIME.Value.ToShortDateString()); //放入了日期时间点
               
               //计算该日期时间点的磁盘空间数据
               var allpage = from a in db.TABLESPACE
                             where
                                 (
                                 a.HOSTID == one.ID &&
                                 a.SAVETIME.Value == t.SAVETIME.Value
                                 )
                             select a;

               long alltotal = 0;
               foreach (var line in allpage)
               {
                   alltotal = alltotal + (long)line.TOTAL;
               }
               ly.Add((alltotal / 1000).ToString());
               
           }
       }

       catch (Exception ex)
       {
           MessageBox.Show(ex.Message.ToString());
       }

       chart1.Series["GB"].Points.Clear();
      // chart1.Series["GB"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Kagi;
       chart1.Series["GB"].Points.DataBindXY(lx, ly);
       chart1.Titles.Clear();
       chart1.Titles.Add(s + "数据库 磁盘占用空间");
   }


   private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
   {

       comboBox2.Items.Clear();

       string s = comboBox1.SelectedItem.ToString();

       myhostsEntities db = new myhostsEntities();

       var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select new { c.ID }).FirstOrDefault();

       var alltime = (from a in db.TABLESPACE where a.HOSTID == one.ID select new { a.SAVETIME }).Distinct();

       foreach (var t in alltime)
       {
           comboBox2.Items.Add(t.SAVETIME.ToString());
           
       }

   }


   private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
   {
        myhostsEntities db = new myhostsEntities();

        string s1 = comboBox1.SelectedItem.ToString();
        var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s1) select new { c.ID }).FirstOrDefault(); //主机ID




       string s = comboBox2.SelectedItem.ToString(); //时间

       DateTime ts = t(s);
  

       var allpage = from a in db.TABLESPACE where 
                         (
                         a.HOSTID == one.ID &&
                         a.SAVETIME.Value.Month == ts.Month &&
                          a.SAVETIME.Value.Year == ts.Year &&
                            a.SAVETIME.Value.Day == ts.Day &&
                            a.SAVETIME.Value.Hour == ts.Hour &&
                            a.SAVETIME.Value.Minute == ts.Minute &&
                            a.SAVETIME.Value.Second == ts.Second
                        )
                     select a;

       listView3.BeginUpdate();//工作线程用这个不会闪烁  
       listView3.Items.Clear();
       long alltotal = 0;
       foreach (var line in allpage)
       {
           ListViewItem item = new ListViewItem();//每读到一行就创建一项    
           listView3.Items.Add(item);//然后加到Listview  
           item.Text = line.NAME.ToString();
           item.SubItems.Add(line.TOTAL.ToString());
           item.SubItems.Add(line.USED.ToString());
           item.SubItems.Add(line.FREE.ToString());
           item.SubItems.Add(line.PUSER.ToString());
           item.SubItems.Add(line.PFREE.ToString());
           item.SubItems.Add("");
           item.SubItems.Add(line.SAVETIME.ToString());  

            alltotal = alltotal + (long)line.TOTAL;
       }
             
          listView3.EndUpdate();
         toolStripStatusLabel5.Text = "Total Size：" + (alltotal / 1000).ToString() + "G";

   }


   ////////////////////
   ////数据库实例TAB///
   ////////////////////

    //数据库清单显示
    public void list2_show()
    {

        listView2.BeginUpdate();//工作线程用这个不会闪烁  
        listView2.Items.Clear();

        myhostsEntities db = new myhostsEntities();

        foreach (var z in db.HOSTS.OrderBy(a =>a.DESCRIPTION))
        {
            ListViewItem item = new ListViewItem();//每读到一行就创建一项    
            listView2.Items.Add(item);//然后加到Listview  
            item.Text = z.DESCRIPTION.ToString();           
            item.SubItems.Add(z.IP.ToString());
            item.SubItems.Add(z.USERNAME.ToString());         
            item.SubItems.Add(z.SID.ToString());
            item.SubItems.Add(z.PORT.ToString());
        }
        listView2.EndUpdate();
    }

    //数据库清单新增
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        Form_new w = new Form_new();
        w.ShowDialog();   
        list2_show();
    }
    //数据库清单修改
    private void toolStripButton2_Click(object sender, EventArgs e)
    {
        if (listView2.FocusedItem == null) { MessageBox.Show("Please select one！"); return; }
       
        Form_mod f3 = new Form_mod(listView2.FocusedItem.SubItems[0].Text);
        f3.ShowDialog(this);
        list2_show();
       
    }

    //数据库清单删除
    private void toolStripButton3_Click(object sender, EventArgs e)
    {
        if (listView2.FocusedItem == null) { MessageBox.Show("Please select one！"); return; }

            string s = listView2.FocusedItem.SubItems[0].Text;

            if (MessageBox.Show("delete " + s + " ?", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                myhostsEntities db = new myhostsEntities();

                var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select c).FirstOrDefault();

                db.DeleteObject(one);
                db.SaveChanges();
                list2_show();

            }
       
     
    }

    //抓取全部数据库信息按钮
    private void toolStripButton4_Click(object sender, EventArgs e)
    {
        DBS = 0; DBOK = 0;
        myhostsEntities db = new myhostsEntities();

        foreach (HOSTS xxx in db.HOSTS)
        {            
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread subThread = new Thread(new ParameterizedThreadStart(silent_oracle)); //多线程
            subThread.Start(xxx);

            DBS++;
        }

        toolStripStatusLabel6.Text = string.Format("DB current/total：{0}/{1}", DBS.ToString(), DBOK.ToString());

    }

    //点击抓取数据库信息
    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView2.SelectedItems.Count != 0)
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
            toolStripStatusLabel4.Text = "Current name：" + listView2.FocusedItem.SubItems[0].Text;

            //操作线程
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(new ThreadStart(listoracle));
            thread.IsBackground = true;
            thread.Start();

        }
    }




    //对ORACLE数据库查询
    public void silent_oracle(object xxx)
    {

            List<TABLESPACE> list = new List<TABLESPACE>();

            HOSTS one = (HOSTS)xxx;
        
            String zip = one.IP;
            String zuser = one.USERNAME;
            String zpass = mytools.DecryptDES(one.PASSWORD, "56eg56eg");
            String zsid = one.SID;
            String zport = one.PORT;

            string s_conn = "Data Source=(DESCRIPTION="
                  + "(ADDRESS=(PROTOCOL=TCP)(HOST=" + zip.Trim() + ")(PORT=" + zport.Trim() + "))"
                  + "(CONNECT_DATA=(SERVICE_NAME=" + zsid.Trim() + ")));"
                  + "User Id=" + zuser.Trim() + ";Password=" + zpass.Trim() + ";";

            OracleConnection conn = new OracleConnection(s_conn);

            try
            {

                conn.Open();             

                if (!conn.State.ToString().Equals("Open")) {  return; }

                //取一般表空间
                string sql = "SELECT A.TABLESPACE_NAME, round(A.BYTES/1024/1024) TOTAL_MB, round(B.BYTES/1024/1024) USED_MB, round(C.BYTES/1024/1024) FREE_MB,round((B.BYTES*100)/A.BYTES) USED_PER,round((C.BYTES*100)/A.BYTES) FREE_PER FROM SYS.SM$TS_AVAIL A,SYS.SM$TS_USED B,SYS.SM$TS_FREE C WHERE A.TABLESPACE_NAME=B.TABLESPACE_NAME AND A.TABLESPACE_NAME=C.TABLESPACE_NAME";

                OracleCommand comm = new OracleCommand(sql, conn);
                OracleDataReader r = comm.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new TABLESPACE
                    {
                        NAME = r.IsDBNull(0) ? "" : r.GetString(0),
                        TOTAL = r.IsDBNull(1) ? 0 : r.GetInt32(1),
                        USED = r.IsDBNull(2) ? 0 : r.GetInt32(2),
                        FREE = r.IsDBNull(3) ? 0 : r.GetInt32(3),
                        PUSER = r.IsDBNull(4) ? 0 : r.GetInt32(4),
                        PFREE = r.IsDBNull(5) ? 0 : r.GetInt32(5)
                    });
                }

                r.Close();
                comm.Cancel();

             
                //取临时表空间     
                OracleCommand cmd = new OracleCommand("SELECT round(BYTES/1024/1024) From v$tempfile", conn);
                OracleDataReader rr = cmd.ExecuteReader();

                while (rr.Read())
                {
                    list.Add(new TABLESPACE
                    {
                        NAME = "TEMP",
                        TOTAL = rr.IsDBNull(0) ? 0 : rr.GetInt32(0),
                    });
                }

                rr.Close();
                cmd.Cancel();              
               
                ///////////////////////////

                myhostsEntities db = new myhostsEntities();

                DateTime thistime = DateTime.Now;

                foreach (var line in list)
                {
                    TABLESPACE c = new TABLESPACE();

                    c.HOSTID = one.ID;
                    c.NAME = line.NAME;
                    c.TOTAL = line.TOTAL;
                    c.USED = line.USED;
                    c.FREE = line.FREE;
                    c.PUSER = line.PUSER;
                    c.PFREE = line.PFREE;
                    c.SAVETIME = thistime;

                    db.TABLESPACE.AddObject(c);
                }

                db.SaveChanges();


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(one.DESCRIPTION + " " +ex.Message.ToString());
            }

            finally
                {               
                    conn.Close();
                    conn.Dispose();
                    DBOK++;
                    toolStripStatusLabel6.Text = string.Format("DB current/total：{0}/{1}", DBS.ToString(), DBOK.ToString());
                    
                }

              

    }



    //对一个ORACLE数据库查询
    public void listoracle()
    {
        if (listView2.FocusedItem == null) { MessageBox.Show("please select one！"); return; }

        toolStripProgressBar1.Value = 10;//**********

        string s = listView2.FocusedItem.SubItems[0].Text;

        tablespacelist.Clear();
        listView1.Items.Clear();


        myhostsEntities db = new myhostsEntities();

        var one = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select c).FirstOrDefault();


        String zip = one.IP;
        String zuser = one.USERNAME;
        String zpass = mytools.DecryptDES(one.PASSWORD, "56eg56eg");
        String zsid = one.SID;
        String zport = one.PORT;



      


            string s_conn = "Data Source=(DESCRIPTION="
                  + "(ADDRESS=(PROTOCOL=TCP)(HOST=" + zip.Trim() + ")(PORT=" + zport.Trim() + "))"
                  + "(CONNECT_DATA=(SERVICE_NAME=" + zsid.Trim() + ")));"
                  + "User Id=" + zuser.Trim() + ";Password=" + zpass.Trim() + ";";

         

              OracleConnection conn = new OracleConnection(s_conn);
              toolStripProgressBar1.Value = 30;


            try
            {  


                    conn.Open();

                  //  MessageBox.Show(conn.State.ToString());

                    if (!conn.State.ToString().Equals("Open")) { toolStripProgressBar1.Value = 0; return; }

                    //取一般表空间
                    string sql = "SELECT A.TABLESPACE_NAME, round(A.BYTES/1024/1024) TOTAL_MB, round(B.BYTES/1024/1024) USED_MB, round(C.BYTES/1024/1024) FREE_MB,round((B.BYTES*100)/A.BYTES) USED_PER,round((C.BYTES*100)/A.BYTES) FREE_PER FROM SYS.SM$TS_AVAIL A,SYS.SM$TS_USED B,SYS.SM$TS_FREE C WHERE A.TABLESPACE_NAME=B.TABLESPACE_NAME AND A.TABLESPACE_NAME=C.TABLESPACE_NAME";

                    OracleCommand comm = new OracleCommand(sql, conn);
                    OracleDataReader r = comm.ExecuteReader();

                    while (r.Read())
                    {
                        tablespacelist.Add(new TABLESPACE
                        {
                            NAME = r.IsDBNull(0) ? "" : r.GetString(0),
                            TOTAL = r.IsDBNull(1) ? 0 : r.GetInt32(1),
                            USED = r.IsDBNull(2) ? 0 : r.GetInt32(2),
                            FREE = r.IsDBNull(3) ? 0 : r.GetInt32(3),
                            PUSER = r.IsDBNull(4) ? 0 : r.GetInt32(4),
                            PFREE = r.IsDBNull(5) ? 0 : r.GetInt32(5)
                        });
                    }

                    r.Close();
                    comm.Cancel();

                    toolStripProgressBar1.Value = 60;
                    //取临时表空间     
                    OracleCommand cmd = new OracleCommand("SELECT round(BYTES/1024/1024) From v$tempfile", conn);
                    OracleDataReader rr = cmd.ExecuteReader();


                    while (rr.Read())
                    {
                        tablespacelist.Add(new TABLESPACE
                        {
                            NAME = "TEMP",
                            TOTAL = rr.IsDBNull(0) ? 0 : rr.GetInt32(0),
                        });
                    }

                    rr.Close();
                    cmd.Cancel();


                    toolStripProgressBar1.Value = 90;
                    //取版本     
                    OracleCommand cmd2 = new OracleCommand("SELECT VERSION from v$instance", conn);
                    OracleDataReader r2 = cmd2.ExecuteReader();

                    while (r2.Read())
                    {
                        string ver = r2.IsDBNull(0) ? " " : r2.GetString(0);
                        toolStripStatusLabel2.Text = "Version：" + ver;
                    }
                    r2.Close();
                    cmd2.Cancel();

                    toolStripProgressBar1.Value = 100;
                    //取日志模式     
                    OracleCommand cmd3 = new OracleCommand("select log_mode from V$Database", conn);
                    OracleDataReader r3 = cmd3.ExecuteReader();

                    while (r3.Read())
                    {
                       
                        string log = r3.IsDBNull(0) ? " " : r3.GetString(0);
                        toolStripStatusLabel3.Text = "Mode：" + log;
                    }
                    r3.Close();
                    cmd3.Cancel();


                    conn.Close();

                    ////////////////控件显示////////////////////////
                    long alltotal = 0;

                    listView1.BeginUpdate();//工作线程用这个不会闪烁  
                    listView1.Items.Clear();
                    foreach (var line in tablespacelist)
                    {
                        ListViewItem item = new ListViewItem();//每读到一行就创建一项    
                        listView1.Items.Add(item);//然后加到Listview  
                        item.Text = line.NAME.ToString();
                        item.SubItems.Add(line.TOTAL.ToString());
                        item.SubItems.Add(line.USED.ToString());
                        item.SubItems.Add(line.FREE.ToString());
                        item.SubItems.Add(line.PUSER.ToString());
                        item.SubItems.Add(line.PFREE.ToString());

                        alltotal = alltotal + (long)line.TOTAL;

                    }

                    listView1.EndUpdate();


                    toolStripStatusLabel1.Text = "Total Size：" + (alltotal / 1000).ToString() + "G";
              
            }

            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message.ToString());

            }

            finally
                {
                    toolStripProgressBar1.Value = 0;
                    conn.Close();
                    conn.Dispose();
               }

    

             
    }









  

    //信息保存
    private void toolStripButton5_Click(object sender, EventArgs e)
    {
        if (listView2.FocusedItem == null) { MessageBox.Show("please select one！"); return; }

        myhostsEntities db = new myhostsEntities();

        string s = listView2.FocusedItem.SubItems[0].Text;
        var host = (from c in db.HOSTS where c.DESCRIPTION.Equals(s) select c).FirstOrDefault();

        DateTime thistime = DateTime.Now;

        foreach ( ListViewItem line in listView1.Items)
        {
            TABLESPACE one = new TABLESPACE();

            one.HOSTID = host.ID;
            one.NAME = line.SubItems[0].Text;
            one.TOTAL = i(line.SubItems[1].Text);
            one.USED = i(line.SubItems[2].Text);
            one.FREE = i(line.SubItems[3].Text);
            one.PUSER = i(line.SubItems[4].Text);
            one.PFREE = i(line.SubItems[5].Text);
            one.SAVETIME = thistime;
            
            db.TABLESPACE.AddObject(one);
        }

        db.SaveChanges();
        MessageBox.Show("Save success！");

    }










    public static int i(object x1)
    {
        if (string.IsNullOrWhiteSpace(x1.ToString())) {return 0;}
        return Convert.ToInt32(x1);

    }

    public static DateTime t(object x1)
    {

        if (s(x1).Equals("0000-00-00")) { x1 = null; }
        return Convert.ToDateTime(x1);

    }

    public static string s(object x1)
    {
        return Convert.ToString(x1);

    }



    private void ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.notifyIcon1.Visible = false;
        this.Close();
        this.Dispose();
        System.Environment.Exit(0);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
        if (e.CloseReason == CloseReason.UserClosing)
        {
            //取消"关闭窗口"事件
            e.Cancel = true;
            //使关闭时窗口向右下角缩小的效果
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = true;
            this.Hide();
            return;
        }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (this.Visible)
        {
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = true;
            this.Hide();
        }
        else
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
    }


    //帮助
    private void toolStripButton6_Click(object sender, EventArgs e)
    {
        string helpfile = @"help.chm";

        Help.ShowHelp(this, helpfile);

    }

   





    }

}
