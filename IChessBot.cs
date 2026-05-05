using System.Collections.Generic;

namespace Chess
{
    // Lets the game swap bot behavior by difficulty without changing the game window code.
    public interface IChessBot
    {
        string Name { get; }
        BotDifficulty Difficulty { get; }
        int ThinkingDelayMilliseconds { get; }
        Move ChooseMove(List<Move> availableMoves);
    }
}

