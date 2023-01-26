using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using TraineeTracker.Application.Constants;

namespace TraineeTracker.Application.UnitTests.Mocks
{
    internal class MockHttpContextAccessor
    {
        public static Mock<IHttpContextAccessor> GetHttpContext(string id, string email)
        {
            var mockContextAccessor = new Mock<IHttpContextAccessor>();

            var userId = id;
            var user = new ClaimsPrincipal(new ClaimsIdentity(
                new Claim[] {
                    new Claim(CustomClaimTypes.Uid, userId),
                    new Claim(ClaimTypes.Email, email)
                }));

            var context = new DefaultHttpContext { User = user };

            mockContextAccessor.Setup(r => r.HttpContext).Returns(context);

            return mockContextAccessor;
        }
    }
}
