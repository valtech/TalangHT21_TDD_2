using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bowling;

using System.Text.Json;
using System.Text.Json.Serialization;

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

        [HttpGet("rendered-state")]
        public string GetRenderedState()
        {
            return renderScoreBoard(_bowling.getState());
        }

        [HttpGet("state")]
        public ActionResult GetState()
        {
            return Ok(_bowling.getState());
        }

        private string renderScoreBoard(GameState gameState) {
            int currentCell = 0;
            var rows = new string[7] {"|", "|", "|", "|", "|", "|", "|"};

            do {
                var cell_row_1 = "-------|";
                var cell_row_2 = String.Format(" {0,5:D} |", currentCell + 1);
                var cell_row_3 = "-------|";
                var cell_row_4 = String.Format(" {0} | {1} |", gameState.Frames[currentCell].ThrowOne, gameState.Frames[currentCell].ThrowTwo);
                var cell_row_5 = "-------|";
                var cell_row_6 = String.Format(" {0,5:D} |", (gameState.Frames[currentCell].ThrowOne + gameState.Frames[currentCell].ThrowTwo));
                var cell_row_7 = "-------|";

                rows[0] = rows[0] + cell_row_1;
                rows[1] = rows[1] + cell_row_2;
                rows[2] = rows[2] + cell_row_3;
                rows[3] = rows[3] + cell_row_4;
                rows[4] = rows[4] + cell_row_5;
                rows[5] = rows[5] + cell_row_6;
                rows[6] = rows[6] + cell_row_7;
                currentCell++;
            } while(currentCell < gameState.Frames.Length - 1);

            // Special rendering for the last frame (hacky, i know)
            var row_1 = "-----------|";
            var row_2 = String.Format(" {0,9:D} |", currentCell + 1);
            var row_3 = "-----------|";
            var row_4 = String.Format(" {0} | {1} | {2} |", gameState.Frames[currentCell].ThrowOne, gameState.Frames[currentCell].ThrowTwo, 0);
            var row_5 = "-----------|";
            var row_6 = String.Format(" {0,9:D} |", (gameState.Frames[currentCell].ThrowOne + gameState.Frames[currentCell].ThrowTwo));
            var row_7 = "-----------|";

            rows[0] = rows[0] + row_1;
            rows[1] = rows[1] + row_2;
            rows[2] = rows[2] + row_3;
            rows[3] = rows[3] + row_4;
            rows[4] = rows[4] + row_5;
            rows[5] = rows[5] + row_6;
            rows[6] = rows[6] + row_7;

            return String.Join(Environment.NewLine, rows) + Environment.NewLine + Environment.NewLine 
            + "Current frame: " + gameState.CurrentFrame + Environment.NewLine 
            + "Current throw: " + gameState.CurrentThrow;
        }
    }
}
