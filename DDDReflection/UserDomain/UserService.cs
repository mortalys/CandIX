using Framework;
using Newtonsoft.Json;
using UserDomain.Requests;

namespace UserDomain
{
    public class UserService : IService
    {
        public object Handle(object parameters)
        {
            UserBaseRequest userBaseRequest = JsonConvert.DeserializeObject<UserBaseRequest>(parameters.ToString());

            return $"Welcome {userBaseRequest.Name}";
        }
    }
}