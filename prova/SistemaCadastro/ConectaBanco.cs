using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=sql10.freemysqlhosting.net;user id=sql10666570;password=iTeWTtSRJx;database=sql10666570");
        public string mensagem;
        //na linha de cima faz a conexão com o banco de daods pedindo os dados da conexao

        public bool inserePedido(Pedido novoPedido)//insere novos pedidos
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_inserePedido", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idpedido", novoPedido.ID_pedido1);
                cmd.Parameters.AddWithValue("cliente", novoPedido.Cliente);
                cmd.Parameters.AddWithValue("valor", novoPedido.Valor);
                cmd.Parameters.AddWithValue("fk_produto", novoPedido.Produto);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }

        }// fim do inserePedido

        public DataTable listaProdutos()//insere novos produtos 
        {
            // comentario
            MySqlCommand cmd = new MySqlCommand("sp_listaProduto", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_generos

        public DataTable listaPedidos()//lista os pedidos no data grid
        {
            MySqlCommand cmd = new MySqlCommand("sp_listapedidos", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_pedidos
        public bool deletaPedido(int idRemovepedido)//deleta os pedidos
        {
            MySqlCommand cmd = new MySqlCommand("sp_removePedido", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpedidos", idRemovepedido);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deletapedido
        public bool alteraPedido(Pedido b, int idpedido)//altera pedidos
        {
            MySqlCommand cmd = new MySqlCommand("sp_alteraPedido", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpedido", idpedido);
            cmd.Parameters.AddWithValue("fk_produto", b.Produto);
            cmd.Parameters.AddWithValue("valor", b.Valor);
            cmd.Parameters.AddWithValue("cliente", b.Cliente);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }//fim
        public bool insereProduto(string nomeProduto)//insere os novos produtos
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereproduto", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome", nomeProduto);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
        }

        public bool verifica(string user, string pass)//verifa a senha do frmlogin
        {
            string senhaHash = biblioteca.makeHash(pass);//biblioteca criada ai chama a sp para verificar se esta cooreto ou nao
            MySqlCommand cmd = new MySqlCommand("consultaLogin", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();// tabela virtual
                da.Fill(ds); //passando os valores consultados para o DataSet
                if (ds.Tables[0].Rows.Count > 0) // verifica se houve retorno
                    return true;
                else
                    return false;

            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
