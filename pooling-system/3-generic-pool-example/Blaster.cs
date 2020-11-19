using UnityEngine;

public class Blaster : MonoBehaviour
{
  [SerializedField]
  private float refireRate = .2f;

  private float fireTimer = 0;

  void Update()
  {
    fireTimer += Time.deltaTime;
    if (fireTimer >= refireRate)
    {
      fireTimer = 0;
      Fire();
    }
  }

  private void Fire()
  {
    var shot = BlasterShotPool.Instance.Get();
    shot.transform.rotation = transform.rotation;
    shot.transform.position = transform.position;
    shot.gameObject.SetActive(true);
  }
}
