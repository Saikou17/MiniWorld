using UnityEngine;

namespace PlayerClassInterfaces
{
    /// <summary>
    /// Class where we implement the interfaces
    /// </summary>
    public class PlayerInterfaceExample : ILife, IAttack
    {
        /*
         * Notice how we are using the ElementInterface class instead of the Element class
         * Also, we are using multiple interfaces, ILife and IAttack because each child class
         * of this class will have to implement the methods of those interfaces and has those methods.
         */
        private ElementInterface _element;

        public PlayerInterfaceExample()
        {
            
        }

        public PlayerInterfaceExample(string name, string @class, int level = 1, int life = 100)
        {
            _element = new ElementInterface(name, @class, level, life);
        }

        public void IncreaseLife(int amount)
        {
            _element.ElementData.life += amount;
            Debug.Log($"{_element.ElementData.GetName()} increased life by {amount}");
        }

        public void DecreaseLife(int amount)
        {
            _element.ElementData.life -= amount;
            Debug.Log($"{_element.ElementData.GetName()} decreased life by {amount}");
        }

        public void Attack()
        {
            Debug.Log($"Player {_element.ElementData.GetName()} attacks with sword");
        }
    }
}