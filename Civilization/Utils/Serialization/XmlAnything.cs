using System;
using System.Xml.Serialization;

namespace Civilization.Utils.Serialization
{
    /// <summary>
    /// This class permit to serialize an object without knowing its type.
    /// </summary>
    /// <typeparam name="T">The type of the object</typeparam>
    [Serializable()]
    public sealed class XmlAnything<T> : IXmlSerializable
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlAnything{T}" /> class.
        /// </summary>
        public XmlAnything()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlAnything{T}" /> class.
        /// </summary>
        /// <param name="t">The t.</param>
        public XmlAnything(T t)
        {
            this.Value = t;       
        }
        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the value of the attribute you want to serialize.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }
        #endregion

        #region methods
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (!reader.HasAttributes)
                throw new FormatException("expected a type attribute!");
            string type = reader.GetAttribute("type");
            reader.Read(); // consume the value
            if (type == "null")
                return;// leave T at default value
            XmlSerializer serializer = new XmlSerializer(Type.GetType(type));
            this.Value = (T)serializer.Deserialize(reader);
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (Value == null)
            {
                writer.WriteAttributeString("type", "null");
                return;
            }
            Type type = this.Value.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            writer.WriteAttributeString("type", type.AssemblyQualifiedName);
            serializer.Serialize(writer, this.Value);
        }
        #endregion
    }
}
