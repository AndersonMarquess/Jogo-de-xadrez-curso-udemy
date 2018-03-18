using System;
using tabuleiro;

namespace Jogo_de_Xadrez
{
    class Program {
        static void Main(string[] args) {
            Posicao p;
            p = new Posicao(1,1);
            Console.WriteLine(p);

            Tabuleiro t = new Tabuleiro(8, 8);



            Console.ReadLine();
        }
    }
}
