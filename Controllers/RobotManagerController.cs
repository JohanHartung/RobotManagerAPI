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
        [HttpPost("CreateEdit/nao")]
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

        [HttpPost("CreateEdit/issue")]
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

        [HttpPost("CreateEdit/note")]
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

        [HttpPost("CreateEdit/clinicVisit")]
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

        [HttpPost("CreateEdit/game")]
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

        [HttpPost("SetStatus/{nao, status}")]
        public JsonResult SetStatus(int nao, Status status)
        {
            var _nao = _context.Naos.Find(nao);
            if (_nao == null)
            {
                return new JsonResult(NotFound());
            }
            _nao.Status = status;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("ReplicateIssue/{id, dateTime}")]
        public JsonResult ReplicateIssue(int issue, DateTime dateTime)
        {
            var _issue = _context.Issues.Find(issue);
            if (_issue == null)
            {
                return new JsonResult(NotFound());
            }
            _issue.Replicated = true;
            _issue.ReplicatedDate = dateTime;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("SolveIssue/{issue, dateTime, report}")]
        public JsonResult SolveIssue(int issue, DateTime dateTime, string report)
        {
            var _issue = _context.Issues.Find(issue);
            if (_issue == null)
            {
                return new JsonResult(NotFound());
            }
            _issue.Solved = true;
            _issue.SolvedDate = dateTime;
            _issue.SolvedReport = report;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("EndClinicVisit/{clinicVisit, dateTime, report}")]
        public JsonResult EndClinicVisit(int clinicVisit, DateTime dateTime, string report)
        {
            var _clinicVisit = _context.ClinicVisits.Find(clinicVisit);
            if (_clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }
            _clinicVisit.BackDate = dateTime;
            _clinicVisit.BackReport = report;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("AddIssueToClinicVisit/{clinicVisit, issue}")]
        public JsonResult AddIssueToClinicVisit(int clinicVisit, int issue)
        {
            var clinicVisitInDb = _context.ClinicVisits.Find(clinicVisit);
            if (clinicVisitInDb == null)
            {
                return new JsonResult(NotFound());
            }
            clinicVisitInDb.Issues.Add(issue);
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        // Get
        [HttpGet("GetSingle/nao/{id}")]
        public JsonResult GetNao(int id)
        {
            var nao = _context.Naos.Find(id);
            if (nao == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(nao));
        }

        [HttpGet("GetSingle/issue/{id}")]
        public JsonResult GetIssue(int id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issue));
        }

        [HttpGet("GetSingle/note/{id}")]
        public JsonResult GetNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(note));
        }

        [HttpGet("GetSingle/clinicVisit/{id}")]
        public JsonResult GetClinicVisit(int id)
        {
            var clinicVisit = _context.ClinicVisits.Find(id);
            if (clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisit));
        }

        [HttpGet("GetSingle/game/{id}")]
        public JsonResult GetGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(game));
        }

        [HttpGet("GetGroup/issue/{nao}")]
        public JsonResult GetIssuesByNao(int nao)
        {
            var issues = _context.Issues.Where(i => i.Nao == nao);
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issues));
        }

        [HttpGet("GetGroup/note/{nao}")]
        public JsonResult GetNotesByNao(int nao)
        {
            var notes = _context.Notes.Where(n => n.Nao == nao);
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(notes));
        }

        [HttpGet("GetGroup/clinicVisit/{nao}")]
        public JsonResult GetClinicVisitsByNao(int nao)
        {
            var clinicVisits = _context.ClinicVisits.Where(c => c.Nao == nao);
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisits));
        }

        // Get All
        [HttpGet("GetAll/naos")]
        public JsonResult GetAllNaos()
        {
            var naos = _context.Naos;
            if (naos == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(naos));
        }

        [HttpGet("GetAll/issues")]
        public JsonResult GetAllIssues()
        {
            var issues = _context.Issues;
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issues));
        }

        [HttpGet("GetAll/notes")]
        public JsonResult GetAllNotes()
        {
            var notes = _context.Notes;
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(notes));
        }

        [HttpGet("GetAll/clinicVisits")]
        public JsonResult GetAllClinicVisits()
        {
            var clinicVisits = _context.ClinicVisits;
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisits));
        }

        [HttpGet("GetAll/games")]
        public JsonResult GetAllGames()
        {
            var games = _context.Games;
            if (games == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(games));
        }

        // Delete
        [HttpDelete("Delete/nao/{nao}")]
        public JsonResult DeleteNao(int nao)
        {
            var _nao = _context.Naos.Find(nao);
            if (_nao == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Naos.Remove(_nao);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("Delete/issue/{issue}")]
        public JsonResult DeleteIssue(int issue)
        {
            var _issue = _context.Issues.Find(issue);
            if (_issue == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Issues.Remove(_issue);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("Delete/note/{note}")]
        public JsonResult DeleteNote(int note)
        {
            var _note = _context.Notes.Find(note);
            if (_note == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Notes.Remove(_note);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("Delete/clinicVisit/{clinicVisit}")]
        public JsonResult DeleteClinicVisit(int clinicVisit)
        {
            var _clinicVisit = _context.ClinicVisits.Find(clinicVisit);
            if (_clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }

            _context.ClinicVisits.Remove(_clinicVisit);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        [HttpDelete("Delete/game/{game}")]
        public JsonResult DeleteGame(int game)
        {
            var _game = _context.Games.Find(game);
            if (_game == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Games.Remove(_game);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

    }
}
