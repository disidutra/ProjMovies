using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces.Rental
{
    public interface IRentalFormViewModelService
    {
        Task<IEnumerable<RentalFormViewModel>> GetAll();
        Task<RentalFormViewModel> GetById(int? id);
        Task Add(RentalFormViewModel obj);

    }
}