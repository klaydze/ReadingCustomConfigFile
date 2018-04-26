using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ReadingConfigFile
{
    public class ToolsSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("settings", IsRequired = true)]
        public BaseCollection Settings
        {
            get
            {
                return base["settings"] as BaseCollection;
            }
        }

        [ConfigurationProperty("xmlformats", IsRequired = true)]
        public XmlFormatCollection XmlFormats
        {
            get
            {
                return base["xmlformats"] as XmlFormatCollection;
            }
        }

        [ConfigurationProperty("countries", IsRequired = true)]
        public CountryCollection Countries
        {
            get
            {
                return base["countries"] as CountryCollection;
            }
        }

        [ConfigurationProperty("datababseobjects", IsRequired = true)]
        public BaseCollection DatabaseObjects
        {
            get
            {
                return base["datababseobjects"] as BaseCollection;
            }
        }
    }

    #region Base
    public class BaseItem : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return base["name"] as string; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return base["value"] as string; }
            set { base["value"] = value; }
        }
    }
    #endregion

    #region Items
    public class XmlFormatItem : BaseItem
    {
        [ConfigurationProperty("title")]
        public string Title
        {
            get
            {
                return base["title"] as string;
            }
            set
            {
                base["title"] = value;
            }
        }
    }
    public class FieldItem : BaseItem
    {
        [ConfigurationProperty("mapTo")]
        public string MapTo
        {
            get
            {
                return base["mapTop"] as string;
            }
            set
            {
                base["mapTo"] = value;
            }
        }
    }
    public class CountryItem : BaseItem
    {
        [ConfigurationProperty("language")]
        public string Language
        {
            get { return base["language"] as string; }
            set { base["language"] = value; }
        }
    }
    #endregion

    #region
    public class XmlFormat : XmlFormatItem
    {
        [ConfigurationProperty("fields")]
        public FieldCollection Fields
        {
            get
            {
                return base["fields"] as FieldCollection;
            }
        }
    }
    #endregion

    #region Collections
    [ConfigurationCollection(typeof(BaseItem), AddItemName = "add")]
    public class BaseCollection : ConfigurationElementCollection, IEnumerable<BaseItem>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BaseItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as BaseItem;

            return configElement?.Name;
        }

        public BaseItem this[int index]
        {
            get
            {
                return BaseGet(index) as BaseItem;
            }
        }

        IEnumerator<BaseItem> IEnumerable<BaseItem>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i]).GetEnumerator();
        }
    }

    [ConfigurationCollection(typeof(FieldItem), AddItemName = "add")]
    public class SettingCollection : ConfigurationElementCollection, IEnumerable<FieldItem>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FieldItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as FieldItem;

            return configElement?.Name;
        }

        public FieldItem this[int index]
        {
            get
            {
                return BaseGet(index) as FieldItem;
            }
        }

        IEnumerator<FieldItem> IEnumerable<FieldItem>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                    .GetEnumerator();
        }
    }

    [ConfigurationCollection(typeof(XmlFormat), AddItemName = "xmlformat")]
    public class XmlFormatCollection : ConfigurationElementCollection, IEnumerable<XmlFormat>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new XmlFormat();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as XmlFormat;

            return configElement?.Name;
        }

        public XmlFormat this[int index]
        {
            get
            {
                return BaseGet(index) as XmlFormat;
            }
        }

        IEnumerator<XmlFormat> IEnumerable<XmlFormat>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i]).GetEnumerator();
        }
    }

    [ConfigurationCollection(typeof(CountryItem), AddItemName = "add")]
    public class CountryCollection : ConfigurationElementCollection, IEnumerable<CountryItem>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CountryItem();
        }
        public CountryItem this[int index]
        {
            get
            {
                return BaseGet(index) as CountryItem;
            }
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as CountryItem;

            return configElement?.Name;
        }
        IEnumerator<CountryItem> IEnumerable<CountryItem>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i]).GetEnumerator();
        }
    }

    [ConfigurationCollection(typeof(FieldItem), AddItemName = "add")]
    public class FieldCollection : ConfigurationElementCollection, IEnumerable<FieldItem>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FieldItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as FieldItem;

            return configElement?.Name;
        }

        public FieldItem this[int index]
        {
            get
            {
                return BaseGet(index) as FieldItem;
            }
        }

        IEnumerator<FieldItem> IEnumerable<FieldItem>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                    .GetEnumerator();
        }
    }
    #endregion
}
