using Microsoft.EntityFrameworkCore;
using Session2.Context;
using Session2.Models;

namespace Session2.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }

        public Project GetProjectById(int projectId)
        {
            return _dbContext.Projects.Find(projectId);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _dbContext.Projects.ToList();
        }
        public void UpdateProject(Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            var project = _dbContext.Projects.Find(projectId);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
            }
        }
    }
}
