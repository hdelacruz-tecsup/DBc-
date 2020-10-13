using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab03
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string Password = Encrypt.GetSHA256(txtPasword.Text.Trim());

            using (Models.db_lab03Entities2 db = new Models.db_lab03Entities2())
            {
                var lst = from u in db.usuario1
                          where u.nombre == txtUsuario.Text
    && u.password == Password
                          select u;

                if (lst.Count() > 0)
                {
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario no Existe");
                }
            }
        }

        private void txtPasword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
