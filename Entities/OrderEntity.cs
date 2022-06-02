using System;
using System.Collections.Generic;
using System.Text;

namespace WebUI.Entities
{
    class OrderEntity
    {
        private string _name;
        private string _country;
        private string _city;
        private string _creditCard;
        private string _month;
        private string _year;

        public string Name { get { return _name; } set { _name = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string CreditCard { get { return _creditCard; } set { _creditCard = value; } }
        public string Month { get { return _month; } set { _month = value; } }
        public string Year { get { return _year; } set { _year = value; } }




        public OrderEntity(string name, string country, string city, string creditCard, string month, string year)
        {
            this._name = name;
            this._country = country;
            this._city = city;
            this._creditCard = creditCard;
            this._month = month;
            this._year = year;
        }
    }
}
