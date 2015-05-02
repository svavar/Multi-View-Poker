using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerWebService.Helpers;
using System.Web.Mvc;
using System.Collections.Specialized;
using Moq;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Principal;

namespace PokerWebService.Test
{
    [TestClass]
    public class RazorViewTest
    {
        //[HostType("ASP.NET")]
        [TestMethod]        
        public void TestMethod1()
        {
            var httpContextMock = new Mock<HttpContextBase>(MockBehavior.Loose);
            var httpResponseMock = new Mock<HttpResponseBase>(MockBehavior.Loose);

            httpContextMock.Setup(c => c.Items).Returns(new Dictionary<object, object>());
            httpContextMock.Setup(c => c.Response).Returns(httpResponseMock.Object);

            var controllerMock = new Mock<ControllerBase>(MockBehavior.Loose);

            var routeData = new RouteData();
            routeData.Values.Add( "controller", "TexasHoldem" );

            //RouteTable.Routes.Clear();
            //RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //RouteTable.Routes.MapRoute(
            //    "Default",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Main", action = "DefaultView", id = UrlParameter.Optional }
            //);

            HttpRuntime.AspInstallDirectoryInternal = "";

             var controllerContext = new ControllerContext(FakeHttpContext(), 
                 routeData, 
                 controllerMock.Object);

             var result = RazorHelper.RenderViewToString(controllerContext, 
                 "C:/Users/svavar/Documents/GitHub/RazorPoker/PokerWebService.Test/Views/TestView.cshtml",
                 new NameValueCollection(),
                 false);

             Assert.IsFalse(result.Contains("Exception"));
        }

        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>(MockBehavior.Loose);
            var request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            var response = new Mock<HttpResponseBase>(MockBehavior.Loose);
            var session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
            var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            var user = new Mock<IPrincipal>(MockBehavior.Loose);
            var identity = new Mock<IIdentity>(MockBehavior.Loose);

            var browser = new Mock<HttpBrowserCapabilitiesBase>(MockBehavior.Loose);

            HttpCookieCollection cookies = new HttpCookieCollection();
            cookies.Add(new HttpCookie(".ASPXBrowserOverride", "false"));

            request.SetupGet(req => req.ApplicationPath).Returns("/");
            request.SetupGet(req => req.AppRelativeCurrentExecutionFilePath).Returns("~/");
            request.SetupGet(req => req.PathInfo).Returns(string.Empty);
            
            request.SetupGet(req => req.Cookies).Returns(cookies);
            request.SetupGet(req => req.Browser).Returns(browser.Object);

            response.Setup(res => res.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns((string virtualPath) => virtualPath);

            response.SetupGet(res => res.Cookies).Returns(cookies);
            
            user.Setup(usr => usr.Identity).Returns(identity.Object);
            
            identity.SetupGet(ident => ident.IsAuthenticated).Returns(true);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);
            context.Setup(ctx => ctx.Items).Returns(new Dictionary<object, object>());

            return context.Object;
        }
    }
}
