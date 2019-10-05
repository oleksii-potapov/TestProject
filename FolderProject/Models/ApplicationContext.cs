namespace FolderProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public DbSet<Folder> Folders { get; set; }
    }
}