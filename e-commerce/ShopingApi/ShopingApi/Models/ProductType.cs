﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingApi.Models
{
    public class ProductType
    {

        [Key]

        public string typeName { get; set; }
    }
}