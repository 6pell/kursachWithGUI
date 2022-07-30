using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections.ObjectModel;

class CarsService
{
    private List<Car> cars = new List<Car>();
	private const string path = "..\\..\\BaseCar.txt";
	~CarsService()
	{
		Console.WriteLine("Out..");
	}

	public List<Car> GetData() 
	{
		return cars;
	}

	public void SetData(List<Car>data) 
	{
		cars = data;
	}

	public ObservableCollection<MarkWithID> GetDataMark()
	{
		ObservableCollection<MarkWithID> data = new ObservableCollection<MarkWithID>();
		string carDataInString = "";
		for (int i = 0; i < cars.Count(); i++) 
		{
			carDataInString = objInString(i);
			data.Add(new MarkWithID(cars[i].id, carDataInString));
		}
		return new ObservableCollection<MarkWithID>();
	}

	public string objInString(int id) 
	{
		string slesh = "/";
		string myData = cars[id].mark + slesh + 
						cars[id].releaseYear + slesh + 
						cars[id].engineVolume.ToString() + slesh +
						cars[id].fuel + slesh +
						cars[id].type;
		return myData;
	}
	public void ReadDataFromFile() 
	{
		using (StreamReader reader = new StreamReader(path))
		{
			do
			{
				int NewId = Convert.ToInt32(reader.ReadLine());
                string NewMark = reader.ReadLine();
                string NewReleaseYear = reader.ReadLine();
                double NewEngineVolume = Convert.ToDouble(reader.ReadLine());
                string NewFuel = reader.ReadLine();
                string NewType = reader.ReadLine();
                string Trash = reader.ReadLine();
                cars.Add(new Car(NewId, NewMark, NewReleaseYear, NewEngineVolume, NewFuel, NewType));
			} while (!reader.EndOfStream);
		}
	}

	public void RewriteDataFile()
	{
		System.IO.File.WriteAllText(path, string.Empty);
		using (StreamWriter writer = new StreamWriter(path))
		{
			for(int i = 0; i < cars.Count(); i++) 
			{
				if (i + 1 != cars.Count())
				{
					writer.WriteLine(cars[i].id);
                    writer.WriteLine(cars[i].mark);
					writer.WriteLine(cars[i].releaseYear);
					writer.WriteLine(cars[i].engineVolume);
					writer.WriteLine(cars[i].fuel);
					writer.WriteLine(cars[i].type + "\n");
				}
				else 
				{
					writer.WriteLine(cars[i].id);
					writer.WriteLine(cars[i].mark);
					writer.WriteLine(cars[i].releaseYear);
					writer.WriteLine(cars[i].engineVolume);
					writer.WriteLine(cars[i].fuel);
					writer.WriteLine(cars[i].type);
				}
			}
		}
	}

	public List<Car> SearchByKey(string keyWord) 
	{
		List<Car> obj = new List<Car>();
		if (int.TryParse(keyWord, out var number1) == true)
		{
			obj = SearchByInt(number1);
		}
		else if (double.TryParse(keyWord, out var number2) == true)
		{
			obj = SearchByDouble(number2);
		}
		else 
		{
			obj = SearchByString(keyWord);
		}
		return obj;
	}

	public List<Car> SearchByDouble(double keyWord)
	{
		List<Car> searchCars = new List<Car>();
		bool found = false;

		for (int i = 0; i < cars.Count(); i++)
		{
			if (cars[i].engineVolume == keyWord)
			{
				found = true;
				searchCars.Add(new Car(cars[i].id, cars[i].mark, cars[i].releaseYear, cars[i].engineVolume, cars[i].fuel, cars[i].type));
			}

		}
		if (found == false)
		{
			searchCars.Add(new Car(0, "NotFound", "NotFound", 0, "NotFound", "NotFound"));
		}
		return searchCars;
	}

	public List<Car> SearchByInt(int keyWord) 
	{
		List<Car> searchCars = new List<Car>();
		bool found = false;

		for (int i = 0; i < cars.Count(); i++) 
		{
			if (cars[i].id == keyWord || Convert.ToInt32(cars[i].releaseYear) == keyWord)
			{
				found = true;
				searchCars.Add(new Car(cars[i].id, cars[i].mark, cars[i].releaseYear, cars[i].engineVolume, cars[i].fuel, cars[i].type));
			}
			
		}
		if (found == false)
		{
			searchCars.Add(new Car(0, "NotFound", "NotFound", 0, "NotFound", "NotFound"));
		}
		return searchCars;
	}

	public List<Car> SearchByString(string keyWord) 
	{
		List<Car> searchCars = new List<Car>();
		bool found = false;
		for(int i = 0;i < cars.Count(); i++)
		{
			if
			(
				cars[i].mark == keyWord ||
				cars[i].type == keyWord ||
				cars[i].fuel == keyWord
			)
			{
				found = true;
				searchCars.Add(new Car(cars[i].id, cars[i].mark, cars[i].releaseYear, cars[i].engineVolume, cars[i].fuel, cars[i].type));
			}
		}
		if (found == false)
		{
			searchCars.Add(new Car(0,"NotFound", "NotFound", 0, "NotFound", "NotFound"));
		}
		return searchCars;
	}
}