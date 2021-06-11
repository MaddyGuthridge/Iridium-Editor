using System;
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
            // TODO: when this is solid, remove the options to conserve space
            var options = new JsonSerializerOptions { WriteIndented = true };
            string save = JsonSerializer.Serialize(proj, options);
            //Console.WriteLine("Save Data: " + save);
            File.WriteAllText(fileAddress, save);
        }
    }

    public class ProjectSerializer
    {
        public ProjectDetailsSerializer Details { get; set; }

        public ProjectSerializer(Project p)
        {
            Details = new ProjectDetailsSerializer(p.Details);
        }

        public ProjectSerializer()
        {
            // For JSON Deserialize
        }
    }
}
