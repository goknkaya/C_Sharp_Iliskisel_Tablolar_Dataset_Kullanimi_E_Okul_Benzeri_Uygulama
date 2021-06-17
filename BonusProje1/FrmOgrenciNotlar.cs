using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-INL76RD3\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string number; //Number of Students
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT DERSAD, SINAV1, SINAV2, SINAV3, PROJE, ORTALAMA, DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @p1",connection);
            command.Parameters.AddWithValue("@p1",number);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
