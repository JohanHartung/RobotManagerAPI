using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotManagerAPI.Models;
using RobotManagerAPI.Data;

namespace RobotManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotManagerController : ControllerBase
    {
        private readonly ApiContext _context;

        public RobotManagerController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost("nao")]
        public JsonResult CreateEditNao(Nao nao)
        {
            if (nao.Id == 0)
            {
                _context.Naos.Add(nao);
            }
            else
            {
                var naoInDb = _context.Naos.Find(nao.Id);
                if (naoInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                naoInDb = nao;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(nao));
        }

        [HttpPost("issue")]
        public JsonResult CreateEditIssue(Issue issue)
        {
            if (issue.Id == 0)
            {
                _context.Issues.Add(issue);
            }
            else
            {
                var issueInDb = _context.Issues.Find(issue.Id);
                if (issueInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                issueInDb = issue;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(issue));
        }

        [HttpPost("note")]
        public JsonResult CreateEditNote(Note note)
        {
            if (note.Id == 0)
            {
                _context.Notes.Add(note);
            }
            else
            {
                var noteInDb = _context.Notes.Find(note.Id);
                if (noteInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                noteInDb = note;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(note));
        }

        [HttpPost("clinicVisit")]
        public JsonResult CreateEditClinicVisit(ClinicVisit clinicVisit)
        {
            if (clinicVisit.Id == 0)
            {
                _context.ClinicVisits.Add(clinicVisit);
            }
            else
            {
                var clinicVisitInDb = _context.ClinicVisits.Find(clinicVisit.Id);
                if (clinicVisitInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                clinicVisitInDb = clinicVisit;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(clinicVisit));
        }

        [HttpPost("game")]
        public JsonResult CreateEditGame(Game game)
        {
            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Find(game.Id);
                if (gameInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                gameInDb = game;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(game));
        }

        // Get
        [HttpGet("nao/{id}")]
        public JsonResult GetNao(int id)
        {
            var nao = _context.Naos.Find(id);
            if (nao == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(nao));
        }

        [HttpGet("issue/{id}")]
        public JsonResult GetIssue(int id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issue));
        }

        [HttpGet("note/{id}")]
        public JsonResult GetNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(note));
        }

        [HttpGet("clinicVisit/{id}")]
        public JsonResult GetClinicVisit(int id)
        {
            var clinicVisit = _context.ClinicVisits.Find(id);
            if (clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisit));
        }

        [HttpGet("game/{id}")]
        public JsonResult GetGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(game));
        }

        [HttpGet("issue/{nao}")]
        public JsonResult GetIssuesByNao(int nao)
        {
            var issues = _context.Issues.Where(i => i.Nao.Id == nao);
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issues));
        }

        [HttpGet("note/{nao}")]
        public JsonResult GetNotesByNao(int nao)
        {
            var notes = _context.Notes.Where(n => n.Nao.Id == nao);
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(notes));
        }

        [HttpGet("clinicVisit/{nao}")]
        public JsonResult GetClinicVisitsByNao(int nao)
        {
            var clinicVisits = _context.ClinicVisits.Where(c => c.Nao.Id == nao);
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisits));
        }

        // Delete
        [HttpDelete("nao/{id}")]
        public JsonResult DeleteNao(int id)
        {
            var nao = _context.Naos.Find(id);
            if (nao == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Naos.Remove(nao);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("issue/{id}")]
        public JsonResult DeleteIssue(int id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Issues.Remove(issue);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("note/{id}")]
        public JsonResult DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("clinicVisit/{id}")]
        public JsonResult DeleteClinicVisit(int id)
        {
            var clinicVisit = _context.ClinicVisits.Find(id);
            if (clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }

            _context.ClinicVisits.Remove(clinicVisit);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("game/{id}")]
        public JsonResult DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Games.Remove(game);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        // Get All
        [HttpGet("naos")]
        public JsonResult GetAllNaos()
        {
            var naos = _context.Naos;
            if (naos == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(naos));
        }

        [HttpGet("issues")]
        public JsonResult GetAllIssues()
        {
            var issues = _context.Issues;
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issues));
        }

        [HttpGet("notes")]
        public JsonResult GetAllNotes()
        {
            var notes = _context.Notes;
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(notes));
        }

        [HttpGet("clinicVisits")]
        public JsonResult GetAllClinicVisits()
        {
            var clinicVisits = _context.ClinicVisits;
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisits));
        }

        [HttpGet("games")]
        public JsonResult GetAllGames()
        {
            var games = _context.Games;
            if (games == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(games));
        }

    }
}
