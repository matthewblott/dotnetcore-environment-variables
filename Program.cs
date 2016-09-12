using System;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using static System.Console;

// Also see
// "System.Runtime.Extensions": "4.1.0-*"

public class Program
{
  public static void Main(string[] args)
  {
    // Microsoft.Extensions.PlatformAbstractions
    ApplicationEnvironment env = PlatformServices.Default.Application;
    
    WriteLine("ApplicationEnvironment :");

    WriteLine($@"
      Base Path:      {env.ApplicationBasePath}
      App Name:       {env.ApplicationName}
      App Version:    {env.ApplicationVersion}
      Runtime:        {env.RuntimeFramework}");

    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);

    // Microsoft.Extensions.Configuration.EnvironmentVariables

    WriteLine("EnvironmentVariables (User) :");

    var config = new ConfigurationBuilder()
      .AddEnvironmentVariables("HOMEBREW")
      .Build();
    
    foreach(var envVar in config.GetChildren())
      WriteLine($"{envVar.Key}: {envVar.Value}");

    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);

    // EnvironmentVariables
    WriteLine("EnvironmentVariables (System) :");

    foreach(DictionaryEntry envVar in System.Environment.GetEnvironmentVariables())
      WriteLine($"{envVar.Key}: {envVar.Value}");

    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);

    // RuntimeInformation

    WriteLine("RuntimeInformation :");

    WriteLine($"FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
    WriteLine($"OSDescription: {RuntimeInformation.OSDescription}");

    WriteLine($"Is Linux: {RuntimeInformation.IsOSPlatform(OSPlatform.Linux)}");
    WriteLine($"Is OSX: {RuntimeInformation.IsOSPlatform(OSPlatform.OSX)}");
    WriteLine($"Is Windows: {RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}");

    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);
    WriteLine(Environment.NewLine);


    // EnvironmentVariables
    WriteLine("ExpandEnvironmentVariables :");
    Environment.ExpandEnvironmentVariables("$HOST");

    //IRuntimeEnvironment runtime = PlatformServices.Default.Runtime;
    // IRuntimeEnvironment:
    //         OS:             {runtime.OperatingSystem}
    //         OS Version:     {runtime.OperatingSystemVersion}
    //         Architecture:   {runtime.RuntimeArchitecture}
    //         Path:           {runtime.RuntimePath}
    //         Type:           {runtime.RuntimeType}
    //         Version:        {runtime.RuntimeVersion}

  }

}