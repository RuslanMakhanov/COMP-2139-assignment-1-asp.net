using Assignment.Models;

namespace Assignment.TechiciansServices
{
    public interface ITechiciansDataService
    {
        List<TechniciansModel> GetallTechicians();
        List<TechniciansModel> SearchTechicians(string searchTerm);
        TechniciansModel GetTechiciansById(int Id);
        int Insert(TechniciansModel product);
        int Delete(TechniciansModel product);
        int Update(TechniciansModel product);
    }
}
