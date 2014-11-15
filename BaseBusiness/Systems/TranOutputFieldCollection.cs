// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:54
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         TranOutputFieldCollection.cs
// Project Item Filename:     TranOutputFieldCollection.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System.Xml.Serialization;

#endregion

namespace FTS.BaseBusiness.Systems {
    public class TranOutputFieldCollection {
        // The XmlArrayAttribute changes the XML element name
        // from the default of "OrderedItems" to "Items".
        [XmlArray("Items")] public TranOutputField[] TranOutputFields;

        public TranOutputFieldCollection() {
        }
    }
}