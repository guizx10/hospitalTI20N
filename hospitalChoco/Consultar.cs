using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospitalChoco
{
    public partial class Consultar : Form
    {
        DAO bd;
        public Consultar()
        {
            InitializeComponent();
            
            bd = new DAO();

            ConfigurarGrid();//Estruturar o grid 
            NomesDados();//Dar os nomes as colunas 
            bd.PreencherVetor();//Consulto banco de dados 
            AdicionarDados();//Inserir linhas na tela
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//fim do dataGrid

        public void NomesDados()
        {
            dataGridView1.Columns[0].Name = "CPF";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Telefone";
            dataGridView1.Columns[3].Name = "Email";

        }//fim do método

        public void AdicionarDados()
        {
            for (int i = 0; i < bd.QuantidadeDados(); i++)
            {
                dataGridView1.Rows.Add(bd.cpf[i], bd.nome[i], bd.telefone[i], bd.email[i]);
            }
        }//fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//o usuario não adiciona linhas
            dataGridView1.AllowUserToAddRows = false;//o usuario não apaga linhas 
            dataGridView1.AllowUserToResizeColumns = false;//o usuario não adiciona colunas
            dataGridView1.AllowUserToResizeRows = false;//o usuario não modifica colunas
            dataGridView1.ColumnCount = 4;//Quanitdade de colunas
        }//fim do metodo
    }//fim da classe
}//fim do projeto
