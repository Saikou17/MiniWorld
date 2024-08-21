using UnityEngine;

/// <summary>
/// Singleton class that can be used to store global variables and methods
/// </summary>
public class UnitySingleton : MonoBehaviour
{
    private int _localCounter;

    // Singleton pattern, note how the instance is private and static
    private static UnitySingleton _instance;

    // Singleton pattern, note how the instance is public and static
    public static UnitySingleton Instance
    {
        get
        {
            // If the instance is null, try to find it in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<UnitySingleton>();

                // If the instance is still null, create a new GameObject and add the UnitySingleton component to it
                if (_instance == null)
                {
                    // Create a new GameObject
                    GameObject go = new GameObject();
                    // Set the name of the GameObject to the name of the class
                    go.name = typeof(UnitySingleton).Name;
                    // Add the UnitySingleton component to the GameObject and set it as the instance
                    _instance = go.AddComponent<UnitySingleton>();
                    // Make the GameObject persistent across scenes
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// Prints a message to the console
    /// </summary>
    /// <param name="message"></param>
    public void PrintMessageSingleton(string message)
    {
        Debug.Log(message);
    }

    /// <summary>
    /// Increases the local counter by a given value and prints it to the console
    /// </summary>
    /// <param name="counter"></param>
    public void IncreaseLocalCounterSingleton(int counter)
    {
        _localCounter += counter;
        Debug.Log("Local Counter: " + _localCounter);
    }
}
