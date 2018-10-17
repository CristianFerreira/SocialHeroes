using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.DonatorContext.Commands.HairCommands.Inputs;
using SocialHeroes.Domain.DonatorContext.Handlers.HairHandlers;
using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Queries;
using SocialHeroes.Domain.DonatorContext.Repositories;
using SocialHeroes.Shared.Commands;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Api.Controllers
{  
    public class HairController : Controller
    {
        private readonly IHairRepository _repository;
        private readonly HairHandler _handler;

        public HairController(IHairRepository repository, HairHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/hairs")]
        public IEnumerable<ListHairQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/hairs/{id}")]
        public Hair GetById(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("v1/hairs")]
        public ICommandResult Post([FromBody]RegisterNewHairCommand command)
        {
            return _handler.Handle(command);
        }

    }
}
