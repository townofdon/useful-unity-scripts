using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System;

// taken from tutorial: Creating Objects in Unity3D using the Factory Pattern
// source: https://www.youtube.com/watch?v=FGVkio4bnPQ

namespace ReflectionFactoryStatic
{
  public abstract class Ability
  {
    // setting abstract methods & properties makes
    // it mandatory that subclasses override them
    public abstract string Name { get; }
    public abstract void Process();
  }

  public class StartFireAbility : Ability
  {
    // the following lambda func is called an "Expression Body Property".
    // for more info: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
    public override string Name => "fire";
    // the above is equivalent to the following:
    // public override string Name { get { return "fire"; } } // this was from Jason's example
    // public override string Name { get => "fire"; } } // I _think_ this works

    public override void Process()
    {
      // show fire particle for N seconds
      GameObject.FindObjectOfType<SimplePlayer>().ShowParticle(0);
    }
  }

  public class HealSelfAbility : Ability
  {
    // the following lambda func is called an "Expression Body Property".
    // for more info: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
    public override string Name => "heal";

    public override void Process()
    {
      var player = GameObject.FindObjectOfType<SimplePlayer>();
      player.health++;
      // Particle 1 was a heal particle effect in Jason's video
      player.ShowParticle(1);
    }
  }

  public static class AbilityFactory
  {
    // looks like Jason uses "name" where I would use the term "key"
    private static Dictionary<string, Type> abilitiesByName;
    private static bool IsInitialized => abilitiesByName != null;

    // This strategy was used to init values for this class and make
    // sure that it is only called once. Apparently it is also
    // possible to add a static class constructor?
    private static void InitializeFactory()
    {
      if (IsInitialized)
        return;

      // high level stuff. This definitely uses the C# Assembly class
      // see: https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly?view=net-5.0
      // see: https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.gettypes?view=net-5.0#System_Reflection_Assembly_GetTypes
      var AbilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
        .Where(myType => myType.IsClass && !myType.IsAbstract && myType.isSubclassOf(typeof(Ability)));

      // initialize dictionary for finding these by name later (could be an enum/id instead of string)
      abilitiesByName = new Dictionary<string, Type>();

      // Get the names and put them into the dictionary
      foreach (var type in abilityTypes)
      {
        // need to instantiate the ability to get its name.
        // I think that a static name property could have also worked??
        var tempEffect = Activator.CreateInstance(type) as Ability;
        abilitiesByName.Add(tempEffect.Name, type);
      }
    }

    public static Ability GetAbility(string abilityType)
    {
      InitializeFactory();

      if (abilitiesByName.ContainsKey(abilityType))
      {
        Type type = abilitiesByName[abilityType];
        // The `as` keyword casts to a type
        var ability = Activator.CreateInstance(type) as Ability;
        return Ability;
      }
    }

    // the `internal` access modifier makes members accessible "only within files in the same assembly"
    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/internal
    internal static IEnumerable<string> GetAbilityNames()
    {
      UnityEngine.Debug.Log("Test");
      InitializeFactory();
      return abilitiesByName.Keys;
    }
  }
}