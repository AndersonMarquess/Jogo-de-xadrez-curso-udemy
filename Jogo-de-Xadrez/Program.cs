using System;
using tabuleiro;
using xadrez;

namespace Jogo_de_Xadrez
{
    class Program {
        static void Main(string[] args) {
            Tabuleiro t = new Tabuleiro(8, 8);

            t.colocarPeca(new Torre(t, Cor.Branco), new Posicao(0, 0));
            t.colocarPeca(new Torre(t, Cor.Branco), new Posicao(1, 3));
            t.colocarPeca(new Rei(t, Cor.Amarelo), new Posicao(2, 4));


            Tela.imprimirTabuleiro(t);


            Console.ReadLine();
        }
    }
}
