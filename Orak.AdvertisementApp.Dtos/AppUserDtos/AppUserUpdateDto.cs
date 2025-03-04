﻿using Orak.AdvertisementApp.Dtos.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Dtos
{
    public class AppUserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
    }
}
