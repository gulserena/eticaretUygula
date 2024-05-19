﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eticaretUygulama.Models
{
    public class slider
    {
        public int SliderId { get; set; }
        public string? SliderName { get; set; } = string.Empty;
        public string? Heeader1 { get; set; }=string.Empty;
        public string? Heeader2 { get; set; } = string.Empty;
        public string? Context { get; set; } = string.Empty;
        public string SliderImage { get; set; } = string.Empty;
        [NotMapped ] 
        public IFormFile ImageUpload { get; set;}
    }
}
