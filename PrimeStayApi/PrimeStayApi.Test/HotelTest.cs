﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeStayApi.Controllers;
using PrimeStayApi.DataAccessLayer;
using PrimeStayApi.DataAccessLayer.DAO;
using PrimeStayApi.Database;
using PrimeStayApi.Enviroment;
using PrimeStayApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace PrimeStayApi.Test
{
    [TestClass]
    public class HotelControllerTest
    {
        private HotelController _controllerWithDB;
        private IDao<HotelEntity> _dao;
        private DataContext _dataContext;
        private HotelController _controllerNoDB;


        [TestInitialize]
        public void SetUp()
        {
            Version.Upgrade(ENV.ConnectionStringTest);
            _dataContext = new DataContext(ENV.ConnectionStringTest);

        }
        [TestCleanup]
        public void CleanUp()
        {
            Version.Drop(ENV.ConnectionStringTest);
        }


        [TestMethod]
        public void GetHotelFromTestDBWithId()
        {
            //arrange
            _dao = DaoFactory.Create<HotelEntity>(_dataContext);
            _controllerWithDB = new HotelController(_dao);
            int hotelId = 1;
            //act 
            var hotel = _controllerWithDB.Details(hotelId);
            //assert 
            Assert.IsTrue(hotel.Name.Equals("Hotel Petrús"));
        }

        [TestMethod]
        public void GetHotelFromTestDBWithHotel()
        {
            //arrange
            _dao = DaoFactory.Create<HotelEntity>(_dataContext);
            _controllerWithDB = new HotelController(_dao);
            var hotel = new HotelEntity()
            {
                Name = "Hotel Petrús",
                Description = "Classic old fashioned hotel with a river of red wine.",
                Stars = 3,
                Staffed_hours = "24/7",
            };
            //act 
            var hotels = _controllerWithDB.Index(hotel.Name, hotel.Description, hotel.Staffed_hours, hotel.Stars);
            //assert 
            Assert.IsTrue(hotels.Count() == 1);
            Assert.IsTrue(hotels.First().Name == hotel.Name);
            Assert.IsTrue(hotels.First().Description == hotel.Description);
            Assert.IsTrue(hotels.First().Staffed_hours == hotel.Staffed_hours);
            Assert.IsTrue(hotels.First().Stars == hotel.Stars);
        }

        internal class FakeHotelDao : IDao<HotelEntity>
        {
            public int Create(HotelEntity model)
            {
                return -1;
            }

            public int Delete(HotelEntity model)
            {
                return -1;
            }

            public IEnumerable<HotelEntity> ReadAll(HotelEntity model)
            {
                return new List<HotelEntity>();
            }

            public HotelEntity ReadById(int id)
            {
                return new HotelEntity();
            }

            public int Update(HotelEntity model)
            {
                return -1;
            }
        }
        [TestMethod]
        public void GetHotelFakeDaoWithId()
        {
            //Arange
            _controllerNoDB = new HotelController(new FakeHotelDao());
            int id = 1;

            //Act
            var res = _controllerNoDB.Details(id);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(res.Name));
        }

        [TestMethod]
        public void GetHotelsFakeDaoWithHotel()
        {
            //Arrange
            _controllerNoDB = new HotelController(new FakeHotelDao());
            var hotel = new HotelEntity()
            {
                Name = "Test",
                Description = "Test",
                Staffed_hours = "Test",
                Stars = 1,
            };

            //Act
            var res = _controllerNoDB.Index(hotel.Name, hotel.Description, hotel.Staffed_hours, hotel.Stars);
            //Assert
            Assert.AreEqual(res.Count(), 0);
        }
    }
}