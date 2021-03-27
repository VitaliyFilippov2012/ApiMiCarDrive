using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Aspects
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute() : base(typeof(DateTime), DateTime.Now.AddYears(-120).ToShortDateString(),
            DateTime.Now.ToShortDateString())
        {
        }
    }
}