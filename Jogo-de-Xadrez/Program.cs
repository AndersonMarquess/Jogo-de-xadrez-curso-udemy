using System;
using tabuleiro;
using xadrez;

namespace Jogo_de_Xadrez
{
    class Program {
        static void Main(string[] args) {

            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.partidaFinalida) {

                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Vez da jogada: " + partida.jogadorAtual);

                        Console.WriteLine("");
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.getPeca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);

                    } catch (TabuleiroException e) {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Tela.imprimirTabuleiro(partida.tab);


            }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
