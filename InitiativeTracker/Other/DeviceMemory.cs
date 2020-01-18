using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace InitiativeTracker.Other
{
    public static class DeviceMemory
    {
        /// <summary>
        /// Saves an object to the user's device in the XML format.
        /// </summary>
        /// <param name="o">
        /// Object to save to the device.
        /// </param>
        /// <param name="fileName">
        /// Name of the file, with the extension.
        /// </param>
        public static void SaveToDevice<T>(T o, string fileName)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                xmlSerializer.Serialize(stringWriter, o);
                File.WriteAllText(filePath, stringWriter.ToString());
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Reads an XML object saved on the user's device.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file, with the extension.
        /// </param>
        /// <returns>
        /// Object read from the device.
        /// </returns>
        public static T ReadFromDevice<T>(string fileName)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                string text = File.ReadAllText(filePath);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StringReader stringReader = new StringReader(text);
                return (T)xmlSerializer.Deserialize(stringReader);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
