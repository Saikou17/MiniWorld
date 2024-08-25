using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Simple class that holds some UnityEvent events
/// </summary>
public class MyUnityEvents : MonoBehaviour
{
    /*
     * UnityEvent is a class that allows you to create events in the editor that can be fired from code.
     * https://docs.unity3d.com/Manual/UnityEvents.html
     *
     * Once you drop this script into some GameObject, you will be able to see the UnityEvents component in the inspector.
     *
     * The UnityEvent class has a generic version that allows you to specify the type of the arguments that the event will have.
     * public UnityEvent<MyType>
     *
     * Remember that the order of the functions in the UnityEvent component is important.
     * The order in which the functions are called is the same as the order in which they are listed in the inspector.
     */

    // Tooltip is a custom attribute that allows you to add a tooltip to a field in the inspector. Over the mouse over the field in Unty to see the tooltip message
    // https://docs.unity3d.com/ScriptReference/TooltipAttribute.html
    [Tooltip("This fdires an event with no arguments")]
    public UnityEvent MyNoArgumentsEvent;

    [Tooltip("This fdires an event with integer arguments")]
    public UnityEvent<int> MyIntegerEvent;

    [Tooltip("This fdires an event with string arguments")]
    public UnityEvent<string> MyStringEvent;
}
