using System.Collections.Generic;
using UnityEngine;

// This is a really good generic solution that provides
// core functionality that is easy to extend to that
// you can keep track of things in separate pools.
// If you want a new pool, just create a new pool and extend
// this generic class just like `ShotPool`.
public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
  [SerializeField] private T prefab;

  private Queue<T> objects = new Queue<T>();

  // singleton design pattern (there can only be one!)
  // note - singleton functionality not fully fleshed out.
  public static GenericObjectPool<T> Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
    // additional code would need to be added here to make sure that
    // another instance doesn't already exist, and also to make sure
    // that the one instance never gets destroyed while the game is
    // running.
  }

  public T Get()
  {
    if (objects.Count == 0)
    {
      AddObjects(1);
    }

    return objects.Dequeue();
  }

  // The reason AddObjects takes a number is
  // to add ability to preload the queue if needed
  // ---------------------------------------------
  // private void OnEnable()
  // {
  //   AddObjects(10);
  // }

  private void AddObjects(int count)
  {
    for (int i = 0; i < count; i++)
    {
      T newObject = GameObject.Instantiate(prefab);
      newObject.SetActive(false);
      objects.Enqueue(newObject);
    }
  }

  public void ReturnToPool(T objectToReturn)
  {
    objectToReturn.gameObject.SetActive(false);
    objects.Enqueue(objectToReturn);
  }
}
