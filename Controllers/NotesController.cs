using E7Kont.Models;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers

{   
    [ApiController, Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        //GET: api/notes
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNote()
        {
            var notes = _notesService.GetNotes();
            return Ok(notes);
        }

        // GET: api/notes/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Note>> GetNote(int id)
        {
            var note = _notesService.GetNoteById(id);
            if (note == null)
            {
                NotFound();
            }
            return Ok(note);
        }
    
        [HttpPost]
        public ActionResult<Note> CreateNote(Note newNote)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _notesService.AddNote(newNote);
            return CreatedAtAction(nameof(GetNote), new {id = newNote.Id}, newNote);
        }

        //PUT: api/notes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, Note updatedNote)
        {
            var existingNote = _notesService.GetNoteById(id);
            if(existingNote == null)
            {
                return NotFound();
            }
            
            _notesService.UpdateNote(id, updatedNote);

            return NoContent();
        }


        //DELETE:
        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            _notesService.DeleteNote(id);
            return NoContent();
        }



    }
}

   


   