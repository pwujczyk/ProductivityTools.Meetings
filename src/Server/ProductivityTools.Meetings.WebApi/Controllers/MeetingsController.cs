using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        [HttpGet]
        [Route("Date")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost]
        [Route("List")]
        public List<Meeting> Get()
        {
            var Meetings = new List<Meeting>();
            Meetings.Add(new Meeting() { Title = "Title1", Date = DateTime.Now, BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "" });
            Meetings.Add(new Meeting() { Title = "Title2", Date = DateTime.Now.AddDays(1), BeforeNotes = "Before2", Notes = "Notes2", AfterNotes = "After2" });
            Meetings.Add(new Meeting() { Title = "Title3", Date = DateTime.Now.AddDays(2), BeforeNotes = "Before3", Notes = "Notes3", AfterNotes = "After3" });
            Meetings.Add(new Meeting() { Title = "Title4", Date = DateTime.Now.AddDays(3), BeforeNotes = "Before4", Notes = "Notes4", AfterNotes = "After4" });
            Meetings.Add(new Meeting() { Title = "Title1", Date = DateTime.Now, BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "" });
            Meetings.Add(new Meeting() { Title = "Title2", Date = DateTime.Now.AddDays(1), BeforeNotes = "Before2", Notes = "Notes2", AfterNotes = "After2" });
            Meetings.Add(new Meeting() { Title = "Title3", Date = DateTime.Now.AddDays(2), BeforeNotes = "Before3", Notes = "Notes3", AfterNotes = "After3" });
            Meetings.Add(new Meeting() { Title = "Title4", Date = DateTime.Now.AddDays(3), BeforeNotes = "Before4", Notes = "Notes4", AfterNotes = "After4" });

            return Meetings;
        }
    }
}
