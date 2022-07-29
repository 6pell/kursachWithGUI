﻿using System;

class Automobile
{
	public static int count = 0;
	public int id { get; set; }
	public string mark { get; set; }
	public string releaseYear { get; set; }
	public double engineVolume { get; set; }
	public string fuel { get; set; }
	public string type { get; set; }
	public Automobile()
	{
		id = count;
		mark = "undefinded";
		releaseYear = "undefinded";
		engineVolume = 00;
		fuel = "undefinded";
		type = "undefinded";
		count++;
	}
	public Automobile(int id, string mark, string releaseYear, double engineVolume, string fuel, string type)
	{
		this.id = id;
		this.mark = mark;
		this.releaseYear = releaseYear;
		this.engineVolume = engineVolume;
		this.fuel = fuel;
		this.type = type;
		count++;
	}
	
	~Automobile()
	{
		Console.WriteLine("Out..");
	}
}
