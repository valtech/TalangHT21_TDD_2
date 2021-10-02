using System;

namespace Bowling
{
    public class BowlingGame
    {
        private GameState _gameState = new GameState();

        public GameState getState() {
            return _gameState;
        }
    }
}
