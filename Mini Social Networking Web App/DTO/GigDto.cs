using Mini_Social_Networking_Web_App.Models;
using System;
using System.Collections.Generic;

namespace Mini_Social_Networking_Web_App.DTO
{
    public class GigDTO
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDTO Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre GenreDTO { get; set; }
    }
}