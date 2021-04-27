using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;

namespace ModularMonolith.Product.Application.Commands
{
    class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IMediator _mediator;


        public AddProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new ProductCratedEvent(request.Name, request.Description, "", DateTime.UtcNow), CancellationToken.None);
        }
    }
}
