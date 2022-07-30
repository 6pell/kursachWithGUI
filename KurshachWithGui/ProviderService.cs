using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections.ObjectModel;

public class ProvidersService
{
	private List<Provider>providers = new List<Provider>();
	private const string path = "..\\..\\BaseProvider.txt";
	~ProvidersService()
	{
		Console.WriteLine("Out..");
	}

	public List<Provider> GetData() 
	{
		return providers;
	}

	public void SetData(List<Provider> data)
	{
		providers = data;
	}
	public ObservableCollection<ProviderWithID> GetDataProvider() 
	{
		ObservableCollection<ProviderWithID>data = new ObservableCollection<ProviderWithID>();
		string providerDataInString = "";
		for (int i = 0; i < providers.Count(); i++) 
		{
			providerDataInString = objInString(i);
			data.Add(new ProviderWithID(providers[i].id, providerDataInString));
		}
		return data;
	}

	public string objInString(int id)
	{
		string slesh = "/";
		string myData = providers[id].fullName + slesh +
						providers[id].number;
		return myData;
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
				string Trash = reader.ReadLine();
				providers.Add(new Provider(Id,FullName, Number));
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
					writer.WriteLine(providers[i].number + "\n");
				}
				else
				{
					writer.WriteLine(providers[i].id);
					writer.WriteLine(providers[i].fullName);
					writer.WriteLine(providers[i].number);
				}
			}
		}
	}

	public List<Provider> SearchByKey(string keyWord)
	{
		List<Provider> obj = new List<Provider>();
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

	public List<Provider> SearchByInt(int keyWord) 
	{
		List<Provider> searchCars = new List<Provider>();
		bool found = false;
		for (int i = 0; i < providers.Count(); i++)
		{
			if(providers[i].number == keyWord || providers[i].id == keyWord)
			{
				found = true;
				searchCars.Add(new Provider(providers[i].id, providers[i].fullName, providers[i].number));
			}
		}
		if (found == false)
		{
			searchCars.Add(new Provider(0, "NotFound", 0));
		}
		return searchCars;
	}

	public List<Provider> SearchByString(string keyWord)
	{
		List<Provider> searchCars = new List<Provider>();
		bool found = false;
		for (int i = 0; i < providers.Count(); i++)
		{
			if(providers[i].fullName == keyWord)
			{
				found = true;
				searchCars.Add(new Provider(providers[i].id,providers[i].fullName, providers[i].number));
			}
		}
		if (found == false)
		{
			searchCars.Add(new Provider(0,"NotFound", 0));
		}
		return searchCars;
	}
}