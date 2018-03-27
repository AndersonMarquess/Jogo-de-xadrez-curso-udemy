using System;
using tabuleiro;
using xadrez;

namespace Jogo_de_Xadrez
{
    class Program {
        static void Main(string[] args) {
            //Tabuleiro t = new Tabuleiro(8, 8);

            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.partidaFinalida) {

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine("");
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executarMovimento(origem, destino);
                }

                Tela.imprimirTabuleiro(partida.tab);


            }catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            //PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            //Console.WriteLine(pos);

            //Console.WriteLine(pos.toPosicao());




            Console.ReadLine();
        }
    }
}
