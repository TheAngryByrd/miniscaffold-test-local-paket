# miniscaffold-test-local-paket

[Enter useful description for miniscaffold-test-local-paket]

---

## Builds

MacOS/Linux | Windows
--- | ---
[![Travis Badge](https://travis-ci.org/MyGithubUsername/miniscaffold-test-local-paket.svg?branch=master)](https://travis-ci.org/MyGithubUsername/miniscaffold-test-local-paket) | [![Build status](https://ci.appveyor.com/api/projects/status/github/MyGithubUsername/miniscaffold-test-local-paket?svg=true)](https://ci.appveyor.com/project/MyGithubUsername/miniscaffold-test-local-paket)
[![Build History](https://buildstats.info/travisci/chart/MyGithubUsername/miniscaffold-test-local-paket)](https://travis-ci.org/MyGithubUsername/miniscaffold-test-local-paket/builds) | [![Build History](https://buildstats.info/appveyor/chart/MyGithubUsername/miniscaffold-test-local-paket)](https://ci.appveyor.com/project/MyGithubUsername/miniscaffold-test-local-paket)  

## Nuget 

Stable | Prerelease
--- | ---
[![NuGet Badge](https://buildstats.info/nuget/miniscaffold-test-local-paket)](https://www.nuget.org/packages/miniscaffold-test-local-paket/) | [![NuGet Badge](https://buildstats.info/nuget/miniscaffold-test-local-paket?includePreReleases=true)](https://www.nuget.org/packages/miniscaffold-test-local-paket/)

### Developing

- [VSCode Dev Container](https://code.visualstudio.com/docs/remote/containers)

---

### Building

Make sure the following **requirements** are installed in your system:

- [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
- [Mono](http://www.mono-project.com/) if you're on Linux or macOS.

```sh
> build.cmd // on windows
$ ./build.sh  // on unix
```

#### Environment Variables

- `CONFIGURATION` will set the [configuration](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build?tabs=netcore2x#options) of the dotnet commands.  If not set it will default to Release.
  - `CONFIGURATION=Debug ./build.sh` will result in things like `dotnet build -c Debug`
- `GITHUB_TOKEN` will be used to upload release notes and nuget packages to github.
  - Be sure to set this before releasing
- `DISABLE_COVERAGE` Will disable running code coverage metrics.  AltCover can have [severe performance degradation](https://github.com/SteveGilham/altcover/issues/57) so it worth disabling when looking to do a quicker feedback loop.
  - `DISABLE_COVERAGE=1 ./build.sh`

### Watch Tests

The `WatchTests` target will use [dotnet-watch](https://github.com/aspnet/Docs/blob/master/aspnetcore/tutorials/dotnet-watch.md) to watch for changes in your lib or tests and re-run your tests on all `TargetFrameworks`

```sh
./build.sh WatchTests
```

### Releasing

- [Start a git repo with a remote](https://help.github.com/articles/adding-an-existing-project-to-github-using-the-command-line/)

```sh
git add .
git commit -m "Scaffold"
git remote add origin origin https://github.com/user/MyCoolNewLib.git
git push -u origin master
```

- [Add your nuget API key to paket](https://fsprojects.github.io/Paket/paket-config.html#Adding-a-NuGet-API-key)

```sh
paket config add-token "https://www.nuget.org" 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
```

- [Create a GitHub OAuth Token](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/)
  - You can then set the `GITHUB_TOKEN` to upload release notes and artifacts to github
  - Otherwise it will fallback to username/password

- Then update the `RELEASE_NOTES.md` with a new version, date, and release notes [ReleaseNotesHelper](https://fsharp.github.io/FAKE/apidocs/fake-releasenoteshelper.html)

```markdown
#### 0.2.0 - 2017-04-20
- FEATURE: Does cool stuff!
- BUGFIX: Fixes that silly oversight
```

- You can then use the `Release` target.  This will:
  - make a commit bumping the version:  `Bump version to 0.2.0` and add the release notes to the commit
  - publish the package to nuget
  - push a git tag

```sh
./build.sh Release
```

### Code formatting

To format code run the following target

```sh
./build.sh FormatCode
```

This uses [Fantomas](https://github.com/fsprojects/fantomas) to do code formatting.  Please report code formatting bugs to that repository.
