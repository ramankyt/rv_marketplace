using System;
using System.Threading.Tasks;
using Marketplace.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Marketplace.Contracts.ClassifiedAds;

namespace Marketplace.API
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi:Controller
    {
        private readonly Func<IHandleCommand<V1.Create>> _createAdCommandHandlerFactory;
        //private readonly IHandleCommand<V1.Create> _createAdCommandHandler;

        // private readonly ClassifiedAdApplicationService _applicationService;

        public ClassifiedAdsCommandsApi(Func<IHandleCommand<V1.Create>> createAdCommandHandlerFactory) 
            => _createAdCommandHandlerFactory = createAdCommandHandlerFactory;

        // public ClassifiedAdsCommandsApi(IHandleCommand<V1.Create> createAdCommandHandler) =>
        //     _createAdCommandHandler = createAdCommandHandler;


        [HttpPost]
        public Task Post(V1.Create request) 
            => _createAdCommandHandlerFactory().Handle(request);
    }
}