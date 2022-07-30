using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class DetailsService
{
	private List<Detail> details = new List<Detail>();
	private const string path = "..\\..\\BaseDetail.txt";
	~DetailsService()
	{
		Console.WriteLine("Out..");
	}
	public List<Detail> GetData() 
	{
		return details;
	}

	public void SetData(List<Detail> data)
	{
		details = data;
	}

	public void ReadDataFromFile()
	{
		using (StreamReader reader = new StreamReader(path))
		{
			do
			{
				int NewId_detail = Convert.ToInt32(reader.ReadLine());
				string NewCountry = reader.ReadLine();
				string NewFirm = reader.ReadLine();
				int NewID_car = Convert.ToInt32(reader.ReadLine());
				int NewID_provider = Convert.ToInt32(reader.ReadLine());
				string NewAgregat = reader.ReadLine();
				string NewVuzol = reader.ReadLine();
				string NewName = reader.ReadLine();
				double NewPrice = Convert.ToDouble(reader.ReadLine());
				int NewCount = Convert.ToInt32(reader.ReadLine());
				string NewAnalogDetailIDS = reader.ReadLine();
				string Trash = reader.ReadLine();
				details.Add
				(
					new Detail
					(
						NewId_detail, NewCountry, NewFirm,
						NewID_car,NewID_provider, NewAgregat, NewVuzol,
						NewName, NewPrice, NewCount, NewAnalogDetailIDS
					)
				);
			} while (!reader.EndOfStream);
		}
	}

	public void RewriteDataFile()
	{
		System.IO.File.WriteAllText(path, string.Empty);
		using (StreamWriter writer = new StreamWriter(path))
		{
			for (int i = 0; i < details.Count(); i++)
			{
				if (i + 1 != details.Count())
				{
					writer.WriteLine(details[i].id_detail);
					writer.WriteLine(details[i].country);
					writer.WriteLine(details[i].firm);
					writer.WriteLine(details[i].id_car);
					writer.WriteLine(details[i].id_provider);
					writer.WriteLine(details[i].agregat);
					writer.WriteLine(details[i].vuzol);
					writer.WriteLine(details[i].name);
					writer.WriteLine(details[i].price);
					writer.WriteLine(details[i].count);
					writer.WriteLine(details[i].analogDetailIDS + "\n");
				}
				else
				{
					writer.WriteLine(details[i].id_detail);
					writer.WriteLine(details[i].country);
					writer.WriteLine(details[i].firm);
					writer.WriteLine(details[i].id_car);
					writer.WriteLine(details[i].id_provider);
					writer.WriteLine(details[i].agregat);
					writer.WriteLine(details[i].vuzol);
					writer.WriteLine(details[i].name);
					writer.WriteLine(details[i].price);
					writer.WriteLine(details[i].count);
					writer.WriteLine(details[i].analogDetailIDS);
				}
			}
		}
	}
	public List<Detail> SearchByKey(string keyWord)
	{
		List<Detail> obj = new List<Detail>();
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

	public List<Detail> SearchByInt(int keyWord)
	{
		List<Detail> searchDetails = new List<Detail>();
		bool found = false;
		for (int i = 0; i < details.Count(); i++)
		{
			if
			(details[i].id_detail == keyWord)
			{
				found = true;
				searchDetails.Add
				(
					new Detail
					(
						details[i].id_detail, details[i].country, details[i].firm,
						details[i].id_car, details[i].id_provider, details[i].agregat, details[i].vuzol,
						details[i].name, details[i].price, details[i].count, details[i].analogDetailIDS
					)
				);
			}
		}
		if (found == false)
		{
			searchDetails.Add
			(
				new Detail
				(
					0, "NotFound", "NotFound",
					0, 0, "NotFound", "NotFound",
					"NotFound", 0.0, 0, "0,0,0"
				)
			);
		}
		return searchDetails;
	}

	public List<Detail> SearchByString(string keyWord)
	{
		List<Detail> searchDetails = new List<Detail>();
		bool found = false;
		for (int i = 0; i < details.Count(); i++)
		{
			if
			(
				details[i].country == keyWord ||
				details[i].firm == keyWord ||
				details[i].agregat == keyWord ||
				details[i].vuzol == keyWord ||
				details[i].name == keyWord
			)
			{
				found = true;
				searchDetails.Add
				(
					new Detail
					(
						details[i].id_detail, details[i].country, details[i].firm,
						details[i].id_car,details[i].id_provider, details[i].agregat, details[i].vuzol,
						details[i].name, details[i].price, details[i].count, details[i].analogDetailIDS
					)
				);
			}
		}
		if (found == false)
		{
			searchDetails.Add
			(
				new Detail
				(
					0, "NotFound", "NotFound",
					0, 0, "NotFound", "NotFound",
					"NotFound", 0.0, 0, "0,0,0"
				)
			);
		}
		return searchDetails;
	}
}
