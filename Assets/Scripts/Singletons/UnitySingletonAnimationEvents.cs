using UnityEngine;

/// <summary>
/// Class that uses my UnitySingleton class to call its methods through Unity's Animation Events
/// </summary>
public class UnitySingletonAnimationEvents : MonoBehaviour
{
    /*
     * Remember, these methods are called from the Animation Events from within the Unity Editor
     * https://docs.unity3d.com/Manual/script-AnimationWindowEvent.html
     */

    /// <summary>
    /// Returns a simple message to the console 
    /// </summary>
    /// <param name="message"></param>
    public void PrintSingletonMessage(string message)
    {
        // In order to call a methos from a singleton class, you need to call the Instance property
        // [MySingletonClass].Instance.[MyMethod]
        UnitySingleton.Instance.PrintMessageSingleton(message);
    }

    /// <summary>
    /// Returns a simple message to the console with an integer value
    /// </summary>
    /// <param name="counter"></param>
    public void IncreaseSingletonCounter(int counter)
    {
        // In order to call a methos from a singleton class, you need to call the Instance property
        // [MySingletonClass].Instance.[MyMethod]
        UnitySingleton.Instance.IncreaseLocalCounterSingleton(counter);
    }

}
