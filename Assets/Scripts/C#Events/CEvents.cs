using UnityEngine;

/// <summary>
/// Class that holds some C# Events
/// </summary>
public class CEvents : MonoBehaviour
{
    /*
     * Delegates events in Unity are implemented in the same way as in C#... Becaus ewe are using C#.
     * https://learn.unity.com/tutorial/delegates#
     */

    // Declare a delegate type
    public delegate void MyNoArgumentsDelegate();

    public delegate void MyDelegateInt(int value);

    public delegate void MyDelegateString(string value);

    // Declare an event of the delegate type
    public static MyNoArgumentsDelegate myNoArgumentsEvent;
    public static MyDelegateInt myIntegerEvent;
    public static MyDelegateString myStringEvent;
    
    private int _localCounter;
    
    private void OnEnable() 
    {
        // Subscribe to the event. Note that the method is not called with parentheses
        myNoArgumentsEvent += NoArgumentsEvent;

        // This method has an integer parameter as same as our delegate
        myIntegerEvent += IncreaseLocalCounter;

        // This method has no arguments, but our delegate has a string parameter. This will throw an error
        //myIntegerEvent += NoArgumentsEvent;

        // This method has a string parameter as same as our delegate
        myStringEvent += PrintMessage;
    }

    private void OnDisable()
    {
        // Don't forget to unsubscribe from the event
        myNoArgumentsEvent -= NoArgumentsEvent;
        myIntegerEvent -= IncreaseLocalCounter;
        myStringEvent -= PrintMessage;
    }

    /// <summary>
    /// Function that will be called when the event is invoked
    /// </summary>
    private void NoArgumentsEvent()
    {
        Debug.Log($"Resseting local counter: {_localCounter = 0}");
    }

    /// <summary>
    /// Inline function that will be called when the event is invoked
    /// </summary>
    /// <param name="value"></param>
    private void IncreaseLocalCounter(int value) => Debug.Log($"Local Counter: { _localCounter += value}");

    /// <summary>
    /// Inline function that will be called when the event is invoked
    /// </summary>
    /// <param name="message"></param>
    private void PrintMessage(string message) => Debug.Log($"My message: {message}");

    private void Update()
    {
        //We are using the mouse buttons to invoke the events. we are no longer using Unity Events for this but
        //we could use them as well.

        if(Input.GetMouseButtonDown(0))
            myNoArgumentsEvent?.Invoke();
        if(Input.GetMouseButton(0))
            myIntegerEvent?.Invoke(1);
        if(Input.GetMouseButtonUp(0))
            myStringEvent?.Invoke("Mouse released");
    }
}
