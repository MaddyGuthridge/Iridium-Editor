using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    class ProjectDetails
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

        // Private properties
        // Time that the project was opened
        private readonly DateTime _openTime;
        // Time spent working on project in previous sessions
        private readonly TimeSpan _workingTime;

        
    }
}
