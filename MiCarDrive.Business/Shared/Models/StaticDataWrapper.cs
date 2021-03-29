using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class StaticDataWrapper
    {
        public UserInfo UserInfo { get; set; }

        public IEnumerable<Type> TypeServices { get; set; }

        public IEnumerable<Type> TypeEvents { get; set; }
    }
}
