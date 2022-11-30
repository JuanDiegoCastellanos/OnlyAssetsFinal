using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.ViewModels;

namespace OnlyAssetsFinal.Data.Services
{
    public class PersonService : EntityBaseRepository<Person>, IPersonService
    {
        public PersonService(ApplicationDbContext context) : base(context)
        {
        }
    }
}