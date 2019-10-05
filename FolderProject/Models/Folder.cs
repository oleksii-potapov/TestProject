using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FolderProject.Models
{
    public class Folder
    {
        [Key]
        public string Name { get; set; }

        public string ParentPath { get; set; }

        [NotMapped]
        public string CurrentPath => $"{ParentPath}/{Name}";

        public ICollection<Folder> ChildFolders { get; set; }

        public Folder()
        {
            ChildFolders = new List<Folder>();
        }
    }
}