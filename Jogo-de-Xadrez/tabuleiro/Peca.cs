using System;


namespace tabuleiro
{
    abstract class Peca {
        public Posicao posicao { set; get; }
        public Cor cor { protected set;  get; }
        public int qtdMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            this.posicao = null;
            this.cor = cor;
            this.qtdMovimento = 0;
            this.tabuleiro = tabuleiro;
        }

        public void incrementarMovimento() {
            qtdMovimento++;
        }

        //Método abstrato PRECISA de uma classe abstrata
        public abstract bool[,] movimentosPossiveis();
        
    }
}
