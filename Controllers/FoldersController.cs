using E7Kont.Models;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers

{   
    [ApiController, Route("api/[controller]")]
    public class FoldersController : ControllerBase
    {
        
        private readonly IFoldersService _FoldersService;

        public FoldersController(IFoldersService FoldersService)
        {
            _FoldersService = FoldersService;
        }

        //GET: api/Folder
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNote()
        {
            var Folder = _FoldersService.GetFolder();
            return Ok(Folder);
        }

        // GET: api/Folder/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Note>> GetNote(int id)
        {
            var note = _FoldersService.GetFolderById(id);
            if (note == null)
            {
                NotFound();
            }
            return Ok(note);
        }
    
        [HttpPost]
        public ActionResult<Folder> CreateFolder(Folder newFolder)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _FoldersService.AddFolder(newFolder);
            return CreatedAtAction(nameof(GetFolder), new {id = newFolder.Id}, newFolder);
        }

        //PUT: api/Folder/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFolder(int id, Folder updatedFolder)
        {
            var existingFolder = _FoldersService.GetFolderById(id);
            if(existingFolder == null)
            {
                return NotFound();
            }
            
            _FoldersService.UpdateFolder(id, updatedFolder);

            return NoContent();
        }


        //DELETE:
        [HttpDelete("{id}")]
        public ActionResult DeleteFolder(int id)
        {
            _FoldersService.DeleteFolder(id);
            return NoContent();
        }



    }
}

   


   