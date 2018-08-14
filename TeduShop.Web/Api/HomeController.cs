using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using AutoMapper;
using TeduShop.Web.Models;
using TeduShop.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        #region initialize
        public HomeController(IErrorService errorService) : base(errorService)
        {

        }
        #endregion

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, hihihaha";
        }
    }
}
