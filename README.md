# Shopping website application (SattiAldi) with ASP.NET MVC5

## SattiAldi Api Addresses

If we want to start the project with [Microsoft Visual Studio](https://visualstudio.microsoft.com/), we start the project by right-clicking on the "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/sattialdi/blob/main/sattiAldi/Views/Home/Index.cshtml)" file while the project is open and selecting "View in Browser ([Selected Browser](https://www.google.com.tr/))".

If we want, we can also use `\Index.cshtml` of other "[\Views](https://github.com/AtakanTurgut/sattialdi/tree/main/sattiAldi/Views)" files to see how other pages look.

However, it's best to start the project with "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/sattialdi/blob/main/sattiAldi/Views/Home/Index.cshtml)" to run it properly.

Ready-made [themes](https://www.free-css.com/free-css-templates) were processed and made suitable for the project.

In order to confirm the cart, the user must first log in. <br />
The application also has an admin panel. <br />
Only people registered as administrators can login to the admin page. <br />
Admin can perform general operations through the panel. <br />
<ul>
  <li>The website is accessible.</li>
  <li>Admin can see what's happening on the dashboard from the control panel.</li>
  <li>Admin can perform operations related to Categories and list all Categories. Can add, delete, edit Categories.</li>
  <li>Admin can perform operations related to Products and list all Products. Can add, delete, edit Products.</li>
  <li>Admin can list all Orders and examine it in detail. Can change order statuses.</li>
  <li>Admin can receive order statuses as notification.</li>
</ul>  

Use this user name and password for the admin page.

                UserName : atakanturgut
                Password : 123456

Use this user name and password for the user page.

                UserName : furkanuvenc
                Password : 123456

The project runs on "[localhost:?/](https://localhost:44312/)".

## Used Packages

- Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [EntityFramework 6.4.4](https://www.nuget.org/packages/EntityFramework/)
```
    PM>  NuGet\Install-Package EntityFramework -Version 6.4.4
```
- [Microsoft.AspNet.Identity.Core 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Core -Version 2.2.3
```
- [Microsoft.AspNet.Identity.Owin 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Owin/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Owin -Version 2.2.3
```
- [Microsoft.AspNet.Identity.EntityFramework 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.EntityFramework -Version 2.2.3
```
- [Microsoft.Owin.Host.SystemWeb 4.2.2](https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb)
```
    PM>  NuGet\Install-Package Microsoft.Owin.Host.SystemWeb -Version 4.2.2
```

- [ ] Use this script to see the page in Turkish [[source]](https://datatables.net/examples/advanced_init/language_file.html):
```html
    <script type="text/javascript">$(function () {
    $("#example1").dataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
        $('#example2').dataTable({
          "bPaginate": true,
          "bLengthChange": false,
          "bFilter": false,
          "bSort": true,
          "bInfo": true,
          "bAutoWidth": false
        });
    });
    </script>

```
-----
## SattiAldi Project [Images](https://github.com/AtakanTurgut/sattialdi/tree/main/pictures)

### 1. Home Page:  https://localhost:44312/Home/Index
![](/pictures/HomePage1.PNG) 
![](/pictures/HomePage2.PNG)
![](/pictures/HomePage3.PNG)

### 2. Product Details Page:  https://localhost:44312/Home/ProductDetails/11
![](/pictures/ProductDetailsPage.PNG)

### 3. Register Page:  https://localhost:44312/Account/Register
![](/pictures/RegisterPage.PNG)

### 4. Login Page:  https://localhost:44312/Account/Login
![](/pictures/LoginPage.PNG)

### 5. Order Page:  https://localhost:44312/Account/Index
![](/pictures/OrderPage.PNG)

### 6. Order Details Page:  https://localhost:44312/Account/Details/2
![](/pictures/OrderDetailsPage.PNG)

### 7. Cart Page:  https://localhost:44312/Cart/Index
![](/pictures/CartPage.PNG)

### 8. Cart Checkout Page:  https://localhost:44312/Cart/Checkout
![](/pictures/CartCheckoutPage.PNG)

### 9. Admin Page:  https://localhost:44312/AdminHome/Index
![](/pictures/AdminPage.PNG)

### 10. Product List Page:  https://localhost:44312/Product/Index
![](/pictures/ProductPage.PNG)

### 11. Product Create Page:  https://localhost:44312/Product/Create
![](/pictures/ProductCreatePage.PNG)

### 12. Category Page:  https://localhost:44312/Category/Index
![](/pictures/CategoryPage.PNG)

### 13. Category Create Page:  https://localhost:44312/Category/Create
![](/pictures/CategoryCreatePage.PNG)

### 14. Order List Page:  https://localhost:44312/Order/Index
![](/pictures/OrderListPage.PNG)

### 15. Order Controller Page:  https://localhost:44312/Order/PendingOrders
![](/pictures/OrderControllerPage.PNG)

### 16. Order Details Page:  https://localhost:44312/Order/Details/1
![](/pictures/OrderDetailsListPage.PNG)