using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using FrontToBack.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class AboutController : Controller
    {
        readonly AppDBContext _context;
        public AboutController(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }
        public IActionResult Index()
        {
            //Team team = new Team()
            //{
            //    FirtName = "Jane",
            //    LastName = "Doe",
            //    Occupation = "Business Development",
            //    ImageURL= "team-01.jpg"
            //};
            //Team team1 = new Team()
            //{
            //    FirtName = "Jane",
            //    LastName = "Doe",
            //    Occupation = "Media Development",
            //    ImageURL = "team-02.jpg"
            //};
            //Team team2 = new Team()
            //{
            //    FirtName = "John",
            //    LastName = "Doe",
            //    Occupation = "Developer",
            //    ImageURL = "team-03.jpg"
            //};
            //_context.Teams.Add(team);
            //_context.Teams.Add(team1);
            //_context.Teams.Add(team2);
            //_context.SaveChanges();

            IEnumerable<Team> teams = _context.Teams.ToList();
            AboutVM aboutVM = new AboutVM()
            {
                Teams = teams
            };

            return View(aboutVM);
        }
    }
}
