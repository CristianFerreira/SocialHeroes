using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Repositories;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Api.Controllers
{  
    public class HairController : Controller
    {
        private readonly IHairRepository _repository;
        public HairController(IHairRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/hairs")]
        public IEnumerable<Hair> Get()
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
        public Hair Post([FromBody]Hair hair)
        {
            return null;
        }

    }
}
