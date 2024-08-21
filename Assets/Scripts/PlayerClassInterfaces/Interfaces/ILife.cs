namespace PlayerClassInterfaces
{
    /// <summary>
    /// Interface for Life  related methods
    /// </summary>
    public interface ILife
    {
        /// <summary>
        /// Increase life
        /// </summary>
        /// <param name="amount"></param>
        public void IncreaseLife(int amount);

        /// <summary>
        /// Decrease life
        /// </summary>
        /// <param name="amount"></param>
        public void DecreaseLife(int amount);
    }
}