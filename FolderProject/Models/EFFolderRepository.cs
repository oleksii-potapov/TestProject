using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FolderProject.Models
{
    public class EFFolderRepository : IFolderRepository
    {
        private ApplicationContext _context;

        public EFFolderRepository(ApplicationContext context)
        {
            _context = context;
            if (_context.Folders.Count() == 0)
                InitializeDb();
        }

        private void InitializeDb()
        {
            Folder root = new Folder { Name = "" };
            AddFolder(root.Name);
            Folder folder = new Folder { Name = "Creating Digital Images" };
            AddFolder(folder.Name, root);
            Folder folder1 = AddFolder("Resources", folder);
            AddFolder("Evidence", folder);
            Folder folder3 = AddFolder("Graphic Products", folder);
            AddFolder("Primary Sources", folder1);
            AddFolder("Secondary Sources", folder1);
            AddFolder("Process", folder3);
            AddFolder("Final Product", folder3);
        }

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
            Folder fd = _context.Folders.Include("ChildFolders").FirstOrDefault(f => f.Name == folder.Name);
            return fd.ChildFolders;
        }

        public Folder GetFolderByName(string name)
        {
            return _context.Folders.Include("ChildFolders").FirstOrDefault(f => f.Name == name);
        }
    }
}