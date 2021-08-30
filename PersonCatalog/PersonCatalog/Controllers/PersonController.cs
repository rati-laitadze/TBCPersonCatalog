using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.ResourceParameters;
using PersonCatalog.Models;
using PersonCatalog.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonCatalog.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IRelationRepository _relationRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IPhoneRepository phoneRepository, IRelationRepository relationRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
            _relationRepository = relationRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<PersonDTO>> GetPeople([FromQuery] PeopleResourceParameters parameters)
        {
            var DBpeople = _personRepository.SearchForPeople(parameters).ToList();
            var people = _mapper.Map<IEnumerable<PersonDTO>>(DBpeople);
            var retValue = new PersonsListDTO();
            retValue.PersonDTOs = people.ToList();

            if (parameters.ItemPerPage > 0 && parameters.PageNumber > 0)
            {
                retValue.TotalPageNumber = _personRepository.SearchForPeople(new PeopleResourceParameters()).Count() / parameters.ItemPerPage;
            }
            return Ok(retValue);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        [HttpHead]
        public IActionResult GetPerson(int id)
        {
            var person = _personRepository.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            person.Phones = _phoneRepository.Set().Where(a => a.PersonID == person.ID).ToList();
            person.RelativeTo = _relationRepository.Set().Where(a => a.PersonToID == person.ID || a.PersonFromID == person.ID).ToList();
            person.City = _cityRepository.Set().Where(a => a.ID == person.CityID).FirstOrDefault();

            return Ok(_mapper.Map<PersonDTO>(person));
        }
    }
}
