using System;

namespace Shared.Models
{
    [Serializable]
    public class UserCredentials
    {
        public string Password { get; set; }

        public string Login { get; set; }
    }
}
