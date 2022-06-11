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
	public static void Main()
	{
		Console.WriteLine("Please fill the string you want convert:");
		var input = Console.ReadLine();
		var stringHandler = new StringHandler();
		Console.WriteLine(stringHandler.ConvertVerboseStringToRawString(input));
	}
}