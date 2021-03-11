using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace EFData.Entity
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
