using UnityEngine;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// NPC Class
    /// </summary>
    public class NPC
    {
        private Element _element;

        public NPC()
        {
            
        }

        public NPC(string name, string @class, int level = 1, int life = 100)
        {
            _element = new Element(name, @class, level, life);
        }

        public void Attack()
        {
            Debug.Log($"{_element.ElementData.GetName()} fist punch");
        }
    }
}