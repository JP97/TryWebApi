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

            if(_context.Users.Count() == 0 || _context.GetServices.Count() == 0)
            {
                //IEnumerable<User> users = new User[]
                //{
                //new User{UserName="Bob",Email="bob@dot.com",JoinDate=DateTime.Now, ID=1},
                //new User{UserName="John",Email="john@dot.com",JoinDate=DateTime.Now, ID=2},
                //new User{UserName="Jim",Email="Jim@dot.com",JoinDate=DateTime.Now, ID=3},
                //new User{UserName="Gurlie",Email="gurlie@dot.com",JoinDate=DateTime.Now, ID=4}
                //};
                //_context.AddRange(users);
                //_context.SaveChanges();
                DbInitializer.Initialize(_context);
            }
            
        }

        //Virker i Postman
        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //put virker kun hvis du har asnotracking med i det lort
           yield return JsonConvert.SerializeObject(_context.Users.AsNoTracking());
        }

        //virker i Postman
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            User userToGet = _context.Users.Find(id);

            if(userToGet == null)
            {
                NotFound();
            }

            return JsonConvert.SerializeObject(userToGet);
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
            if(id != updatedUser.ID)
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
           User userToDelete = _context.Users.Find(id);

           if(userToDelete == null)
           {
                NotFound();
           }

            _context.Users.Remove(userToDelete);

            _context.SaveChangesAsync();
        }
    }
}
