﻿using DataAccessLayer.DTO;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.DAO

{
    internal class BookingDao : BaseDao<IDataContext<IRestClient>>, IDao<BookingDto>
    {
        public BookingDao(IDataContext<IRestClient> dataContext, string accessToken) : base(dataContext, accessToken)
        {
        }

        public string Create(BookingDto model, string token)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/booking", Method.POST, DataFormat.Json).AddJsonBody(model);
            var res = client.Execute<int>(request).Headers.Where(res => res.Name == "Location").Select(res => res.Value).FirstOrDefault() as string;
            return res;
        }

        public int Delete(BookingDto model, string token)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BookingDto> ReadAll(BookingDto model, string token)
        {
            throw new System.NotImplementedException();
        }

        public BookingDto ReadByHref(string href)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest(href, Method.GET, DataFormat.Json);
            var res = client.Execute<BookingDto>(request).Data;
            return res;
        }

        public int Update(BookingDto model, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}