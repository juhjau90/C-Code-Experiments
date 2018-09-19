/* Small experiment which - if succesfull - opens the Notepad application. This has been writen from nothing without IDE tools. 
   Pieni kokeilu joka oikein toimiessaan käynnistää Notepad applikaation. Koodi on kirjoitettu tyhjältä pohjalta ilman IDE työkaluja. */

using System;
using System.Diagnostics;
using System.ComponentModel;

namespace ActivateNotepad 
{
	class OpenApplication
	{
		void StartNotepad()
		{
			/* We'll use Process.Start method to activate the Notepad application. 
		    Käytämme Process.Start metodia aktivoimaan Notepad sovelluksen. */
			Process.Start("Notepad.exe");
		}
		
		static void Main()
		{
			/* We'll create an object containing new instance of the class that we can use to call the "StartNotepad" function. 
			Luomme uuden luokkainstanssin olioon jota käytämme kutsumaan "StartNotepad" funktiota. */
			OpenApplication openApplication = new OpenApplication();
			
			openApplication.StartNotepad();
		}
		
	}
	
}