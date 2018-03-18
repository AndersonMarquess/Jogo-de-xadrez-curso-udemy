using System;
using tabuleiro;

namespace xadrez {
    class Peao : Peca {

        public Peao (Tabuleiro tab, Cor cor) : base(cor, tab) {
        }

        public override string ToString() {
            return "P";
        }
    }
}
