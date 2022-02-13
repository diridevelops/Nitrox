using System;
using System.IO;
using System.Threading.Tasks;
using NitroxModel.Helper;
using NitroxModel.Platforms.OS.Shared;
using NitroxModel.Platforms.Store.Interfaces;

namespace NitroxModel.Platforms.Store
{
    public sealed class NoSteam : IGamePlatform
    {
        private static NoSteam instance;
        public static NoSteam Instance => instance ??= new NoSteam();

        public string Name => nameof(NoSteam);

        public bool OwnsGame(string gameDirectory)
        {
            return File.Exists(Path.Combine(gameDirectory, "steam_api64.dll"));
        }

        public async Task<ProcessEx> StartPlatformAsync()
        {
            await Task.CompletedTask; // Suppresses async-without-await warning - can be removed.
            throw new NotImplementedException();
        }

        public string GetExeFile()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessEx> StartGameAsync(string pathToGameExe, string launchArguments)
        {
            return await Task.FromResult(
                ProcessEx.Start(
                    pathToGameExe,
                    new[] { (NitroxUser.LAUNCHER_PATH_ENV_KEY, NitroxUser.LauncherPath) },
                    Path.GetDirectoryName(pathToGameExe),
                    launchArguments)
                );
        }
    }
}
