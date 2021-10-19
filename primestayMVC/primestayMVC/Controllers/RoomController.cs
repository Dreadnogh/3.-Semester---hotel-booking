﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using primestayMVC.Model;
using primestayMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using primestayMVC.Model.DTO;

namespace primestayMVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;

        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
        public static IEnumerable<Room> getAllHotelRooms(string hotelHref)
        {
            RestClient client = new("https://localhost:44312/");
            RestRequest request = new($"api/room?hotel_id={hotelHref.GetIdFromHref()}",Method.GET, DataFormat.Json);
            return client.Execute<IEnumerable<Room>>(request).Data;
        }
    }
}
