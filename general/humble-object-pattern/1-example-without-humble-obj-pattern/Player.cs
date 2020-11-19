using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializedField]
  private int maxHeight = 3;

  [SerializedField]
  private int minHeight = 3;

  private void Update()
  {
    float vertical = Input.GetAxis("Vertical");
    Move(vertical);
  }

  private void Move(float vertical)
  {
    transform.position += Vector3.up * vertical;

    // make sure that position does not exceed limits
    if (transform.position.y > maxHeight)
    {
      transform.position = new Vector3(
        transform.position.x,
        maxHeight,
        transform.position.z
      );
    }
    if (transform.position.y < minHeight)
    {
      transform.position = new Vector3(
        transform.position.x,
        minHeight,
        transform.position.z
      );
    }
  }
}