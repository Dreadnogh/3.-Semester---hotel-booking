﻿using Microsoft.AspNetCore.Mvc;
using PrimeStay.MVC.DataAccessLayer;
using PrimeStay.MVC.DataAccessLayer.DTO;
using PrimeStay.MVC.Model;

namespace PrimeStay.MVC.Controllers
{
    public class LocationController : Controller
    {
        private readonly IDao<LocationDto> _dao;

        public LocationController(IDao<LocationDto> dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public Location GetLocationById(int id)
        {
            return _dao.ReadById(id).Map();
        }
    }
}
