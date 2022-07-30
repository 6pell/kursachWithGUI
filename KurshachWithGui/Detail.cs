using System;

public class Detail
{
	public static int idCounter = 0;
	public int id_detail { get; set; }
	public int id_car { get; set; }
	public int id_provider { get; set; }
	public string country { get; set; }
	public string firm { get; set; }
	public string agregat { get; set; }
	public string vuzol { get; set; }
	public string name { get; set; }
	public double price { get; set; }
	public int count { get; set; }
	public string analogDetailIDS { get; set; }
	public Detail()
	{
		id_detail = idCounter;
		country = "undefinded";
		firm = "undefinded";
		agregat = "undefinded";
		vuzol = "undefinded";
		name = "undefinded";
		price = 0.0;
		count = 0;
		analogDetailIDS = "0,0,0";
		idCounter++;
	}

	public Detail(int id_detail, string country, string firm, int id_car, int id_provider, string agregat, string vuzol, string name, double price, int count, string analogDetailIDS) 
	{
		this.id_detail = id_detail;
		this.country = country;
		this.firm = firm;
		this.id_car = id_car;
		this.id_provider = id_provider;
		this.agregat = agregat;
		this.vuzol = vuzol;
		this.name = name;
		this.price = price;
		this.count = count;
		this.analogDetailIDS = analogDetailIDS;
		idCounter++;
	}

	~Detail() 
	{
		Console.WriteLine("Out..");
	}
}