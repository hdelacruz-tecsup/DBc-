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

namespace Lab03
{
    public partial class Persona1 : Form
    {
        SqlConnection conn;
        public Persona1(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("select * from People1", conn);
            SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                dgvListado.Rows.Add();
                dgvListado.Rows[i].Cells[0].Value = reader["LastName"].ToString();
                dgvListado.Rows[i].Cells[1].Value = reader["FirstName"].ToString();
                dgvListado.Rows[i].Cells[2].Value = reader["HireTime"].ToString();
                i++;
                }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                string FirstName = txtNombre.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaNombre";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@FirstName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = FirstName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    dgvListado.Rows.Add();
                    dgvListado.Rows[i].Cells[0].Value = reader["LastName"].ToString();
                    dgvListado.Rows[i].Cells[1].Value = reader["FirstName"].ToString();
                    dgvListado.Rows[i].Cells[2].Value = reader["HireTime"].ToString();
                    i++;
                }
            }
            else
            {
                MessageBox.Show("La conexion esta cerrada");
            }
        }
    }
}
