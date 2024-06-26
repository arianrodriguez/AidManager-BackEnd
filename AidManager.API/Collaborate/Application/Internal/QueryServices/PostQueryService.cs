﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Model.Queries;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Collaborate.Domain.Services;

namespace AidManager.API.Collaborate.Application.Internal.QueryServices;

public class PostQueryService(IPostRepository postRepository) : IPostQueryService
{
    public async Task<IEnumerable<Post>?> Handle(GetAllPostsQuery query)
    {
        return await postRepository.GetAllPosts();
    }
    
    public async Task<Post?> Handle(GetPostById query)
    {
        return await postRepository.FindPostById(query.Id);
    }
    
    public async Task<IEnumerable<Post>?> Handle(GetAllPostsByCompanyId query)
    {
        return await postRepository.GetAllPostsByCompanyId(query.CompanyId);
    }
}