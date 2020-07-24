using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Bll.Service.Interface
{
    public interface ICategoryService
    {
        IEnumerable GetAllCategories();
    }
}
