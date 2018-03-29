using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool partidaFinalida { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            colocarPeca();
            partidaFinalida = false;
        }

        //Movimenta uma peça do tabuleiro, remove uma peça se o destino já estiver ocupado
        public void executarMovimento(Posicao origem, Posicao destino) {
            Peca pecaMovida = tab.retiraPeca(origem);
            pecaMovida.incrementarMovimento();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(pecaMovida, destino);
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



        //Coloca uma peça no tabuleiro com a classe PosicaoXadrez, essa aceita char e linha e retorna posicao.
        private void colocarPeca() {
            tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('c',1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('c',2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('d',2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('e',1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('e',2).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('d',1).toPosicao());


            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
