using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Provider
{
	private List<ProviderFields> providers = new List<ProviderFields>();
	private string path = "..\\..\\BaseProvider.txt";
	~Provider()
	{
		Console.WriteLine("Out..");
	}

	public List<ProviderFields> GetData() 
	{
		return providers;
	}

	public void SetData(List<ProviderFields> data)
	{
		providers = data;
	}

	public void ReadDataFromFile()
	{
		using (StreamReader reader = new StreamReader(path))
		{
			do
			{
				int Id = Convert.ToInt32(reader.ReadLine());
				string FullName = reader.ReadLine();
				int Number = Convert.ToInt32(reader.ReadLine());
				string NameDetail = reader.ReadLine();
				string Trash = reader.ReadLine();
				providers.Add(new ProviderFields(Id,FullName, Number, NameDetail));
			} while (!reader.EndOfStream);
		}
	}

	public void RewriteDataFile()
	{
		System.IO.File.WriteAllText(path, string.Empty);
		using (StreamWriter writer = new StreamWriter(path))
		{
			for (int i = 0; i < providers.Count(); i++)
			{
				if (i + 1 != providers.Count())
				{
					writer.WriteLine(providers[i].id);
					writer.WriteLine(providers[i].fullName);
					writer.WriteLine(providers[i].number);
					writer.WriteLine(providers[i].nameDetail + "\n");
				}
				else
				{
					writer.WriteLine(providers[i].id);
					writer.WriteLine(providers[i].fullName);
					writer.WriteLine(providers[i].number);
					writer.WriteLine(providers[i].nameDetail);
				}
			}
		}
	}

	public List<ProviderFields> SearchByKey(string keyWord)
	{
		List<ProviderFields> obj = new List<ProviderFields>();
		if (int.TryParse(keyWord, out var number1) == true)
		{
			obj = SearchByInt(number1);
		}
		else
		{
			obj = SearchByString(keyWord);
		}
		return obj;
	}

	public List<ProviderFields> SearchByInt(int keyWord) 
	{
		List<ProviderFields> searchCars = new List<ProviderFields>();
		bool found = false;
		for (int i = 0; i < providers.Count(); i++)
		{
			if
			(
				providers[i].number == keyWord ||
				providers[i].id == keyWord
			)
			{
				found = true;
				searchCars.Add(new ProviderFields(providers[i].id, providers[i].fullName, providers[i].number, providers[i].nameDetail));
			}
		}
		if (found == false)
		{
			searchCars.Add(new ProviderFields(0, "NotFound", 0, "NotFound"));
		}
		return searchCars;
	}

	public List<ProviderFields> SearchByString(string keyWord)
	{
		List<ProviderFields> searchCars = new List<ProviderFields>();
		bool found = false;
		for (int i = 0; i < providers.Count(); i++)
		{
			if
			(
				providers[i].fullName == keyWord ||
				providers[i].nameDetail == keyWord
			)
			{
				found = true;
				searchCars.Add(new ProviderFields(providers[i].id,providers[i].fullName, providers[i].number, providers[i].nameDetail));
			}
		}
		if (found == false)
		{
			searchCars.Add(new ProviderFields(0,"NotFound", 0, "NotFound"));
		}
		return searchCars;
	}
}