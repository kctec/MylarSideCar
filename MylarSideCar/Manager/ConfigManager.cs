using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Windows.Forms;

using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;

namespace MylarSideCar.Manager
{
    public static class ConfigManager
    {
        static string _FileNameWithoutPath = "\\AppConfig.xml";

        internal static bool HasValue<T>()
        {
            string name = typeof(T).Name;
            return HasValue(name);
        }

        static Dictionary<string, object> _ConfigDict = new Dictionary<string, object>();

        static bool _NoSave = false;

        public static string GetStorageDirectory()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }


        /// <summary>
        /// Indicates if config has been saved to disk yet (in other words, if this is a first-time launch)
        /// </summary>
        public static bool ConfigFileExists
        {
            get
            {
                return File.Exists(GetStorageDirectory() + _FileNameWithoutPath) ||
                        File.Exists(GetStorageDirectory() + _FileNameWithoutPath);
            }
        }

        /// <summary>
        /// loads config
        /// </summary>
        public static void Load()
        {
            string FileName = GetStorageDirectory() + _FileNameWithoutPath;
            if (!File.Exists(FileName))
                FileName = GetStorageDirectory() + _FileNameWithoutPath;
            if (!File.Exists(FileName))
                return;

            XmlDocument X = new XmlDocument();
            try
            {
                X.Load(FileName);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Unable to load settings.\r\n\r\n" + e.Message, "NzbSearcher");
            }

 

            _ConfigDict.Clear();
            XmlNodeList Items = X.SelectNodes("/ConfigItems/item");
            foreach (XmlNode Item in Items)
            {
                string type = string.Empty;

                try
                {
                    object value = null;
                    type = Item.Attributes["type"].Value;

                    if (Item.Attributes.Count != 1) //only "type" attributes are allowed in the new config
                        throw new Exception("Incompatible Config");

                    Type SerializedType = Type.GetType(type);
                    XmlSerializer ValueSerializer = new XmlSerializer(SerializedType);
                    using (StringReader InnerStream = new StringReader(Item.InnerXml))
                        value = ValueSerializer.Deserialize(InnerStream);

                    Type ValueType = value.GetType();
                    if (!ValueType.FullName.StartsWith("MylarSideCar."))
                        throw new Exception("Incompatible Config");

                    _ConfigDict.Add(value.GetType().Name, value);
                }
                catch (Exception e)
                {

                    Debug.Write(e.Message);
 
                }
            }
        }

        /// <summary>
        /// Save the configuration to disk
        /// </summary>
        public static void Save()
        {
            if (_NoSave)
                return;
           
            XmlDocument X = new XmlDocument();
            X.AppendChild(X.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlNode ConfigElm = X.CreateElement("ConfigItems");

            foreach (KeyValuePair<string, object> KeyValue in _ConfigDict)
            {
                try
                {
                    XmlNode ItemElm = X.CreateElement("item");
                    //XmlNode NameAttr = X.CreateAttribute("name");
                    XmlNode TypeAttr = X.CreateAttribute("type");

                    //NameAttr.Value = KeyValue.Key;
                    TypeAttr.Value = KeyValue.Value.GetType().FullName;
                    if (Type.GetType(TypeAttr.Value) == null) // if GetType can't resolve just by FullName, use AssemblyQualifiedName
                        TypeAttr.Value = KeyValue.Value.GetType().AssemblyQualifiedName;

                    //ItemElm.Attributes.SetNamedItem(NameAttr);
                    ItemElm.Attributes.SetNamedItem(TypeAttr);

                    XmlSerializer ValueSerializer = new XmlSerializer(KeyValue.Value.GetType());
                    StringBuilder SB = new StringBuilder();
                    using (XmlWriter xw = XmlWriter.Create(SB, new XmlWriterSettings() { OmitXmlDeclaration = true }))
                        ValueSerializer.Serialize(xw, KeyValue.Value);
                    ItemElm.InnerXml = SB.ToString();
                    ItemElm.FirstChild.Attributes.RemoveAll();

                    ConfigElm.AppendChild(ItemElm);
                }
                catch (Exception)
                {
                      MessageBox.Show("Unable to save setting '" + KeyValue.Key + "'.");
                }
            }

            X.AppendChild(ConfigElm);

            try
            {
                //delete from all possible storage locations
                string GlobalFileName = GetStorageDirectory() + _FileNameWithoutPath;
                if (File.Exists(GlobalFileName))
                    File.Delete(GlobalFileName);
                string LocalFileName = GetStorageDirectory() + _FileNameWithoutPath;
                if (File.Exists(LocalFileName))
                    File.Delete(LocalFileName);

                //now actually save the file 
                Directory.CreateDirectory(GetStorageDirectory());
                X.Save(GetStorageDirectory() + _FileNameWithoutPath);
            }
            catch (System.Exception)
            {
                 MessageBox.Show("Unable to save settings to '" +  GetStorageDirectory() + _FileNameWithoutPath + "'.");
            }
        }

        /// <summary>
        /// Determines if a specified configuration key is found in the current config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasValue(string key)
        {
            return _ConfigDict.ContainsKey(key);
        }

        /*
        /// <summary>
        /// Obtain configuration value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public object GetValue(string key, object DefaultValue)
        {
            if (HasValue(key))
            {
                object value = _ConfigDict[key];
                if (DefaultValue == null || value.GetType() == DefaultValue.GetType())
                    return value;
            }
            if (DefaultValue != null) //Doesn't exist yet, so create it
                SetValue(key, DefaultValue);
            return DefaultValue;
        }
        */

        public static T GetValue<T>()
        {
            return GetValue<T>(typeof(T).Name);
        }

        public static T GetValue<T>(string key)
        {
            if (HasValue(key))
            {
                object value = _ConfigDict[key];
                if (value is T)
                    return (T)value;
            }
            //Doesn't exist yet, so create it
            T NewValue = Activator.CreateInstance<T>();
            SetValue( NewValue);
            return NewValue;
        }

        /*
        public void SetValue(object Value)
        {
            if (Value != null)
                SetValue(Value.GetType().Name, Value);
        }
        */

        /// <summary>
        /// Set value in config data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Value"></param>
        public static void SetValue<T>( T Value)
        {
            _ConfigDict[typeof(T).Name] = Value;
        }

        /// <summary>
        /// Remove a value from the configuration
        /// </summary>
        /// <param name="key"></param>
        /// <param name="UserData"></param>
        public static void RemoveValue<T>()
        {
            if (_ConfigDict.ContainsKey(typeof( T).Name))
                _ConfigDict.Remove(typeof(T).Name);
        }
    }

}
