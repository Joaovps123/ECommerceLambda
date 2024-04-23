using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApproveOrderLambda
{
    public class Function
    {
        public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            foreach (var message in input.Records)
            {
                await ProcessMessages(message, context);
            }
        }

        private async Task ProcessMessages(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.Log("Message processed");
            context.Logger.Log(message.Body);

            await Task.CompletedTask;
        }
    }
}