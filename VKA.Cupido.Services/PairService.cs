﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKA.Cupido.Clients;
using VKA.Cupido.Entities;
using VKA.Cupido.Models;
using VKA.Cupido.Persistence.Interfaces;

namespace VKA.Cupido.Services
{
    public class PairService : IPairService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPairRepository _pairRepository;
        private readonly IMapper _mapper;
        private readonly IMailClient _mailClient;
        
        private List<PairModel> _pairs;

        public PairService(IPersonRepository personRepository, IPairRepository pairRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _pairRepository = pairRepository;
            _mapper = mapper;
        }

        public async Task NotifyAboutPairing()
        {
            foreach(var pair in _pairs)
            {
                await SendEmail(pair.FirstPerson, pair.SecondPerson);
                await SendEmail(pair.SecondPerson, pair.FirstPerson);
            }
        }

        public async Task<List<PairModel>> PairUpPersons()
        {
            List<PersonEntity> personEntities = await _personRepository.GetPersons();
            List<PersonModel> persons = personEntities.Select(x => _mapper.Map<PersonModel>(x)).ToList();

            persons = persons.OrderBy(x => Guid.NewGuid()).ToList();

            int count = persons.Count;
            int midpoint = count / 2;

            List<PersonModel> firstHalfPersons = persons.GetRange(0, midpoint);
            List<PersonModel> secondHalfPersons = persons.GetRange(midpoint, count - midpoint);
            List<PairModel> pairs = new();

            for(int i = 0; i < midpoint; i++)
            {
                PairModel pair = new(firstHalfPersons[i], secondHalfPersons[i], DateOnly.FromDateTime(DateTime.Now));
                pairs.Add(pair);
            }

            List<PairEntity> savedPairs = await _pairRepository.SavePairs(pairs.Select(x => _mapper.Map<PairEntity>(x)).ToList());
            _pairs = savedPairs.Select(x => _mapper.Map<PairModel>(x)).ToList();

            return _pairs;
        }

        private async Task SendEmail(PersonModel recipient, PersonModel assignedPartner)
        {

            EmailModel emailModel = new EmailModel()
            {
                SenderEmail = "vainiotux@gmail.com",
                SenderName = "Vainius",
                RecipientEmail = recipient.Email,
                RecipientName = recipient.Name,
                Subject = "Email" ,
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>" + assignedPartner.Name,
                PlainTextContent = "and easy to do anywhere, even with C# " + recipient.FacebookProfileLink
            };

            await _mailClient.SendEmail(_mapper.Map<EmailEntity>(emailModel));
        }
    }
}
