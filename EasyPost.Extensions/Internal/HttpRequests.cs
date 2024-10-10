using Microsoft.AspNetCore.Http;

namespace EasyPost.Extensions.Internal;

public static class HttpRequests
{
    /// <summary>
    ///     Use this method to read the request body of a <see cref="HttpRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequest"/> to read the body from.</param>
    /// <returns>The request body as a byte array.</returns>
    public static async Task<byte[]> ReadRequestBody(HttpRequest request)
    {
        using MemoryStream ms = new();
        await request.Body.CopyToAsync(ms);
        var bodyData = ms.ToArray();

        return bodyData;
    }
}