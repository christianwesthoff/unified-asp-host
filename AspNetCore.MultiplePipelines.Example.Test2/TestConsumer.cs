using System.Threading.Tasks;
using AspNetCore.MultiplePipelines.Example.Events;
using AspNetCore.MultiplePipelines.Extensions;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AspNetCore.MultiplePipelines.Example.Test2
{
    public class TestConsumer: IConsumer<Test>
    {
        private readonly ILogger<TestConsumer> _logger;
        private readonly IPipelineIdentity _identity;

        public TestConsumer(ILogger<TestConsumer> logger, IPipelineIdentity identity)
        {
            _logger = logger;
            _identity = identity;
        }
        
        public async Task Consume(ConsumeContext<Test> context)
        {
            _logger.LogInformation($"[{_identity.Name}] {context.Message.Content}");
            await Task.CompletedTask;
        }
    }
}