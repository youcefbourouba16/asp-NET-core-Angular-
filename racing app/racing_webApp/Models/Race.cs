﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using racing_webApp.Data.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace racing_webApp.Models
{
    public class Race
    {
        private const string DefaultImageUrl = "https://media.istockphoto.com/id/143920084/photo/group-of-runners-in-a-cross-country-race.jpg?s=612x612&w=0&k=20&c=tIGYGDaKyM4qEs0RbXiAxt4WGGWcGRSTnS-T-lo750c=";
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private string? _image;
        public string Image
        {
            get { return _image; }
            set { _image = string.IsNullOrWhiteSpace(value) ? DefaultImageUrl : value; }
        }
        public DateTime? StartTime { get; set; }
        public int? EntryFee { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Contact { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public RaceCategory RaceCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}