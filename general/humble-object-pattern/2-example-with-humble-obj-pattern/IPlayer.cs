using UnityEngine;

public interface IPlayer
{
  Vector3 Position { get; set; }
  float MaxHeight { get; }
  float MinHeight { get; }
}