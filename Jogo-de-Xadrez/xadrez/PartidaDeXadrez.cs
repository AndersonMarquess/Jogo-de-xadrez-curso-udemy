using System.Collections.Generic;
using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool partidaFinalida { get; private set; }
        public bool xeque { get; private set; }
        private HashSet<Peca> pecasHashSet;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            partidaFinalida = false;
            xeque = false;
            pecasHashSet = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPeca();
        }

        //Movimenta uma peça do tabuleiro, remove uma peça se o destino já estiver ocupado
        public Peca executarMovimento(Posicao origem, Posicao destino) {
            Peca pecaMovida = tab.retiraPeca(origem);
            pecaMovida.incrementarMovimento();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(pecaMovida, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public Peca desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca pecaMovida = tab.retiraPeca(destino);
            pecaMovida.decrementarMovimento();
            //Peca pecaCapturada = tab.retiraPeca(origem);
            tab.colocarPeca(pecaMovida, origem);
            if (pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            return pecaCapturada;
        }

        //Aciona o gatilho de mover a peça
        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca capturada = executarMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, capturada);
                throw new TabuleiroException("Seu rei ficou em xeque, jogada desfeita");
            }
            if (estaEmXeque(corAdversario(jogadorAtual))) {
                xeque = true; //se o seu movimento não o colocou em xeque então o rei adversario o está
            } else {
                xeque = false;
            }
            //Se o adversario estiver em xequemate então nós ganhamos
            if (testeXequemata(corAdversario(jogadorAtual))) {
                partidaFinalida = true;
                return;
            }
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

        //Retorna a cor do adversario
        private Cor corAdversario(Cor cor) {
            if (cor == Cor.Branco) {
                return Cor.Preto;
            } else { 
                return Cor.Branco;
            }
        }

        //Retorna o rei de acordo com a cor especificada
        private Peca getRei(Cor cor) {
            foreach (Peca item in pecasEmJogo(cor)) {
                //is serve para verificar se o Item é uma Instancia de rei
                if (item is Rei) {
                    return item;
                }
            }
            return null;
        }

        //Verifica se o rei da cor especificada está em xeque
        //public bool estaEmXeque(Cor cor) {
        public bool estaEmXeque(Cor cor) {
            Peca rei = getRei(cor);
            if (rei == null) {
                throw new TabuleiroException("O Rei da cor: "+cor+" Não está em jogo BIZARRO!");
            }

            foreach (Peca item in pecasEmJogo(corAdversario(cor))) {
                bool[,] mat = item.movimentosPossiveis();
                if (mat[rei.posicao.Linha, rei.posicao.Coluna]) {
                    //ConsoleColor original = Console.ForegroundColor;
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("O Rei da cor: "+ corAdversario(cor) + " está em xeque.");
                    //Console.ForegroundColor = original;
                    return true;
                }
            }
            return false;
        }

        //Verifica se esta em xequemate
        public bool testeXequemata(Cor cor) {
            if (!estaEmXeque(cor)) {
                return false;
            }

            foreach (Peca item in pecasEmJogo(cor)) {
                bool[,] mat = item.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++) {
                    for (int j = 0; j < tab.colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = item.posicao;
                            Posicao destino = new Posicao(i, j);
                            //Verifica se após fazer algum movimento o rei continua em xeque
                            Peca pecaCapturada = executarMovimento(origem, destino);
                            bool testXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (testXeque) { 
                                return testXeque;
                            }
                        }
                    }
                }


            }
            return true;
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
            if (!tab.getPeca(origem).movimentoPossivel(destino)) {
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
            //colocarNovaPeca('c', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('b', 1, new Torre(tab, Cor.Branco));
            //colocarNovaPeca('c', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('h', 7, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branco));

            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preto));
            //colocarNovaPeca('c', 7, new Torre(tab, Cor.Preto));
            //colocarNovaPeca('d', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preto));
            //colocarNovaPeca('e', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('a', 8, new Rei(tab, Cor.Preto));
        }
    }
}
