using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Detail
{
	private List<DetailFields> details = new List<DetailFields>();
	private const string path = "..\\..\\BaseDetail.txt";
	~Detail()
	{
		Console.WriteLine("Out..");
	}
	public List<DetailFields> GetData() 
	{
		return details;
	}

	public void SetData(List<DetailFields> data)
	{
		details = data;
	}

	public void ReadDataFromFile()
	{
		using (StreamReader reader = new StreamReader(path))
		{
			do
			{
				int NewId = Convert.ToInt32(reader.ReadLine());
				string NewCountry = reader.ReadLine();
				string NewFirm = reader.ReadLine();
				int NewIdMark = Convert.ToInt32(reader.ReadLine());
				string NewAgregat = reader.ReadLine();
				string NewVuzol = reader.ReadLine();
				string NewDetail = reader.ReadLine();
				double NewPrice = Convert.ToDouble(reader.ReadLine());
				int NewCount = Convert.ToInt32(reader.ReadLine());
				string Trash = reader.ReadLine();
				details.Add
				(
					new DetailFields
					(
						NewId, NewCountry, NewFirm, 
						NewIdMark, NewAgregat, NewVuzol, 
						NewDetail, NewPrice, NewCount
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
					writer.WriteLine(details[i].id);
					writer.WriteLine(details[i].country);
					writer.WriteLine(details[i].firm);
					writer.WriteLine(details[i].idMark);
					writer.WriteLine(details[i].agregat);
					writer.WriteLine(details[i].vuzol);
					writer.WriteLine(details[i].detail);
					writer.WriteLine(details[i].price);
					writer.WriteLine(details[i].count + "\n");
				}
				else
				{
					writer.WriteLine(details[i].id);
					writer.WriteLine(details[i].country);
					writer.WriteLine(details[i].firm);
					writer.WriteLine(details[i].idMark);
					writer.WriteLine(details[i].agregat);
					writer.WriteLine(details[i].vuzol);
					writer.WriteLine(details[i].detail);
					writer.WriteLine(details[i].price);
					writer.WriteLine(details[i].count);
				}
			}
		}
	}
	public List<DetailFields> SearchByKey(string keyWord)
	{
		List<DetailFields> obj = new List<DetailFields>();
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

	public List<DetailFields> SearchByInt(int keyWord)
	{
		List<DetailFields> searchDetails = new List<DetailFields>();
		bool found = false;
		for (int i = 0; i < details.Count(); i++)
		{
			if
			(details[i].id == keyWord)
			{
				found = true;
				searchDetails.Add
				(
					new DetailFields
					(
						details[i].id, details[i].country, details[i].firm, 
						details[i].idMark, details[i].agregat, details[i].vuzol, 
						details[i].detail, details[i].price, details[i].count
					)
				);
			}
		}
		if (found == false)
		{
			searchDetails.Add
			(
				new DetailFields
				(
					0, "NotFound", "NotFound", 
					0, "NotFound", "NotFound", 
					"NotFound", 0.0, 0
				)
			);
		}
		return searchDetails;
	}

	public List<DetailFields> SearchByString(string keyWord)
	{
		List<DetailFields> searchDetails = new List<DetailFields>();
		bool found = false;
		for (int i = 0; i < details.Count(); i++)
		{
			if
			(
				details[i].country == keyWord ||
				details[i].firm == keyWord ||
				details[i].agregat == keyWord ||
				details[i].vuzol == keyWord ||
				details[i].detail == keyWord
			)
			{
				found = true;
				searchDetails.Add
				(
					new DetailFields
					(
						details[i].id, details[i].country, details[i].firm,
						details[i].idMark, details[i].agregat, details[i].vuzol,
						details[i].detail, details[i].price, details[i].count
					)
				);
			}
		}
		if (found == false)
		{
			searchDetails.Add
			(
				new DetailFields
				(
					0, "NotFound", "NotFound",
					0, "NotFound", "NotFound",
					"NotFound", 0.0, 0
				)
			);
		}
		return searchDetails;
	}
}
