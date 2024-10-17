using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Application.Common.Utility;
using NathaniVilla.Domain.Entities;
using NathaniVilla.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathaniVilla.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;        
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).Wait();

                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@sam.com",
                        Email = "admin@sam.com",
                        Name = "Samsuddin Asliwala",
                        NormalizedUserName = "ADMIN@SAM.COM",
                        NormalizedEmail = "ADMIN@SAM.COM",
                        PhoneNumber = "8320551924",
                    }, "Sam@0108896").GetAwaiter().GetResult();

                    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@sam.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }                
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
