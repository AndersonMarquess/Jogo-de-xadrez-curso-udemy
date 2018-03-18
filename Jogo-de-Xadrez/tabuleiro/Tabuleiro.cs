﻿namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //Retorna uma peça do tabuleiro na posição especificada
        public Peca getPeca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        //Coloca a peça X na posição especificada
        public void colocarPeca(Peca peca, Posicao posicao) {
            pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.posicao = posicao;
        }
    }
}
