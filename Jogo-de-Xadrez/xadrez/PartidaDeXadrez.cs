using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool partidaFinalida { get; private set; }
        private HashSet<Peca> pecasHashSet;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            partidaFinalida = false;
            pecasHashSet = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPeca();
        }

        //Movimenta uma peça do tabuleiro, remove uma peça se o destino já estiver ocupado
        public void executarMovimento(Posicao origem, Posicao destino) {
            Peca pecaMovida = tab.retiraPeca(origem);
            pecaMovida.incrementarMovimento();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(pecaMovida, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
        }

        //Aciona o gatilho de mover a peça
        public void realizaJogada(Posicao origem, Posicao destino) {
            executarMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        //Muda o jogador que vai realizar o movimento
        public void mudarJogador() {
            if (jogadorAtual == Cor.Branco) {
                jogadorAtual = Cor.Preto;
            } else {
                jogadorAtual = Cor.Branco;
            }
        }

        //Faz um foreach nas peças capturadas e pega adiciona todas as peças da cor especificada em uma hashset e retorna
        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in capturadas) {
                if (item.cor == cor) {
                    aux.Add(item);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in pecasHashSet) {
                if (item.cor == cor) {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }



        public void validarPosicaoOrigem(Posicao posOrigem) {
            if (tab.getPeca(posOrigem) == null) {
                throw new TabuleiroException("Não existem peça na posição escolhida");
            }
            if (jogadorAtual != tab.getPeca(posOrigem).cor) {
                throw new TabuleiroException("A Peça escolhida não é sua");
            }
            if (!tab.getPeca(posOrigem).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para esse peça");
            }

        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!tab.getPeca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Destino invalido!");
            }
        }

        //Coloca uma peça no tabuleiro
        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecasHashSet.Add(peca);
        }

        //Coloca uma peça no tabuleiro com a classe PosicaoXadrez, essa aceita char e linha e retorna posicao.
        private void colocarPeca() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branco));

            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preto));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preto));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preto));
        }
    }
}
