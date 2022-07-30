using System;

public class ProviderWithID
{
	public int id { get; set; }
	public string name { get; set; }
	public ProviderWithID()
	{
		id = 0;
		name = "undefinded";
	}
	public ProviderWithID(int id, string name)
	{
		this.id = id;
		this.name = name;
	}
	~ProviderWithID()
		{
		Console.WriteLine("Out..");
	}
}
