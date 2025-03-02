using E7Kont.Models;


public interface IFoldersService
{
    IEnumerable<Folder> GetFolders(); 
    Note GetFolderById(int id);
    void AddFolder(Folder folder);
    void UpdateFolder(int id, Folder folder);
    void DeleteFolder(int id);
}


