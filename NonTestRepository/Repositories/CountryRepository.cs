using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonTestRepository.Entities;

namespace NonTestRepository.Repositories
{
    public class CountryRepository
    {
        private List<Country> _countryList;

        public CountryRepository()
        {
            _countryList = new List<Country>();
        }

        public List<Country> GetAllCountries()
        {
            //For test purposes we just add a few countries here.
            _countryList.Add(new Country { ISOCode = "SE", Name = "Sweden" });
            _countryList.Add(new Country { ISOCode = "NO", Name = "Norway" });

            return _countryList;
        }

        public Country GetCountryFromIsoCode(string isoCountry)
        {
            return _countryList.FirstOrDefault(x => x.ISOCode.Equals(isoCountry, StringComparison.InvariantCultureIgnoreCase)) ?? new Country {ISOCode = isoCountry};
        }
    }
}
