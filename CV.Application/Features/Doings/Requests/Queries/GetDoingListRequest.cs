using CV.Application.DTOs.Doings;
using MediatR;

namespace CV.Application.Features.Doings.Requests.Queries
{
    public class GetDoingListRequest:IRequest<List<DoingDto>>
    {
    }
}
