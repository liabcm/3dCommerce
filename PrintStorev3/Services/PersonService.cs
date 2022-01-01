using PrintStorev3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintStorev3.Models;

namespace PrintStorev3.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public PersonService(DataContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AddPerosnDto> AddPerson(AddPerosnDto addPerosn)
        {
            context.Person.Add(mapper.Map<Person>(addPerosn));
            await context.SaveChangesAsync();
            return addPerosn;
        }

        public async Task<List<GetPersonDto>> GetBuyers()
        {
            return await context.Person.Where(p=>p.IsBuyer==1).Select(p => mapper.Map<GetPersonDto>(p)).ToListAsync();
        }

        public async Task<List<GetPersonDto>> GetDesigners()
        {
            return await context.Person.Where(p => p.IsDesigner == 1).Select(p => mapper.Map<GetPersonDto>(p)).ToListAsync();
        }

        public async Task<List<GetPersonDto>> GetPeople(int id)
        {
            if (id == 0)
            {
                return await context.Person.Select(p => mapper.Map<GetPersonDto>(p)).ToListAsync();
            }
            else
            {
                return await context.Person.Where(p => p.Id == id).Select(p => mapper.Map<GetPersonDto>(p)).ToListAsync();
            }
        }

        public async Task<List<GetPersonDto>> GetPrinters()
        {
            return await context.Person.Where(p => p.IsPrinter == 1).Select(p => mapper.Map<GetPersonDto>(p)).ToListAsync();
        }

        public async Task<UpdatePerson> UpdatePerson(UpdatePerson updatePerson)
        {
            try
            {
                Person person = context.Person.Where(p => p.Id == updatePerson.Id).FirstOrDefault();
                mapper.Map(updatePerson,person);
                 await context.SaveChangesAsync();
                return updatePerson;
            }
            catch(Exception e)
            {
                return new UpdatePerson ();
            }
        }
    }
}
