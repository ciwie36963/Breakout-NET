using Xunit;
using Moq;
using BreakOutGameTest.Data;
using BreakOutGame.Models.Domain.RepsitoryInterfaces;
using BreakOutGame.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BreakOutGameTest.Controllers
{
    public class SessionTest
    {
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IBoBSessionRepository> _sessionRepository;
        private readonly SessionController _controller;
        private readonly Mock<HttpContext> _mockHttp;
        private readonly MockSession _mockSession;

        public SessionTest()
        {
            this._dummyContext = new DummyApplicationDbContext();
            this._sessionRepository = new Mock<IBoBSessionRepository>();
            this._mockHttp = new Mock<HttpContext>();
            this._mockSession = new MockSession();
            this._controller = new MockSessionController(_sessionRepository.Object, _mockHttp.Object);
        }

        #region tests

        [Fact]
        public void SessionCode_Valid_RedirectsTo_SesionDetail()
        {

            //trek een id binnen, get sessie met id, check of deze sessie actief is
            _sessionRepository.Setup(s => s.GetById(1)).Returns(_dummyContext.ValidSession);
            _mockHttp.Setup(http => http.Session).Returns(_mockSession);
            var result = _controller.ActivateSession(1) as RedirectToActionResult;
            Assert.Equal("SessionDetail", result?.ActionName);
            Assert.Equal(null, result?.ControllerName);
        }


        [Fact]
        public void SessionCode_ClosedSession_RedirectBackTo_SessionCodeScreen()
        {
            _sessionRepository.Setup(s => s.GetById(2)).Returns(_dummyContext.ClosedSession);
            _mockHttp.Setup(http => http.Session).Returns(_mockSession);

            var result = _controller.ActivateSession(2) as RedirectToActionResult;

            Assert.Equal("Session", result?.ControllerName);
            Assert.Equal("Index", result?.ActionName);
        }

        [Fact]
        public void SessionCode_ActiveSession_RedirectBackTo_SessionCodeScreen()
        {
            _sessionRepository.Setup(s => s.GetById(3)).Returns(_dummyContext.ActiveSession);
            _mockHttp.Setup(http => http.Session).Returns(_mockSession);
            var result = _controller.ActivateSession(3) as RedirectToActionResult;

            Assert.Equal("Session", result?.ControllerName);
            Assert.Equal("Index", result?.ActionName);
        }

        [Fact]
        public void SessionCode_StartedSession_RedirectBackTo_SessionCodeScreen()
        {
            _sessionRepository.Setup(s => s.GetById(4)).Returns(_dummyContext.StartedSession);
            _mockHttp.Setup(http => http.Session).Returns(_mockSession);
            var result = _controller.ActivateSession(4) as RedirectToActionResult;

            Assert.Equal("Session", result?.ControllerName);
            Assert.Equal("Index", result?.ActionName);
        }

        #endregion
    }
}