using System;

namespace Bowling
{
    public class BowlingGame
    {
        private GameState _gameState = new GameState {
            Frames = new Throw[]{
                new Throw{ThrowOne = 0, ThrowTwo = 0}, new Throw{ThrowOne = 0, ThrowTwo = 0}, 
                new Throw{ThrowOne = 0, ThrowTwo = 0}, new Throw{ThrowOne = 0, ThrowTwo = 0},
                new Throw{ThrowOne = 0, ThrowTwo = 0}, new Throw{ThrowOne = 0, ThrowTwo = 0}, 
                new Throw{ThrowOne = 0, ThrowTwo = 0}, new Throw{ThrowOne = 0, ThrowTwo = 0},
                new Throw{ThrowOne = 0, ThrowTwo = 0}, new Throw{ThrowOne = 0, ThrowTwo = 0}
            },
            CurrentFrame = 1,
            CurrentThrow = 1
        };

        public GameState getState() {
            return _gameState;
        }
    }
}
