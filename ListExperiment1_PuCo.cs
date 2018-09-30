/*C# experiment where an list generated based on external file can be filtered/items removed based on user inputs.
Code is written purely with Notepad++ only. C# kokeilu jossa ulkoisesta tiedostosta muodostettua listaa voidaan 
siistiä/filteröidä käyttäjän syötteen mukaisesti. Koodi on kirjoitettu puhtaasti pelkällä Notepad++ sovelluksella.*/

/*Also a small touch on so-called "ninja" coding with variable names.
Samalla myös pieni kosketus "ninja" koodailuun muuttuja nimien kanssa.*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Ling;
using System.Text;

class ListExperiment1
{
	static void Main()
	{		
		//We'll place the code within try-catch structure. Koodi kirjoitetaan try-catch rakenteen sisään.
		try
		{
			List<string> itm = new List<string>();
			
			fillList(itm);
			
			Console.Write("List contains the following;");
			displayList(itm);
			
			//Variables to strore user inputs. Muuttujat joihin tallennamme käyttäjän syötteet.
			int staInd;
			int rne;
			
			userInputs(staInd, rne);
			
			itm.RemoveRange(staInd, rne);
			
		}
		catch (Exception u)
		{
			Console.WriteLine(u.Message);
		}
		
				
	}
	
	/*Function containing the steps involving user inputs. Funktio joka pitää sisällään käyttäjän
	syötteiden käsittelyyn keskittyneet toiminnot.*/
	static void userInputs(int j, int k)
	{
		Console.WriteLine("Do you wish to filter/clean the list? (y/n)");
		string ans = Console.ReadLine();
		
		if(ans.Equals("y"))
		{
			Console.Write("Enter the number of the item you wish to use as starting point: ");
			string nmr = Console.ReadLine();
			j = Convert.ToInt32(nmr);
			Console.WriteLine("");
			
			Console.Write("Enter the number of items you wish to remove after the starting point: ");
			string snmr = Console.ReadLine();
			k = Convert.ToInt32(snmr);
			Console.WriteLine("");
			
		}
		else if (ans.Equals("n"))
		{
			Console.WriteLine("Thank you for using this small application!");
			break;
		}
	}
	
	/*Function to fill the list variable with external file and StreamReader.
	Funktio listan täyttämiseen ulkoisen tiedoston ja StreamReaderin avulla.*/
	static void fillList(List<string> lt)
	{
		using (StreamReader rar = new StreamReader("testTextLines.txt"))
		{
			var le;
			
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
}