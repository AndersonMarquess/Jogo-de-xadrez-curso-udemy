using tabuleiro;

namespace xadrez {

    class Dama : Peca {

        public Dama(Tabuleiro tabuleiro, Cor cor) : base(cor, tabuleiro) {
        }

        public override string ToString() {
            return "D";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.getPeca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha, pos.Coluna - 1);
            }

            // direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha, pos.Coluna + 1);
            }

            // acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna);
            }

            // abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna);
            }

            // NO
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // SO
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            while (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}

