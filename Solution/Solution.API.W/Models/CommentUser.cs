﻿using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class CommentUser
{
    public int CommentUserId { get; set; }

    public int CommentId { get; set; }

    public string UserId { get; set; } = null!;
}
