using BreakOutGame.Controllers;
using BreakOutGame.Models.Domain.RepsitoryInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOutGameTest.Data
{
    class MockSessionController : SessionController
    {
        //needed for injection during testing
        public MockSessionController(IBoBSessionRepository boBSessionRepository, HttpContext http) : base(boBSessionRepository)
        {
            ControllerContext.HttpContext = http;
        }
    }
}
