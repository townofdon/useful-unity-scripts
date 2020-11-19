using UnityEngine;

public class BlasterShot : MonoBehaviour
{
  public float moveSpeed = 30f;

  private float lifeTime;
  private float maxLifeTime;

  private void OnEnable()
  {
    lifeTime = 0f;
  }

  private void Update()
  {
    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    lifeTime += Time.deltaTime;
    if (lifeTime > maxLifeTime)
    {
      ShotPool.Instance.ReturnToPool(this);
    }
  }
}
