using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuyenMinh2.mvc.ViewModels;

namespace TuyenMinh2.mvc.Models
{
    
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

        public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }
