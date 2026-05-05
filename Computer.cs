using System;
using System.Linq;
using System.Collections.Generic;

namespace Chess
{
    public enum BotDifficulty
    {
        Basic,
        Mid,
        High
    }

    // Contains the evaluation and move-search logic used by the computer player.
    class Computer
    {
        private static readonly IChessBot[] AvailableBots =
        {
            ChessBotFactory.Create(BotDifficulty.Basic),
            ChessBotFactory.Create(BotDifficulty.Mid),
            ChessBotFactory.Create(BotDifficulty.High)
        };

        public Computer()
        {
        }
        public static int Depth = 3;
 
        public static bool MovePutKingInCheck = false;
        public static BotDifficulty Difficulty = BotDifficulty.Mid;
        private static readonly Random RandomMovePicker = new Random();

        public static IChessBot CurrentBot
        {
            get
            {
                foreach (IChessBot bot in AvailableBots)
                {
                    if (bot.Difficulty == Difficulty)
                    {
                        return bot;
                    }
                }

                return AvailableBots[1];
            }
        }
 
 
 
        public static int EvaluatePos()
        {
            // The score combines material, king activity in the endgame, and whether the move gave check.
            int Evaluation = 0;
            int EndGameWeight = GameControl.GetEndGameWeight();
            if (MovePutKingInCheck == true)
            {
                Evaluation += 150 * GameControl.GetEndGameWeight() > 4 ? 3 : 1;
            }
            int OpposingKingSquare = PieceLocator.GetLocationsOf(GameControl.OpposingSide() | Piece.King)[0];
            int FriendlyKingSquare = PieceLocator.GetLocationsOf(GameControl.computerSide | Piece.King)[0];

            int OpposingKingRow = OpposingKingSquare % 8;
            int OpposingKingCol = OpposingKingSquare / 8;

            int FriendlyKingRow = FriendlyKingSquare % 8;
            int FriendlyKingCol = FriendlyKingSquare / 8;
            int DistanceBetweenKingsCols = Math.Abs(FriendlyKingCol - OpposingKingCol);
            int DistanceBetweenKingsRows = Math.Abs(FriendlyKingRow - OpposingKingRow);
            int DistanceBetweenKings = DistanceBetweenKingsCols + DistanceBetweenKingsRows;

            Evaluation += 14 - (DistanceBetweenKings * EndGameWeight);
            int OpposingKingsDistanceFromCentreRow = Math.Max(3 - OpposingKingRow, OpposingKingRow - 4);
            int OpposingKingsDistanceFromCentreCol = Math.Max(3 - OpposingKingCol, OpposingKingCol - 4);
            int OpponsingKingsDistanceFromCentre = OpposingKingsDistanceFromCentreRow + OpposingKingsDistanceFromCentreCol;

            Evaluation += (OpponsingKingsDistanceFromCentre * EndGameWeight);
            Evaluation += PieceLocator.GetPosEval();

            return Evaluation;
        }
 
 
 
        public static Move GenerateMove()
        {
            Console.WriteLine("Generating Computer Move");
            Move moveToPlay = new Move { Piece = 0, MoveFrom = -1, MoveTo = -1 };
            List<Move> AvailableMoves = RuleBook.GenerateLegalMoves();
            if (AvailableMoves.Count == 0) 
            {
                return moveToPlay;
            }

            if (Difficulty != BotDifficulty.High)
            {
                return CurrentBot.ChooseMove(AvailableMoves);
            }

            moveToPlay = GenerateHighMove(AvailableMoves);
            return moveToPlay;
        }

        public static Move GenerateHighMove(List<Move> availableMoves)
        {
            Move moveToPlay = new Move { Piece = 0, MoveFrom = -1, MoveTo = -1 };
 
 
 
            if (GameControl.Moves < 8)
            {
                Console.WriteLine("Move within first four, getting opening move");
                moveToPlay = OpeningBook.GetMove(availableMoves);

                if (moveToPlay.MoveFrom != -1)
                {
                    Console.WriteLine($"Opening move chosen: {DescribeMove(moveToPlay)}");
                    return moveToPlay;
                }
            }
            int BestEval = -999999999;
            availableMoves = sortMoves(availableMoves);

            // Try each move on a temporary board, search the reply tree, then undo it.
 
 
 
 
            foreach (Move move in availableMoves.ToArray())
            {

                GameControl.makeTestMove(move);
                int moveEval = (GetMoveEvaluationToDepthOf(Depth, -100000000, 100000000)*-1) + LocationInscentives.GetLocationInscentiveFor(move.Piece, move.MoveTo)*-1;

                Console.WriteLine($"Best eval for move {Piece.PieceToFullName(move.Piece)} moves from {move.MoveFrom} to {move.MoveTo}: {moveEval} "); 
                if (moveEval > BestEval)
                {
                    BestEval = moveEval;
                    moveToPlay = move;
                }

                GameControl.unmakeTestMove(move);
            }

            Console.WriteLine($"Computer chooses {DescribeMove(moveToPlay)} with eval {BestEval}");

            return moveToPlay;
        }

        public static Move GenerateBasicMove(List<Move> availableMoves)
        {
            int index = RandomMovePicker.Next(availableMoves.Count);
            Move moveToPlay = availableMoves[index];
            Console.WriteLine($"Basic difficulty picks {DescribeMove(moveToPlay)}");
            return moveToPlay;
        }

        public static Move GenerateMidMove(List<Move> availableMoves)
        {
            // Mid difficulty uses a one-move heuristic instead of a deeper search.
            Move bestMove = availableMoves[0];
            int bestScore = -100000;

            foreach (Move move in availableMoves)
            {
                int score = 0;
                int capturedPiece = GameControl.Board[move.MoveTo].PieceOnSquare;

                if (capturedPiece != 0)
                {
                    score += Piece.Value(capturedPiece) - Piece.Value(move.Piece);
                }

                if (RuleBook.EnemyAttacks.Contains(move.MoveTo))
                {
                    score -= Piece.Value(move.Piece);
                }

                if (Piece.Type(move.Piece) == Piece.Pawn && Piece.Type(RuleBook.CheckPromotion(move)) == Piece.Queen)
                {
                    score += Piece.Value(Piece.Queen);
                }

                score += LocationInscentives.GetLocationInscentiveFor(move.Piece, move.MoveTo);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }

            Console.WriteLine($"Mid difficulty picks {DescribeMove(bestMove)} with score {bestScore}");
            return bestMove;
        }

        private static string DescribeMove(Move move)
        {
            if (move == null || move.MoveFrom < 0 || move.MoveTo < 0)
            {
                return "no legal move";
            }

            int fromRow = 8 - (move.MoveFrom / 8);
            int toRow = 8 - (move.MoveTo / 8);
            char fromCol = (char)('a' + (move.MoveFrom % 8));
            char toCol = (char)('a' + (move.MoveTo % 8));
            return $"{Piece.PieceToFullName(move.Piece)} {fromCol}{fromRow} to {toCol}{toRow}";
        }
 
 
 
 
        public static int GetMoveEvaluationToDepthOf(int depth, int alpha, int beta)
        {
            // Negamax with alpha-beta pruning for the high-difficulty search.
            if(depth == 0)
            {
                return EvaluatePos();
            }

            List<Move> responses = RuleBook.GenerateLegalMoves();
 
            MovePutKingInCheck = false;
            if(RuleBook.KingInCheck == true)
            {
                MovePutKingInCheck = true;
            }

            if(responses.Count == 0)
            {
                if(MovePutKingInCheck == true)
                {
                    return -10000 * depth;
                }
                return 0;
            }

            responses = sortMoves(responses);

            foreach(Move response in responses.ToArray())
            {
                GameControl.makeTestMove(response);
                int MoveEval = (GetMoveEvaluationToDepthOf(depth - 1, -beta, -alpha) * -1);
                GameControl.unmakeTestMove(response);
                if(MoveEval >= beta)
                {
                    return beta;
                }
                alpha = Math.Max(alpha, MoveEval);
            }

            return alpha;
        }
 
 
        public static List<Move> sortMoves(List<Move> moveList)
        {
            // Order stronger-looking moves first so pruning happens earlier.
            foreach (Move move in moveList)
            {
                int moveScore = 0;
                int piece = move.Piece;
                int capturedPiece = GameControl.Board[move.MoveTo].PieceOnSquare;

                if (capturedPiece != 0)
                {
                    moveScore = Piece.Value(capturedPiece) - Piece.Value(piece);
                }

                if(MovePutKingInCheck == true)
                {
                    moveScore += 300;
                }

                if (RuleBook.SquaresToMoveToThatStopCheck.Contains(move.MoveTo))
                {
                    moveScore += 100;
                }

                if (RuleBook.EnemyAttacks.Contains(move.MoveTo))
                {
                    moveScore -= 250;
                }

                if (Piece.Type(piece) == Piece.Pawn && Piece.Type(RuleBook.CheckPromotion(move)) == Piece.Queen)
                {
                    moveScore += 500;
                }

                move.MoveScore = moveScore;
            }

            moveList = QuickSort(moveList.ToArray(), 0, moveList.Count - 1).ToList();
            moveList.Reverse();

            return moveList;
        }
        public static Move[] QuickSort(Move[] unsortedList, int leftStartPointer, int rightStartPointer)
        {
            int leftPointer = leftStartPointer;
            int rightPointer = rightStartPointer;
            int pivotNumber = unsortedList[leftPointer].MoveScore;

            while (leftPointer <= rightPointer) 
            {
                while (unsortedList[leftPointer].MoveScore < pivotNumber)
                {
                    leftPointer++;
                }
                while (unsortedList[rightPointer].MoveScore > pivotNumber)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
 
                    Move moveHolder = unsortedList[leftPointer];
                    unsortedList[leftPointer] = unsortedList[rightPointer];
                    unsortedList[rightPointer] = moveHolder;
                    leftPointer++;
                    rightPointer--;
                }
            }

            if (leftStartPointer < rightPointer)
            {
                QuickSort(unsortedList, leftStartPointer, rightPointer);
            }
            if (leftPointer < rightStartPointer)
            {
                QuickSort(unsortedList, leftPointer, rightStartPointer);
            }

            Move[] sortedList = unsortedList;

            return sortedList;

        }
    }
}

