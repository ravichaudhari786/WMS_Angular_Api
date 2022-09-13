using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        WMS_Entities _context;
        AccountController()
        {
            _context= new WMS_Entities();
        }

        /// <summary>
        ///  user name  and password  filed  data  required
        /// </summary>
        /// <param name="user">Username,Password required</param>
        /// <returns></returns>
       
        [HttpPost]
        [Route("api/Login")]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] LoginModel user)
            {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
                
                var model = _context.Accountuser_Login(user.Username, user.Password).ToList();
                //FirstOrDefault();
                if (model != null)
                {
                    
                    if (model[0].UserID > 0)
                    {
                        string token = createToken(user.Username);
                        ApplicationUser appuser = new ApplicationUser();
                        appuser.UserID = Convert.ToInt32(model[0].UserID);
                        appuser.CompanyID = Convert.ToInt32(model[0].CompanyID);
                        appuser.Token = token;
                        //appuser.sploginlist = model;
                        var users = _context.Users.FirstOrDefault(s => s.UserID == appuser.UserID);
                        appuser.RoleID = users.RoleID;
                        var yearList = _context.Finacialyear_Select().ToList();
                        var currentUser = new { user = appuser, warehouseList = model,finantialYears= yearList };

                        return Ok(currentUser);
                    }
                    
                    return Ok(false);
                    
                }
                else
                {
                    return NotFound();
                }
           
        }

        /// <summary>
        /// Get GetfinantialYears Info
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/finantialYears")]
        public IHttpActionResult GetfinantialYears()
        {
            var data = _context.Finacialyear_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        private string createToken(string username)
        {     
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);


            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            System.Security.Claims.ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:50191", audience: "http://localhost:50191",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

    }
}
