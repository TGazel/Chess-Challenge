using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    // array (64) of danger values
    int[] WhiteDangerLvl; 
    int[] BlackDangerLvl;

    public MyBot() //initialisation with precalculated values at start (temporary 0)
    {
        this.WhiteDangerLvl = new int[64];
        this.BlackDangerLvl = new int[64];
    }

    public MyBot(int[] wdl, int[] bdl) //initialisation with given values for testing purposes
    {
        if (wdl.GetLength(0) != 64 || bdl.GetLength(0) != 64) //TODO: replace by proper unittest
        {
        this.WhiteDangerLvl = new int[64];
        this.BlackDangerLvl = new int[64];
        }
        this.WhiteDangerLvl = wdl;
        this.BlackDangerLvl = bdl;
    }

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        Move move = moves[0];
        float metric = 1.0F;


        for (int nbm = 0; nbm < moves.GetLength(0); nbm ++)
        {
            Move testmove = moves[nbm];
            float testmetric= 1.0F;
            board.MakeMove(testmove);
            //TODO: update dangerlvls & compute testmetric for decision making
            board.UndoMove(testmove);

            if (testmetric<metric)
            {
                metric = testmetric;
                move = testmove;
            }

        }
        
        return move;
    }
    
}