using UnityEngine;

namespace PlayerClassInterfaces
{
    public class EnemyInterfaceExample : ILife, IAttack
    {
        /*
         * Notice how we are using the ElementInterface class instead of the Element class
         * Also, we are using multiple interfaces, ILife and IAttack because each child class
         * of this class will have to implement the methods of those interfaces and has those methods.
         */
        private ElementInterface _element;

        public EnemyInterfaceExample()
        {

        }

        public EnemyInterfaceExample(string name, string @class, int level = 1, int life = 100)
        {
            _element = new ElementInterface(name, @class, level, life);
        }

        public void IncreaseLife(int amount)
        {
            _element.ElementData.life += amount;
            // Debug.Log($"{_element.ElementData.GetName()} increased life by {amount}");
        }

        public void DecreaseLife(int amount)
        {
            _element.ElementData.life -= amount;
            Debug.Log($"{_element.ElementData.GetName()} decreased life by {amount}");
        }

        public void Attack()
        {
            Debug.Log($"Enemy {_element.ElementData.GetName()} attacks with magic");
        }
    }
}