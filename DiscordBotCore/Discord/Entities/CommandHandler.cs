using Discord.Commands;
using Discord.WebSocket;
using DiscordBotCore.Storage;
using System.Threading.Tasks;
using Discord;
using System;

namespace DiscordBotCore.Discord.Entities
{
	public class CommandHandler
	{
		public CommandHandler (IDataStorage storage, DiscordSocketClient client, CommandService commands) {
			_storage = storage;
			_client = client;
			_commands = commands;
		}

		private readonly DiscordSocketClient _client;
		private readonly IDataStorage _storage;
		private readonly CommandService _commands;
		internal async Task OnMessageReceivedAsync (SocketMessage s) {
			var msg = s as SocketUserMessage;
			if(msg == null) return;
			if(msg.Author.Id == _client.CurrentUser.Id) return;

			var context = new SocketCommandContext(_client, msg);

			var prefix = _storage.RestoreObject<string>("Config/Prefix");

			int argPos = 0;
			if(msg.HasStringPrefix(prefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)) {
				var result = await _commands.ExecuteAsync(context, argPos);

				if(!result.IsSuccess) {
					await context.Channel.SendMessageAsync(result.ToString());
				}
			} else if(msg.Content == "костя") {
				await context.Channel.SendMessageAsync("krasava");
			} else {
				await context.Channel.SendMessageAsync("pidoor");
			}
		}
	}
}
