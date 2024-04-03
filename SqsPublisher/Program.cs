using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Name = "John",
    Email = "example@example.com",
    FullName = "John Doe",
    DateOfBirth = new DateTime(1993, 1, 1),
    GithubUserName = "johndoe",
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("Customers");

//sending the message

var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer)
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine();


