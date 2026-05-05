using System.Collections.Generic;

namespace Chess
{
    // Shared shape for all difficulty-specific bot classes.
    public abstract class ChessBotBase : IChessBot
    {
        public abstract string Name { get; }
        public abstract BotDifficulty Difficulty { get; }
        public abstract int ThinkingDelayMilliseconds { get; }

        public abstract Move ChooseMove(List<Move> availableMoves);
    }

    public class BasicChessBot : ChessBotBase
    {
        public override string Name => "Basic Bot";
        public override BotDifficulty Difficulty => BotDifficulty.Basic;
        public override int ThinkingDelayMilliseconds => 900;

        public override Move ChooseMove(List<Move> availableMoves)
        {
            return Computer.GenerateBasicMove(availableMoves);
        }
    }

    public class MidChessBot : ChessBotBase
    {
        public override string Name => "Mid Bot";
        public override BotDifficulty Difficulty => BotDifficulty.Mid;
        public override int ThinkingDelayMilliseconds => 650;

        public override Move ChooseMove(List<Move> availableMoves)
        {
            return Computer.GenerateMidMove(availableMoves);
        }
    }

    public class HighChessBot : ChessBotBase
    {
        public override string Name => "High Bot";
        public override BotDifficulty Difficulty => BotDifficulty.High;
        public override int ThinkingDelayMilliseconds => 400;

        public override Move ChooseMove(List<Move> availableMoves)
        {
            return Computer.GenerateHighMove(availableMoves);
        }
    }

    public static class ChessBotFactory
    {
        // Returns the bot object that matches the selected difficulty.
        public static IChessBot Create(BotDifficulty difficulty)
        {
            switch (difficulty)
            {
                case BotDifficulty.Basic:
                    return new BasicChessBot();
                case BotDifficulty.Mid:
                    return new MidChessBot();
                default:
                    return new HighChessBot();
            }
        }
    }
}

