using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class RubyDBContext : DbContext
    {
        public RubyDBContext()
        {
            Database.SetInitializer<RubyDBContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<UserServer> UserServers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Audit> Audits { get; set; }
    }
}