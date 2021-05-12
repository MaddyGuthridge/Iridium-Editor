using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    // Contains all open projects
    class ProjectContainer
    {
        private readonly Dictionary<int, Project> _openProjects;
        private readonly IdentifierGenerator _generator;

        public ProjectContainer()
        {
            _openProjects = new Dictionary<int, Project>();
            _generator = new IdentifierGenerator();
        }

        // Create a new project, returning its ID
        public int CreateProject()
        {
            int id = _generator.GetNewValue();
            _openProjects[id] = new Project();
            return id;
        }
    }
}
