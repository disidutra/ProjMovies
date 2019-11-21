using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces.Rental
{
    public interface IRentalFormViewModelService
    {
        // Task<IEnumerable<RentalFormViewModel>> GetAll();
        // Task<IEnumerable<RentalFormViewModel>> GetAllByUserId();
        Task<RentalFormViewModel> GetRentalForm(ApplicationCore.Entities.Rental obj);
        Task AddOrUpdate(RentalFormViewModel obj);

    }
}