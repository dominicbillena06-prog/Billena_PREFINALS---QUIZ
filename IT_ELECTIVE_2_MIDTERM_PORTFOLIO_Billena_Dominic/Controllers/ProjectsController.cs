using IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private static readonly List<Project> Projects = new()
        {
            new Project
            {
                Id = 1,
                Title = "C# FizzBuzz Challenge",
                Category = "Prelim A1",
                Description = "A beginner C# console application implementing the classic FizzBuzz programming challenge using loops and conditional statements.",
                Technologies = "C#, .NET, Visual Studio, GitHub Desktop",
                ImageUrl = "https://images.unsplash.com/photo-1515879218367-8466d910aaa4?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/BSIT31EE1_PRELIM_A1_Billena_Dominic"
            },

            new Project
            {
                Id = 2,
                Title = "C# Calculator Challenge",
                Category = "Prelim A2",
                Description = "A C# calculator application demonstrating user input, arithmetic operations, validation, and Git-based development.",
                Technologies = "C#, .NET, Visual Studio, GitHub Desktop",
                ImageUrl = "https://images.unsplash.com/photo-1611224923853-80b023f02d71?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/BSIT31E-x-_PRELIM_A2_Billena_Dominic"
            },

            new Project
            {
                Id = 3,
                Title = "File Ingestion Engine",
                Category = "Prelim H2",
                Description = "A C# file ingestion system designed to process multiple file formats through separate reader implementations and a resolver.",
                Technologies = "C#, Interfaces, Strategy Pattern, File Processing",
                ImageUrl = "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/BSIT31E3_PRELIM_H2_billena_dominic"
            },

            new Project
            {
                Id = 4,
                Title = "Personal Portfolio Website",
                Category = "Midterm Activity 1",
                Description = "A responsive personal portfolio created using ASP.NET Core MVC, Razor Views, and Bootstrap 5.",
                Technologies = "ASP.NET Core MVC, C#, Razor, Bootstrap 5",
                ImageUrl = "https://images.unsplash.com/photo-1467232004584-a241de8bcf5d?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/IT_ELECTIVE_2_Assignment_One_Billena_Dominic"
            },

            new Project
            {
                Id = 5,
                Title = "MVC Model Binding",
                Category = "Midterm Project",
                Description = "An ASP.NET Core MVC project demonstrating model binding and how submitted form data is transferred into C# model objects.",
                Technologies = "ASP.NET Core MVC, C#, Razor, Model Binding",
                ImageUrl = "https://images.unsplash.com/photo-1555066931-4365d14bab8c?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/IT_ELECTIVE_BSIT_-BSIT31E3-_-lBILLENA_DOMINIC---MIDTERM--PROJECT"
            },

            new Project
            {
                Id = 6,
                Title = "MVC Authentication System",
                Category = "Midterm Q3",
                Description = "An ASP.NET Core MVC authentication project implementing login, logout, password functionality, account locking, and protected portfolio pages.",
                Technologies = "ASP.NET Core MVC, C#, Authentication, Authorization",
                ImageUrl = "https://images.unsplash.com/photo-1563013544-824ae1b704d3?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/BILLENA_IT_ELECTIVE_2_MIDTERM_Q3"
            },

            new Project
            {
                Id = 7,
                Title = "IT Elective Pre-Finals Project",
                Category = "Pre-Finals",
                Description = "A group ASP.NET Core MVC project using EF Core and SQLite for application workflows and database management.",
                Technologies = "ASP.NET Core MVC, C#, EF Core, SQLite",
                ImageUrl = "https://images.unsplash.com/photo-1551434678-e076c223a692?auto=format&fit=crop&w=1200&q=80",
                GithubUrl = "https://github.com/dominicbillena06-prog/IT_ELECTIVE_PREFINALS_PROJECT_Billena_Pantaleon_Mendoza"
            }
        };

        private static readonly List<Comment> Comments = new();

        public IActionResult Index()
        {
            return View(Projects);
        }

        public IActionResult Details(int id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            ViewBag.Comments = Comments
                .Where(c => c.ProjectId == id)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(
            int projectId,
            string name,
            string message)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(message))
            {
                TempData["CommentError"] =
                    "Name and comment are required.";

                return RedirectToAction(
                    "Details",
                    new { id = projectId });
            }

            Comments.Add(new Comment
            {
                Id = Comments.Count + 1,
                ProjectId = projectId,
                Name = name.Trim(),
                Message = message.Trim(),
                CreatedAt = DateTime.Now
            });

            return RedirectToAction(
                "Details",
                new { id = projectId });
        }
    }
}