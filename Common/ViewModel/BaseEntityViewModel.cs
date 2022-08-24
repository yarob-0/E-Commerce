namespace Common
{
	using System;

    public class BaseEntityViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
