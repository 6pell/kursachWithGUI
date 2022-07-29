using System;

public class DetailFields
{
	public static int idCounter = 0;
	public int id { get; set; }
	public int idMark { get; set; }
	public string country { get; set; }
	public string firm { get; set; }
	public string agregat { get; set; }
	public string vuzol { get; set; }
	public string detail { get; set; }
	public double price { get; set; }
	public int count { get; set; }
	public DetailFields()
	{
		id = idCounter;
		country = "undefinded";
		firm = "undefinded";
		agregat = "undefinded";
		vuzol = "undefinded";
		detail = "undefinded";
		price = 0.0;
		count = 0;
		idCounter++;
	}

	public DetailFields(int id,string country, string firm, int mark, string agregat, string vuzol, string detail, double price, int count) 
	{
		this.id = id;
		this.country = country;
		this.firm = firm;
		this.idMark = mark;
		this.agregat = agregat;
		this.vuzol = vuzol;
		this.detail = detail;
		this.price = price;
		this.count = count;
		idCounter++;
	}

	~DetailFields() 
	{
		Console.WriteLine("Out..");
	}
}