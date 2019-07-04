# EasyCertInstall
A C# console program that makes it easy to install certificates for sideloaded UWP apps.

## Where to get the program:
You can get the program from here: [EasyCertInstall Releases](https://github.com/colinkiama/EasyCertInstall/releases)

## How to use the program:
### 1. Using Windows Explorer:
Start "EasyCertInstall.exe" in the directory where the certificate or signed app package with the certificate you want to install is located. The app will try to install a certificate file (.cer), that is located in the currently opened folder. If no certificate files are in the current folder, it will look for a signed .appxbundle file then as a last resort, it will look for a signed .appx file before giving up.

### 2. Using a command line program (e.g Command Prompt):
You can run the app with a path to a directory or file as a parameter.
For example:
```
C:\>EasyCertInsall.exe [App Package Path]
```
Usage Examples: 

```
//Program will install the "MyAppCert" certificate
C:\>EasyCertInsall.exe C:\Certs\MyAppCert.cer

// MyApp.appxbundle is located in the "C:\AppPkg". There is no certificate file (.cer) there.
// This will install the certificate from "MyApp.appxbundle"
C:\>EasyCertInsall.exe C:\AppPkg


```


### For heavy command line users:
You can follow this tutorial to add the folder where this progam is contained to the Path environment variable: https://helpdeskgeek.com/windows-10/add-windows-path-environment-variable/

After you do this, you'll be able to simply use "EasyCertInstall" from anywhere in the command line!

## Roadmap:
- [x] Installing certificates from certificate files
- [x] Installing certificates from the signed package
- [x] Installing certificates from from path passed in as an argument.

