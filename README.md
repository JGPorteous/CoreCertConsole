# CoreCertConsole
Playing with Certificates in .Net Core

Some of the functionality was used from https://github.com/gsoft-inc/dotnet-certificate-tool

# Testing in Linux
Install dotnet
https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-debian9

# Basic Help
C:\Source\_Play\CoreCertConsole\CoreCertConsole\bin\Debug\netcoreapp3.0>CoreCertConsole.exe help
CoreCertConsole 1.0.0
Copyright (C) 2020 CoreCertConsole

  read       Read the Certificate Store(s).

  add        Add a certificate to the Store.

  remove     Removes a certificate from the Store.

  list       List available Stores.

  help       Display more information on a specific command.

  version    Display version information.


  # Add Help
  C:\Source\_Play\CoreCertConsole\CoreCertConsole\bin\Debug\netcoreapp3.0>CoreCertConsole.exe help add
CoreCertConsole 1.0.0
Copyright (C) 2020 CoreCertConsole

  --StoreLocation    (Default: CurrentUser) StoreLocation [CurrentUser]

  --StoreName        (Default: My) StoreName [My]

  --Path             Path

  --StoreName        Base64

  --Password         Password

  --Thumbprint       Thumbprint

  --help             Display this help screen.

  --version          Display version information.

  # Remove Help
  C:\Source\_Play\CoreCertConsole\CoreCertConsole\bin\Debug\netcoreapp3.0>CoreCertConsole.exe help remove
CoreCertConsole 1.0.0
Copyright (C) 2020 CoreCertConsole

  --StoreLocation    (Default: CurrentUser) StoreLocation [CurrentUser]

  --StoreName        (Default: My) StoreName [My]

  --Path             Path

  --StoreName        Base64

  --Password         Password

  --Thumbprint       Thumbprint

  --help             Display this help screen.

  --version          Display version information.
