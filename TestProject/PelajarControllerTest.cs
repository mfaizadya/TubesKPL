using LoginAPI;
using LoginAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject;

[TestClass]
public class PelajarControllerTest
{
    [TestMethod]
    public void LoginValid()
    {
        var controller = new LoginAPI.Controllers.PelajarController();
        var loginReq = new LoginReq { Username = "pela1", Password = "pass"};

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);

        var pelajar = okResult.Value as Pelajar;
        Assert.IsNotNull(pelajar);
        Assert.AreEqual("pela1", pelajar.Username);
    }

    [TestMethod]
    public void LoginUnauthorized()
    {
        var controller = new LoginAPI.Controllers.PelajarController();
        var loginReq = new LoginReq { Username = "pela1", Password = "salah" };

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void LoginBadReq()
    {
        var controller = new LoginAPI.Controllers.PelajarController();
        var loginReq = new LoginReq { Username = " ", Password = " " };

        var result = controller.Login(loginReq);

        Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
    }
}
