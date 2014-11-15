#region
using System.Collections.Generic;
using FTS.Global.Classes;

#endregion

namespace FTS.Global.Interface{
    public interface IHead{
        DataState DataState { get; set; }
        object IdValue { get; set; }        
    }
}