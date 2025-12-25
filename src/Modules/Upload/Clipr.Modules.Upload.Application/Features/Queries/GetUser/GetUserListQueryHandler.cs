using AutoMapper;
using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;
using MediatR;

namespace Clipr.Modules.Upload.Application.Features.Queries.GetUser;

//TODO: Delete this test code
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

}

public record GetUserListQuery() : IRequest<List<UserDto>>;

public record UserDto(string Username, string Email);