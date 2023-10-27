using System;
using System.Collections.Generic;

namespace FrontEnd.W.Models
{
    public partial class AspNetUserLogin
    {
        public string UserId { get; set; } = null!;
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;

        public virtual AspNetUser User { get; set; } = null!;
    }
}
