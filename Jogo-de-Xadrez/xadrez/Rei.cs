using tabuleiro;

namespace xadrez {
    class Rei : Peca {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(cor, tabuleiro) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.getPeca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tabuleiro.getPeca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimento == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // ne
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // se
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // so
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // no
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (tabuleiro.posicaoNoTabuleiro(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadaespecial roque
            if (qtdMovimento == 0 && !partida.xeque) {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    if (tabuleiro.getPeca(p1) == null && tabuleiro.getPeca(p2) == null) {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (testeTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);
                    if (tabuleiro.getPeca(p1) == null && tabuleiro.getPeca(p2) == null && tabuleiro.getPeca(p3) == null) {
                        mat[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}