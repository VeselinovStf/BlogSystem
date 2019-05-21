﻿using System;

namespace BS.Services.TagService.ModelDTO
{
    public class TagDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
