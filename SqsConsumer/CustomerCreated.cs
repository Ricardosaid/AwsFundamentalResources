﻿namespace SqsConsumer;

public class CustomerCreated
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string FullName{ get; set; }
    public required string Email { get; set; }
    public required string GithubUserName { get; set; }
    public required DateTime DateOfBirth { get; set; }
}
