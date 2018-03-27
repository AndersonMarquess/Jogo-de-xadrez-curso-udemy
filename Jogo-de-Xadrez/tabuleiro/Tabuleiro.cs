namespace tabuleiro {
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

        public Peca getPeca(Posicao posicao) {
            return pecas[posicao.Linha, posicao.Coluna];
        }

        //Verifica primeiro se a posição é valida e dpeois se existe uma peça na posição especificada
        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return getPeca(pos) != null;
        }



        //Coloca a peça X na posição especificada
        public void colocarPeca(Peca peca, Posicao posicao) {
            if (existePeca(posicao)) {
                throw new TabuleiroException("Atenção: Já existe uma peça nessa posição!");
            }
            pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.posicao = posicao;
        }

        //Retira uma peça do tabuleiro
        public Peca retiraPeca(Posicao pos) {
            if (getPeca(pos) == null) {
                return null;
            }
            Peca aux = getPeca(pos);
            aux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        //Verifica se a posição especificada está dentro dos limites do tabuleiro
        public bool posicaoNoTabuleiro (Posicao posicao) {
            if (posicao.Linha < 0 || posicao.Linha >= linhas || posicao.Coluna < 0 || posicao.Coluna >= colunas) {
                return false;
            }
            return true;
        }

        //Retorna uma exceção no console informando que a posição não é valida
        public void validarPosicao(Posicao pos) {
            if (!posicaoNoTabuleiro(pos)) {
                throw new TabuleiroException("Posição inválida.");
            }
        }
    }
}
