using System;


namespace tabuleiro {
    class TabuleiroException : Exception {
        
        //Cria uma exceção personalizada
        public TabuleiroException(String mensagem) : base (mensagem) {
        }
    }
}
