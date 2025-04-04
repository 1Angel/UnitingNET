﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;
using UnitingBE.Common;
using UnitingBE.Dtos.Posts;
using UnitingBE.Dtos.Auth;

namespace UnitingBE.Features.posts.GetAllCommunityPosts
{
    public class GetAllCommunityPostsHandler : IRequestHandler<GetAllCommunityPostsRequest, PageResponse<List<ResponseDto<PostResponseDto>>>>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUser _currentUser;
        public GetAllCommunityPostsHandler(AppDBContext context, IMapper mapper, CurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<PageResponse<List<ResponseDto<PostResponseDto>>>> Handle(GetAllCommunityPostsRequest request, CancellationToken cancellationToken)
        {
            var queryable = _context.posts.AsQueryable();

            //if (!String.IsNullOrEmpty(request.searchTerm))
            //{
            //    queryable = await queryable.Where(x=>x.description.Contains(request.searchTerm)).ToListAsync();
            //}

            var posts = await queryable
                .Where(x => x.CommunityId == request.communityId)
                .Select(x => new ResponseDto<PostResponseDto>
                {
                    PostInfo = new PostResponseDto
                    {
                        Id = x.Id,
                        description = x.description,
                        createdDate = x.createdDate,
                        user = new UserDto
                        {
                            Id = x.user.Id,
                            Email = x.user.Email,
                            userName = x.user.UserName,
                        },
                        
                    },
                    userCreated = x.AppUserId == _currentUser.GetUserId(),
                    TotalFavorites = x.favorites.Count(),
                    TotalBookmarks = x.bookmarks.Count(),
                    TotalComments = x.comments.Count(),
                })
                .Skip((request.pageNumber - 1) * request.pageSize)
                .Take(request.pageSize)
                .OrderByDescending(x=>x.PostInfo.createdDate)
                .ToListAsync();

            var totalCount =  await queryable.CountAsync();

            return new PageResponse<List<ResponseDto<PostResponseDto>>>(request.pageNumber,
                                                                  request.pageSize,
                                                                  totalCount,
                                                                  posts);

        }
    }
}
