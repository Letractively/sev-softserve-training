using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited=true)]
    public class ContainSpacesAttribute : RegularExpressionAttribute
    {
        public ContainSpacesAttribute()
            : base(@"(\S)+")
        {

        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

    }
}