﻿namespace ChatHistory.Domain.Models
{
    public class User
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
