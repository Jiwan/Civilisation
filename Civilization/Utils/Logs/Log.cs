using System;
using Civilization.Player.Actions;

namespace Civilization.Utils.Logs
{
    public delegate void WriteDelegate(string info);

    public class Log
    {
        #region fields
        /// <summary>
        /// The instance
        /// </summary>
        static Log instance;
        #endregion

        #region properties
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                }

                return instance;
            }
        }

        /// <summary>
        /// The write function.
        /// </summary>
        public WriteDelegate WriteFunction;
        #endregion

        #region constructors
        /// <summary>
        /// Prevents a default instance of the <see cref="Log" /> class from being created.
        /// </summary>
        private Log()
        {

        }
        #endregion


        #region methods
        /// <summary>
        /// Writes the specified info.
        /// </summary>
        /// <param name="info">The info.</param>
        public void Write(string info)
        {
            if (WriteFunction != null)
            {
                WriteFunction(string.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss tt"), info));
            }
        }

        /// <summary>
        /// Writes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Write(IPlayerAction action)
        {
            Write(action.GetLog());
        }
        #endregion


    }
}
