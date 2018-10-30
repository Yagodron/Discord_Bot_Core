using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RandomCommands.Modules
{
	[Name("RandomCommands")]
	public class RandomCommandsModule : ModuleBase<SocketCommandContext>
	{
		[Command("say"), Alias("s")]
		[Summary("Make the bot say something")]
		[RequireUserPermission(GuildPermission.Administrator)]
		public Task Say ([Remainder]string text)
			=> ReplyAsync(text);

		[Command("roll")]
		[Summary("Make the bot say something")]
		[RequireUserPermission(GuildPermission.Administrator)]
		public Task Roll ([Remainder]string text) {
			int val = 0;
			if(Int32.TryParse(text, out val)){
				return ReplyAsync(RollCalculations(val));
			} else {
				return ReplyAsync(text + " is not a number");
			}
		}

		private string RollCalculations (int number) {
			string result = $"Rolling {number} d6 dice:" + Environment.NewLine + ":game_die: ";
			int value = 0;
			for(int i = 0; i < number; i ++) {
				Random rnd = new Random();
				int dice = rnd.Next(1, 7);
				value += dice;
				result += dice + " + ";
			}
			result = result.Substring(0, result.Length - 2) + "= " + value;
			return result;
		}
	}
}
