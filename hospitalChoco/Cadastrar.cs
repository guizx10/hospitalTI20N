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
    public partial class Cadastrar : Form
    {
        DAO bd;
        public Cadastrar()
        {
            InitializeComponent();
            bd = new DAO();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo cpf

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo telefone

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo email

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os dados do banco 
                long cpf = Convert.ToInt64(textBox4.Text);
                string nome = textBox1.Text;
                string telefone = textBox3.Text;
                string email = textBox2.Text;
                //Cadastrar
                MessageBox.Show(bd.Inserir(cpf, nome, telefone, email));//Insere dados no BD
                textBox4.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";                            
            }catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }
        }//fim do botao cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botao cancelar
    }
}
