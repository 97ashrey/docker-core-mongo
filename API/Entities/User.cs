using System;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class User
    {
        [BsonId]
        public Guid Id {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}

        public Profile Profile {get;set;}
    }

    public class Profile {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PhoneNumber {get;set;}
        public Address[] Addresses {get;set;}
        public SocialNetwork[] SocialNetworks {get;set;}
    }

    public class Address {
        public string State {get;set;}
        public string Zip {get;set;}
        public string City {get;set;}
        public string Street {get;set;}
    }

    public class SocialNetwork {
        public string Name {get;set;}
        public string Url {get;set;}
    }
}
