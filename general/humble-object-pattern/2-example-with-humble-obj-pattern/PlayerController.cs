using UnityEngine;

public class PlayerController
{
  private IPlayer _player;

  public PlayerController(IPlayer player)
  {
    _player = player;
  }

  public void Move(float vertical)
  {
    _player.Position += Vector3.up * vertical;

    // make sure that position does not exceed limits
    if (_player.position.y > maxHeight)
    {
      _player.position = new Vector3(
        _player.position.x,
        maxHeight,
        _player.position.z
      );
    }
    if (_player.position.y < minHeight)
    {
      _player.position = new Vector3(
        _player.position.x,
        minHeight,
        _player.position.z
      );
    }
  }
}