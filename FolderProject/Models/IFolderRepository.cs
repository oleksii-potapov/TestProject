using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderProject.Models
{
    public interface IFolderRepository
    {
        Folder GetFolderByName(string name);

        IEnumerable<Folder> GetChildFolders(Folder folder);

        Folder AddFolder(string name, Folder parent = null);
    }
}