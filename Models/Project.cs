using System.IO;
using System.Text.Json;

namespace IridiumEditor.Models
{
    // Class representing a project type
    public class Project
    {
        // Project details
        public ProjectDetails Details;

        // Create empty project
        public Project()
        {
            Details = new ProjectDetails();
        }
        // Open project from file
        public Project(string fileAddress)
        {
            string json = File.ReadAllText(fileAddress);
            ProjectSerializer p = JsonSerializer.Deserialize<ProjectSerializer>(json);
            
            Details = new ProjectDetails(p.Details);
        }

        // Saves the project
        public void Save(string fileAddress)
        {
            ProjectSerializer proj = new(this);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string save = JsonSerializer.Serialize(proj, options);
            File.WriteAllText(fileAddress, save);
        }
    }

    public class ProjectSerializer
    {
        public ProjectDetailsSerializer Details;

        public ProjectSerializer(Project p)
        {
            Details = new ProjectDetailsSerializer(p.Details);
        }
    }
}
