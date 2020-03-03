using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
//using System.Web.Mvc;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("logintest")]
        //public async Task<HttpResponseMessage> LoginTest(HttpRequestMessage request, TagViewModel username)
        public bool LoginTest(HttpRequestMessage request, TagViewModel username)
        {
            if (!ModelState.IsValid)
            {
                //return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return false;
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            //return request.CreateResponse(HttpStatusCode.OK);
            return true;
        }

        //[Route("logintest2")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, string username)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;

        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newProduct = new Product();
        //            newProduct.UpdateProduct(productVm);
        //            newProduct.CreatedDate = DateTime.Now;

        //            this._productService.Add(newProduct);
        //            this._productService.Save();

        //            var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }

        //        return response;
        //    });
        //}
    }
}
