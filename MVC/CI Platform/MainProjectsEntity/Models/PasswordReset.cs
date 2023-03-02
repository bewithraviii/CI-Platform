using System;
using System.Collections.Generic;

namespace MainProjectsEntity.Models;

public partial class PasswordReset
{
    public string? Email { get; set; }

    public string? Token { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? ResetFlag { get; set; }
}
