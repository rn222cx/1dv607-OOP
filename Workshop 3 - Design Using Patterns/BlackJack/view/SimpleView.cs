﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    class SimpleView : IView
    {

        public void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Hello Black Jack World");
            Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }

        public MenuValue GetInput()
        {
            //char c = Console.ReadKey().KeyChar;
            int c = Console.In.Read();
            if (c == 'q')
            {
                return MenuValue.Quit;
            }
            if (c == 'h')
            {
                return MenuValue.Hit;
            }
            if (c == 'p')
            {
                return MenuValue.Start;
            }
            if (c == 's')
            {
                return MenuValue.Stand;
            }

            return MenuValue.None;
        }

        public void DisplayCard(model.Card a_card)
        {
            Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            Console.WriteLine("Score: {0}", a_score);
            Console.Write(Environment.NewLine);
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
        }

        public void PauseGame()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(" \nDealing.");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
        }
    }
}
