/* Expanded version of an earlier Notepad activation experiment which checks firts if "Notepad++" is available. This also has been made without IDE tools.
Laajennettu versio aiemmasta Notepad aktivointi kokeilusta joka tarkastaa onko "Notepad++" käytettävissä. Tämäkin on tehty ilman IDE työkaluja. */

using System;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace ActivateNotepad
{
	class OpenApplication
	{
		void StartNotepad()
		{
			/* We run a check first to see if the directory for "Notepad++" application exists. This check assumes the directory is located in its default location. 
			Ajamme ensin tarkistuksen siitä onko "Notepad++" kohtainen kansio olemassa. Tämä tarkistus olettaa että kansio on asennettu sen oletussijaintiin. */
						
			string directory = @"C:\Program Files\Notepad++"; //variable which contains directory path. / Muuttuja joka sisältää kansiopolun
			
			/*If the directory exists, activate "Notepad++".
			Jos kansio on olemassa, aktivoimme "Notepad++" applikaation. */			
			if(Directory.Exists(directory))
			{
				Process.Start("notepad++.exe");
			}
			/* In other case, we'll just activate the standard "Notepad" application. 
			Muussa tapauksessa aktivoimme perinteisen "Notepad" applikaation. */
			else
			{
				Process.Start("Notepad.exe");
			}
		}
		
		static void Main()
		{
			OpenApplication openApplication = new OpenApplication();
			
			/* For error checking and logging, we'll put our code into "try-catch" structure. 
			Virheiden tarkistuksen ja seuraamisen puolesta laitamme koodimme "try-catch" rakenteen sisään. */
			try
			{
				openApplication.StartNotepad();
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
			}
		}
	}
}