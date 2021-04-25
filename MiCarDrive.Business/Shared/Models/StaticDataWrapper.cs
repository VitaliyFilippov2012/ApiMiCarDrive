using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class StaticDataWrapper
    {
        public UserInfo UserInfo { get; set; }

        public IEnumerable<Type> ServiceTypes { get; set; }

        public IEnumerable<Type> FuelTypes { get; set; }

        public IEnumerable<Type> TransmissionTypes { get; set; }

        public IEnumerable<Type> EventTypes { get; set; }

        public IEnumerable<Type> Rights { get; set; }

        public IEnumerable<Type> Roles { get; set; }
    }
}
