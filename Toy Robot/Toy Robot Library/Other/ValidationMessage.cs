namespace Toy_Robot_Library
{
    /// <summary>
    /// Class used to pass information regarding successful or unsuccessful usage of a function
    /// </summary>
    public struct ValidationMessage
    {
        /// <summary>
        /// Value showing whether the function was used successfully
        /// </summary>
        public bool success { get; private set; }
        
        /// <summary>
        /// Message explaining why function usage was unsuccessful
        /// </summary>
        public string message { get; private set; }

        internal ValidationMessage(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
    }
}
