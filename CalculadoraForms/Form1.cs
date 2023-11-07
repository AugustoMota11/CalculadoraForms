using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int numero1;
        string ultimoOp;
        bool novaOperacao;
   
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;

            if (novaOperacao == false && txbTela.Text != "" && txbAux.Text == "")
            {

               

                numero1 = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbAux.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
            }
            else if (txbAux.Text != "")
            {
                btnIgual.PerformClick();
                txbAux.Text = txbTela.Text + botao.Text;
                numero1 = int.Parse(txbTela.Text);
                txbTela.Text = "";
                ultimoOp = botao.Text;
            }


        }
        private void Numero_Click(object sender, EventArgs e)
        {
            
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txbTela.Text != "")
            {
                switch(ultimoOp)
                {
                    case "+":
                        txbAux.Clear();
                        txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                        break;

                    case "-":
                        txbAux.Clear();
                        txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                        break;

                    case "x":
                        txbAux.Clear();
                        txbTela.Text = (numero1 * int.Parse(txbTela.Text)).ToString();
                        break;


                    case "÷":
                        if(int.Parse(txbTela.Text) != 0)
                        {
                            txbAux.Clear();
                            txbTela.Text = (numero1 / int.Parse(txbTela.Text)).ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel divir por 0");

                            
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show ("Dados Inválidos");
            }
        }
    }
}
