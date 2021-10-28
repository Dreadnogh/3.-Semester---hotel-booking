using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeStay.MVC.DataAccessLayer;
using PrimeStay.MVC.DataAccessLayer.DTO;
using PrimeStay.MVC.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeStay.MVC.Controllers
{
    public class HotelController : Controller
    {
        private readonly IDao<HotelDto> _dao;
        private readonly RoomController _RoomCTRL;
        private readonly LocationController _locationCTRL;

        public HotelController(IDao<HotelDto> dao, IDao<LocationDto> locationDao, IDao<RoomDto> roomDao)
        {
            _dao = dao;
            _locationCTRL = new LocationController(locationDao);
            _RoomCTRL = new RoomController(roomDao);
        }
        public IActionResult Index([FromQuery] Hotel hotel)
        {
            //if (hotels == null) 
            IEnumerable<HotelDto> hotels = _dao.ReadAll(hotel.Map());
            List<Hotel> hotelList = hotels.Select(h => h.Map()).ToList();
            hotelList.ForEach(h => h.Location = GetHotelLocation(h));
            return View(hotelList);
        }

        public IActionResult Result(IFormCollection collection)
        {
            IEnumerable<HotelDto> hotels = _dao.ReadAll(new HotelDto());
            List<Hotel> hotelMatches = hotels.Select(h => h.Map()).ToList();
            hotelMatches.ForEach(h => h.Location = GetHotelLocation(h));
            hotelMatches = hotelMatches.Where(h => h.Matches(collection["Location"])).ToList();

            int guests = int.Parse(collection["guests"]);
            int minPrice = int.Parse(collection["minPrice"]);
            int maxPrice = int.Parse(collection["maxPrice"]);

            HttpContext.Session.SetString("hotelLocation", collection["location"]);
            HttpContext.Session.SetString("checkIn", collection["startDate"]);
            HttpContext.Session.SetString("checkOut", collection["endDate"]);
            HttpContext.Session.SetInt32("guests", guests);
            HttpContext.Session.SetInt32("minPrice", minPrice);
            HttpContext.Session.SetInt32("maxPrice", maxPrice);

            return View((collection, hotelMatches));
        }
        //[Route("Details")]
        public IActionResult Details([FromQuery] string href)
        {
            var hotel = GetHotel(href);
            hotel.Location = GetHotelLocation(hotel);
            hotel.rooms = _RoomCTRL.GetAllHotelRoomsForHotel(href);

            HttpContext.Session.SetString("selectedHotel", href);
            return View(hotel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private Hotel GetHotel(string href)
        {
            return _dao.ReadByHref(href).Map();
        }
        public IEnumerable<Hotel> GetAllHotels()
        {
            HotelDto emptyHotel = new();
            return _dao.ReadAll(emptyHotel).Select(h => h.Map());
        }
        private Location GetHotelLocation(Hotel h)
        {
            //TODO get controller from 
            return _locationCTRL.GetLocationByHref($"/api/location/{h.Location_Id}");
        }


    }
}
