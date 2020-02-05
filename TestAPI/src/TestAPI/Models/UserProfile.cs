using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class UserProfile
    {
        public int profileId { get; set; }
        public string ImgUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }
    }
}
