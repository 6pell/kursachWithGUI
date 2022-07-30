using System;

public class Provider
{
	public static int count = 0;
	public int id { get; set; }
	public string fullName { get; set; }
	public long number { get; set; }
	public Provider()
	{
		id = count;
		fullName = "undefinded";
		number = 0;
		count++;
	}

	public Provider(int id, string fullName, long number) 
	{
		this.id = id;
		this.fullName = fullName;
		this.number = number;
	}
	~Provider()
	{
		Console.WriteLine("Out..");
	}
}
