using System;
using System.ComponentModel.DataAnnotations;
using Shared.Aspects;

namespace Shared.Models
{
    [Serializable]
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public Guid UserCarId { get; set; }
        public string Gender { get; set; }

        [DateRange]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public Guid? PhotoArchiveId { get; set; }
    }
}
