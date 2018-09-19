/* Coding experiment which opens up either Notepad++ or regular Notepad depending on the result of availability check
   and writes a small line of dialogue into it. / Koodikokeilu joka aukaisee joko Notepad++ tai perus Notepad sovelluksen 
   riippuen ehtotarkistuksen tuloksesta ja kirjoittaa pienen pätkän tekstiä ohjelmaan. */
   
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
//using System.Object;
using System.Runtime.InteropServices;
using System.Threading;

namespace NotepadMessage
{
	class ApplicationAction
	{
		/*We'll import an DLL library so that we can use functions to help us focus on desired app for writing process.
		Tuomme koodiin DLL kirjaston jotta voimme hyödyntää funktioita jotka auttavat kohdistamaan oikean applikaation kirjoitusta varten.*/
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		static IntPtr handleForNotepad;
		
		static void Main()
		{
			/*We'll use try-catch structure for error detection and prevention.
			Käytämme try-catch rakennetta virheiden etsintään ja estoon.*/
			try
			{
				OpenNotepad();
			}
			catch(Exception e)
			{
				Console.WriteLine("{0}Exception has been caught.", e);
			}
		}
		
		static void OpenNotepad()
		{
			/*Based on the check results, we either launch Notepad++ or regular Notepad.
			Riippuen tarkistuksen tuloksesta käynnistämme joko Notepad++ tai perus Notepad sovelluksenö.*/
			
			string dir = @"C:\Program Files\Notepad++"; //Variable that is used for condition check. Ehtotarkistuksessa käytettävä muuttuja.
			
			/*If the folder path stored in earlier variable exists, launch Notepad++. Otherwisely launch regular Notepad.
			Jos muuttujaan tallennettu kansiopolku on olemassa, käynnistä Notepad++. Muussa tapauksessa käynnistä perus Notepad.*/
			if(Directory.Exists(dir))
			{
				Process notepadApp = new Process();
				
				notepadApp.StartInfo.FileName = "notepad++.exe";
				
				notepadApp.Start();
				
				notepadApp.WaitForInputIdle();
				
				handleForNotepad = notepadApp.MainWindowHandle;
				
				WritingToNotepad("Hello. This is a line written from a code.");
				
				KeyPress(Environment.NewLine);
				
				WritingToNotepad("Tervehdys. Tämä viesti tulee suoraan koodista.");
				
				HoldOn();
				
				notepadApp.Kill();
				
			}
			else
			{
				Process notepadApp = new Process();
				
				notepadApp.StartInfo.FileName = "Notepad.exe";
				
				notepadApp.Start();
				
				notepadApp.WaitForInputIdle();
				
				handleForNotepad = notepadApp.MainWindowHandle;
				
				WritingToNotepad("Hello. This is a line written from a code.");
				
				KeyPress(Environment.NewLine);
				
				WritingToNotepad("Tervehdys. Tämä viesti tulee suoraan koodista.");
				
				HoldOn();
				
				notepadApp.Kill();
			}
		}
		
		/*Small function to help us put pauses between operations. Pieni funktio toimintojen tauotukseen.*/
		static void HoldOn()
		{
			Random rand = new Random();
			
			Thread.Sleep(rand.Next(50, 150));
		}
		
		/*Function hat handles the writing process. Kirjoitusprosessin hoitava funktio.*/
		static void WritingToNotepad(string lineToBeWritten)
		{
			for(int i=0; i<lineToBeWritten.Length; i++)
			{
				HoldOn();
				
				KeyPress(lineToBeWritten[i].ToString());
			}
		}
		
		/*Function for making sure keyinputs go to Notepad application. Funktio joka varmistaa että näppäinsyötteet menevät Notepadiin.*/
		static void KeyPress(string PushedKey)
		{
			SetForegroundWindow(handleForNotepad);
			SendKeys.SendWait(PushedKey);
		}
		
	}
}


