using System;

namespace tabuleiro
{
    class Posicao {
        private int linha;
        private int coluna;

        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public int Linha { get => linha; set => linha = value; }
        public int Coluna { get => coluna; set => coluna = value; }


        public void definirValores(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString() {
            return linha + ", "+coluna;
        }

    }
}
