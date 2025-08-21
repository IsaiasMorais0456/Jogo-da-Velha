using System;

class Program
{
    static void Main()
    {


        // tabuleiro vazio
        char[,] tabuleiro = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        char jogadorAtual = 'X'; // começa com X
        int jogadas = 0; // Contador 


        while (true)
        {
            MostrarTabuleiro(tabuleiro); // Mostra o tabuleiro atualizado
            Jogada(tabuleiro, jogadorAtual); // envia para a função Jogada
            jogadas++;


            if (VerificarVitoria(tabuleiro, jogadorAtual)) //
            {
                MostrarTabuleiro(tabuleiro); // Mostra o tabuleiro atualizado
                Console.WriteLine("\n\t♛---------------------------♛");
                Console.WriteLine($"\t|     Jogador {jogadorAtual} venceu!     |");
                Console.WriteLine("\t♛---------------------------♛\n");

                break;
            }


            if (jogadas == 9) // indica empate
            {
                MostrarTabuleiro(tabuleiro);
                Console.WriteLine("\n\t𖦹---------------------------𖦹");
                Console.WriteLine($"\t|         Deu Velha!         |");
                Console.WriteLine("\t𖦹---------------------------𖦹\n");
                break;
            }

            // Alterna jogador: se era X, passa a ser O, e vice-versa 
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
        }
    }

    static void MostrarTabuleiro(char[,] t)
    { //literalmente faz um tabuleiro
        Console.Clear(); //limpa o console
        Console.WriteLine("\t⋆---------------------------⋆");
        Console.WriteLine("\t|       JOGO DA VELHA       |");
        Console.WriteLine("\t⋆---------------------------⋆\n");
        Console.WriteLine("\t\t  0   1   2");  // Colunas
        for (int i = 0; i < 3; i++)
        {
            Console.Write("\t\t" + i + " "); // linhas
            for (int j = 0; j < 3; j++)
            {
                Console.Write(t[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("\t\t ---+---+---");
        }
    }

    static void Jogada(char[,] t, char jogador)
    { //Função que recebe as informações do usuário
        int linha, coluna;
        string linha1, coluna1;
        do
        {
            Console.Write($"\nJogador {jogador}, informe o número da linha: ");
            linha1 = Console.ReadLine(); //le resposta
            linha = int.Parse(linha1); // transforma em inteiro
            Console.Write($"\nJogador {jogador}, informe o número da coluna: ");
            coluna1 = Console.ReadLine(); //le resposta 
            coluna = int.Parse(coluna1); // transforma em inteiro
        } while (linha < 0 || linha > 2 || coluna < 0 || coluna > 2 || t[linha, coluna] != ' ');


        t[linha, coluna] = jogador; //Coloca X ou O na posição escolhida
    }

    static bool VerificarVitoria(char[,] t, char jogador)
    {
        // Verificação de linhas e colunas
        for (int i = 0; i < 3; i++)
        {
            if (t[i, 0] == jogador && t[i, 1] == jogador && t[i, 2] == jogador) return true; // linha
            if (t[0, i] == jogador && t[1, i] == jogador && t[2, i] == jogador) return true; // coluna
        }

        // Verificação das diagonais
        if (t[0, 0] == jogador && t[1, 1] == jogador && t[2, 2] == jogador) return true;
        if (t[0, 2] == jogador && t[1, 1] == jogador && t[2, 0] == jogador) return true;

        return false; // Se não venceu
    }
}