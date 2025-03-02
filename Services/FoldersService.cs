

using E7Kont.Models;

public class FoldersService : IFoldersService
{
    private static readonly List<Folder> folders = new ()
        {
            new Folder {Id = 1, Name = "Hverdagshandling",  Notes() },

            new Folder {Id = 2, Name = "Ukeshandling", Notes() },

            new Folder {Id = 3, Name = "SkalHandles", Notes() }

        };

    public IEnumerable<Folder> GetFolders() => folders;

    public Folder GetFolderById(int id) => folders.FirstOrDefault(f => f.Id == id) ?? new Folder();

    public void AddFolder(Folder folder) 
    {
        folder.Id = folders.Max(f => f.Id) +1;
        folders.Add(folder);
    }

    public void UpdateFolder(int id, Folder updatedFolder)
    {
        var folder = GetFolderById(id);
        if (folder == null) return;

        folder.Name = updatedFolder.Name;
        folder.Notes = updatedFolder.Notes;
        
    }
    
     public void DeleteFolder(int id)
     {
        var folder = GetFolderById(id);
        if(folder != null) folders.Remove(folder);
     }


}






   
