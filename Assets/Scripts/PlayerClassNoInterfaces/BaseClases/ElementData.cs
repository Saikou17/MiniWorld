namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// Blueprint of any character in the game, since we don't use any Unity method, we don't need to inherit from MonoBehaviour
    /// </summary>
    public class ElementData
    {
        public int life;
        public string name;
        public string @class;
        public int level;

        /// <summary>
        /// Parameter less constructor
        /// </summary>
        public ElementData()
        {

        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="class"></param>
        /// <param name="level"></param>
        /// <param name="life"></param>
        public ElementData(string name, string @class, int level = 1, int life = 100)
        {
            this.name = name;
            // We use @class because class is a reserved keyword in C#
            this.@class = @class;
            this.level = level;
            this.life = life;
        }

        /// <summary>
        /// Increase the character's life
        /// </summary>
        /// <param name="life"></param>
        public void IncreaseLife(int life)
        {
            this.life += life;
        }

        /// <summary>
        /// Decrease the character's life
        /// </summary>
        /// <param name="life"></param>
        public void DecreaseLife(int life)
        {
            this.life -= life;
        }

        /// <summary>
        /// Return the character's name 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Return the character's class
        /// </summary>
        /// <returns></returns>
        public string GetClass()
        {
            return @class;
        }
    }
}