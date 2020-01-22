using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracking.Web.Configuration
{
    /// <summary>
    /// Passes Identity options to configure in startup.cs.
    /// </summary>
    public static class FitnessTrackingIdentityOptions
    {
        ///<summary>
        /// Gets the default settings for startup.cs
        /// </summary>
        /// <returns>
        /// Starting parameters for setting up identity in FitnessTracking.Web.
        /// </returns>
        public static IdentityOptions GetDefault()
        {
            return new IdentityOptions
            {
                Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false,
                    RequiredLength = 6,
                    RequiredUniqueChars = 1,
                    RequireUppercase = true
                },
                Lockout = new LockoutOptions
                {
                    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10),
                    MaxFailedAccessAttempts = 5,
                    AllowedForNewUsers = true
                },
                User = new UserOptions
                {
                    RequireUniqueEmail = true,
                    AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+"
                }
            };
        }
    }
}
