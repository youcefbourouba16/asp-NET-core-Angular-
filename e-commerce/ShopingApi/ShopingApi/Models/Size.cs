﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopingApi.Models
{
    public class Size
    {
        [Key]

        public string Name { get; set; }
    }
}