/*C# experiment where an list generated based on external file can be filtered/items removed based on user inputs.
Code is written purely with Notepad++ only. C# kokeilu jossa ulkoisesta tiedostosta muodostettua listaa voidaan 
siistiä/filteröidä käyttäjän syötteen mukaisesti. Koodi on kirjoitettu puhtaasti pelkällä Notepad++ sovelluksella.*/

/*Also a small touch on so-called "ninja" coding with variable names.
Samalla myös pieni kosketus "ninja" koodailuun muuttuja nimien kanssa.*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class ListExperiment1
{
	static void Main()
	{		
		//We'll place the code within try-catch structure. Koodi kirjoitetaan try-catch rakenteen sisään.
		try
		{
			List<string> itm = new List<string>();
			
			fillList(itm);
			
			Console.WriteLine("List contains the following;");
			Console.WriteLine("");
			displayList(itm);
			Console.WriteLine("");
			
			holdOn();
			
			//We'll ask if the user wants to filter the list. Kysymme haluaako käyttäjä filtteröidä listaa.
			Console.WriteLine("Do you wish to filter the list? (y/n)");
			string ans = Console.ReadLine();
			Console.WriteLine("");
			
			if(ans.Equals("y"))
			{
				//number variables to contain the inputs. Numeromuuttujia säilömään käyttäjän syötteet
				int fiVa;
				int rne;
				
				Console.Write("Input the index of the entry that serves as starting point: ");
				string val = Console.ReadLine();
				fiVa = Convert.ToInt32(val);
				Console.WriteLine("");
				
				Console.Write("Input the range/amount entries you wish to remove (including the starting point): ");
				string val2 = Console.ReadLine();
				rne = Convert.ToInt32(val2);
				Console.WriteLine("");
				
				holdOn();
				
				//Removing items from list based on earlier inputs. Listasisältöä poistetaan aiemppiin syötteisiin pohjautuen.
				itm.RemoveRange(fiVa, rne); 
				
				Console.WriteLine("Here's the list after filtering: ");
				Console.WriteLine("");
				displayList(itm);
				
				holdOn();
			}
			else if(ans.Equals("n"))
			{
				Console.WriteLine("Thank you for using this application.");
				holdOn();
			}
			
			
		}
		catch (Exception u)
		{
			Console.WriteLine(u.Message);
		}
		
				
	}
	
	
	/*Function to fill the list variable with external file and StreamReader.
	Funktio listan täyttämiseen ulkoisen tiedoston ja StreamReaderin avulla.*/
	static void fillList(List<string> lt)
	{
		using (StreamReader rar = new StreamReader("testTextLines.txt"))
		{
			string le;
			
			while((le = rar.ReadLine())!= null)
			{
				lt.Add(le);
			}
		}
	}
	
	/*Small function to display the list. Pieni funktio listan näyttämiseen.*/
	static void displayList(List<string> lst)
	{
		foreach (string lne in lst)
		{
			Console.WriteLine(lne);
		}
	}
	
	//Small function for pausing. Pieni funktio paussittamista varten.
	static void holdOn()
	{
		Random rnd = new Random();
		
		Thread.Sleep(rnd.Next(60, 160));
	}
}