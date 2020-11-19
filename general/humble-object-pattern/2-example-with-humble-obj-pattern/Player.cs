using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
  private BirdController _birdController;

  [SerializedField]
  private int maxHeight = 3;
  // public float MaxHeight { get { return maxHeight; } }
  // I think the following getter lambda will work:
  public float MaxHeight => maxHeight;

  [SerializedField]
  private int minHeight = 3;
  // public float MinHeight { get { return minHeight; } }
  // I think the following getter lambda will work:
  public float MinHeight => minHeight;

  public Vector3 Position
  {
    get { return transform.position; }
    set { transform.position; }
  }

  private void Awake()
  {
    _birdController = new BirdController(this);
  }

  private void Update()
  {
    float vertical = Input.GetAxis("Vertical");
    _birdController.Move(vertical);
  }
}