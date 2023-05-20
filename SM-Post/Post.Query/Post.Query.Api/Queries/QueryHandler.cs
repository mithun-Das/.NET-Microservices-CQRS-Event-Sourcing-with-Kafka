﻿using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;


namespace Post.Query.Api.Queries
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IPostRepository _postRepository;

        public QueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostEntity>> HandleAsync(FindAllPostsQuery query)
        {
            return await this._postRepository.ListAllAsync();
        }

        public async Task<List<PostEntity>> HandleAsync(FindPostByIdQuery query)
        {
            var post = await this._postRepository.GetByIdAsync(query.Id);
            return new List<PostEntity> { post };
        }

        public async Task<List<PostEntity>> HandleAsync(FindPostsByAuthorQuery query)
        {
            return await this._postRepository.ListByAuthorAsync(query.Author);
        }

        public async Task<List<PostEntity>> HandleAsync(FindPostsWithCommentsQuery query)
        {
            return await this._postRepository.ListWithCommentsAsync();
        }

        public async Task<List<PostEntity>> HandleAsync(FindPostsWithLikesQuery query)
        {
            return await this._postRepository.ListWithLikesAsync(query.NumberOfLikes);
        }
    }
}
