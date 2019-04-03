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
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void WhenLeaveGame_ThenNotInGame()
        {
            var player = new Player();
            var game = new Game();
            player.JoinGame(game);

            player.LeaveGame(game);

            Assert.False(player.IsInGame);
        }
    }
}