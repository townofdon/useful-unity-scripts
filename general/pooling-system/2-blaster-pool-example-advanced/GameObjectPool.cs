using System;
using System.Collections.Generic;
using UnityEngine;

// This is a more generic example for the blaster. I don't know
// what this example accomplishes, since this pool is really
// only limited to a single object type at one time.
public class GameObjectPool : MonoBehaviour
{
  [SerializeField] private GameObject prefab;

  private Queue<GameObject> objects = new Queue<GameObject>();

  // singleton design pattern (there can only be one!)
  // note - singleton functionality not fully fleshed out.
  public static GameObjectPool Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
    // additional code would need to be added here to make sure that
    // another instance doesn't already exist, and also to make sure
    // that the one instance never gets destroyed while the game is
    // running.
  }

  public GameObject Get()
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
      GameObject newObject = GameObject.Instantiate(prefab);
      newObject.SetActive(false);
      objects.Enqueue(newObject);

      // what the heck? what is a #region?
      // it's just a handy way to signify parts of the code that
      // should be collapsible: https://www.dotnetperls.com/region
      #region
      // We need to link the object to this pool so we can
      // access it later.
      newObject.GetComponent<IGameObjectPooled>().Pool = this;
      #endregion
    }
  }

  public void ReturnToPool(GameObject objectToReturn)
  {
    objectToReturn.SetActive(false);
    objects.Enqueue(objectToReturn);
  }
}

// Need to define the interface in each file apparently?
// Should look into a way to define this in a separate file.
internal interface IGameObjectPooled
{
  GameObjectPool Pool { get; set; }
}
