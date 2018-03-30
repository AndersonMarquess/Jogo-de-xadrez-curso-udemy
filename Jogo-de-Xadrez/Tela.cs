using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Jogo_de_Xadrez {
    class Tela {

        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.partidaFinalida) {
                Console.WriteLine("Vez da jogada: " + partida.jogadorAtual);
                if (partida.xeque) {
                    ConsoleColor original = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("XEQUE!");
                    Console.ForegroundColor = original;
                }
            } else {
                Console.WriteLine("Xequemate!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }


        public static void imprimirCapturadas(PartidaDeXadrez partida) {
            Console.Write("Peças Brancas capturadas: ");
            imprimirConjuntos(partida.pecasCapturadas(Cor.Branco));
            Console.WriteLine("");

            ConsoleColor original = Console.ForegroundColor;
            Console.Write("Peças Pretas capturadas: ");
            Console.ForegroundColor = ConsoleColor.Green;
            imprimirConjuntos(partida.pecasCapturadas(Cor.Preto));
            Console.ForegroundColor = original;
        }


        public static void imprimirConjuntos(HashSet<Peca> conjuntos) {
            Console.Write("[ ");
            foreach (Peca item in conjuntos) {
                Console.Write(item +" ");
            }
            Console.Write(" ]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i+ " ");
                for (int j = 0; j < tab.colunas; j++) {
                    imprimirPeca(tab.getPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] possioesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.Yellow;

            for (int i = 0; i < tab.linhas; i++) {

                Console.Write(8 - i+ " ");

                for (int j = 0; j < tab.colunas; j++) {
                    if (possioesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.getPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }


        //Lê uma entrada de dados do teclado
        public static PosicaoXadrez lerPosicaoXadrez() {
            String escolha = Console.ReadLine();
            Char coluna = escolha[0];
            int linha = int.Parse(escolha[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        //Imprime uma peça no console
        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            } else {
                
                if (peca.cor == Cor.Branco) {
                    Console.Write(peca);
                } else {
                    //Classe para mudar a cor
                    ConsoleColor auxColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                    Console.ForegroundColor = auxColor;
                }
                Console.Write(" ");
            }
        }
    }
}
