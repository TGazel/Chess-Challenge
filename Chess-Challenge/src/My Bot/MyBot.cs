using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    bool BotInit;
    int[,] WhiteDangerLvl;
    int[,] BlackDangerLvl;


    public Move Think(Board board, Timer timer)
    {
        if (!this.BotInit) //initialisation with precalculated values at start
        {
            this.WhiteDangerLvl = new int[8,8];
            this.BlackDangerLvl = new int[8,8];
        }

        Move[] moves = board.GetLegalMoves();
        Move move = moves[0];
        //board.MakeMove(move);
        //board.UndoMove(move);
        return move;
    }
    
}