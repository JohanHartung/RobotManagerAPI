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
        public JsonResult CreateEditNao([FromBody] NaoCreateEditRequest request)
        {
            if (!VerifyUserToken(request.UserId, request.DeviceId, request.DateTime, request.UserSecret))
            {
                return new JsonResult(NotFound());
            }

            //var nao = Reasamble(request);
            var nao = request.Nao;
            
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

            return new JsonResult(nao);
        }

        [HttpPost("CreateEdit/issue")]
        public JsonResult CreateEditIssue([FromBody] IssueCreateEditRequest request)
        {
            if (!VerifyUserToken(request.UserId, request.DeviceId, request.DateTime, request.UserSecret))
            {
                return new JsonResult(NotFound());
            }
            if (request.Issue.Id == 0)
            {
                _context.Issues.Add(request.Issue);
            }
            else
            {
                var issueInDb = _context.Issues.SingleOrDefault(i => i.Id == request.Issue.Id);
                if (issueInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                issueInDb = request.Issue;
            }

            _context.SaveChanges();

            return new JsonResult(request.Issue);
        }

        [HttpPost("CreateEdit/note")]
        public JsonResult CreateEditNote([FromBody] NoteCreateEditRequest request)
        {
            if (!VerifyUserToken(request.UserId, request.DeviceId, request.DateTime, request.UserSecret))
            {
                return new JsonResult(NotFound());
            }
            if (request.Note.Id == 0)
            {
                _context.Notes.Add(request.Note);
            }
            else
            {
                var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == request.Note.Id);
                if (noteInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                noteInDb = request.Note;
            }

            _context.SaveChanges();

            return new JsonResult(request.Note);
        }

        [HttpPost("CreateEdit/clinicVisit")]
        public JsonResult CreateEditClinicVisit([FromBody] ClinicVisitCreateEditRequest request)
        {
            if (!VerifyUserToken(request.UserId, request.DeviceId, request.DateTime, request.UserSecret))
            {
                return new JsonResult(NotFound());
            }
            if (request.ClinicVisit.Id == 0)
            {
                _context.ClinicVisits.Add(request.ClinicVisit);
            }
            else
            {
                var clinicVisitInDb = _context.ClinicVisits.SingleOrDefault(n => n.Id == request.ClinicVisit.Id);
                if (clinicVisitInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                clinicVisitInDb = request.ClinicVisit;
            }

            _context.SaveChanges();

            return new JsonResult(request.ClinicVisit);
        }

        [HttpPost("CreateEdit/game")]
        public JsonResult CreateEditGame([FromBody] GameCreateEditRequest request)
        {
            if (!VerifyUserToken(request.UserId, request.DeviceId, request.DateTime, request.UserSecret))
            {
                return new JsonResult(NotFound());
            }
            if (request.Game.Id == 0)
            {
                _context.Games.Add(request.Game);
            }
            else
            {
                var gameInDb = _context.Games.SingleOrDefault(n => n.Id == request.Game.Id);
                if (gameInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                gameInDb = request.Game;
            }

            _context.SaveChanges();

            return new JsonResult(request.Game);
        }

        [HttpPost("SetStatus/{nao}/{status}")]
        public JsonResult SetStatus(int nao, Status status)
        {
            var _nao = _context.Naos.SingleOrDefault(n => n.Id == nao);
            if (_nao == null)
            {
                return new JsonResult(NotFound());
            }
            _nao.Status = status;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("ReplicateIssue/{id, dateTime, user}")]
        public JsonResult ReplicateIssue(int issue, string dateTime, int user)
        {
            var _issue = _context.Issues.SingleOrDefault(n => n.Id == issue);
            if (_issue == null)
            {
                return new JsonResult(NotFound());
            }
            _issue.Replicated.Add(user, dateTime);
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("SolveIssue/{issue, dateTime, report, user}")]
        public JsonResult SolveIssue(int issue, string dateTime, string report, int user)
        {
            var _issue = _context.Issues.SingleOrDefault(n => n.Id == issue);
            if (_issue == null)
            {
                return new JsonResult(NotFound());
            }
            _issue.Solved = new(user, dateTime);
            _issue.SolvedReport = report;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("EndClinicVisit/{clinicVisit, dateTime, report, user}")]
        public JsonResult EndClinicVisit(int clinicVisit, string dateTime, string report, int user)
        {
            var _clinicVisit = _context.ClinicVisits.SingleOrDefault(n => n.Id == clinicVisit);
            if (_clinicVisit == null)
            {
                return new JsonResult(NotFound());
            }
            _clinicVisit.BackDate = dateTime;
            _clinicVisit.BackReport = report;
            _clinicVisit.Collector = user;
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpPost("AddIssueToClinicVisit/{clinicVisit, issue}")]
        public JsonResult AddIssueToClinicVisit(int clinicVisit, int issue)
        {
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

            return new JsonResult(nao);
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

            return new JsonResult(note);
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

            return new JsonResult(game);
        }

        [HttpGet("GetGroup/issue/{nao}")]
        public JsonResult GetIssuesByNao(int nao)
        {
            var issues = _context.Issues.Where(i => i.Nao == nao);
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(issues);
        }

        [HttpGet("GetGroup/note/{nao}")]
        public JsonResult GetNotesByNao(int nao)
        {
            var notes = _context.Notes.Where(n => n.Nao == nao);
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(notes);
        }

        [HttpGet("GetGroup/clinicVisit/{nao}")]
        public JsonResult GetClinicVisitsByNao(int nao)
        {
            var clinicVisits = _context.ClinicVisits.Where(c => c.Nao == nao);
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(clinicVisits);
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

            return new JsonResult(naos);
        }

        [HttpGet("GetAll/issues")]
        public JsonResult GetAllIssues()
        {
            var issues = _context.Issues;
            if (issues == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(issues);
        }

        [HttpGet("GetAll/notes")]
        public JsonResult GetAllNotes()
        {
            var notes = _context.Notes;
            if (notes == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(notes);
        }

        [HttpGet("GetAll/clinicVisits")]
        public JsonResult GetAllClinicVisits()
        {
            var clinicVisits = _context.ClinicVisits;
            if (clinicVisits == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(clinicVisits);
        }
        
        [HttpGet("GetAll/games")]
        public JsonResult GetAllGames()
        {
            var games = _context.Games;
            if (games == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(games);
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
        public JsonResult CreateUser([FromBody] UserCreateRequest request)
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
            user.Username = request.Username;
            user.Password = request.Password;

            var deviceId = Guid.NewGuid().ToString();
            var token = Guid.NewGuid().ToString();
            user.Tokens.Add(deviceId, token);

            _context.Users.Add(user);
            _context.SaveChanges();

            return new JsonResult(new { user.Id, deviceId, token });
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
            return new JsonResult(Ok());
        }

        [HttpGet("GetSingle/user/{id}")]
        public JsonResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(n => n.Id == id);
            if (user == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(new {user.Username});
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

        [HttpGet("ValidUsername/{username}")]
        public JsonResult ValidUsername(string username)
        {
            if (!VerifyUserName(username))
            {
                return new JsonResult(NoContent());
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

            string clearText = challenge == null ? password : Hash(password) + challenge;
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

        private bool VerifyUserToken(int userId, string deviceId, string dateTime, string userSecret)
        {
            var user = _context.Users.SingleOrDefault(n => n.Id == userId);
            if (!LastMinute(dateTime))
            {
                return false;
            }

            if (user == null || user.Tokens == null || !user.Tokens.ContainsKey(deviceId))
            {
                return false;
            }

            string token = user.Tokens[deviceId];
            string secret = Hash(token, dateTime);
            return secret == userSecret;
        }

        private bool VerifyUserName(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            return user != null;
        }

        private static bool LastMinute(string date)
        {
            DateTime now = DateTime.Now;
            DateTime parsedDate;
            if (!DateTime.TryParse(date, null, System.Globalization.DateTimeStyles.RoundtripKind, out parsedDate))
            {
                return false;
            }
            double minutes = (now - parsedDate).TotalMinutes;
            return minutes < 2 && minutes >= 0;
        }

        /*
        private Nao Reasamble(NaoCreateEditRequest request)
        {
            if (request == null)
            {
                return null;
            }
            Nao nao = new Nao();
            nao.Id = request.Id;
            nao.Name = request.Name;
            nao.HeadID = request.HeadID;
            nao.BodyID = request.BodyID;
            nao.WarrantyExtension = request.WarrantyExtension;
            nao.Purchased = request.Purchased;
            nao.Status = request.Status;
            return nao;
        }*/
        public class UserCreateRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class NaoCreateEditRequest
        {
            public Nao Nao { get; set; }
            // Nao Data
            //public int Id { get; set; }
            //public string Name { get; set; }
            //public string HeadID { get; set; }
            //public string BodyID { get; set; }
            //public int WarrantyExtension { get; set; }
            //public string Purchased { get; set; }
            //public List<int> Issues { get; set; }
            //public List<int> Notes { get; set; }
            //public List<int> ClinicVisits { get; set; }
            
            //public int Status { get; set; }

            // User Data for Authentication
            public int UserId { get; set; }
            public string DeviceId { get; set; }
            public string DateTime { get; set; }
            public string UserSecret { get; set; }
        }
        //Issue issue, int userId, string deviceId, string dateTime, string userSecret
        public class IssueCreateEditRequest
        {
            public Issue Issue { get; set; }
            public int UserId { get; set; }
            public string DeviceId { get; set; }
            public string DateTime { get; set; }
            public string UserSecret { get; set; }
        }
        public class NoteCreateEditRequest
        {
            public Note Note { get; set; }
            public int UserId { get; set; }
            public string DeviceId { get; set; }
            public string DateTime { get; set; }
            public string UserSecret { get; set; }
        }
        public class ClinicVisitCreateEditRequest
        {
            public ClinicVisit ClinicVisit { get; set; }
            public int UserId { get; set; }
            public string DeviceId { get; set; }
            public string DateTime { get; set; }
            public string UserSecret { get; set; }
        }
        public class GameCreateEditRequest
        {
            public Game Game { get; set; }
            public int UserId { get; set; }
            public string DeviceId { get; set; }
            public string DateTime { get; set; }
            public string UserSecret { get; set; }
        }
        public class SetStatusRequest
        {
            public int Nao { get; set; }
            public Status Status { get; set; }
        }
    }
}

