using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jogo_dos_Experientes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string JogadorAtual = "X";

        private string[,] grade = new string[3, 3];

        public MainWindow()
        {
            InitializeComponent();

            EncerrarPartida();
        }

        public void TravarJogo()
        {
            btCedula_0_0.IsEnabled = false;
            btCedula_0_1.IsEnabled = false;
            btCedula_0_2.IsEnabled = false;

            btCedula_1_0.IsEnabled = false;
            btCedula_1_1.IsEnabled = false;
            btCedula_1_2.IsEnabled = false;

            btCedula_2_0.IsEnabled = false;
            btCedula_2_1.IsEnabled = false;
            btCedula_2_2.IsEnabled = false;
        }

        public void EncerrarPartida()
        {

            TravarJogo();

            btCedula_0_0.Content = "";
            btCedula_0_1.Content = "";
            btCedula_0_2.Content = "";

            btCedula_1_0.Content = "";
            btCedula_1_1.Content = "";
            btCedula_1_2.Content = "";

            btCedula_2_0.Content = "";
            btCedula_2_1.Content = "";
            btCedula_2_2.Content = "";

            grade = new string[3, 3];


            rbX.IsEnabled = true;
            rbY.IsEnabled = true;


            btIniciarPartida.IsEnabled = true;
            btEncerrarPartida.IsEnabled = false;

            DefinirJogador("X");
        }

        public void IniciarPartida()
        {
            btCedula_0_0.IsEnabled = true;
            btCedula_0_1.IsEnabled = true;
            btCedula_0_2.IsEnabled = true;

            btCedula_1_0.IsEnabled = true;
            btCedula_1_1.IsEnabled = true;
            btCedula_1_2.IsEnabled = true;

            btCedula_2_0.IsEnabled = true;
            btCedula_2_1.IsEnabled = true;
            btCedula_2_2.IsEnabled = true;

            rbX.IsEnabled = false;
            rbY.IsEnabled = false;

            
            btIniciarPartida.IsEnabled = false;
            btEncerrarPartida.IsEnabled = true;
        }

        private void btIniciarPartida_Click(object sender, RoutedEventArgs e)
        {
            this.IniciarPartida();
        }

        private void btEncerrarPartida_Click(object sender, RoutedEventArgs e)
        {
            this.EncerrarPartida();
        }

        private void DefinirJogador(string jogador)
        {
            JogadorAtual = jogador;

            if(lblJogadorAtual != null) {
                lblJogadorAtual.Content = jogador;
            }

            if(jogador == "X")
            {
                rbX.IsChecked = true;
            }

            if(jogador == "O")
            {
                rbY.IsChecked = true;
            }
        }

        private string VerificarGanhador()
        {   
            for(int linha = 0; linha < 3; linha++)
            {
                if (
                    grade[linha, 0] != null &&
                    grade[linha, 0] == grade[linha, 1] && grade[linha, 1] == grade[linha, 2]
                )
                {
                    return grade[linha, 0];
                }
            }

            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (
                    grade[0, coluna] != null &&
                    grade[0, coluna] == grade[1, coluna] && grade[1, coluna] == grade[2, coluna]
                )
                {
                    return grade[0, coluna];
                }
            }

            if (grade[0, 0] != null && grade[0, 0] == grade[1, 1] && grade[1, 1] == grade[2, 2])
            {
                return grade[0, 0];
            }

            if (grade[2, 0] != null && grade[0, 2] == grade[1, 1] && grade[1, 1] == grade[2, 0])
            {
                return grade[0, 0];
            }


            return "";
        }

        private void rbX_Checked(object sender, RoutedEventArgs e)
        {
            DefinirJogador("X");
        }

        private void rbY_Checked(object sender, RoutedEventArgs e)
        {
            DefinirJogador("O");
        }

        private void ConsiderarJogada(int linha, int coluna, Button botaoClicado)
        {

            var casa = grade[linha, coluna];

            if(casa == null)
            {
                grade[linha, coluna] = JogadorAtual;
                
                botaoClicado.Content = JogadorAtual;
                botaoClicado.IsEnabled = false;

                string ganhador = VerificarGanhador();

                if(ganhador != "")
                {
                    MessageBox.Show("O jogador " + JogadorAtual + " ganhou!");
                    TravarJogo();
                } else
                {
                    if (JogadorAtual == "X")
                    {
                        DefinirJogador("O");
                    }
                    else
                    {
                        DefinirJogador("X");
                    }
                }

            } else
            {
                MessageBox.Show("Você está jogando em uma casa ocupada");
            }

        }

        private void btCedula_0_0_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(0, 0, btCedula_0_0);
        }

        private void btCedula_0_1_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(0, 1, btCedula_0_1);
        }

        private void btCedula_0_2_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(0, 2, btCedula_0_2);
        }

        private void btCedula_1_0_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(1, 0, btCedula_1_0);
        }

        private void btCedula_1_1_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(1, 1, btCedula_1_1);
        }

        private void btCedula_1_2_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(1, 2, btCedula_1_2);
        }

        private void btCedula_2_0_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(2, 0, btCedula_2_0);
        }

        private void btCedula_2_1_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(2, 1, btCedula_2_1);
        }

        private void btCedula_2_2_Click(object sender, RoutedEventArgs e)
        {
            this.ConsiderarJogada(2, 2, btCedula_2_2);
        }
    }
}
