using UnityEngine;

/// <summary>
/// This class provides the functionality to log messages to the console using UnityEvent events in the inspector
/// </summary>
public class UnityEventsLogger : MonoBehaviour
{
    private int _localCounter;
    /// <summary>
    /// Prints a message to the console
    /// </summary>
    /// <param name="message"></param>
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }

    /// <summary>
    /// Increases the local counter by a given value and prints it to the console
    /// </summary>
    /// <param name="counter"></param>
    public void IncreaseLocalCounter(int counter)
    {
        Debug.Log("Local Counter: " + (_localCounter += counter));
    }

    /// <summary>
    /// Resets the local counter to 0
    /// </summary>
    public void ResetLocalCounter()
    {
        _localCounter = 0;
        Debug.Log("Local Counter Reset");
    }


}
