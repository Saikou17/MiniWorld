using UnityEngine;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// elementClass is a class that represents a element in the game
    /// It has a lot of elements that are common to all elements
    /// </summary>
    public class Element
    {
        private ElementData _elementData;
        public ElementData ElementData => _elementData;

        public Element()
        {
            _elementData = new ElementData();
            Spawn();
        }

        public Element(string name, string @class, int level = 1, int life = 100)
        {
            _elementData = new ElementData(name, @class, level, life);
            Spawn();
        }

        /// <summary>
        /// Notifies that the element has spawned
        /// </summary>
        private void Spawn()
        {
            Debug.Log($"{_elementData.GetName()} of class {_elementData.GetClass()} has spawned");
        }

        /// <summary>
        /// Increases the element's life
        /// </summary>
        /// <param name="life"></param>
        public void IncreaseLife(int life)
        {
            _elementData.IncreaseLife(life);
        }

        /// <summary>
        /// Decreases the element's life
        /// </summary>
        /// <param name="life"></param>
        public void DecreaseLife(int life)
        {
            _elementData.DecreaseLife(life);
        }

        /// <summary>
        /// Kills the element
        /// </summary>
        public void Kill()
        {
            _elementData.DecreaseLife(_elementData.life);
            Debug.Log($"{_elementData.GetName()} has been killed");
        }

        /// <summary>
        /// Mpves the element to a specific position
        /// </summary>
        /// <param name="position"></param>
        public void StartPosition(Vector3 position)
        {
            Debug.Log($"{_elementData.GetName()} is moving to {position}");
        }

        /// <summary>
        /// Plays a specific VFX for the element
        /// </summary>
        /// <param name="vfxName"></param>
        public void PlayVFX(string vfxName)
        {
            Debug.Log($"{_elementData.GetName()} is playing {vfxName}");
        }

        /// <summary>
        /// Plays a specific SFX for the element
        /// </summary>
        /// <param name="sfxName"></param>
        public void PlaySFX(string sfxName)
        {
            Debug.Log($"{_elementData.GetName()} is playing {sfxName}");
        }

        /// <summary>
        /// Plays a specific animation for the element
        /// </summary>
        /// <param name="animationName"></param>
        public void PlayAnimation(string animationName)
        {
            Debug.Log($"{_elementData.GetName()} is playing {animationName}");
        }
    }
}