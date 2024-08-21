using UnityEngine;

namespace PlayerClassInterfaces
{
    public class BeastNoAttackInterfaceExample: ILife
    {
        /*
         * Notice how we are using the ElementInterface class instead of the Element class
         * Also, we are using interface ILife but no attack class.
         */
        private ElementInterface _element;

        public BeastNoAttackInterfaceExample()
        {
            
        }

        public BeastNoAttackInterfaceExample(string name, string @class, int level = 1, int life = 100)
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
    }
}