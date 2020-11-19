using UnityEngine;

// could use something like NSubstitute that would give us
// an auto mock obj without needing to create this intermediate
// file.

public class MockPlayer : IPlayer
{
  public Vector3 Position { get; set; }
  public float MaxHeight { get; set; }
  public float MinHeight { get; set; }
}
