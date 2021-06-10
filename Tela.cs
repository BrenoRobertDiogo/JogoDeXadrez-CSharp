using tabuleiro;
using System;
using xadrez;
using System.Collections.Generic;
namespace XadrezProjeto
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + "    ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    Tela.imprimirPeca(tab.peca(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("     a   b   c   d   e   f   g   h");
        }

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Tela.imprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);

            Console.WriteLine(partida.turno + " turno");
            Console.WriteLine("Aguardando " + partida.jogadorAtual + "s jogarem");
            if (partida.xeque)
            {
            Console.WriteLine("XEQUE");

            }

            Console.WriteLine("\n===== MOVIMENTANDO PEÇA =====");
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write(" | Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x+" ");
            }
            Console.Write("]");

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + "    ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("     a   b   c   d   e   f   g   h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez posicaoDoXadrez()
        {
            string s = Console.ReadLine();
            char linha = s[0];
            int coluna = int.Parse(s[1] + "");
            return new PosicaoXadrez(linha, coluna);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-   ");
            }
            else
            {


                ConsoleColor aux = Console.ForegroundColor;
                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(peca);
                Console.ForegroundColor = aux;
                Console.Write("   ");
            }
        }
    }
}
