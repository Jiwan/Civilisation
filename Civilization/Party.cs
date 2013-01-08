using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Civilization.Player;
using Civilization.World.Map;
using Civilization.Utils.Serialization;

namespace Civilization
{
    [Serializable()]
    public class Party
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Party" /> class.
        /// </summary>
        public Party()
        {
        }

        /// <summary>
        /// The players
        /// </summary>
        public List<XmlAnything<IPlayer>> Players { get; set; }

        /// <summary>
        /// The players
        /// </summary>
        public Map Map { get; set; }
    }
}
