using NUnit.Framework;
using UnityEngine;

public class PlayerTests
{
  [Test]
  public void PlayerMovesUpOneMeter()
  {
    IPlayer player = new MockPlayer() { MaxHeight = 3, MinHeight = -3 };
    PlayerController playerController = new PlayerController(player);
    playerController.Move(1f);
    Assert.AreEqual(1f, player.Position.y);
  }

  [Test]
  public void PlayerStopsAtMinHeight()
  {
    IPlayer player = new MockPlayer() { MaxHeight = 3, MinHeight = -3 };
    PlayerController playerController = new PlayerController(player);
    playerController.Move(-10f);
    Assert.AreEqual(-3f, player.Position.y);
  }

  [Test]
  public void PlayerStopsAtMaxHeight()
  {
    IPlayer player = new MockPlayer() { MaxHeight = 3, MinHeight = -3 };
    PlayerController playerController = new PlayerController(player);
    playerController.Move(10f);
    Assert.AreEqual(3f, player.Position.y);
  }
}
