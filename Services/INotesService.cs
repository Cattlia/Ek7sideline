using E7Kont.Models;

public interface INotesService
{
    IEnumerable<Note> GetNotes(); 
    Note GetNoteById(int id);
    void AddNote(Note note);
    void UpdateNote(int id, Note note);
    void DeleteNote(int id);
}