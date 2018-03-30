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

        public void decrementarMovimento() {
            qtdMovimento--;
        }

        //Verifica a existencia de movimentos possíveis
        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        //Valida o destino
        public bool movimentoPossivel(Posicao posDestino) {
            return movimentosPossiveis()[posDestino.Linha, posDestino.Coluna];
        } 

        //Método abstrato PRECISA de uma classe abstrata
        public abstract bool[,] movimentosPossiveis();
        
    }
}
