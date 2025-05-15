using LoginAPI;
using Microsoft.AspNetCore.Mvc;

namespace TestProject;

[TestClass]
public class AdminControllerTest
{
    [TestMethod]
    public void LoginValid()
    {
        var controller = new LoginAPI.Controllers.AdminController();
        var loginReq = new LoginReq { Username = "admin", Password = "password" };

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);

        var admin = okResult.Value as Admin;
        Assert.IsNotNull(admin);
        Assert.AreEqual("admin", admin.Username);
    }

    [TestMethod]
    public void LoginUnauthorized()
    {
        var controller = new LoginAPI.Controllers.AdminController();
        var loginReq = new LoginReq { Username = "admin", Password = "salah" };

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void LoginBadReq()
    {
        var controller = new LoginAPI.Controllers.AdminController();
        var loginReq = new LoginReq { Username = " ", Password = " " };

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
    }
}
