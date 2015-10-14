﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game : ISubject
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        List<IBlackJackObserver> m_observers;

        public Game(Dealer dealer, Player player)
        {
            m_dealer = dealer;
            m_player = player;
            m_observers = new List<IBlackJackObserver>();
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            Notify();
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            Notify();
            // TODO: Implement this according to Game_Stand.sequencediagram
            //return m_dealer.Stand(m_dealer);
            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }

        public void Subscribe(IBlackJackObserver observer)
        {
            m_observers.Add(observer);
        }

        public void Notify()
        {
            m_observers.ForEach(x => x.HasNewCard());
        }
    }
}
