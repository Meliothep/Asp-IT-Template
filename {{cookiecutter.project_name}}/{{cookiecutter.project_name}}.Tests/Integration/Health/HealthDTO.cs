
namespace {{cookiecutter.project_name}}.Tests.Integration.Health;

public class Data
{
}

public class Entries
{
    public Kafka? kafka { get; set; }
}

public class Kafka
{
    public Data? data { get; set; }
    public string? duration { get; set; }
    public string? status { get; set; }
    public List<object>? tags { get; set; }
}

public class HealthDTO
{
    public string? status { get; set; }
    public string? totalDuration { get; set; }
    public Entries? entries { get; set; }
}

