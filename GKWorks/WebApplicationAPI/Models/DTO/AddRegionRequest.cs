﻿namespace WebApplicationAPI.Models.DTO
{
    public class AddRegionRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Late { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}