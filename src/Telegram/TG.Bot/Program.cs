﻿using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TG.Bot.TelegramApi;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TG.Bot.Intagrations;
using TG.Bot.Contracts;
using TG.Bot.Common.FiniteStateMachine;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        var token = hostContext.Configuration.GetValue<string>("BotSettings:Token")!;

        services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(
                token: token));
        services.ConfigureIntergrations(hostContext.Configuration);
        services.ConfigureTelegramApi(hostContext.Configuration);

        var botService = services
            .BuildServiceProvider()
            .GetRequiredService<BotService>();

        botService.SetBotCommandsAsync();
        botService.StartBot();
    });

builder.ConfigureAppConfiguration(conf =>
{
    conf.AddJsonFile("appsettings.json", optional: false, true)
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
        .AddEnvironmentVariables();
});

var app = builder.Build();

await app.RunAsync();
