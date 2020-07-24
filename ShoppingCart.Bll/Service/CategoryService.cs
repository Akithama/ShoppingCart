using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Infrastructure.Repository;
using System.Collections;

namespace ShoppingCart.Bll.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable GetAllCategories()
        {
            return _unitOfWork.Category.GetAll();            
        }
    }
}
