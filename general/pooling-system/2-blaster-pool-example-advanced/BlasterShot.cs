using UnityEngine;

public class BlasterShot : MonoBehaviour, IGameObjectPooled
{
  public float moveSpeed = 30f;

  private float lifeTime;
  private float maxLifeTime;

  private GameObjectPool pool;
  public GameObjectPool Pool
  {
    get { return pool; }
    set {
      if (pool == null)
        pool = value;
      else
        throw new System.Exception("Bad pool use, this should only get set once!");
    }
  }

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
      pool.ReturnToPool(this.gameObject);
    }
  }
}

// Need to define the interface in each file apparently?
// Should look into a way to define this in a separate file.
internal interface IGameObjectPooled
{
  GameObjectPool Pool { get; set; }
}
