using System.Data;
using System;
using UnityEngine;

/**
 * P L A Y E R   S A V E   /   L O A D   S Y S T E M
 *
 * Rudimentary player loading and saving. Saves to a
 * binary file.
 */

public class Player : MonoBehaviour
{
  public int level = 3;
  public int health = 40;
  public bool flightEnabled = false;

  public void SavePlayer()
  {
    SaveSystem.Save(this);
    Debug.Log("--------------");
    Debug.Log("SAVED SETTINGS");
    Debug.Log("--------------");
    Debug.Log("Level: " + level);
    Debug.Log("Health: " + health);
    Debug.Log("Flight Enabled: " + flightEnabled);
  }

  public void LoadPlayer()
  {
    PlayerData data = SaveSystem.LoadPlayer();
    level = data.level;
    health = data.health;
    flightEnabled = data.flightEnabled;
    Vector3 position;
    position.x = data.position[0];
    position.y = data.position[1];
    position.z = data.position[2];
    transform.position = position;

    Debug.Log("-----------------");
    Debug.Log("RESTORED SETTINGS");
    Debug.Log("-----------------");
    Debug.Log("Level: " + level);
    Debug.Log("Health: " + health);
    Debug.Log("Flight Enabled: " + flightEnabled);
  }

  // can assign a unity Input to target this method
  public void setLevel(string _level)
  {
    level = _stringToInt(_level);
  }

  // can assign a unity Input to target this method
  public void setHealth(string _health)
  {
    health = _stringToInt(_health);
  }

  // can assign a unity Input to target this method
  public void setFlightEnabled(bool _flightEnabled)
  {
    flightEnabled = _flightEnabled;
  }

  private int _stringToInt(string input)
  {
    try
    {
      int result = Int32.Parse(input);
      return result;
    }
    catch (FormatException)
    {
      Debug.LogError($"Unable to parse '{input}'");
      return 0;
    }
  }
}
