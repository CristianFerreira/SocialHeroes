using MediatR;
using SocialHeroes.Domain.Events;
using SocialHeroes.Domain.Interfaces.MirrorRepository;
using SocialHeroes.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.MirroringHandler
{
    public class HairMirroringHandler 
    {
        private readonly IHairMirrorRepository _hairRepository;

        public HairMirroringHandler(IHairMirrorRepository hairRepository)
        {
            _hairRepository = hairRepository;
        }

        public Task<Unit> Handle(HairRegisteredEvent request, CancellationToken cancellationToken)
        {
            var Hair = new Hair(request.Id, request.Color);
            _hairRepository.Add(Hair);

            return Unit.Task;
        }
    }
}
