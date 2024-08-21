using UnityEngine;

namespace PlayerClassInterfaces
{
    public class ElementInterface
    {
        private ElementInterfacesData _elementData;
        public ElementInterfacesData ElementData => _elementData;

        public ElementInterface()
        {
            _elementData = new ElementInterfacesData();
            Spawn();
        }

        public ElementInterface(string name, string @class, int level = 1, int life = 100)
        {
            _elementData = new ElementInterfacesData(name, @class, level, life);
            Spawn();
        }

        /// <summary>
        /// Notifies that the element has spawned
        /// </summary>
        private void Spawn()
        {
            Debug.Log($"{_elementData.GetName()} of class {_elementData.GetClass()} has spawned");
        }
    }
}