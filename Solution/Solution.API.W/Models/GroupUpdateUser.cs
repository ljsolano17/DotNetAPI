﻿using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class GroupUpdateUser
{
    public int GroupUpdateUserId { get; set; }

    public int GroupUpdateId { get; set; }

    public string UserId { get; set; } = null!;
}
