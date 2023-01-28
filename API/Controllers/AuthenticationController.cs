using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using SparklesAPI.FrameWork;
using SparklesAPI.Models;

namespace SparklesAPI.Controllers
{
    [Route("api")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("api/Authentication")]
        [AllowAnonymous]
        public IHttpActionResult GetToken([FromBody] User user)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            SqlParameter sqlparamusername;
            SqlParameter sqlparampassword;


            sqlparamusername = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
            sqlparamusername.Direction = ParameterDirection.Input;
            sqlparamusername.Value = user.UserName;

            sqlparam.Add(sqlparamusername);

            sqlparampassword = new SqlParameter("@PASSWORD", SqlDbType.NVarChar, 200);
            sqlparampassword.Direction = ParameterDirection.Input;
            sqlparampassword.Value = user.Password;

            sqlparam.Add(sqlparampassword);


            List<Items> Items = new List<Items>();
            DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHECKUSER", sqlparam);

            if (dt.Rows.Count > 0)
            {
                
                string key = ConfigurationManager.AppSettings.Get("key");

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.Name, user.UserName)
                        }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                //4. Create Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var jwt_token = tokenHandler.WriteToken(token);

                return Ok(new { data = jwt_token });
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
