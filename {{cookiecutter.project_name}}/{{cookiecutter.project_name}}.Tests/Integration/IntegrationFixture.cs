
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.Kafka;
using Testcontainers.PostgreSql;

namespace {{cookiecutter.project_name}}.Tests.Integration;
public class IntegrationFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("{{cookiecutter.project_name}}DB")
            .WithUsername("{{cookiecutter.postgres_username}}")
            .WithPassword("{{cookiecutter.postgres_password}}")
            .WithPortBinding({{cookiecutter.postgres_port}}, 5432)
            .Build();

    private readonly KafkaContainer _kafkaContainer = new KafkaBuilder()
            .WithImage("confluentinc/cp-kafka:latest")
            .WithPortBinding(9092)
            .Build();

    public WebApplicationFactory<Program>? factory;

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        await _kafkaContainer.StartAsync();
        factory = new WebApplicationFactory<Program>();
    }

    public async Task DisposeAsync()
    {
        await factory!.DisposeAsync();
        await _dbContainer.DisposeAsync();
        await _kafkaContainer.DisposeAsync();
    }
}