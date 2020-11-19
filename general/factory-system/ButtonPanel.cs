using ReflectionFactoryStatic;
using UnityEngine;

// attach this script to a panel inside of a canvas to dynamically
// generate buttons for each defined Ability
public class ButtonPanel : MonoBehaviour
{
  [SerializeField]
  private AbilityButton buttonPrefab;

  private void OnEnable()
  {
    foreach (string name in AbilityFactory.GetAbilityNames())
    {
      var button = Instantiate(buttonPrefab);
      button.gameObject.name = name + " Button";
      button.SetAbilityName(name);
      // nest the button inside of this panel
      button.transform.SetParent(transform);
    }
  }
}
