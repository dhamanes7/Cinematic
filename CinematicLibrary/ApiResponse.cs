﻿
using System.ComponentModel.DataAnnotations;

namespace Cinematic.ApiClient
{
    public class Response<T>
    {
        [Required]
        public Data<T> data { get; set; }
    }
    public class Data<T>
    {
        [Required]
        public List<T> upcoming { get; set; }
    }
}
