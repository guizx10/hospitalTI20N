using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hospitalChoco
{
    public partial class Atualizar : Form
    {
        DAO bd;
        public Atualizar()
        {
            InitializeComponent();
            bd = new DAO();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo cpf

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo campo

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo dado 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os dados do banco 
                long cpf = Convert.ToInt64(textBox1.Text);
                string campo = textBox2.Text;
                string dado = textBox4.Text;
                //Cadastrar
                MessageBox.Show(bd.Atualizar(cpf, "hospitalChoco", campo, dado));//Insere dados no BD
                //limpar os campos
                textBox4.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }//fim do try
        }//fim do botao Atualizar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botao cancelar
    }//fim da classe
}//fim do projeto
