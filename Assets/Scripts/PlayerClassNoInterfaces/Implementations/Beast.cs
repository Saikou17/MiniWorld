using System;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// Beast Class
    /// </summary>
    public class Beast
    {
        private Element _element;

        public Beast()
        {
            
        }

        public Beast(string name, string @class, int level = 1, int life = 100)
        {
            _element = new Element(name, @class, level, life);
        }

        /// <summary>
        /// Attacks
        /// </summary>
        public void Attack()
        {
            Console.WriteLine($"{_element.ElementData.GetName()} roars");
        }
    }
}