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

namespace BienThanhPhong_5951071073
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=BienThanhPhong_5951071073;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            GetStudentsRecord();
        }
        private void GetStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("select* from StudentsTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentsRecordData.DataSource = dt;
        }
        private bool IsValiData()
        { 
            if(txtHo.Text == string.Empty 
                || txtTen.Text == string.Empty 
                || txtDiachi.Text == string.Empty 
                ||string.IsNullOrEmpty(txtSdt.Text)
                ||String.IsNullOrEmpty(txtSBD.Text))
            {
                MessageBox.Show("Có chỗ chưa nhâp thông tin !!!",
                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValiData())
            {
                SqlCommand cmd = new SqlCommand("insert into StudentsTb(Name, FatherName, RollNumber, Address, Mobile) VALUES(@Name, @FatherName, @RollNumber, @Address, @Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHo.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTen.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSdt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
        }
        private void StudentsRecordData_SelectionChanged(object sender, EventArgs e)
        {
            int index = StudentsRecordData.CurrentCell.RowIndex;
            DataTable dt = (DataTable)StudentsRecordData.DataSource;
            if (dt.Rows.Count > 0)
            {
                txtID.Text = StudentsRecordData.Rows[index].Cells[0].Value.ToString();
                txtHo.Text = StudentsRecordData.Rows[index].Cells[1].Value.ToString();
                txtTen.Text = StudentsRecordData.Rows[index].Cells[2].Value.ToString();
                txtSBD.Text = StudentsRecordData.Rows[index].Cells[3].Value.ToString();
                txtDiachi.Text = StudentsRecordData.Rows[index].Cells[4].Value.ToString();
                txtSdt.Text = StudentsRecordData.Rows[index].Cells[5].Value.ToString();
            }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand("update StudentsTb set Name=@Name, FatherName=@FatherName, RollNumber=@RollNumber, Address=@Address, Mobile=@Mobile WHERE StudentsID="+txtID.Text+"", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHo.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTen.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSdt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update StudentsTb set Name=@Name, FatherName=@FatherName, RollNumber=@RollNumber, Address=@Address, Mobile=@Mobile WHERE StudentsID=" + txtID.Text + "", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", txtHo.Text);
            cmd.Parameters.AddWithValue("@FatherName", txtTen.Text);
            cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
            cmd.Parameters.AddWithValue("@Address", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtSdt.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetStudentsRecord();
            txtID.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtSBD.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from StudentsTb WHERE StudentsID=" + txtID.Text + "", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", txtHo.Text);
            cmd.Parameters.AddWithValue("@FatherName", txtTen.Text);
            cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
            cmd.Parameters.AddWithValue("@Address", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtSdt.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetStudentsRecord();
            txtID.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtSBD.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
