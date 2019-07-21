using System;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMyScopedService is injected into Invoke
        public async Task Invoke(HttpContext httpContext, IUsersRepository repository)
        {
            if (!repository.GetUsers().Any())
            {
                User[] users = new User[]{
                new User(){
                    Username = "ashrey97",
                    Password = "test",
                    Profile = new Profile(){
                        FirstName = "Aleksandar",
                        LastName = "Kojic",
                        PhoneNumber = "+381 612234931",
                        Addresses = new Address[]{
                            new Address(){
                                State = "Serbia",
                                City = "Smederevo",
                                Street = "Dragoljuba Pajica 5/9",
                                Zip = "11300"
                            }
                        },
                        SocialNetworks = new SocialNetwork[]{
                            new SocialNetwork(){
                                Name = "Facebook",
                                Url = "someurl"
                            }
                        }

                    }
                },
                new User(){
                    Username = "deksi",
                    Password = "test",
                    Profile = new Profile(){
                        FirstName = "Dejan",
                        LastName = "Kojic",
                        PhoneNumber = "+381 650454512",
                        Addresses = new Address[]{
                            new Address(){
                                State = "Serbia",
                                City = "Smederevo",
                                Street = "Dragoljuba Pajica 5/9",
                                Zip = "11300"
                            }
                        },
                        SocialNetworks = new SocialNetwork[]{
                            new SocialNetwork(){
                                Name = "Facebook",
                                Url = "someurl"
                            }
                        }

                    }
                }
                };

                foreach (User user in users)
                {
                    repository.CreateUser(user);
                }
            }


            await _next(httpContext);
        }
    }
}
