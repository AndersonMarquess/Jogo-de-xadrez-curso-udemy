using System;
using tabuleiro;

namespace xadrez {
    class Rainha : Peca {

        public Rainha(Tabuleiro tab, Cor cor) : base(cor, tab) {
        }

        public override string ToString() {
            return "Rai";
        }
    }
}
