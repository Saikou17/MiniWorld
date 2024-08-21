namespace PlayerClassInterfaces
{
    /// <summary>
    /// Class to hold Element data for the interfaces example
    /// </summary>
    public class ElementInterfacesData
    {
        public int life;
        public string name;
        public string @class;
        public int level;

        /// <summary>
        /// Parameter less constructor
        /// </summary>
        public ElementInterfacesData()
        {

        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="class"></param>
        /// <param name="level"></param>
        /// <param name="life"></param>
        public ElementInterfacesData(string name, string @class, int level = 1, int life = 100)
        {
            this.name = name;
            // We use @class because class is a reserved keyword in C#
            this.@class = @class;
            this.level = level;
            this.life = life;
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