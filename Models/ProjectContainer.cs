using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    // Contains all open projects
    public class ProjectContainer
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

        // Closes an open project
        public void CloseProject(int projId)
        {
            _openProjects.Remove(projId);
        }

        // Returns the project associated with an ID
        public Project GetProject(int projId)
        {
            return _openProjects[projId];
        }

        // Saves all open projects
        public void SaveAllProjects()
        {
            foreach(Project proj in _openProjects.Values)
            {
                proj.Save();
            }
        }

        // Returns an array of tuples of project ids and names
        public KeyValuePair<int, string>[] AllProjects()
        {
            var ret = new KeyValuePair<int, string>[_openProjects.Count];

            // For each project and ID, add it's ID and name to 
            int i = 0;
            foreach(KeyValuePair<int, Project> proj in _openProjects.AsEnumerable())
            {
                ret[i] = new KeyValuePair<int, string>(proj.Key, proj.Value.details.Name);
                i++;
            }

            return ret;
        }
    }
}
