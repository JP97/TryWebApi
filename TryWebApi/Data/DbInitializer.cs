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
            Service[] services = new Service[5];

            if (!context.GetServices.Any())
            {
                services = new Service[]
                {
                new Service{ServiceName="Grammateket", Cost=29.99},
                new Service{ServiceName="MatematikLegFlex", Cost=49.99},
                new Service{ServiceName="IntoWords", Cost=99.99},
                new Service{ServiceName="OutroWords", Cost=99.99},
                new Service{ServiceName="Outrotek", Cost=39.99}
                };

                foreach (Service s in services)
                {
                    context.GetServices.Add(s);
                }
                //context.SaveChanges(); 
            } 

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
                //context.SaveChanges();
            }


            if (!context.ServiceAssignments.Any())
            {
                var serviceAssignments = new ServiceAssignment[]
                {
                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "Grammateket").ServiceID,
                UserID = users.Single(u => u.UserName == "Bob").UserID
                },
                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "MatematikLegFlex").ServiceID,
                UserID = users.Single(u => u.UserName == "Bob").UserID
                },
                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "IntoWords").ServiceID,
                UserID = users.Single(u => u.UserName == "Bob").UserID
                },
                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "MatematikLegFlex").ServiceID,
                UserID = users.Single(u => u.UserName == "John").UserID
                },

                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "IntoWords").ServiceID,
                UserID = users.Single(u => u.UserName == "Jim").UserID
                },
                new ServiceAssignment{
                ServiceID = services.Single(s => s.ServiceName == "OutroWords").ServiceID,
                UserID = users.Single(u => u.UserName == "Gurlie").UserID},
                };

                foreach (ServiceAssignment serviceAssignemt in serviceAssignments)
                {
                    context.ServiceAssignments.Add(serviceAssignemt);
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






        }
    }
}
