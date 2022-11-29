using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=iniresponsi";


        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridView r;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);    
        }

        private void btnLoaddata_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                dataGridView1.DataSource = null;
                sql = "select * from st_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd =cmd.ExecuteReader();   
                dt.Load(rd);
                dataGridView1.DataSource = dt;

                conn.Close();

            }

            catch(Exception ex)
            {
                MessageBox.Show("error : " + ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}