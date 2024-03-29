﻿using Microsoft.AspNetCore.Identity;

namespace TraineeTracker.Indentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
