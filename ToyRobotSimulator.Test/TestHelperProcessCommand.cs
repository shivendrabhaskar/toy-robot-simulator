using NUnit.Framework;
using System;
using ToyRobotSimulator.Helper;

namespace ToyRobotSimulator.Test
{
    public class TestHelperProcessCommand
    {
        /// <summary>
        /// Testing the Vanilla Happy Flow
        /// </summary>
        [Test]
        public void TestVanillaScenario()
        {
            string[] lines = new string[] {"PLACE 0,0,NORTH","MOVE","RIGHT", "MOVE", "LEFT", "REPORT" };
            string message=ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, "Current Toy Position:  1,1,NORTH");
        }

        /// <summary>
        /// Testing the scenario where commands are passed in different cases
        /// </summary>
        [Test]
        public void TestWithDifferentCasedCommands()
        {
            string[] lines = new string[] { "place 0,0,NORTH", "MOVE", "RIGht", "move", "LEFT", "REpoRT" };
            string message = ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, "Current Toy Position:  1,1,NORTH");
        }

        /// <summary>
        /// Testing a scenario where the PLACE command is placed at the end after other commands
        /// </summary>
        [Test]
        public void TestWithPlaceCommandAtEnd()
        {
            string[] lines = new string[] { "MOVE", "RIGHT", "MOVE", "LEFT", "PLACE 0,0,NORTH", "REPORT" };
            string message = ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, "Current Toy Position:  0,0,NORTH");
        }

        /// <summary>
        /// Testing a scenario where an incorrect direction is passed with the PLACE command
        /// </summary>
        [Test]
        public void TestWithIncorrectDirection()
        {
            string[] lines = new string[] { "PLACE 0,0,SOUTHWEST", "MOVE", "RIGHT", "MOVE", "LEFT", "REPORT" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Invalid Direction input. You can only enter in NORTH,SOUTH,EAST,WEST");
        }

        /// <summary>
        /// Testing a scenario where an incorrect X coordinate has been passed with the PLACE command
        /// </summary>
        [Test]
        public void TestWithIncorrectXCoordinatesWithPlace()
        {
            string[] lines = new string[] { "PLACE 6,0,NORTH", "MOVE", "RIGHT", "MOVE", "LEFT", "REPORT" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Invalid X coordiante input. You can only enter in values from 0-5");
        }

        /// <summary>
        /// Testing a scenario where an incorrect Y coordinate has been passed with the PLACE command
        /// </summary>
        [Test]
        public void TestWithIncorrectYCoordinatesWithPlace()
        {
            string[] lines = new string[] { "PLACE 0,6,NORTH", "MOVE", "RIGHT", "MOVE", "LEFT", "REPORT" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Invalid Y coordiante input. You can only enter in values from 0-5");
        }

        /// <summary>
        /// Testing a scenario where no PLACE command has been provided
        /// </summary>
        [Test]
        public void TestWithNoPlaceCommand()
        {
            string[] lines = new string[] { "MOVE", "RIGHT", "MOVE", "LEFT", "REPORT" };
            string message = ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, string.Empty);
        }

        /// <summary>
        /// Testing a scenario where no REPORT command has been passed
        /// </summary>
        [Test]
        public void TestWithNoReportCommand()
        {
            string[] lines = new string[] { "PLACE 0,0,NORTH", "MOVE", "RIGHT", "MOVE", "LEFT" };
            string message = ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, string.Empty);
        }

        /// <summary>
        /// Testing scenario where incorrect Command texts has been passed
        /// </summary>
        [Test]
        public void TestWithIncorrectCommand()
        {
            string[] lines = new string[] { "PLAC 0,0,NORTH", "MOVE", "RIGH", "MOVE", "LEFT", "REPORT" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Invalid Command input. You can only enter in PLACE,MOVE,LEFT,RIGHT,REPORT");
        }

        /// <summary>
        /// Testing a Scenario where only Report Command has been passed
        /// </summary>
        [Test]
        public void TestWithOnlyReportCommand()
        {
            string[] lines = new string[] { "REPORT" };
            string message = ProcessCommand.Calculate(lines);
            Assert.AreEqual(message, string.Empty);
        }

        /// <summary>
        /// Testing a Scenario where No command has been passed
        /// </summary>
        [Test]
        public void TestWithNoCommand()
        {
            string[] lines = new string[] { "" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Invalid Command input.");
        }

        /// <summary>
        /// Testing a scenario which lead to the movement of the toy outside of the 5x5 Board
        /// </summary>
        [Test]
        public void TestCommandWithInvalidMovement()
        {
            string[] lines = new string[] { "PLACE 5,5,NORTH", "MOVE", "RIGHT", "MOVE", "LEFT", "REPORT" };
            var ex = Assert.Throws<ArgumentException>(() => ProcessCommand.Calculate(lines));
            Assert.That(ex.Message == "Entered commands lead to invalid positioning of the toy on the 5x5 Board");
        }


    }
}