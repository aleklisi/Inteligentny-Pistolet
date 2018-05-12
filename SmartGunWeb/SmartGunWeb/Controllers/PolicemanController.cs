using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;
using ObjectsManager.Model;

namespace SmartGunWeb.Controllers
{
    public class PolicemanController : ApiController
    {
        private readonly IPolicemanRepository policemans = new PolicemanRepository();

        //GET api/policeman
        public IEnumerable<Policeman> Get()
        {
            return policemans.GetAll();
        }

        //GET api/policeman/id
        public HttpResponseMessage Get(int id)
        {
            Policeman policeman = policemans.Get(id);
            HttpResponseMessage response;

            if (policeman == null)
            {
                response =
                    Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                response.Content = new StringContent("The user with " + id + "not found", Encoding.Unicode);
                return response;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + "exists");
            response.Content = new StringContent("Name: " + policeman.Name + " status: " + policeman.status, Encoding.Unicode);

            return response;
        }

        // POST api/policeman/
        public HttpResponseMessage Post([FromBody] Policeman policeman)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during registration");    

                if (policeman.Password == null || policeman.Name == null)
                {
                    response.Content = new StringContent("The password can't be empty", Encoding.Unicode);
                    return response;
                }

            int policemanId = policemans.Add(policeman);

            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + policemanId + "is created");
            response.Content = new StringContent("Welcome", Encoding.Unicode);

            return response;
        }

        // PUT api/policeman/id/{password}
       /* public HttpResponseMessage Put(int id, string password)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during sign in");
            response.Content = new StringContent("Sign is failed", Encoding.Unicode);

            var policeman = allPoliceman.FirstOrDefault((p) => p.Id == id);
            if (policeman == null)
            {
                response.Content = new StringContent("The user with " + id + " is not exist", Encoding.Unicode);
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
        }*/

        // PUT api/policeman/id
        public HttpResponseMessage Put(int id, [FromBody]Status status)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during changing status");
            response.Content = new StringContent("Change status is failed", Encoding.Unicode);

            Policeman policeman = policemans.Get(id);

            if (policeman == null)
            {
                response.Content = new StringContent("The user with " + id + " is not exist", Encoding.Unicode);
                return response;
            }

            policeman.status = status;
            policemans.Update(policeman);

            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + " change status");
            response.Content = new StringContent("Change status succesfully", Encoding.Unicode);

            return response;
        }

        //DELETE api/policeman/id
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Forbidden, "Error during sign out");
            response.Content = new StringContent("Sign out is failed", Encoding.Unicode);

            if (!policemans.Delete(id))
            {
                return response;
            }

            response = Request.CreateResponse(HttpStatusCode.OK, "The user with " + id + "is logged out");
            response.Content = new StringContent("Sign out succesfully", Encoding.Unicode);
            return response;
        }

    }
}
