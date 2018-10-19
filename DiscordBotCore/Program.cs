using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
	internal class Program
    {
        private static async Task Main()
        {
			Unity.RegisterTypes();
			Console.WriteLine("Hello, Discord!");

			var storage = Unity.Resolve<IDataStorage>();

			var connection = Unity.Resolve<Connection>();
			await connection.ConnectAsync(new DiscordBotConfig {
				Token = storage.RestoreObject<string>("Config/BotToken")
			});
		}
    }
}
