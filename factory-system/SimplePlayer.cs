using System.Collections;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
  [SerializeField]
  private GameObject[] particles;

  public int Health { get; internal set; }

  public void ShowParticle(int index)
  {
    GameObject particle = particles[index];

    particle.SetActive(true);
    StartCoroutine(HideParticleAfterSecond(particle));
  }

  private IEnumerator HideParticleAfterSecond(GameObject particle)
  {
    yield return new WaitForSeconds(1);
    particle.SetActive(false);
  }
}