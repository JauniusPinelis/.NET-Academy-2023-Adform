using Infrastructure.Clients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.WebApi.Dtos;

namespace Application.Users.Queries
{
    internal record GetUsersQuery : IRequest<List<UserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IJsonPlaceholderClient _jsonPlaceholderClient;

        public GetUsersQueryHandler(IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
        }

         async Task<List<UserDto>> IRequestHandler<GetUsersQuery, List<UserDto>>.Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result =  await _jsonPlaceholderClient.GetUsers();
            return result;
        }
    }
}
