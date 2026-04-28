
using EmployeeAdminPortal.Data;

namespace EmployeeAdminPortal.Reposotiry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _unitOfWork;
        public UnitOfWork(ApplicationDbContext context) 
        {
            _unitOfWork = context;
        }
        public async Task Save()
        {
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
