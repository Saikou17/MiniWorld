using UnityEngine;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// Player Class
    /// </summary>
    public class Player : MonoBehaviour
    {
        private Element _element;

        public Player()
        {
            
        }

        public Player(string name, string @class, int level = 1, int life = 100)
        {
            _element = new Element(name, @class, level, life);
        }


        public void Attack()
        {
            Debug.Log($"{_element.ElementData.GetName()} trows sword"); 
        }
    }
}