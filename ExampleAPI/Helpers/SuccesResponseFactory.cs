using System.Diagnostics;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ExampleWebAPI.Helpers
{
    public class SuccesResponseFactory
    {

        public SucessResponse CreateResponse(StateExecution stateExecution)
        {

            return new SucessResponse(stateExecution.MessageState.Description,
                                       stateExecution.MessageState.Detail,
                                       StatusCode.GetStatusCode(stateExecution.StateType));

        }

        public SucessResponse<T> CreateResponse<T>(StateExecution<T> stateExecution) where T : class
        {
            return new SucessResponse<T>(
                                      stateExecution.MessageState.Description,
                                      stateExecution.MessageState.Detail,
                                      StatusCode.GetStatusCode(stateExecution.StateType),
                                      stateExecution.Data);

        }
    }
}
