using System.Data;
using System;
using UnityEngine;

/**
 * P L A Y E R   M O V E M E N T
 *
 * Super simple player movement script.
 * Note - the movement vector below moves the player around
 * in a plane in 3D space.
 */

public class Player : MonoBehaviour
{
  private float speed = 10;

  public void Update()
  {
    Vector3 input = new Vector3(
      // Input.GetAxis vs. Input.GetAxisRaw
      // ----------------------------------
      // Input.GetAxis smoothes the input over time, whereas
      // Input.GetAxisRaw applies no smoothing. The latter is
      // prefferable if you want to add your own easing.
      Input.GetAxisRaw("Horizontal"),
      Input.GetAxisRaw("Vertical"),
      0
    );

    Vector3 direction = input.normalized;
    Vector3 velocity = direction * speed;
    Vector3 moveAmount = velocity * Time.deltaTime;

    transform.position += moveAmount;
  }
}
