namespace LaFermeWeb.Helper;

public static class FileHelper
{
	public static async Task<string> ReadFormFileAsync(IFormFile file)
	{
		if (file == null || file.Length == 0)
		{
			return await Task.FromResult((string)null);
		}

		using (var reader = new StreamReader(file.OpenReadStream()))
		{
			return await reader.ReadToEndAsync();
		}
	}
}
