using Booking.Domain.Result;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace Booking.API.Infrastructure;

public static class JsonPatch
{
    public static async Task<JsonPatchDocument<T>> GetJsonPatchDocumentAsync<T>(HttpContext context) where T : class
    {
        if (context.Request == null)
            throw new ArgumentNullException(nameof(context.Request), "Request is null.");

        if (context.Request.Body == null)
            throw new ArgumentNullException(nameof(context.Request.Body), "Request body is null.");

        if (!context.Request.HasJsonContentType())
            throw new InvalidOperationException("Content type is not application/json.");

        try
        {
            using var stream = new StreamReader(context.Request.Body);
            var stringContent = await stream.ReadToEndAsync();
            var patchDocument = JsonConvert.DeserializeObject<JsonPatchDocument<T>>(stringContent);
            return patchDocument ?? throw new JsonException("Deserialization resulted in a null JsonPatchDocument.");
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Error deserializing request body into JsonPatch document.", ex);
        }
    }
}