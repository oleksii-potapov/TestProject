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

        public ICollection<Folder> Childs { get; set; }

        public Folder()
        {
            Childs = new List<Folder>();
        }
    }
}