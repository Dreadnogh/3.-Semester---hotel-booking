﻿using System;

namespace PrimeStay.MVC.DataAccessLayer
{
    internal class DaoFactoryException : Exception
    {
        public DaoFactoryException(string message) : base(message)
        {
        }
    }
}