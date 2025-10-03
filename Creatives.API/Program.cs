using Amazon.S3;
using Amazon.S3.Model;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args: args);

WebApplication app = builder.Build();

app.MapGet(pattern: "/generate-upload-url", handler: async () =>
{
    string accessKey = "SUA_ACCESS_KEY";
    string secretKey = "SUA_SECRET_KEY";
    string spaceName = "meus-arquivos";
    string endpoint = "nyc3.digitaloceanspaces.com";

    AmazonS3Config config = new AmazonS3Config
    {
        ServiceURL = $"https://{endpoint}",
        ForcePathStyle = true
    };

    using AmazonS3Client client = new AmazonS3Client(awsAccessKeyId: accessKey, awsSecretAccessKey: secretKey, clientConfig: config);

    GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
    {
        BucketName = spaceName,
        Key = $"imagens/{Guid.NewGuid()}.png",
        Verb = HttpVerb.PUT,
        Expires = DateTime.UtcNow.AddMinutes(value: 10),
        ContentType = "image/png"
    };

    string? url = client.GetPreSignedURL(request: request);

    return Results.Ok(value: new { uploadUrl = url });
});

app.Run();