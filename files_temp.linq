<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	FileProvider.BlockCopy(@"C:\Users\user\Desktop\source.txt", @"C:\Users\user\Desktop\drain.txt").Dump();
FileProvider.AreEqual(@"C:\Users\user\Desktop\source.txt", @"C:\Users\user\Desktop\drain.txt").Dump();

}

// Define other methods and classes here
public static class FileProvider
{
	public static int BlockCopy(string sourcePath, string drainPath)
	{
		ValidateInput(sourcePath, drainPath);
		byte[] buffer;

		using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
		{
			buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
		}

		int result;

		using (FileStream destination = new FileStream(drainPath, FileMode.OpenOrCreate, FileAccess.Write))
		{
			destination.Write(buffer, 0, buffer.Length);
			result = (int)destination.Length;
		}
		return result;
	}

	public static int MemoryStreamBlockCopy(string source, string drain)
	{
		ValidateInput(source, drain);

		byte[] buffer;
		byte[] msResult;
		int result;

		using (TextReader reader = new StreamReader(source))
		{
			buffer = Encoding.UTF8.GetBytes(reader.ReadToEnd());
		}

		using (MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length))
		{
			ms.Write(buffer, 0, buffer.Length);
			msResult = ms.ToArray();
		}

		char[] chars = Encoding.UTF8.GetChars(msResult);

		using (StreamWriter sw = new StreamWriter(drain))
		{
			sw.Write(chars);
			result = sw.Encoding.GetByteCount(chars);
		}

		return result;
	}

	public static int LinesCopy(string source, string drain){
		ValidateInput(source, drain);
		
		string[] ss = File.ReadAllLines(source);
		File.WriteAllLines(drain, ss);
		return File.ReadAllLines(drain).Length;
	}
	
	public static bool AreEqual(string file1, string file2)
	{
		if (!File.Exists(file1) || !File.Exists(file2))
		{
			throw new FileNotFoundException($"files doesn't found");
		}

		return File.ReadAllBytes(file1).SequenceEqual(File.ReadAllBytes(file2));
	}

	private static void ValidateInput(string source, string drain)
	{
		if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(drain))
		{
			throw new ArgumentNullException("path is empty");
		}

		if (!File.Exists(source))
		{
			throw new FileNotFoundException($"{(nameof(source))} doesn't found");
		}
	}
}