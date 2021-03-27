using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class StaticDataWrapper
    {
        public UserInfo UserInfo { get; set; }

        public List<Type> TypeServices { get; set; }

        public List<Type> TypeEvents { get; set; }
    }
}
