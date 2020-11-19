using System;
using System.Collections.Generic;
using UnityEngine;

// This is great as a pool if you are only pooling one
// thing in your game. If you are pooling more than one
// thing, you may want to move to a more generic solution.
public class BlasterShotPool : MonoBehaviour
{
  [SerializeField] private BlasterShot blasterShotPrefab;

  private Queue<BlasterShot> blasterShots = new Queue<BlasterShot>();

  // singleton design pattern (there can only be one!)
  // note - singleton functionality not fully fleshed out.
  public static BlasterShotPool Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
    // additional code would need to be added here to make sure that
    // another instance doesn't already exist, and also to make sure
    // that the one instance never gets destroyed while the game is
    // running.
  }

  public BlasterShot Get()
  {
    if (blasterShots.Count == 0)
    {
      AddShots(1);
    }

    return blasterShots.Dequeue();
  }

  // The reason AddShots takes a number is
  // to add ability to preload the queue if needed
  // ---------------------------------------------
  // private void OnEnable()
  // {
  //   AddShots(10);
  // }

  private void AddShots(int count)
  {
    for (int i = 0; i < count; i++)
    {
      BlasterShot blasterShot = Instantiate(blasterShotPrefab);
      blasterShot.gameObject.SetActive(false);
      blasterShots.Enqueue(blasterShot);
    }
  }

  public void ReturnToPool(BlasterShot blasterShot)
  {
    blasterShot.gameObject.SetActive(false);
    blasterShots.Enqueue(blasterShot);
  }
}
