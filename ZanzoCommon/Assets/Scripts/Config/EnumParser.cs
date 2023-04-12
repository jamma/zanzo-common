// +-------------------------------------------------------------------------------------------------------------------
// + File: EnumParser.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 11:50 on 2023/04/11
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;


using Zanzo.Common;

namespace Zanzo.Common.Config
{

    [XmlRoot(ElementName = "entry")]
    public class Entry
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "enum")]
    public class Enum
    {
        [XmlElement(ElementName = "entry")]
        public List<Entry> Entry { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "enum_domain")]
    public class EnumDefinitions
    {
        [XmlElement(ElementName = "enum")]
        public List<Enum> Enum { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "start_value")]
        public int ValueStart { get; set; } = -1;

        [XmlAttribute(AttributeName = "namespace")]
        public string Namespace { get; set; }
    }
}
