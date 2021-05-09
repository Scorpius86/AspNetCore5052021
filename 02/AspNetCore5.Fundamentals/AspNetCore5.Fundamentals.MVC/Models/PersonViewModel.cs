﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5.Fundamentals.MVC.Models
{
    public class PersonViewModel
    {
        public PersonViewModel(string firstName, string lastName , int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
