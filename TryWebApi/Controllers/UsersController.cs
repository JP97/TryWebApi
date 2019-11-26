using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryWebApi.Data;
using TryWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TryWebApi.Models.ViewModels;

namespace TryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TryWebApiContext _context;

        public UsersController(TryWebApiContext context)
        {
            _context = context;

            if(_context.Users.Count() == 0 || _context.GetServices.Count() == 0 || _context.ServiceAssignments.Count() == 0)
            {
                DbInitializer.Initialize(_context);
            }
            
        }

        //Virker i Postman
        // GET: api/Users
        [HttpGet]
        public List<User> Get()
        {
            //https://docs.microsoft.com/de-de/aspnet/core/data/ef-mvc/read-related-data?view=aspnetcore-2.2#about-explicit-loading
            //put virker kun hvis du har asnotracking med i det lort
            List<User> users = _context.Users.Include(i => i.ServiceAssignment)
                                                .ThenInclude(sa => sa.Service)
                                                .ToList();
            //List<UserIndexData> listWithUserData = new List<UserIndexData>();

            //var users = _context.Users;

            //----------------------------------------Bliver ikke slettet!----------------------------------------//
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            //foreach(User u in users)                                                                            //
            //{                                                                                                   //
            //    List<Service> services = new List<Service>();                                                   //
            //     UserIndexData userinformation = new UserIndexData();                                           //
            //    userinformation.User = u;                                                                       //
            //    _context.ServiceAssignments.Where(sa => sa.UserID == u.UserID).Load();                          //
            //    foreach (ServiceAssignment sa in u.ServiceAssignment)                                           //
            //    {                                                                                               //
            //        services.Add(_context.GetServices.SingleOrDefault(s => s.ServiceID == sa.ServiceID));       //
            //    }                                                                                               //
            //    userinformation.Services = services;                                                            //
            //    listWithUserData.Add(userinformation);                                                          //
            //    //services.Clear();                                                                             //
            //}                                                                                                   //
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            return users;
        }

        //private Service FindService(List<Service> services, int serviceID)
        //{
        //    Service serviceToFind = new Service();

        //    foreach (Service service in services)
        //    {
        //        if(service.ServiceID == serviceID)
        //        {
        //            serviceToFind = service;
        //        }
        //    }
        //    return serviceToFind;
        //}

        //virker i Postman
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public List<User> Get(int id)
        {
            List<User> userToGet = _context.Users
                .Where(u => u.UserID == id)
                .Include(sa => sa.ServiceAssignment)
                .ThenInclude(s => s.Service)
                .ToList();
                                                                       

            if(userToGet[0] == null)
            {
                NotFound();
            }

            return userToGet;
        }

        //virker i postman its alive/working
        // POST: api/Users
        [HttpPost]
        public void Post(User newUser)
        {
            _context.AddAsync(newUser);
            _context.SaveChangesAsync();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, User updatedUser)
        { 
            if(id != updatedUser.UserID)
            {
                BadRequest();
            }

            _context.Entry(updatedUser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //virker i Postman, der stod i hvertfald 200 OK
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<User> userToDelete = _context.Users.Where(u => u.UserID == id).Include(sa => sa.ServiceAssignment).ThenInclude(s => s.Service).ToList();


 

            if (userToDelete[0] == null)
           {
                NotFound();
           }

            _context.Users.Remove(userToDelete[0]);

            _context.SaveChangesAsync();
        }
    }
}
