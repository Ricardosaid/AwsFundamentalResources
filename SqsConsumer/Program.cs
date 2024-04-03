using Amazon.SQS;
using Amazon.SQS.Model;

var cts = new CancellationTokenSource();
var sqsClient = new AmazonSQSClient();

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("Customers");

var receiveMessageRequest = new ReceiveMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl
};

while (!cts.IsCancellationRequested)
{
    var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest,cts.Token);

    foreach (var message in response.Messages)
    {
        Console.WriteLine($"MessageId: {message.MessageId}");
        Console.WriteLine($"ReceiptHandle: {message.ReceiptHandle}");
        Console.WriteLine($"Body: {message.Body}");
        await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, cts.Token);
    }
    await Task.Delay(3000);
    
}