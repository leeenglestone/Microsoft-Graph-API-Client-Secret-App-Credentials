# Microsoft Graph API Access Client Using App Secret Credentials
**Calling the Microsoft Graph API from C# using ClientSecret App credentials.**

Whilst there are a lot of examples of C# code to call the Microsoft Graph API using delegated access (where the user is prompted to enter their username and passport via a browser), I couldn't find that many examples of how to call he Microsoft Graph API from C# without needing to supply credentials in this manner.

This sample shows how to call the Mictosoft Graph API in C# by providing a Client App Id and Client Secret created in Azure Active Directory

## Microsoft GraphAPI Hackathon & Inspiration
I started looking at the Microsoft Graph API because of the [Hack Together: Microsoft graph & API Hackathon](https://github.com/microsoft/hack-together/)

This code is based off some of the example code to be found in the repo for that hackathon.

## Running the code
In order to run the code you will have to create an App in Azure Active Directory, provide it with appropriate permissions (depending on what information you want to retrieve from the Graph API - Calenders, Groups etc) and make note of the `TenantId`, `App Client Id` and `App Client Secret`.

You'll then need to insert these into the code in `Program.cs` in order to authenticate


## Useful links
This documentation provides the basics regarding using client app credentials to make calls to Microsoft Graph

- https://learn.microsoft.com/fi-fi/graph/sdks/choose-authentication-providers?tabs=CS#client-credentials-provider

This post on StackOverflow was particularly useful as it helped overcome some permission issues I was having
- https://stackoverflow.com/questions/74775906/some-methods-in-graphserviceclient-not-available-microsoft-graph