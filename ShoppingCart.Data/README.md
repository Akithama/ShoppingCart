Generate Models
Scaffold-DbContext "Server=.\SQLExpress;Database=ShoppingCart;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


Update Models
Scaffold-DbContext "Server=.\SQLExpress;Database=ShoppingCart;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force