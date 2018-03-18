using System;


namespace tabuleiro
{
    class Peca {
        public Posicao posicao { set; get; }
        public Cor cor { set; protected get; }
        public int qtdMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro) {
            this.posicao = posicao;
            this.cor = cor;
            this.qtdMovimento = 0;
            this.tabuleiro = tabuleiro;
        }

        
    }
}
