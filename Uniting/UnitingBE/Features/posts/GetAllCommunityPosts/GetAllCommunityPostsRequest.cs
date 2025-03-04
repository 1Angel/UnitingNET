using MediatR;
using UnitingBE.Common;
using UnitingBE.Dtos.Posts;
using UnitingBE.Features.Communities.GetCommunities;

namespace UnitingBE.Features.posts.GetAllCommunityPosts
{
    //public record GetAllCommunityPostsRequest(int pageNumber, int pageSize, int communityId) : IRequest<IResult>;

    public class GetAllCommunityPostsRequest : IRequest<PageResponse<List<ResponseDto<PostResponseDto>>>>
    {
        public int communityId { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }

        public string? searchTerm { get; set; }
    }
}
