using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class that calls UnityEvents from our UnityEvents class
/// </summary>
public class UnityAnimationEventCaller : MonoBehaviour
{
    /*
     * Remember, the functions that are going to be triggered by the UnityEvent class are going to be visible once
     * we add the MyUnityEvents class to a GameObject in the scene.
     *
     * This class is used to call the UnityEvent events from MyUnityEvents class.
     *
     * The methods in this class are called from the Unity Animator Events
     */

    // Reference to the UnityEvents class. Thi is the entry point to invoke our UnityEvent events
    [FormerlySerializedAs("_unityEvents")] [SerializeField]
    private MyUnityEvents myUnityEvents;

    /// <summary>
    /// Calls the UnityEvent with no arguments
    /// </summary>
    public void CallUnityEventNoArguments()
    {
        // The ?. operator is a null-conditional operator that allows you to call a method on a null object without throwing an exception.
        myUnityEvents.MyNoArgumentsEvent?.Invoke();
    }

    /// <summary>
    /// Calls the UnityEvent with an integer argument
    /// </summary>
    /// <param name="value"></param>
    public void CallUnityEventInteger(int value)
    {
        myUnityEvents.MyIntegerEvent?.Invoke(value);
    }

    /// <summary>
    /// Calls the UnityEvent with a string argument
    /// </summary>
    /// <param name="value"></param>
    public void CallUnityEventString(string value)
    {
        myUnityEvents.MyStringEvent?.Invoke(value);
    }

}
