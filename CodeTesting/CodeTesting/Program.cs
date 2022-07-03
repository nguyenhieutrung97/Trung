using CodeTesting.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public interface IStringHandler
{
	string ConvertVerboseStringToRawString(string input);
}
public class StringHandler : IStringHandler
{
	public string ConvertVerboseStringToRawString(string input)
	{
		if (input[0] == input[input.Length - 1] && input[0] == '\'')
		{
			input = input.Substring(1, input.Length - 2);
		}
		return input;
	}
}
public class Program
{
	public async static Task Main(string[] args)
	{
		IHost host = Host.CreateDefaultBuilder(args)
		.ConfigureServices((_, services) =>
			services.AddSingleton<IWeaponBehavior, HammerBehavior>()
					.AddSingleton<IWeaponBehavior, SwordBehavior>()
					)
		.Build();

		await host.RunAsync();

		//Console.WriteLine("Please fill the string you want convert:");
		//var input = Console.ReadLine();
		//var stringHandler = new StringHandler();
		//Console.WriteLine(stringHandler.ConvertVerboseStringToRawString(input ?? ""));


	}
}