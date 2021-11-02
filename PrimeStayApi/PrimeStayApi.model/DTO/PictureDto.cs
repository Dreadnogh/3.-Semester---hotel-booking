﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeStayApi.Model.DTO
{
    public class PictureDto:BaseModelDto
    {
        public string? RoomHref { get; set; }
        public string? HotelHref { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

    }
}
