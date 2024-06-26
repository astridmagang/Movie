﻿using Microsoft.Extensions.Options;
using RestSharp;
using Zeta.Movie.Client.Common.Extensions;
using Zeta.Movie.Shared.Common.Requests;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoGroups.Commands.CreateToDoGroup;
using Zeta.Movie.Shared.ToDoGroups.Commands.UpdateToDoGroup;
using Zeta.Movie.Shared.ToDoGroups.Queries.GetToDoGroup;
using Zeta.Movie.Shared.ToDoGroups.Queries.GetToDoGroups;

namespace Zeta.Movie.Client.Services.BackEnd;

public class ToDoGroupService
{
    private readonly RestClient _restClient;

    public ToDoGroupService(IOptions<BackEndOptions> backEndServiceOptions)
    {
        _restClient = new RestClient($"{backEndServiceOptions.Value.BaseUrl}/ToDoGroups");
    }

    public async Task<ResponseResult<CreateToDoGroupResponse>> CreateToDoGroupAsync(CreateToDoGroupRequest request)
    {
        var restRequest = new RestRequest(string.Empty, Method.Post);
        restRequest.AddParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<CreateToDoGroupResponse>();
    }

    public async Task<ResponseResult<SuccessResponse>> UpdateToDoGroupAsync(UpdateToDoGroupRequest request)
    {
        var restRequest = new RestRequest(request.ToDoGroupId.ToString(), Method.Put);
        restRequest.AddParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<SuccessResponse>();
    }

    public async Task<ResponseResult<SuccessResponse>> DeleteToDoGroupAsync(Guid toDoGroupId)
    {
        var restRequest = new RestRequest(toDoGroupId.ToString(), Method.Delete);
        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<SuccessResponse>();
    }

    public async Task<ResponseResult<PaginatedListResponse<GetToDoGroupsToDoGroup>>> GetToDoGroupsAsync(PaginatedListRequest request)
    {
        var restRequest = new RestRequest(string.Empty, Method.Get);
        restRequest.AddQueryParameters(request);

        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<PaginatedListResponse<GetToDoGroupsToDoGroup>>();
    }

    public async Task<ResponseResult<GetToDoGroupResponse>> GetToDoGroupAsync(Guid toDoGroupId)
    {
        var restRequest = new RestRequest(toDoGroupId.ToString(), Method.Get);
        var restResponse = await _restClient.ExecuteAsync(restRequest);

        return restResponse.ToResponseResult<GetToDoGroupResponse>();
    }
}
