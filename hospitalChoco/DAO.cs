using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Importar o Msql

namespace hospitalChoco
{
    class DAO
    {
        public MySqlConnection conexao;
        public long[] cpf;
        public string[] nome;
        public string[] telefone;
        public string[] email;
        public int i;
        public int contador;

        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;Database=hospitalChoco;Uid=root;password=");
            try
            {
                conexao.Open();//abrir conexao               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado!!\n\n" + ex);
            }
        }//fim do construtor

        public string Inserir(long cpf, string nome, string telefone, string email)
        {

            string inserir = $"Insert into hospitalChoco(cpf, nome, telefone, email) values " +
            $"('{cpf}', '{nome}', '{telefone}','{email}')";

            MySqlCommand sql = new MySqlCommand(inserir, conexao);
            string resultado = sql.ExecuteNonQuery() + "Executado!";
            return resultado;
        }//fim do metodo

        public void PreencherVetor()

        {
            string query = "select * from hospitalChoco";

            //instaciar
            this.cpf = new long[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.email = new string[100];


            //fazer comando de sel~çao do banco
            MySqlCommand sql = new MySqlCommand(query, conexao);
            //leitor do banco
            MySqlDataReader leitura = sql.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                cpf[i] = Convert.ToInt64(leitura["cpf"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                email[i] = leitura["email"] + "";
                i++;//percorrer o vetor
                contador++;//contar qts dados eu tenho
            }//fim do while

            //encerro  a comunicação com o software
            leitura.Close();
        }//fim do preencher


        //criar metodo pra retornar o contador

        public int QuantidadeDados()
        {
            return contador;
        }//fim da quantidade de dados

        public string Atualizar(long cpf, string nomeTabela, string campo, string dado)
        {
            string query = $"update {nomeTabela} set {campo} = '{dado}' where CPF = '{cpf}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + "Atualizado!";
            return resultado;
        }//Fim do Método

        public string Excluir(long cpf, string nomeTabela)
        {
            string query = $"delete from {nomeTabela} where CPF = '{cpf}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + "Excluido!";
            return resultado;
        }//Fim do Excluir   
    }//fim do classe
}//fim do projeto
