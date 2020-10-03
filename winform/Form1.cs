using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSinStore_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Server=localhost;Database=injectionsql;User Id=SA;Password=Cordova2020_;");
            SqlCommand cmd = new SqlCommand("select * from usuarios where nomusu = '" + txtUsuario.Text + "' and PWDCOMPARE('" + txtPassword.Text + "', pasusu) = 1", cnx);
            cmd.CommandType = CommandType.Text;
            cnx.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show(this, "Ingreso al sistema", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, "No puedo ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnx.Close();
        }

        private void btnConStore_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Server=localhost;Database=injectionsql;User Id=SA;Password=Cordova2020_;");
            SqlCommand cmd = new SqlCommand("usp_login", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usu", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@pas", txtPassword.Text);
            cnx.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show(this, "Ingreso al sistema", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "No puedo ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnx.Close();
        }
    }
}
