using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DDDReflection.Requests;
using Framework;
using Microsoft.AspNetCore.Mvc;

namespace DDDReflection.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private Dictionary<string, string> Router { get; set; } = new Dictionary<string, string>
        {
            { "User", "UserDomain.UserService" }
        };

        [HttpGet("EntryPoint")]
        public object EntryPoint([FromBody]BaseRequest baseRequest)
        {
            string route = baseRequest.Route;
            object parameters = baseRequest.Parameters;

            string dll = Router[route];
            IService service = LoadModule(dll);
            return service.Handle(parameters);
        }

        private IService LoadModule(string dll)
        {
            try
            {
                string assemblyname = dll.Substring(0, dll.IndexOf("."));
                string classname = dll.Substring(dll.IndexOf(".") + 1);

                Assembly assembly = Assembly.Load(assemblyname);

                return (IService)assembly.CreateInstance(dll, true, BindingFlags.CreateInstance, null, null, null, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}