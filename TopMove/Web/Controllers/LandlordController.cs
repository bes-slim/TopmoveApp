using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Models;
using Web.Security;

namespace Web.Controllers
{
    public interface ILandlordRepository
    {
        Task<IEnumerable<LandLordViewModel>> FindAsync();
        Task<LandLordViewModel> FindAsync(string reference);
        Task CreateAsync(LandLordViewModel landLord);
    }

    public class LandlordRepository   : ILandlordRepository
    {
        private int _id = 0;

        private static IList<LandLordViewModel> _landLords;
        private ReferenceGenerator generator;
     
        public LandlordRepository()
        {
            _landLords = new List<LandLordViewModel>();
            generator = new ReferenceGenerator();
        }
        public Task<IEnumerable<LandLordViewModel>> FindAsync()
        {
            return Task.FromResult(_landLords.AsEnumerable());
        }

        public Task<LandLordViewModel> FindAsync(string reference)
        {
            if (_landLords.Any(l => l.Reference== reference))
                return Task.FromResult(_landLords.Single(i => i.Reference == reference));
            else 
                return new Task<LandLordViewModel>(null);
        }

        public Task CreateAsync(LandLordViewModel landLord)
        {
            landLord.Reference = generator.CreateReference(10);
            _landLords.Add(landLord);
            return Task.FromResult(landLord);
        }
    }

    public class LandlordController : ApiController
    {
        private ConcurrentBag<LandLordViewModel> _landLords;
        private ILandlordRepository _landlordRepo;

        public LandlordController()
        {
            _landLords = new ConcurrentBag<LandLordViewModel>();
            _landlordRepo = new LandlordRepository();
        }

        public async Task<HttpResponseMessage> Get()
        {
            var result = await _landlordRepo.FindAsync();
            var landLords = result as IList<LandLordViewModel> ?? result.ToList();
            return !landLords.Any() ? Request.CreateResponse(HttpStatusCode.NotFound) : Request.CreateResponse(HttpStatusCode.OK, landLords);
        }

        public async Task<HttpResponseMessage> Post([FromBody]LandLordViewModel newLandlord)
        {
            var landlord = new LandLordViewModel()
            {
                Title = newLandlord.Title,
                FirstName = newLandlord.FirstName,
                LastName = newLandlord.LastName,
                Address = new AddressViewModel()
                {
                    HouseNameNumber = newLandlord.Address.HouseNameNumber,
                    StreetName = newLandlord.Address.StreetName,
                    Town = newLandlord.Address.Town,
                    County = newLandlord.Address.County,
                    Country = newLandlord.Address.Country,

                },
                PhoneNumbers = newLandlord.PhoneNumbers,
                Properties = newLandlord.Properties
            };

            await _landlordRepo.CreateAsync(landlord);
            return Request.CreateResponse(HttpStatusCode.Created, landlord);
        }
    }
}
