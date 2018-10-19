using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord
{
    public class Connection
    {
		private readonly DiscordSocketClient _client;
		private readonly DiscordLogger _logger;
		private readonly CommandHandler _handler;
		private readonly CommandService _commands;

		public Connection (DiscordLogger logger, DiscordSocketClient client, CommandHandler handler, CommandService commands) {
			_logger = logger;
			_client = client;
			_handler = handler;
			_commands = commands;
		}

		internal async Task ConnectAsync(DiscordBotConfig config) {
			_client.Log += _logger.Log;
			_client.MessageReceived += _handler.OnMessageReceivedAsync;

			await _client.LoginAsync(TokenType.Bot, config.Token);
			await _client.StartAsync();

			await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
		}
	}
}
