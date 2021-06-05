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
using Microsoft.VisualBasic;
using System.Collections;
using System.IO;

namespace GestorDB
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;
        string bdname;
        public int lots;


        public Form1()
        {
            InitializeComponent();
            Conexion c = new Conexion();
            conexion = c.conexion;
            Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bdname = Interaction.InputBox("Ingrese el Nombre de la Base de Datos: ", "Eliminar Base de Datos", "ejemplo",600, 500);
                if (bdname != null)
                {
                    conexion.Open();
                    SqlCommand command = new SqlCommand("DROP DATABASE " + bdname + ";", conexion);
                    command.ExecuteNonQuery();
                    conexion.Close();
                    Load();
                    MessageBox.Show("¡Base de Datos eliminada con éxito!");
                }
            }
            catch (Exception o) { MessageBox.Show("Ocurrió un error inesperado: " + o); conexion.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bdname = Interaction.InputBox("Ingrese el Nombre de la Base de Datos: ", "Crear Base de Datos", "ejemplo", 600, 500);
                if (bdname != null)
                {
                    conexion.Open();
                    SqlCommand command = new SqlCommand("CREATE DATABASE " + bdname + ";", conexion);
                    command.ExecuteNonQuery();
                    conexion.Close();
                    Load();
                    MessageBox.Show("¡Base de Datos creada con éxito!");
                }
            }
            catch (Exception o) { MessageBox.Show("Ocurrió un error inesperado: " + o); conexion.Close(); }

        }
        public void Load()
        {
            treeView1.Nodes.Clear();
            conexion.Open();
            SqlCommand consulta1 = new SqlCommand("SELECT count(*) as Cont FROM master.dbo.sysdatabases", conexion);
            SqlDataReader dr = consulta1.ExecuteReader();
            while (dr.Read())
            {
                lots = dr.GetInt32(0);
            }
            dr.Close();
            SqlCommand consulta2 = new SqlCommand("SELECT name as Nombre FROM master.dbo.sysdatabases", conexion);
            SqlDataReader dr2 = consulta2.ExecuteReader();
            while (dr2.Read())
            {
                treeView1.Nodes.Add(Convert.ToString(dr2["Nombre"]));
            }
            dr2.Close();
            conexion.Close();
            
        }
    }
}
