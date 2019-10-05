using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FolderProject.Models
{
    public class EFFolderRepository : IFolderRepository
    {
        private ApplicationContext _context = new ApplicationContext();

        public void AddChild(Folder parent, Folder child)
        {
            parent.ChildFolders.Add(child);
            _context.SaveChanges();
        }

        public Folder AddFolder(string name, Folder parent = null)
        {
            Folder folder = new Folder { Name = name };
            _context.Folders.Add(folder);

            if (parent == null)
            {
                folder.ParentPath = "";
            }
            else
            {
                folder.ParentPath = parent.CurrentPath.TrimEnd('/');
                AddChild(GetFolderByName(parent.Name), folder);
            }
            _context.SaveChanges();
            return folder;
        }

        public IEnumerable<Folder> GetChildFolders(Folder folder)
        {
            return folder.ChildFolders;
        }

        public Folder GetFolderByName(string name)
        {
            return _context.Folders.First(f => f.Name == name);
        }
    }
}