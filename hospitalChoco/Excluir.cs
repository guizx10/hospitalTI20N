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
    public partial class Excluir : Form
    {
        DAO bd;
        public Excluir()
        {
            InitializeComponent();
            bd = new DAO();
        }
  
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo cpf

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long CPF = Convert.ToInt64(textBox4.Text);//Coletando o CPF
                //Chamar o método
                MessageBox.Show(bd.Excluir(CPF, "hospitalChoco"));
                //Limpando o banco
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }//fim do try    
        }//fim do botao excluir 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botao cancelar
    }//fim da classe
}//fim do projeto
