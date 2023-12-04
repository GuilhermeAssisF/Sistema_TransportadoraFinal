using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//botao de fechar
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//botao de login
        {
            ConectaBanco con = new ConectaBanco();
            if (con.verifica(txtlogin.Text,txtsenha.Text)== true)
            {
                Sistema sis = new Sistema();
                this.Hide();
                sis.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("USUARIO OU SENHA INCORRETOS" + con.mensagem);

            }
        }
    }
}
