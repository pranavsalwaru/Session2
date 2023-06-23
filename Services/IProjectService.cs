using Session2.Models;

namespace Session2.Services
{
    public interface IProjectService
    {
        void AddProject(Project project);
        Project GetProjectById(int projectId);
        IEnumerable<Project> GetAllProjects();
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
    }
}
