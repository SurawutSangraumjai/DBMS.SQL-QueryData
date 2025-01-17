using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SQL_QueryData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //��С�ȵ������������
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        private void connect()
        {
            string server = @"ADM403-13\SQLEXPRESS";
            string db = "Minimart";
            string strCon = string.Format(@"Data source={0};Initial Catalog={1};"
                         + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }
        private void disconnect()
        {
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            showData("select * from Products");

        }
        private void showData(string sql)
        {
            //string sql = "select * from Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData("select EmployeeID,Title+FirstName+' '+LastName EmpName, Position from Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showData("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData("select * from Products");
        }

    }
}
