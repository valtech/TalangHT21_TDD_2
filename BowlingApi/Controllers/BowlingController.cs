using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bowling;

namespace BowlingApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class BowlingController : ControllerBase
    {
        private readonly ILogger<BowlingController> _logger;
        private readonly BowlingGame _bowling;

        public BowlingController(ILogger<BowlingController> logger)
        {            
            _logger = logger;
            _bowling = new BowlingGame();
        }

        [HttpGet("state")]
        public string Get()
        {
            return renderScoreBoard(_bowling.getState());
        }

        private string renderScoreBoard(GameState gameState) {
            int currentCell = 0;
            var rows = new string[7] {"|", "|", "|", "|", "|", "|", "|"};

            do {
                var cell_row_1 = "-------|";
                var cell_row_2 = String.Format(" {0,5:D} |", currentCell + 1);
                var cell_row_3 = "-------|";
                var cell_row_4 = String.Format(" {0} | {1} |", gameState.board[currentCell, 0], gameState.board[currentCell, 1]);
                var cell_row_5 = "-------|";
                var cell_row_6 = String.Format(" {0,5:D} |", (gameState.board[currentCell, 0] + gameState.board[currentCell, 1]));
                var cell_row_7 = "-------|";

                rows[0] = rows[0] + cell_row_1;
                rows[1] = rows[1] + cell_row_2;
                rows[2] = rows[2] + cell_row_3;
                rows[3] = rows[3] + cell_row_4;
                rows[4] = rows[4] + cell_row_5;
                rows[5] = rows[5] + cell_row_6;
                rows[6] = rows[6] + cell_row_7;
                currentCell++;
            } while(currentCell < 12);


            return String.Join("\n", rows) + "\n\nCurrent move: " + gameState.currentMove + "\nCurrent throw: " + gameState.currentThrow;
        }
    }
}
