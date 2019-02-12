using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MylarSideCar.Manager
{
    public static class ConfigManager
    {
        private const string FileNameWithoutPath = "\\AppConfig.xml";

        private static readonly Dictionary<string, object> ConfigDict = new Dictionary<string, object>();

        internal static bool HasValue<T>()
        {
            var name = typeof(T).Name;
            return HasValue(name);
        }


        public static string GetStorageDirectory()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }


        /// <summary>
        ///     loads config
        /// </summary>
        public static void Load()
        {
            var fileName = GetStorageDirectory() + FileNameWithoutPath;
            if (!File.Exists(fileName))
                fileName = GetStorageDirectory() + FileNameWithoutPath;
            if (!File.Exists(fileName))
                return;

            var x = new XmlDocument();
            try
            {
                x.Load(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load settings.\r\n\r\n" + e.Message, "NzbSearcher");
            }


            ConfigDict.Clear();
            var items = x.SelectNodes("/ConfigItems/item");
            if (items == null) return;

            foreach (XmlNode item in items)
                try
                {
                    object value = null;
                    if (item.Attributes != null)
                    {
                        var type = item.Attributes["type"].Value;

                        if (item.Attributes.Count != 1) //only "type" attributes are allowed in the new config
                            throw new Exception("Incompatible Config");

                        var serializedType = Type.GetType(type);
                        var valueSerializer =
                            new XmlSerializer(serializedType ?? throw new InvalidOperationException());
                        using (var innerStream = new StringReader(item.InnerXml))
                        {
                            value = valueSerializer.Deserialize(innerStream);
                        }
                    }

                    var valueType = value?.GetType();
                    if (valueType?.FullName != null && !valueType.FullName.StartsWith("MylarSideCar."))
                        throw new Exception("Incompatible Config");

                    if (value != null) ConfigDict.Add(value.GetType().Name, value);
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
        }

        /// <summary>
        ///     Save the configuration to disk
        /// </summary>
        public static void Save()
        {
            var x = new XmlDocument();
            x.AppendChild(x.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlNode configElm = x.CreateElement("ConfigItems");

            foreach (var keyValue in ConfigDict)
                try
                {
                    XmlNode itemElm = x.CreateElement("item");
                    //XmlNode NameAttr = X.CreateAttribute("name");
                    XmlNode typeAttr = x.CreateAttribute("type");

                    //NameAttr.Value = KeyValue.Key;
                    typeAttr.Value = keyValue.Value.GetType().FullName;
                    if (Type.GetType(typeAttr.Value ?? throw new InvalidOperationException()) == null
                    ) // if GetType can't resolve just by FullName, use AssemblyQualifiedName
                        typeAttr.Value = keyValue.Value.GetType().AssemblyQualifiedName;

                    //ItemElm.Attributes.SetNamedItem(NameAttr);
                    if (itemElm.Attributes != null)
                    {
                        itemElm.Attributes.SetNamedItem(typeAttr);

                        var valueSerializer = new XmlSerializer(keyValue.Value.GetType());
                        var sb = new StringBuilder();
                        using (var xw = XmlWriter.Create(sb, new XmlWriterSettings {OmitXmlDeclaration = true}))
                        {
                            valueSerializer.Serialize(xw, keyValue.Value);
                        }

                        itemElm.InnerXml = sb.ToString();
                        itemElm.FirstChild.Attributes?.RemoveAll();
                    }

                    configElm.AppendChild(itemElm);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to save setting '" + keyValue.Key + "'.");
                }

            x.AppendChild(configElm);

            try
            {
                //delete from all possible storage locations
                var globalFileName = GetStorageDirectory() + FileNameWithoutPath;
                if (File.Exists(globalFileName))
                    File.Delete(globalFileName);
                var localFileName = GetStorageDirectory() + FileNameWithoutPath;
                if (File.Exists(localFileName))
                    File.Delete(localFileName);

                //now actually save the file 
                Directory.CreateDirectory(GetStorageDirectory());
                x.Save(GetStorageDirectory() + FileNameWithoutPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save settings to '" + GetStorageDirectory() + FileNameWithoutPath + "'.");
            }
        }

        /// <summary>
        ///     Determines if a specified configuration key is found in the current config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasValue(string key)
        {
            return ConfigDict.ContainsKey(key);
        }

        public static T GetConfig<T>()
        {
            return GetConfig<T>(typeof(T).Name);
        }

        public static T GetConfig<T>(string key)
        {
            if (HasValue(key))
            {
                var value = ConfigDict[key];
                if (value is T variable)
                    return variable;
            }

            //Doesn't exist yet, so create it
            var newValue = Activator.CreateInstance<T>();
            SetValue(newValue);
            return newValue;
        }

        /// <summary>
        ///     Set value in config data
        /// </summary>
        /// <param name="value"></param>
        public static void SetValue<T>(T value)
        {
            ConfigDict[typeof(T).Name] = value;
        }

        /// <summary>
        ///     Remove a value from the configuration
        /// </summary>
        public static void RemoveValue<T>()
        {
            if (ConfigDict.ContainsKey(typeof(T).Name))
                ConfigDict.Remove(typeof(T).Name);
        }
    }
}