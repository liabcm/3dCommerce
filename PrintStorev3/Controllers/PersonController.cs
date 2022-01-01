using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;
using PrintStorev3.Services;

namespace PrintStorev3.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        [HttpGet]
        public async Task<List<GetPersonDto>> Get(int id=0)
        {
            return await personService.GetPeople(id);
        }
        [HttpGet]
        [Route("buyers")]
        public async Task<List<GetPersonDto>> GetBuyers()
        {
            return await personService.GetBuyers();
        }
        [HttpGet]
        [Route("printers")]
        public async Task<List<GetPersonDto>> GetPrinters()
        {
            return await personService.GetPrinters();
        }
        [HttpGet]
        [Route("designers")]
        public async Task<List<GetPersonDto>> GetDesigners()
        {
            return await personService.GetDesigners();
        }
        [HttpPost]
        public async Task<AddPerosnDto> Add(AddPerosnDto addPerosn)
        {
            return await personService.AddPerson(addPerosn);
        }
        [HttpPut]
        public async Task<UpdatePerson> Update(UpdatePerson updatePerson)
        {
            return await personService.UpdatePerson(updatePerson);
        }
    }
}
