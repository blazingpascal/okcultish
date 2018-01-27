using System;

namespace AssemblyCSharp
{
    public class GameState
    {
        private UserProfile currentMatch;
        private int score;

        public GameState()
        {
            score = 0;
        }

        public void SetCurrentMatch(UserProfile match)
        {
            currentMatch = match;
        }

        public void IncrementScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }

        public bool TryToRecruit()
        {
            bool success = currentMatch.User.tryToConvert();
            if (success)
            {
                score++;
            }
            currentMatch = null;
            return success;
        }
    }
}
