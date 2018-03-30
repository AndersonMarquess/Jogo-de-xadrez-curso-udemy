using tabuleiro;

namespace xadrez {

    class Cavalo : Peca {

        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(cor, tabuleiro) {
        }

        public override string ToString() {
            return "C";
        }

       
        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.getPeca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //Fork do professor Nelio
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 2);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha - 2, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha - 2, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 2);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 2);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 2, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 2, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 2);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
