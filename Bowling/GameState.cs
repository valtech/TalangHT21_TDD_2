using System.Text.Json.Serialization;

namespace Bowling
{
  public record Throw {
    public int ThrowOne {get; init;}
    public int ThrowTwo {get; init;}
  };

  public record GameState {
    public Throw[] Frames {get; init;}
    public int CurrentFrame {get; init;}
    public int CurrentThrow {get; init;}
  };
}