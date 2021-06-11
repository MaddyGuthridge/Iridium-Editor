using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    public class ProjectDetails
    {

        // Constructors
        public ProjectDetails()
        {
            Name = "Untitled Project";
            Author = "";
            Description = "";
            Copyright = "";
            _workingTime = new TimeSpan();
            _openTime = DateTime.Now;
        }

        // From JSON serialized
        public ProjectDetails(ProjectDetailsSerializer d)
        {
            Name = d.Name;
            Author = d.Author;
            Description = d.Description;
            Copyright = d.Copyright;
            _workingTime = TimeSpan.FromSeconds(d.WorkingTime);
        }

        // Helpers
        // Returns the total time spent working on the project
        public TimeSpan GetWorkingTime()
        {
            return _workingTime + (DateTime.Now - _openTime);
        }

        // Public properties
        // Project name
        public string Name { get; set; }
        // Author of project
        public string Author { get; set; }
        // Description of project
        public string Description { get; set; }
        // Project's copyright info
        public string Copyright { get; set; }
        // Project's location

        // Private properties
        // Time that the project was opened
        private readonly DateTime _openTime;
        // Time spent working on project in previous sessions
        private readonly TimeSpan _workingTime;
    }

    public class ProjectDetailsSerializer
    {
        public string Name;
        public string Author;
        public string Description;
        public string Copyright;
        
        // number of seconds
        public int WorkingTime;

        public ProjectDetailsSerializer(ProjectDetails d)
        {
            Name = d.Name;
            Author = d.Author;
            Description = d.Description;
            Copyright = d.Copyright;
            // Round to nearest second then convert to int
            WorkingTime = (int) Math.Round(d.GetWorkingTime().TotalSeconds);
        }
    }
}
