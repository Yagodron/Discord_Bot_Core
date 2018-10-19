using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Example.Modules
{
	[Name("Example")]
	public class ExampleModule : ModuleBase<SocketCommandContext>
	{
		[Command("say"), Alias("s")]
		[Summary("Make the bot say something")]
		[RequireUserPermission(GuildPermission.Administrator)]
		public Task Say ([Remainder]string text)
			=> ReplyAsync(text);
	}
}
