using System;
using tabuleiro;

namespace Jogo_de_Xadrez {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.linhas; i++) {

                Console.Write(8 - i+ " ");

                for (int j = 0; j < tab.colunas; j++) {

                    if (tab.getPeca(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        imprimirPeca(tab.getPeca(i, j));
                        Console.Write(" ");
                        //Console.Write(tab.getPeca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branco) {
                Console.Write(peca);
            } else {
                //Classe para mudar a cor
                ConsoleColor auxColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(peca);
                Console.ForegroundColor = auxColor;
            }
        }
    }
}
