using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryWebApi.Models;

namespace TryWebApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(TryWebApiContext context)
        {
            context.Database.EnsureCreated();
            User[] users = new User[4];
            Service[] services = new Service[3];

            // Look for any users.
            if (!context.Users.Any())
            {
                users = new User[]
                {
                new User{UserName="Bob",Email="bob@dot.com",JoinDate=DateTime.Now},
                new User{UserName="John",Email="john@dot.com",JoinDate=DateTime.Now},
                new User{UserName="Jim",Email="Jim@dot.com",JoinDate=DateTime.Now},
                new User{UserName="Gurlie",Email="gurlie@dot.com",JoinDate=DateTime.Now}
                };

                foreach (User user in users)
                {
                    context.Users.Add(user);
                }
                context.SaveChanges();
            }

            //var users = new User[]
            //{
            //    new User{UserName="Bob",Email="bob@dot.com",JoinDate=DateTime.Now},
            //    new User{UserName="John",Email="john@dot.com",JoinDate=DateTime.Now},
            //    new User{UserName="Jim",Email="Jim@dot.com",JoinDate=DateTime.Now},
            //    new User{UserName="Gurlie",Email="gurlie@dot.com",JoinDate=DateTime.Now}
            //};

            //foreach (User user in users)
            //{
            //    context.Users.Add(user);
            //}
            //context.SaveChanges();



            if (!context.GetServices.Any())
            {
                services = new Service[]
                {
                new Service{ServiceID=1000,ServiceName="Grammateket", Cost=29.99},
                new Service{ServiceID=1001,ServiceName="MatematikLegFlex", Cost=49.99},
                new Service{ServiceID=1002,ServiceName="IntoWords", Cost=99.99}
                       };

                foreach (Service s in services)
                {
                    context.GetServices.Add(s);
                }
                context.SaveChanges(); 
            } 



        }
    }
}
