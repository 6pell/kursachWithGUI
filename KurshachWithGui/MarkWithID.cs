﻿using System;

public class MarkWithID
{
	public int id { get; set; }
	public string name { get; set; }
	public MarkWithID()
	{
		id = 0;
		name = "undefinded";
	}
	public MarkWithID(int id, string name)
	{
		this.id = id;
		this.name = name;
	}
	~MarkWithID() 
	{
		Console.WriteLine("Out..");
	}
}
