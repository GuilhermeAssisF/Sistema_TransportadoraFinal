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
    public partial class frmaddprodutocs : Form
    {
        public frmaddprodutocs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sistema formSistema = new Sistema();
            formSistema.ShowDialog();
            this.Close();
            
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {

            ConectaBanco con = new ConectaBanco();
            bool retorno = con.insereProduto(txtaddgenero.Text);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show("Produto adicionado com sucesso");
            txtaddgenero.Clear();
            txtaddgenero.Focus();
        }
    }
}
