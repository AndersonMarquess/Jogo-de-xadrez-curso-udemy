using System;
using tabuleiro;

namespace xadrez {
    class Bispo : Peca {

        public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab) {
        }

        public override string ToString() {
            return "B";
        }
    }
}
