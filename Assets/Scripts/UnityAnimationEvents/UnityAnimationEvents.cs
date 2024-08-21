using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Class that exemplifies the use of Unity's Animation Events
/// </summary>
public class UnityAnimationEvents : MonoBehaviour
{
    private int _localCounter = 0;

    /*
     * Remember, these methods are called from the Animation Events from within the Unity Editor
     * https://docs.unity3d.com/Manual/script-AnimationWindowEvent.html
     */

    /// <summary>
    /// Returns a simple message to the console
    /// </summary>
    /// <param name="message"></param>
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }

    /// <summary>
    /// Inmcreases the local counter by a given value and prints it to the console
    /// </summary>
    /// <param name="counter"></param>
    public void IncreaseLocalCounter(int counter)
    {
        _localCounter += counter;
        Debug.Log("Local Counter: " + _localCounter);
    }

    /// <summary>
    /// Returns a simple message to the console with an integer value
    /// </summary>
    /// <param name="message"></param>
    /// <param name="value"></param>
    public void PrintMessageWithInt(string message, int value)
    {
        Debug.Log(message + " " + value);
    }

    /// <summary>
    /// Uses an object type from the Animation Event
    /// </summary>
    /// <param name="obj"></param>
    public void MyObjectMethod(Object obj)
    {
        // https://www.c-sharpcorner.com/blogs/is-and-as-keywords-in-c-sharp

        // Object class is the base class for all objects in the Unity Scene
        Debug.Log("Object name: " + obj.name + " Object type: " + obj.GetType());

        // Examples of use of 'is' keyword
        Debug.Log($"Given Object IS a Material? [{obj is Material}]");
        Debug.Log($"Given Object IS an AudioClip? [{obj is AudioClip}]");
        Debug.Log($"Given Object IS an GameObject? [{obj is GameObject}]");
        Debug.Log($"Given Object IS an Texture2D? [{obj is Texture2D}]");

        // Cast the Object type into a more specific type, in this case, Texture2D using the 'as' keyword
        // https://www.geeksforgeeks.org/c-sharp-as-operator-keyword/
        Texture2D texture = obj as Texture2D;

        // Safe check if our texture is not null
        if (texture != null)
        {
            // Set the texture to the cube material. The cube must have a material with a texture.
            // Also, in this example the cube is the same that hoolds this script.
            GetComponent<Renderer>().material.mainTexture = texture;
        }
    }
}
