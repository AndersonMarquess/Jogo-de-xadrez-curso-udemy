using tabuleiro;

namespace xadrez {
    class Dama : Peca {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(cor, tabuleiro) {
        }

        public override string ToString() {
            return "D";
        }

        public bool podeMover(Posicao pos) {
            Peca peca = tabuleiro.getPeca(pos);
            return peca == null || peca.cor != this.cor;
        }



        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //NO
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha--;
                pos.Coluna--;
            }


            //NE
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha--;
                pos.Coluna++;
            }

            //SE
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha++;
                pos.Coluna++;
            }

            //SO
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha++;
                pos.Coluna--;
            }

            //Acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha--;
            }

            //Baixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Linha++;
            }

            //Esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Coluna--;
            }

            //Direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && (podeMover(pos))) {
                mat[pos.Linha, pos.Coluna] = true;
                //Verifica se existe uma peça na posição especificada e se a cor dela é diferente
                if ((tabuleiro.getPeca(pos) != null) && (tabuleiro.getPeca(pos).cor != this.cor)) {
                    break;
                }
                pos.Coluna++;
            }

            return mat;
        }
    }
}
