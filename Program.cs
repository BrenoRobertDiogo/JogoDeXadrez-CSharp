using System;
using tabuleiro;
using xadrez;
namespace XadrezProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        
                        Tela.imprimirPartida(partida);
                        Console.Write("De: ");
                        Posicao origem = Tela.posicaoDoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Para: ");
                        Posicao destino = Tela.posicaoDoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }


                }
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Final do programa");
            Console.ReadKey();
        }
    }
}
