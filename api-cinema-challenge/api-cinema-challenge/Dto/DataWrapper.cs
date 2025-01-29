using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace cinema.Dto;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    success,
    notFound,
}

public class DataWrapper<T>
{
    public Status Status { get; set; }
    public T Data { get; set; }

    public DataWrapper() { }

    public DataWrapper(T data)
    {
        Status = Status.success;
        Data = data;
    }
}
