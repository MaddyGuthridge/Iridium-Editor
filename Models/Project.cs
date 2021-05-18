using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    // Class representing a project type
    public class Project
    {
        // Project details
        public ProjectDetails details;

        // Create empty project
        public Project()
        {
            details = new ProjectDetails();
        }

        // Saves the project
        public void Save()
        {
            // Not implemented
        }

    }
}
