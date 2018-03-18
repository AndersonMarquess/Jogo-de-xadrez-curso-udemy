using System;
using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {

        public char posicao { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char posicao, int linha) {
            this.posicao = posicao;
            this.linha = linha;
        }

        //Retorna uma posição valida, lembrando que 'a' tem o valor 1, 'b' é 2...
        public Posicao toPosicao() {
            return new Posicao(8 - linha, posicao - 'a');
        }

        public override string ToString() {
            return ""+posicao+linha;
        }
    }
}
