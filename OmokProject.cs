using System;

namespace omokProject3
{
    class Program
    {
        const int MAX = 19;
        enum GameState
        {
            ContinueGame,
            UserWin,
            ComputerWin
        }

        static void Main(string[] args)
        {
            GameState gameState = GameState.ContinueGame;

            PlayGame(gameState);
            Console.WriteLine("Game Over");
        }

        static void PlayGame(GameState gameState)
        {
            int[,] board = new int[20, 20];
            int xInput = -1;
            int yInput = -1;
            int computerX = -1;
            int computerY = -1;
            int turn = 1;
            Random random = new Random();

            if (gameState == GameState.UserWin)
                turn = 2;
            else if (gameState == GameState.ComputerWin)
                turn = 1;

            while (true)
            {
                PrintBoard(board, xInput, yInput, turn);
                Console.WriteLine();

                while (true)
                {
                    if (turn % 2 != 0)
                    {
                        if (turn == 1)
                        {
                            Console.Write("○'s X, Y : ");
                            string[] input = Console.ReadLine().Split(" ");
                            xInput = int.Parse(input[0]);
                            yInput = int.Parse(input[1]);
                        }
                        else
                        {
                            Console.WriteLine("●'s X, Y : {0} {1}", computerX, computerY);
                            Console.Write("○'s X, Y : ");
                            string[] input = Console.ReadLine().Split(" ");
                            xInput = int.Parse(input[0]);
                            yInput = int.Parse(input[1]);
                        }

                        if (xInput == computerX && yInput == computerY)
                        {
                            Console.WriteLine("Can not put there. Try again.");
                            continue;
                        }
                    }
                    else
                    {
                        do
                        {
                            xInput = random.Next(1, MAX + 1);
                            yInput = random.Next(1, MAX + 1);
                        } while (board[yInput, xInput] != 0);

                        computerX = xInput;
                        computerY = yInput;
                    }

                    if (xInput == 99 && yInput == 99)
                    {
                        return;
                    }
                    else if (xInput < 1 || xInput > MAX || yInput < 0 || yInput > MAX)
                    {
                        Console.WriteLine("Can not put there. Try again.");
                        continue;
                    }
                    else if (board[yInput, xInput] != 0)
                    {
                        Console.WriteLine("Can not put there. Try again.");
                        continue;
                    }
                    else
                        break;
                }
                board[yInput, xInput] = turn % 2 + 1;
                turn++;
                Console.Clear();

                gameState = CheckBoard(board);
                if (gameState == GameState.UserWin)
                {
                    PrintBoard(board, xInput, yInput, turn);
                    Console.WriteLine("\n○ win.");
                    break;
                }
                else if (gameState == GameState.ComputerWin)
                {
                    PrintBoard(board, xInput, yInput, turn);
                    Console.WriteLine("\n● win.");
                    break;
                }
            }
            Console.Write("Play again? (y/n): ");
            string playAgain = Console.ReadLine();

            if (playAgain == "y")
            {
                if (gameState == GameState.UserWin)
                {
                    Console.Clear();
                    PlayGame(GameState.UserWin); // 다음 게임에서 컴퓨터에게 먼저 돌을 놓도록 재귀적으로 호출합니다.
                }
                else if (gameState == GameState.ComputerWin)
                {
                    Console.Clear();
                    PlayGame(GameState.ComputerWin);
                }
            }
        }

        static void PrintBoard(int[,] board, int xInput, int yInput, int turn)
        {
            Console.WriteLine("=========== Let's Play Omok ===========\n");
            Console.WriteLine("  1 2 3 4 5 6 7 8 910111213141516171819");

            for (int y = 1; y <= MAX; y++)
            {
                Console.Write("{0,2}", y);

                for (int x = 1; x <= MAX; x++)
                {
                    if (x == xInput && y == yInput || board[y, x] != 0)
                    {
                        PrintStone(x, y, xInput, yInput, board, turn);
                    }
                    else
                    {
                        PrintLine(x, y);
                    }
                }
            }
        }

        static void PrintStone(int x, int y, int xInput, int yInput, int[,] board, int turn)
        {
            if (board[y, x] == 0 && x == xInput && y == yInput)
            {
                if (turn % 2 == 1)
                {
                    if (x == MAX)
                        Console.WriteLine("○");
                    else
                        Console.Write("○─");
                }
                else
                {
                    if (x == MAX)
                        Console.WriteLine("●");
                    else
                        Console.Write("●─");
                }
            }
            else if (board[y, x] == 1)
            {
                if (x == MAX)
                    Console.WriteLine("●");
                else
                    Console.Write("●─");
            }
            else if (board[y, x] == 2)
            {
                if (x == MAX)
                    Console.WriteLine("○");
                else
                    Console.Write("○─");
            }
        }

        static void PrintLine(int x, int y)
        {
            if (y == 1)
            {
                if (x == 1)
                    Console.Write("┌─");
                else if (x == MAX)
                    Console.WriteLine("┐");
                else
                    Console.Write("┬─");
            }
            else if (y == MAX)
            {
                if (x == 1)
                    Console.Write("└─");
                else if (x == MAX)
                    Console.WriteLine("┘");
                else
                    Console.Write("┴─");
            }
            else
            {
                if (x == 1)
                    Console.Write("├─");
                else if (x == MAX)
                    Console.WriteLine("┤");
                else
                    Console.Write("┼─");
            }
        }

        static GameState CheckBoard(int[,] board)
        {
            for (int y = 1; y <= MAX - 4; y++)
            {
                for (int x = 1; x <= MAX - 4; x++)
                {
                    if (board[y, x] != 0 && board[y + 1, x] != 0 && board[y + 2, x] != 0 && board[y + 3, x] != 0 && board[y + 4, x] != 0)
                    {
                        return board[y, x] == 2 ? GameState.UserWin : GameState.ComputerWin;
                    }
                    else if (board[y, x] != 0 && board[y, x + 1] != 0 && board[y, x + 2] != 0 && board[y, x + 3] != 0 && board[y, x + 4] != 0)
                    {
                        return board[y, x] == 2 ? GameState.UserWin : GameState.ComputerWin;
                    }
                    else if (board[y, x] != 0 && board[y + 1, x + 1] != 0 && board[y + 2, x + 2] != 0 && board[y + 3, x + 3] != 0 && board[y + 4, x + 4] != 0)
                    {
                        return board[y, x] == 2 ? GameState.UserWin : GameState.ComputerWin;
                    }
                    else if (board[y + 4, x] != 0 && board[y + 3, x + 1] != 0 && board[y + 2, x + 2] != 0 && board[y + 1, x + 3] != 0 && board[y, x + 4] != 0)
                    {
                        return board[y + 4, x] == 2 ? GameState.UserWin : GameState.ComputerWin;
                    }
                }
            }
            return GameState.ContinueGame;
        }
    }
}