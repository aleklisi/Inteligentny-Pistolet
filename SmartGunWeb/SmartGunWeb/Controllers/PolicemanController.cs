using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using SmartGunWeb.Core;

namespace SmartGunWeb.Controllers
{
    public class PolicemanController : ApiController
    {
        HashSet<Policeman> loggedPoliceman = new HashSet<Policeman>();
        HashSet<Policeman> allPoliceman = new HashSet<Policeman>();

        public IEnumerable<Policeman> GetAllCurrentLoggedPoliceman()
        {
            return loggedPoliceman;
        }

        public Policeman GetPolicemanById(int id)
        {
            var policeman = allPoliceman.FirstOrDefault((p) => p.Id == id);
            if (policeman == null)
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.NotFound, "Not founf");
                response.Content = new StringContent("The user with " + id + "not found", Encoding.Unicode);
            }
            return policeman;
        }

        public IEnumerable<Policeman> GetPolicemanWithStatus(string status) => allPoliceman.Where(
            (p) => string.Equals(p.Status.ToString(), status,
                StringComparison.OrdinalIgnoreCase));

        // POST api/policeman/{id}/{password}
        public HttpResponseMessage Post(int id, [FromBody]string password)
        {
            int userId;
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during registration"); 
            response.Content = new StringContent("The user with " + id + "can't be created", Encoding.Unicode);

                var policeman = allPoliceman.FirstOrDefault((p) => p.Id == id);

                if (policeman != null)
                {
                    response.Content = new StringContent("The user with " + id + " already exist", Encoding.Unicode);
                    return response;
                }

                if (password == null)
                {
                    response.Content = new StringContent("The password can't be empty", Encoding.Unicode);
                    return response;
                }

                var newPoliceman = new Policeman(id, password);
                response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + "is created");
                response.Content = new StringContent("Welcome", Encoding.Unicode);
                allPoliceman.Add(newPoliceman);

            return response;
        }

        // PUT api/policeman/id/{password}
        public HttpResponseMessage Put(int id, [FromBody]string password)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during sign in");
            response.Content = new StringContent("Sign is failed", Encoding.Unicode);

            var policeman = allPoliceman.FirstOrDefault((p) => p.Id == id);
            if (policeman == null)
            {
                response.Content = new StringContent("The user with " + id + "is not exist", Encoding.Unicode);
                return response;
            }

            var loggedpoliceman = loggedPoliceman.FirstOrDefault((p) => p.Id == id);
            if (loggedpoliceman != null)
            {
                response.Content = new StringContent("The user with " + id + "is already logged", Encoding.Unicode);
                return response;
            }

            if (password == null)
            {
                response.Content = new StringContent("Password is empty", Encoding.Unicode);
                return response;
            }

            if (policeman.Password != password)
            {
                response.Content = new StringContent("Password is incorrect", Encoding.Unicode);
                return response;
            }

            var newPoliceman = new Policeman(id, password);
            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + "is logged");
            response.Content = new StringContent("Sign in succesfully", Encoding.Unicode);
            loggedPoliceman.Add(newPoliceman);

            return response;
        }

        //DELETE api/policeman/id
        public HttpResponseMessage SignOut(int id)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during sign out");
            response.Content = new StringContent("Sign out is failed", Encoding.Unicode);

            var policeman = allPoliceman.FirstOrDefault((p) => p.Id == id);
            if (policeman == null)
            {
                response.Content = new StringContent("The user with " + id + "is not exist", Encoding.Unicode);
                return response;
            }

            var loggedpoliceman = loggedPoliceman.FirstOrDefault((p) => p.Id == id);
            if (loggedpoliceman == null)
            {
                response.Content = new StringContent("The user with " + id + "is not logged", Encoding.Unicode);
                return response;
            }

            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + "is logged out");
            response.Content = new StringContent("Sign out succesfully", Encoding.Unicode);
            loggedPoliceman.Remove(GetPolicemanById(id));
            return response;
        }

    }
}
