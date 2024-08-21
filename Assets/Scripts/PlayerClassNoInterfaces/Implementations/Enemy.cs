using UnityEngine;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// Enemy Class
    /// </summary>
    public class Enemy
    {
        private Element _element;

        public Enemy()
        {
            
        }

        public Enemy(string name, string @class, int level = 1, int life = 100)
        {
            _element = new Element(name, @class, level, life);
        }

        public void Attack()
        {
            Debug.Log($"{_element.ElementData.GetName()} trows spell"); 
        }
    }
}