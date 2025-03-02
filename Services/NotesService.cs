
using E7Kont.Models;

public class NotesService : INotesService
{
    private static readonly List<Note> notes = new ()
        {
            new Note {Id = 1, Title = "HandlelisteMandag", Content = "Egg, melk og torskerogn", IsArchived = true, FolderId = 1},

            new Note {Id = 2, Title = "HandlelisteTirsdag", Content = "Syltetøy, brød, majones, tomat og ost", IsArchived = false},

            new Note {Id = 3, Title = "HandlelisteFredag", Content = "Jordbær, strå, sukker og laurbær", IsArchived = true, FolderId = 1},

            new Note {Id = 4, Title = "HandlelisteNesteLørdag", Content = "Melis, krabber, Veuve Cliquot og røde roser", IsArchived = true, FolderId = 3},

            new Note {Id = 5, Title = "HandlelisteKalender", Content = "Kuli, Porche, Toyota, kråke og syvende sans", IsArchived = true, FolderId = 2}
        };

    public IEnumerable<Note> GetNotes() => notes;

    public Note GetNoteById(int id) => notes.FirstOrDefault(n => n.Id == id) ?? new Note();

    public void AddNote(Note note) 
    {
        note.Id = notes.Max(n => n.Id) +1;
        notes.Add(note);
    }

    public void UpdateNote(int id, Note updatedNote)
    {
        var note = GetNoteById(id);
        if (note == null) return;

        note.Title = updatedNote.Title;
        note.Content = updatedNote.Content;
        note.IsArchived = updatedNote.IsArchived;
        note.FolderId = updatedNote.FolderId;
        
    }
    
     public void DeleteNote(int id)
     {
        var note = GetNoteById(id);
        if(note != null) notes.Remove(note);
     }


}