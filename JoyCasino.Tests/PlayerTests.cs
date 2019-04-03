using System;
using JoyCasino.Domain;
using Xunit;

namespace JoyCasino.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoinsGame_ThenInGame()
        {
            var game = Create.Game.Build();
            var player = Create.Player.Build();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void WhenLeaveGame_ThenNotInGame()
        {
            var game = Create.Game.Build();
            var player = Create.Player.InGame(game).Build();

            player.LeaveGame(game);

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void WhenBuysChips_ThenHasChips()
        {
            var player = Create.Player.Build();

            player.BuyChips(1);

            Assert.Equal(1, player.ChipsAmount);
        }

        [Fact]
        public void WhenBet_ThenBetIsRegistered()
        {
            var player = Create.Player.InGame().Build();

            player.Bet(1);
            
            Assert.Equal(1, player.CurrentBet);
        }
        

        [Fact]
        public void WhenBetMoreThanBought_ThenFail()
        {
            var player = Create.Player.WithChips(1).Build();

            Assert.Throws<InvalidOperationException>(() => player.Bet(2));
        }
    }
}