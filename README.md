Original project: [https://github.com/SubnauticaNitrox/Nitrox](https://github.com/SubnauticaNitrox/Nitrox)
 
### Changes
- Unblocked mod on pirated game
- Launch pirated Steam game without looking for Steam

### Build from source
[Original wiki](https://github.com/SubnauticaNitrox/Nitrox/wiki/Setting-up-a-development-environment-for-Nitrox#development-setup)

- Install .NET SDK
- Generate DLLs<br/>
  ```
  dotnet run --project Nitrox.BuildTool
  ```
  If you get error `Argument 'installDir' must not be null.` it means you installed the game in a path the launcher is not able to automatically detect.<br/>
  You can force it to look there by setting a key in the Windows Registry:
  - Open the Registry Editor
  - Right click on `Computer\HKEY_CURRENT_USER\Software`
  - Create a new *key* named `Nitrox`
  - Inside it create a new *String Value* named `PreferredGamePath` with value the installation folder, e.g. `C:\Games\Subnautica`
- Build in **Debug** mode (in game cheats and logs enabled)<br/>
  ```
  dotnet build
  ```
- Build in **Release** mode (cheats and logs disabled)<br/>
  ```
  dotnet build --configuration Release
  ```
Run `NitroxLauncher\bin\Release\NitroxLauncher.exe` as Administrator and add Firewall exceptions if requested.
