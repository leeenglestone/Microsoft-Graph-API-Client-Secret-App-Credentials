using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;

try
{
    var scopes = new[] { "https://graph.microsoft.com/.default" };

    var tenantId = "<Insert TenantId Here>";

    // Values from app registration in Azure Active Directory
    var clientId = "<Insert App Client Id Here>";
    var clientSecret = "<Insert App Client Secret Here>";

    var options = new TokenCredentialOptions
    {
        AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
    };

    var clientSecretCredential = new ClientSecretCredential(
        tenantId, clientId, clientSecret, options);

    var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

    // Retreive and show groups
    var groups = await graphClient.Groups.GetAsync();

    foreach (var group in groups.Value)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Group: {group.DisplayName}");

        // Retrieve and display group users
        var groupUsers = await graphClient.Groups[group.Id].Members.GraphUser.GetAsync();

        foreach (var groupUser in groupUsers.Value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"User: {groupUser.DisplayName}, ({groupUser.JobTitle})");

            // Retreive and show user calendar events
            var userEvents = await graphClient.Users[groupUser.Id].Calendar.Events.GetAsync();

            foreach (var userEvent in userEvents.Value)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Event: {userEvent.Subject} - {userEvent.Start.ToDateTime().ToString("dd/MM/yyyy HH:mm")} ({userEvent.End.ToDateTime().Subtract(userEvent.Start.ToDateTime()).TotalMinutes} minutes)");
            }

            // Retreive and show user messages
            var userMessages = await graphClient.Users[groupUser.Id].Messages.GetAsync();

            foreach (var userMessage in userMessages.Value)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Message Subject: {userMessage.Subject}");
                Console.WriteLine($"Message Body Preview: {userMessage.BodyPreview}");
            }
        }
    }
}
catch (ODataError odataError)
{
    Console.WriteLine(odataError.Error.Code);
    Console.WriteLine(odataError.Error.Message);
    throw;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}