using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;

namespace PrintStorev3.Services
{
    public interface IPersonService
    {
        Task<List<GetPersonDto>> GetPeople(int id);
        Task<List<GetPersonDto>> GetBuyers();
        Task<List<GetPersonDto>> GetPrinters();
        Task<List<GetPersonDto>> GetDesigners();
        Task<AddPerosnDto> AddPerson(AddPerosnDto addPerosn);
        Task<UpdatePerson> UpdatePerson(UpdatePerson updatePerson);
    }
}
