using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SistemaCadastro//fromulario principal
{
    public partial class Sistema : Form
    {
        int idAlterar;//declara variavel global
        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)//botao de saida do app
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            txtalteraproduto.SelectedTab = txtalteraproduto.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            txtalteraproduto.SelectedTab = txtalteraproduto.TabPages[1];
        }


        void listagridProdutos()//mais usado para atualizar os modificacoes feitas
        {
            ConectaBanco con = new ConectaBanco();
            dgBandas.DataSource = con.listaPedidos();
        }




        private void Sistema_Load(object sender, EventArgs e)
        {
            listaCBProdutos();
            listagridProdutos();
            
        }

        public void listaCBProdutos()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaProdutos();
            cbProduto.DataSource = tabelaDados;
            cbProduto.DisplayMember = "produto";
            cbProduto.ValueMember = "idproduto";

            cbAlteraGenero.DataSource = tabelaDados;
            cbAlteraGenero.DisplayMember = "produto";
            cbAlteraGenero.ValueMember = "idproduto";

        }


        private void txtBusca_TextChanged(object sender, EventArgs e)//tem a funcao de buscar digitando 
        {
            (dgBandas.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("cliente like '{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)//botao que remove pedidos
        {
            int linha = dgBandas.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgBandas.Rows[linha].Cells["idpedido"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Pedido", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaPedido(id);
                if (retorno == true)
                {
                    MessageBox.Show("pedido excluido com sucesso!");
                    listagridProdutos();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

       



        private void btnAlterar_Click(object sender, EventArgs e)//botao de alterar os pedidos
        {
            int linha = dgBandas.CurrentRow.Index;// pega a linha selecionada
            idAlterar = Convert.ToInt32(
              dgBandas.Rows[linha].Cells["idpedido"].Value.ToString());
            txtalteracliente.Text =
                 dgBandas.Rows[linha].Cells["cliente"].Value.ToString();
            txtalteraproduto.Text =
                dgBandas.Rows[linha].Cells["produto"].Value.ToString();
            txtAlteravalor.Text =
                dgBandas.Rows[linha].Cells["valor"].Value.ToString();
            
            // muda aba
        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)//botao de confirmar as alteracoes 
        {

            ConectaBanco con = new ConectaBanco();
            Pedido novoPedido = new Pedido();
            novoPedido.Cliente = txtalteracliente.Text;
            novoPedido.Valor = Convert.ToInt32(txtAlteravalor.Text);
            novoPedido.Produto = Convert.ToInt32(cbAlteraGenero.SelectedValue.ToString());
            bool retorno = con.alteraPedido(novoPedido,idAlterar);
            if (retorno == false)
            {
                MessageBox.Show(con.mensagem);
            }
            else
                MessageBox.Show("Alteração Concluida !");
            listagridProdutos();


        }

        private void bntAddGenero_Click(object sender, EventArgs e)//botao de adicionar o genero pra abri o form
        {
            frmaddprodutocs formproduto = new frmaddprodutocs();
            this.Hide();
            formproduto.ShowDialog();
            this.Close();
        }

        void limpaCampos()
        {
            txtidpedido.Clear();
            cbProduto.Text = "";
            txtclientes.Clear();
            txtvalor.Clear();
            txtidpedido.Focus();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)//confirma cadastro de novo cliente
        {
            ConectaBanco con = new ConectaBanco();
            Pedido novoPedido = new Pedido();
            novoPedido.ID_pedido1 = Convert.ToInt32(txtidpedido.Text);
            novoPedido.Cliente = txtclientes.Text;
            novoPedido.Valor = Convert.ToInt32(txtvalor.Text);
            novoPedido.Produto = Convert.ToInt32(cbProduto.SelectedValue.ToString());
            bool retorno = con.inserePedido(novoPedido);
            if (retorno==false)
            {
                MessageBox.Show(con.mensagem);
            }
            limpaCampos();
            listagridProdutos();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
