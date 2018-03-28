using System;
using tabuleiro;

namespace xadrez {
    class Rei : Peca {

        public Rei(Tabuleiro tab, Cor cor) : base(cor, tab) {
        }

        public override string ToString() {
            return "R";
        }

        public bool podeMover(Posicao pos) {
            Peca peca = tabuleiro.getPeca(pos);
            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //BAIXO
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //BAIXO ESQUERDA
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //ESQUERDA
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //PARA CIMA DIREITA
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //PARA CIMA
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //PARA CIMA ESQUERDA
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            //ESQUERDA
            pos.definirValores(posicao.Linha , posicao.Coluna-1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }

            //PARA BAIXO ESQUERDA
            pos.definirValores(posicao.Linha -1 , posicao.Coluna-1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                //Na matriz informa que a posição onde a peça será movida recebe true
                mat[pos.Linha, pos.Coluna] = true; 
            }
            return mat;
        }
    }
}
