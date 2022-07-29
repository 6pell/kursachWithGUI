using System;

public class ProviderFields
{
	public static int count = 0;
	public int id { get; set; }
	public string fullName { get; set; }
	public long number { get; set; }
	public string nameDetail { get; set; }
	public ProviderFields()
	{
		id = count;
		fullName = "undefinded";
		number = 0;
		nameDetail = "undefinded";
		count++;
	}

	public ProviderFields(int id, string fullName, long number, string nameDetail) 
	{
		this.id = id;
		this.fullName = fullName;
		this.number = number;
		this.nameDetail = nameDetail;
	}
	~ProviderFields()
	{
		Console.WriteLine("Out..");
	}
}
