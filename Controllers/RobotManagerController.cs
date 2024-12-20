using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotManagerAPI.Models;
using RobotManagerAPI.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Server.HttpSys;

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
        public JsonResult CreateEditNao(Nao nao, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            if (nao.Id == 0)
            {
                _context.Naos.Add(nao);
            }
            else
            {
                var naoInDb = _context.Naos.SingleOrDefault(n => n.Id == nao.Id);
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
        public JsonResult CreateEditIssue(Issue issue, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            if (issue.Id == 0)
            {
                _context.Issues.Add(issue);
            }
            else
            {
                var issueInDb = _context.Issues.SingleOrDefault(i => i.Id == issue.Id);
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
        public JsonResult CreateEditNote(Note note, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            if (note.Id == 0)
            {
                _context.Notes.Add(note);
            }
            else
            {
                var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == note.Id);
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
        public JsonResult CreateEditClinicVisit(ClinicVisit clinicVisit, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            if (clinicVisit.Id == 0)
            {
                _context.ClinicVisits.Add(clinicVisit);
            }
            else
            {
                var clinicVisitInDb = _context.ClinicVisits.SingleOrDefault(n => n.Id == clinicVisit.Id);
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
        public JsonResult CreateEditGame(Game game, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.SingleOrDefault(n => n.Id == game.Id);
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
        public JsonResult SetStatus(int nao, Status status, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            var _nao = _context.Naos.SingleOrDefault(n => n.Id == nao);
            if (_nao == null)
            {
                return new JsonResult(NotFound());
            }
            _nao.Status = status;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("ReplicateIssue/{id, dateTime}")]
        public JsonResult ReplicateIssue(int issue, DateTime dateTime, int userId, string deviceId, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            var _issue = _context.Issues.SingleOrDefault(n => n.Id == issue);
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
        public JsonResult SolveIssue(int issue, DateTime dateTime, string report, int userId, string deviceId, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            var _issue = _context.Issues.SingleOrDefault(n => n.Id == issue);
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
        public JsonResult EndClinicVisit(int clinicVisit, DateTime dateTime, string report, int userId, string deviceId, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            var _clinicVisit = _context.ClinicVisits.SingleOrDefault(n => n.Id == clinicVisit);
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
        public JsonResult AddIssueToClinicVisit(int clinicVisit, int issue, int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            if (!VerifyUserToken(userId, deviceId, dateTime, userSecret))
            {
                return new JsonResult(NotFound());
            }
            var clinicVisitInDb = _context.ClinicVisits.SingleOrDefault(n => n.Id == clinicVisit);
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
            var nao = _context.Naos.SingleOrDefault(n => n.Id == id);
            if (nao == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(nao));
        }

        [HttpGet("GetSingle/issue/{id}")]
        public JsonResult GetIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(n => n.Id == id);
            if (issue == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(issue));
        }

        [HttpGet("GetSingle/note/{id}")]
        public JsonResult GetNote(int id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);
            if (note == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(note));
        }

        [HttpGet("GetSingle/clinicVisit/{id}")]
        public JsonResult GetClinicVisit(int id)
        {
            var clinicVisit = _context.ClinicVisits.SingleOrDefault(n => n.Id == id);
            if (clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(clinicVisit));
        }

        [HttpGet("GetSingle/game/{id}")]
        public JsonResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(n => n.Id == id);
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
            var _nao = _context.Naos.SingleOrDefault(n => n.Id == nao);
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
            var _issue = _context.Issues.SingleOrDefault(n => n.Id == issue);
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
            var _note = _context.Notes.SingleOrDefault(n => n.Id == note);
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
            var _clinicVisit = _context.ClinicVisits.SingleOrDefault(n => n.Id == clinicVisit);
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
            var _game = _context.Games.SingleOrDefault(n => n.Id == game);
            if (_game == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Games.Remove(_game);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        // User management

        [HttpPost("Create/user")]
        public JsonResult CreateUser(string username, string password)
        {
            User user = new();
            try
            {
            user.Id = _context.Users.Count() + 1;
            }
            catch
            {
                user.Id = 1;
            }
            user.Username = username;
            user.Password = password;

            var deviceId = Guid.NewGuid().ToString();
            var token = Guid.NewGuid().ToString();
            user.Tokens.Add(deviceId, token);

            _context.Users.Add(user);

            _context.SaveChanges();
            return new JsonResult(Ok(new { user.Id, deviceId, token }));
        }

        [HttpPost("Edit/user/{id}")]
        public JsonResult EditUser(int id, string username, string token, string? password = null)
        {
            var user = _context.Users.SingleOrDefault(n => n.Id == id);

            if (user == null)
            {
                return new JsonResult(NotFound());
            }

            if (user.Tokens == null || !user.Tokens.ContainsValue(token))
            {
                return new JsonResult(NotFound());
            }

            user.Username = username;

            if (password != null)
            {
                user.Password = password;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(user));
        }

        [HttpGet("GetSingle/user/{id}")]
        public JsonResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(n => n.Id == id);
            if (user == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(user));
        }

        [HttpDelete("Delete/user/{user}")]
        public JsonResult DeleteUser(int user)
        {
            var _user = _context.Users.SingleOrDefault(n => n.Id == user);
            if (_user == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Users.Remove(_user);
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpGet("ValidUsername/{usename}")]
        public JsonResult ValidUsername(string username)
        {
            if (!VerifyUserName(username))
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());

        }

        [HttpGet("LoginChallenge/{username}")]
        public JsonResult LoginChallenge(string username)
        {

            if (!VerifyUserName(username))
            {
                return new JsonResult(NotFound());
            }

            var process = CreateProcess();

            return new JsonResult(Ok(new { process.Id, process.Secret }));
        }

        [HttpGet("LoginResponse/{processId, response}")]
        public JsonResult LoginResponse(int processId, string response)
        {
            var process = _context.Processes.SingleOrDefault(n => n.Id == processId);
            if (process == null) { return new JsonResult(NotFound()); }
            var user = _context.Users.SingleOrDefault(n => n.Id == process.UserId);
            if (user == null) { return new JsonResult(NotFound()); }

            bool responseCorrect = Hash(user.Password!, process.Secret) == response;
            string deviceId = Guid.NewGuid().ToString();
            string token = Guid.NewGuid().ToString();
            AddUserToken(user, deviceId, token);

            if (responseCorrect)
            {
                return new JsonResult(Ok(new { user.Id, deviceId, token }));
            }

            return new JsonResult(NotFound());
        }

        [HttpGet("ValidRegistrationCode/{code}")]
        public JsonResult ValidRegistrationCode(string code)
        {
            if (code == "1234") // test value
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }



        // Helpers

        private string Hash(string password, string? challenge = null)
        {
            using var sha256 = SHA256.Create();

            string clearText = challenge == null ? password : password + challenge;
            var bytes = Encoding.UTF8.GetBytes(clearText);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private Process CreateProcess()
        {

            Process process = new Process();
            process.Id = _context.Processes.Count() + 1;
            process.Secret = Guid.NewGuid().ToString();
            _context.Processes.Add(process);
            _context.SaveChanges();
            return process;
        }

        private void AddUserToken(User user, string deviceId, string token)
        {
            if (user.Tokens == null)
            {
                user.Tokens = new();
            }
            user.Tokens.Add(deviceId, token);
            _context.SaveChanges();
        }

        private bool VerifyUserToken(int userId, string deviceId, DateTime dateTime, string userSecret)
        {
            var user = _context.Users.SingleOrDefault(n => n.Id == userId);
            if (user == null || user.Tokens == null || !user.Tokens.ContainsKey(deviceId))
            {
                return false;
            }

            string token = user.Tokens[deviceId];
            string secret = Hash(token, dateTime.ToString());
            return secret == userSecret;
        }

        private bool VerifyUserName(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            return user != null;
        }
    }
}
