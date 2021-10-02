namespace Bowling {
  public record GameState {
    public int[,] board = new int[12, 2];
    public int currentMove = 1;
    public int currentThrow = 1;
  }
}