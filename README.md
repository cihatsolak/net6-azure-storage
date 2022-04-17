# Net6 Azure Storage

## Support Statement

- We will be making only fixes related data integrity and security for 11.x.
- We will not be adding new storage service version support for this SDK. 
- We will not be back porting fixes and features added to the current version to the versions in this repo
- We will not be making any changes to the performance characteristics of this SDK.
    
We have engineered a highly performant and scalable SDK with our V12 releases. We encourage all our customers to give it a try.

# Microsoft Azure Storage SDK for .NET (11.2.3)

## Getting Started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page][] and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

Please review [Get started with Azure Storage][] if you are not familiar with Azure Storage.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes. 

- NuGet packages for [Blob][], [File][], [Queue][]
- [Azure Storage APIs for .NET][]
- Quickstart for [Blob][blob-quickstart], [File][file-quickstart], [Queue][queue-quickstart]

## Target Frameworks

- .NET Framework 4.5.2: As of September 2018, Storage Client Libraries for .NET supports primarily the desktop .NET Framework 4.5.2 release and above.
- Netstandard1.3: Storage Client Libraries for .NET are available to support Netstandard application development including Xamarin/UWP applications. 
- Netstandard2.0: Storage Client Libraries for .NET are available to support Netstandard2.0 application development including Xamarin/UWP applications. 

## Requirements

- Microsoft Azure Subscription: To call Microsoft Azure services, you need to first [create an account][]. Sign up for a free trial or use your MSDN subscriber benefits.
- Hosting: To host your .NET code in Microsoft Azure, you additionally need to download the full Microsoft Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools, or use Microsoft Azure Web Sites to deploy ASP.NET web applications.

## Versioning Information

- The Storage Client Libraries use [the semantic versioning scheme][semver]

## Use with the Azure Storage Emulator

- The Client Libraries use a particular Storage Service version. In order to use the Storage Client Libraries with the Storage Emulator, a corresponding minimum version of the Azure Storage Emulator must be used. Older versions of the Storage Emulator do not have the necessary code to successfully respond to new requests.
- Currently, the minimum version of the Azure Storage Emulator needed for this library is 5.3. If you encounter a `VersionNotSupportedByEmulator` (400 Bad Request) error, please [update the Storage Emulator.][emulator]

## Download & Install

The Storage Client Libraries ship with the Microsoft Azure SDK for .NET and also on NuGet. You'll find the latest version and hotfixes on NuGet via the `Microsoft.Azure.Storage.Blob`, `Microsoft.Azure.Storage.File`, `Microsoft.Azure.Storage.Queue`, and `Microsoft.Azure.Storage.Common` packages. 

### Via NuGet

To get the binaries of this library as distributed by Microsoft, ready for use
within your project you can also have them installed by the .NET package manager: [Blob][], [File][], [Queue][].

Please note that the minimum NuGet client version requirement has been updated to 2.12 in order to support multiple .NET Standard targets in the NuGet package.

```
Install-Package Microsoft.Azure.Storage.Blob
Install-Package Microsoft.Azure.Storage.File
Install-Package Microsoft.Azure.Storage.Queue
```

The `Microsoft.Azure.Storage.Common` package should be automatically entailed by NuGet.

## Code Samples

How-Tos focused around accomplishing specific tasks are available on the [Microsoft Azure .NET Developer Center][].

## Need Help?
Be sure to check out the [Azure Community Support][] page if you have trouble with the provided code or use StackOverflow.

# Learn More

- [Microsoft Azure .NET Developer Center][]
- [Azure Storage APIs for .NET][]
- [Azure Storage Team Blog][blog]
- [Azure Management Libraries for CRUD Storage Accounts][azure-sdk-for-net]


[contributing]: .github/CONTRIBUTING.md
[code of conduct]: https://opensource.microsoft.com/codeofconduct/
[code of conduct faq]: https://opensource.microsoft.com/codeofconduct/faq/
[opencode-email]: mailto:opencode@microsoft.com
[UserVoice forum]: http://feedback.azure.com/forums/34192--general-feedback
[blog]: https://azure.microsoft.com/en-us/blog/topics/storage-backup-and-recovery/

[Azure Storage APIs for .NET]: https://docs.microsoft.com/en-us/dotnet/api/overview/azure/storage?view=azure-dotnet
[Microsoft Azure .NET Developer Center]: http://azure.microsoft.com/en-us/develop/net/
[Azure Community Support]: http://go.microsoft.com/fwlink/?LinkId=234489
[Microsoft Azure Downloads Page]: http://azure.microsoft.com/en-us/downloads/?sdk=net
[Get started with Azure Storage]: https://docs.microsoft.com/en-us/azure/storage/storage-dotnet-how-to-use-blobs
[azure-sdk-for-net]: https://github.com/Azure/azure-sdk-for-net
[create an account]: https://account.Azure.com/Home/Index
[semver]: http://semver.org/
[emulator]: https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator

[blob-changelog]: Blob/Changelog.txt
[file-changelog]: File/Changelog.txt
[queue-changelog]: Queue/Changelog.txt

[blob-quickstart]: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
[file-quickstart]: https://docs.microsoft.com/en-us/azure/storage/files/storage-dotnet-how-to-use-files
[queue-quickstart]: https://docs.microsoft.com/en-us/azure/storage/queues/storage-dotnet-how-to-use-queues

[Blob]: https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/
[File]: https://www.nuget.org/packages/Microsoft.Azure.Storage.File/
[Queue]: https://www.nuget.org/packages/Microsoft.Azure.Storage.Queue/
[WindowsAzure.Storage]: https://www.nuget.org/packages/WindowsAzure.Storage/
[Microsoft.Azure.Cosmos.Table]: https://www.nuget.org/packages/Microsoft.Azure.Cosmos.Table

[Newtonsoft.Json]: https://www.nuget.org/packages/Newtonsoft.Json/
[IdentityModel.Clients.ActiveDirectory]: https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/
[KeyVault.Core]: https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Core/
[KeyVault.Extensions]: https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Extensions/

[FiddlerCore]: http://www.telerik.com/fiddler/fiddlercore
