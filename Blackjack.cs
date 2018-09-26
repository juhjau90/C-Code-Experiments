/*C# program that's meant to simulate an simplified version of Blackjack card game.
C# sovellus jonka on tarkoitus simuloida yksinkertaistettua versiota Blackjack korttipelistä.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Threading;

/*GAME RULES (EDIT 26.09.2018): AI and the player have 4 cards to play ranging from Ace (1) to King (13). Cards are dealt randomly 
to both AI and the player (because deck usually has 4 suits, duplicates or more cards with same value are allowed to appear). 
After cards have been dealt, AI and the player must present their cards. The one who gets the total value of the cards 
closer to 21 is the winner.*/

/*PELIN SÄÄNNÖT (EDIT 26.09.2018): AI:lla ja pelaajalla on neljä korttia pelattavana arvojen ollessa välillä ässä (1) ja 
kunkku (13). Kortit on jaettu sattumanvaraisesti sekä AI:lle että pelaajalle (koska korttipakassa on tyypillisesti neljä maata,
toistuvat kortit ovat hyväksyttäviä). Jaon jälkeen, kortit pitää esitellä. Se joka saa korttien kokonaisarvon lähemmäksi 21:tä 
on voittaja.*/

namespace Blackjack
{
	static class Game
	{
		/*Shared random variable which must be set to static in order for it be usable within the class. We use this for
		various functions. Jaettu sattuma muuttuja joka täytyy asettaa staattiseksi jotta se toimisi luokan sisällä.
		Käytämme tätä useassa funktiossa.*/
		static Random rand = new Random();
		
		static void Main()
		{
			try
			{
				/*We create new list variables to store the cards in hand and to count the total sum of the hand.
				Luomme uusia lista muuttujia tallentamaan saadut kortit ja laskemaan käden kokonaisarvon.*/
				List<int> playerCards = PlayerCards();
				List<int> aiCards = AICards();
				
				
				int playerHandSum = playerCards.Sum(); //Player hand total. Pelaajan käden kokonaisarvo.
				int aiHandSum = aiCards.Sum(); //AI hand total. AI:n käden kokonaisarvo.
				
				Console.WriteLine("The players hand is: ");
				playerCards.ForEach(Console.WriteLine);				
				Console.WriteLine("");
				
				HoldIt();
				
				Console.WriteLine("The AI hand is: ");
				aiCards.ForEach(Console.WriteLine);
				Console.WriteLine("");
				
				HoldIt();
				
				Console.WriteLine("The sum of players hand is " + playerHandSum.ToString());
				Console.WriteLine("The sum of AI hand is " + aiHandSum.ToString());
				
				HoldIt();
				
				if(playerHandSum < aiHandSum)
				{
					Console.WriteLine("The player wins!");
				}
				else if(playerHandSum == aiHandSum)
				{
					Console.WriteLine("It's a draw.");
				}
				else
				{
					Console.WriteLine("The AI wins!");
				}
				
				HoldIt();
				
			}
			catch(Exception e)
			{
				Console.WriteLine("{0}Exception has been caught.", e);
			}
		}
		
		/*Small function to pause between operations/steps. Pieni funktio toimintojen/vaiheiden tauotukseen.*/
		static void HoldIt()
		{			
			Thread.Sleep(rand.Next(500, 1500));
		}
		
		
		/*Function that creates the player hand. Funktio joka luo pelaajan kortit.*/
		static List<int> PlayerCards()
		{
			
			var playerHand = new List<int>();
			
			for (int a = 0; a < 4; a++)
			{
				playerHand.Add(rand.Next(13));
			}
			
			return playerHand;
		}
		
		/*Function that creates the AI cards. Funktio joka luo AIn kortit.*/
		static List<int> AICards()
		{
			
			var AIHand = new List<int>();
			
			for (int b = 0; b < 4; b++)
			{
				AIHand.Add(rand.Next(13));
			}
			
			return AIHand;
		}
		
	}
}