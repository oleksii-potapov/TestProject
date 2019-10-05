using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FolderProject.Models
{
    public class MockFolderRepository : IFolderRepository
    {
        private List<Folder> _folders = new List<Folder>();

        public MockFolderRepository()
        {
        }

        public void AddChild(Folder parent, Folder child)
        {
            parent.ChildFolders.Add(child);
        }

        public Folder AddFolder(string name, Folder parent = null)
        {
            Folder folder = new Folder { Name = name };
            _folders.Add(folder);

            if (parent == null)
            {
                folder.ParentPath = "";
            }
            else
            {
                folder.ParentPath = parent.CurrentPath.TrimEnd('/');
                AddChild(GetFolderByName(parent.Name), folder);
            }

            return folder;
        }

        public IEnumerable<Folder> GetChildFolders(Folder folder)
        {
            return folder.ChildFolders;
        }

        public Folder GetFolderByName(string name)
        {
            return _folders.FirstOrDefault(f => f.Name == name);
        }
    }
}