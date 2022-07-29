using System;

public class MarkWithID
{
	public int id;
	public string name;
	public MarkWithID()
	{
		id = 0;
		name = "undefinded";
	}
	public MarkWithID(int id, string name)
	{
		this.id = id;
		this.name = name;
		Console.WriteLine(id + " " + name);
	}
	~MarkWithID() 
	{
		Console.WriteLine("Out..");
	}
}
