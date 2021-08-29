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
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IPhoneRepository phoneRepository, IRelationRepository relationRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
            _relationRepository = relationRepository;
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
    }
}
