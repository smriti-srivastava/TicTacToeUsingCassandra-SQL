using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.BusinessLayer
{
    public class Game
    {
        public static int[] gameBoard = new int[9];
        public static int currentPlayer = -1;
        public static string playerAccessTokenOne;
        public static string playerAccessTokenTwo;
        public static string gameStatus = "In Progress";

        public static void UpdateGameStatus()
        {
            if ((gameBoard[0] == 1 && gameBoard[1] == 1 && gameBoard[2] == 1) ||
                (gameBoard[3] == 1 && gameBoard[4] == 1 && gameBoard[5] == 1) ||
                (gameBoard[6] == 1 && gameBoard[7] == 1 && gameBoard[8] == 1) ||
                (gameBoard[0] == 1 && gameBoard[3] == 1 && gameBoard[6] == 1) ||
                (gameBoard[1] == 1 && gameBoard[4] == 1 && gameBoard[7] == 1) ||
                (gameBoard[2] == 1 && gameBoard[5] == 1 && gameBoard[8] == 1) ||
                (gameBoard[0] == 1 && gameBoard[4] == 1 && gameBoard[8] == 1) ||
                (gameBoard[2] == 1 && gameBoard[4] == 1 && gameBoard[6] == 1))
            {
                gameStatus = "Player 1 Won!";
            }
            else
            {
                if ((gameBoard[0] == 2 && gameBoard[1] == 2 && gameBoard[2] == 2) ||
                (gameBoard[3] == 2 && gameBoard[4] == 2 && gameBoard[5] == 2) ||
                (gameBoard[6] == 2 && gameBoard[7] == 2 && gameBoard[8] == 2) ||
                (gameBoard[0] == 2 && gameBoard[3] == 2 && gameBoard[6] == 2) ||
                (gameBoard[1] == 2 && gameBoard[4] == 2 && gameBoard[7] == 2) ||
                (gameBoard[2] == 2 && gameBoard[5] == 2 && gameBoard[8] == 2) ||
                (gameBoard[0] == 2 && gameBoard[4] == 2 && gameBoard[8] == 2) ||
                (gameBoard[2] == 2 && gameBoard[4] == 2 && gameBoard[6] == 2))
                {
                    gameStatus = "Player 2 Won!";
                }
                else
                {
                    bool isEmpty = false;
                    for (int index = 0; index < 9; index++)
                    {
                        if (gameBoard[index] == 0)
                        {
                            isEmpty = true;
                            break;
                        }
                    }
                    if (isEmpty)
                    {
                        gameStatus = "In Progress";
                    }
                    else
                    {
                        gameStatus = "Game Over! Draw!";
                    }
                }
            }
        }
        public static void Move(int id, string token)
        {
            if (token != playerAccessTokenOne && token != playerAccessTokenTwo && playerAccessTokenOne != null && playerAccessTokenTwo != null)
                throw new Exception("2 Players are already Playing");
            if (gameStatus == "In Progress")
            {
                if (id > 9 || id < 1)
                {
                    throw new Exception("Invalid Box Id");
                }
                else if(gameBoard[id-1] == 0)
                {
                    if (currentPlayer == 1 && token == playerAccessTokenOne)
                        throw new Exception("Sorry! Invalid Turn. Player 2 Chance");
                    else if (currentPlayer == 2 && token == playerAccessTokenTwo)
                        throw new Exception("Sorry! Invalid Turn. Player 1 Chance");
                    if (playerAccessTokenOne == null)
                    {
                        playerAccessTokenOne = token;
                        currentPlayer = 1;
                    }
                    else if (playerAccessTokenTwo == null && token != playerAccessTokenOne)
                    {
                        playerAccessTokenTwo = token;
                        currentPlayer = 2;
                    }
                    else
                    {

                        if (currentPlayer == 1)
                            currentPlayer = 2;
                        else currentPlayer = 1;
                    }
                    gameBoard[id - 1] = currentPlayer;
                    UpdateGameStatus();
                }
                else
                    throw new Exception("This Box Is Already Filled");
            }
            else
            {
                throw new Exception("Game Is Already Over");
            }
        }
    }
}
