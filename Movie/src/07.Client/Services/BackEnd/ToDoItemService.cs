﻿using Microsoft.Extensions.Options;
using RestSharp;
using Zeta.Movie.Client.Common.Extensions;
using Zeta.Movie.Shared.Common.Requests;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoItems.Commands.CreateToDoItem;
using Zeta.Movie.Shared.ToDoItems.Commands.UpdateToDoItem;
using Zeta.Movie.Shared.ToDoItems.Commands.UpdateToDoItemStatus;
using Zeta.Movie.Shared.ToDoItems.Queries.GetToDoItem;
using Zeta.Movie.Shared.ToDoItems.Queries.GetToDoItemsByToDoGroupId;

namespace Zeta.Movie.Client.Services.BackEnd;

public class ToDoItemService
{
    private readonly RestClient _restClient;

    public ToDoItemService(IOptions<BackEndOptions> backEndServiceOptions)
    {
        _restClient = new RestClient($"{backEndServiceOptions.Value.BaseUrl}/ToDoItems");
    }

    public async Task<ResponseResult<CreateToDoItemResponse>> CreateToDoItemAsync(CreateToDoItemRequest request)
    {
        var restRequest = new RestRequest(string.Empty, Method.Post);
        restRequest.AddParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<CreateToDoItemResponse>();
    }

    public async Task<ResponseResult<SuccessResponse>> UpdateToDoItemAsync(UpdateToDoItemRequest request)
    {
        var restRequest = new RestRequest(request.ToDoItemId.ToString(), Method.Put);
        restRequest.AddParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<SuccessResponse>();
    }

    public async Task<ResponseResult<SuccessResponse>> UpdateToDoItemStatusAsync(UpdateToDoItemStatusRequest request)
    {
        var restRequest = new RestRequest($"Status/{request.ToDoItemId}", Method.Put);
        restRequest.AddParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<SuccessResponse>();
    }

    public async Task<ResponseResult<SuccessResponse>> DeleteToDoItemAsync(Guid toDoItemId)
    {
        var restRequest = new RestRequest(toDoItemId.ToString(), Method.Delete);
        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<SuccessResponse>();
    }

    public async Task<ResponseResult<PaginatedListResponse<GetToDoItemsByToDoGroupIdToDoItem>>> GetToDoItemsByToDoGroupIdAsync(Guid toDoGroupId, PaginatedListRequest request)
    {
        var restRequest = new RestRequest($"ByToDoGroupId/{toDoGroupId}", Method.Get);
        restRequest.AddQueryParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<PaginatedListResponse<GetToDoItemsByToDoGroupIdToDoItem>>();
    }

    public async Task<ResponseResult<GetToDoItemResponse>> GetToDoItemAsync(Guid toDoItemId)
    {
        var restRequest = new RestRequest(toDoItemId.ToString(), Method.Get);
        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<GetToDoItemResponse>();
    }
}
