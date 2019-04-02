﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private readonly IDiceRoller _diceRoller;
        private readonly List<IPlayer> players = new List<IPlayer>();

        public RollDiceGame(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }

        public void AddPlayer(IPlayer player)
        {
            if (players.Count == 6) throw new TooManyPlayersException();
            players.Add(player);
        }
 
        public void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }

        public void Play()
        {
            var luckyScore = _diceRoller.RollDice();
            foreach (var player in players)
                if (player.CurrentBet.Score == luckyScore)
                    player.Win(player.CurrentBet.Chips.Amount * 6);
                else
                    player.Lose();
        }
    }
}