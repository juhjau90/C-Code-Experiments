/*C# program that's meant to simulate an simplified version of Blackjack card game.
C# sovellus jonka on tarkoitus simuloida yksinkertaistettua versiota Blackjack korttipelistä.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;

/*GAME RULES: AI and the player have 6 cards to play ranging from Ace (1) to King (13). Cards are dealt randomly to both 
AI and the player (because deck usually has 4 suits, duplicates or more cards with same value are allowed to appear). 
After cards have been dealt, AI and the player must present their cards. The one who gets the total value of the cards 
closer to 21 is the winner. However, if either one have a hand that exceeds 21, they lose the game. */

/*PELIN SÄÄNNÖT: AI:lla ja pelaajalla on kuusi korttia pelattavana arvojen ollessa välillä ässä (1) ja kunkku (13). Kortit 
on jaettu sattumanmukaisesti sekä AI:lle että pelaajalle (koska korttipakassa on tyypillisesti neljä maata, toistuvat 
kortit ovat hyväksyttäviä). Jaon jälkeen, kortit pitää esitellä. Se joka saa korttien kokonaisarvon lähemmäksi 21:tä on 
voittaja. Jos jompikumpi kuitenkin saavat käden jonka arvo ylittää 21, hän häviää pelin. */

namespace Blackjack
{
	class Game
	{
		/*Some shared variables - the random for number generation and shuffeling and variables for player and AI cards. 
		Jaettuja muuttujia - satunnaismuuttuja numero generointiin ja sekoitukseen ja muuttujat pelaajan ja AIn korteille.*/
		Random rand = new Random();
		var playerHand;
		var AIHand;
		
		static void Main()
		{
			try
			{
				/*We create new list variables to store the cards in hand and to count the total sum of the hand.
				Luomme uusia lista muuttujia tallentamaan saadut kortit ja laskemaan käden kokonaisarvon.*/
				List<int> playerCards = PlayerCards();
				List<int> aiCards = AICards();
				
				playerCards.Shuffelin();
				aiCards.Shuffelin();
				
				int playerHandSum = playerCards.Sum(); //Player hand total. Pelaajan käden kokonaisarvo.
				int aiHandSum = aiCards.Sum(); //AI hand total. AI:n käden kokonaisarvo.
				
				Console.WriteLine("The players hand is: ");
				playerCards.ForEach(Console.Writeline);				
				Console.WriteLine("");
				
				Console.WriteLine("The AI hand is: ");
				aiCards.ForEach(Console.Writeline);
				Console.WriteLine("");
				
				Console.Writeline("The sum of players hand is " + playerHandSum.ToString());
				Console.Writeline("The sum of AI hand is " + aiHandSum.ToString());
				
				if(playerHandSum > aiHandSum && playerHandSum <= 21)
				{
					Console.Writeline("The player wins!");
				}
				else if(aiHandSum > playerHandSum && aiHandSum <= 21)
				{
					Console.Writeline("The AI wins!");
				}
				
				
				
			}
			catch(Exception e)
			{
				
			}
		}
		
		
		/*Function used to shuffle cards. Basis on Fisher-Yates shuffle algorithm.
		Korttien sekoitukseen käytettävä funktio. Pohjana toimii Fisher-Yates shuffle algoritmi.*/
		public static void Shuffelin<T>(this IList<T> cards>
		{
			int x = cards.Count;
			
			for(int i = cards.Count - 1; i > 1; i++)
			{
				int rng = rand.Next(i + 1);
				
				T value = cards[rng];
				cards[rng] = cards[i];
				cards[i] = value;
			}
		}
		
		/*Function that creates the player hand. Funktio joka luo pelaajan kortit.*/
		static List<int> PlayerCards()
		{
			playerHand = new List<int>();
			
			for (int a = 0; a < 6; a++)
			{
				playerHand.Add(rand.Next(13));
			}
			
			return playerHand;
		}
		
		/*Function that creates the AI cards. Funktio joka luo AIn kortit.*/
		static List<int> AICards()
		{
			AIHand = new List<int>();
			
			for (int b = 0; b < 6; b++)
			{
				AIHand.Add(rand.Next(13));
			}
			
			return AIHand;
		}
	}
}