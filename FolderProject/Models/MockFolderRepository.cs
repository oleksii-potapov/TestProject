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

        public Folder AddFolder(string name, Folder parent = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Folder> GetChildFolders(Folder folder)
        {
            throw new NotImplementedException();
        }

        public Folder GetFolderByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}