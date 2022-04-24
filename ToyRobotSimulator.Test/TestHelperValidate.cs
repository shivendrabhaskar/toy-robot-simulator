using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using ToyRobotSimulator.Controllers;
using ToyRobotSimulator.Helper;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Test
{
    public class TestHelperValidate
    {
        #region Test PlaceCommand method
        /// <summary>
        /// Testing Valid scenario for PLACE command
        /// </summary>
        [Test]
        public void TestValidPlaceCommand()
        {
            string PlaceCommand = "PLACE 0,0,NORTH";
            Assert.DoesNotThrow(() => Validate.PlaceCommand(PlaceCommand));
        }

        /// <summary>
        /// Testing In-Valid scenario of PLACE command without spaces 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandWithoutSPace()
        {
            string PlaceCommand = "PLACE0,0,NORTH";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid Input argument for PLACE command");
        }

        /// <summary>
        /// Testing In-Valid scenario of PLACE command with incorrect command text 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandText()
        {
            string PlaceCommand = "PLACES 0,0,NORTH";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid command input. You can only enter in format PLACE X,Y,Face");
        }

        /// <summary>
        /// Testing In-Valid scenario of PLACE command with incorrect number of arguments 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandArguments()
        {
            string PlaceCommand = "PLACE 0,0,0,NORTH";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid Input argument for PLACE command");
        }

        /// <summary>
        /// Testing In-Valid scenario of PLACE command with incorrect Direction text 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandDirection()
        {
            string PlaceCommand = "PLACE 0,0,NORTHEAST";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid Direction input. You can only enter in NORTH,SOUTH,EAST,WEST");
        }


        /// <summary>
        /// Testing In-Valid scenario of PLACE command with incorrect X Cordinate 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandXCoordinate()
        {
            string PlaceCommand = "PLACE 8,0,NORTH";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid X coordiante input. You can only enter in values from 0-5");
        }

        /// <summary>
        /// Testing In-Valid scenario of PLACE command with incorrect Y Cordinate 
        /// </summary>
        [Test]
        public void TestInValidPlaceCommandYCoordinate()
        {
            string PlaceCommand = "PLACE 0,8,NORTH";
            var ex = Assert.Throws<ArgumentException>(() => Validate.PlaceCommand(PlaceCommand));
            Assert.That(ex.Message == "Invalid Y coordiante input. You can only enter in values from 0-5");
        }
        #endregion

        #region Test CheckToyPosition Method
        /// <summary>
        /// Testing Valid scenario to check the toy position on the 5x5 board
        /// </summary>
        [Test]
        public void TestCorrectToyPosition()
        {
            ToyPositionModel toyPosition = new ToyPositionModel() { XPosition = 3, YPosition = 4, Face = Enums.Direction.NORTH };
            Assert.DoesNotThrow(() => Validate.CheckToyPosition(toyPosition));
        }

        /// <summary>
        /// Testing null scenario to check the toy position on the 5x5 board
        /// </summary>
        [Test]
        public void TestNullToyPosition()
        {
            ToyPositionModel toyPosition = null;
            var ex = Assert.Throws<ArgumentException>(() => Validate.CheckToyPosition(toyPosition));
            Assert.That(ex.Message == "Invalid Input command");
        }


        /// <summary>
        /// Testing In-Valid X coordinate scenario to check the toy position on the 5x5 board
        /// </summary>
        [Test]
        public void TestInValidXCordinateToyPosition()
        {
            ToyPositionModel toyPosition = new ToyPositionModel() { XPosition = 8, YPosition = 4, Face = Enums.Direction.NORTH };
            var ex = Assert.Throws<ArgumentException>(() => Validate.CheckToyPosition(toyPosition));
            Assert.That(ex.Message == "Entered commands lead to invalid positioning of the toy on the 5x5 Board");
        }


        /// <summary>
        /// Testing In-Valid Y coordinate scenario to check the toy position on the 5x5 board
        /// </summary>
        [Test]
        public void TestInValidYCordinateToyPosition()
        {
            ToyPositionModel toyPosition = new ToyPositionModel() { XPosition = 4, YPosition = 8, Face = Enums.Direction.NORTH };
            var ex = Assert.Throws<ArgumentException>(() => Validate.CheckToyPosition(toyPosition));
            Assert.That(ex.Message == "Entered commands lead to invalid positioning of the toy on the 5x5 Board");
        }

        #endregion

        #region Test CheckInputCommand method
        /// <summary>
        /// Testing Valid scenario to check the input text with place command
        /// </summary>
        [Test]
        public void TestCorrectPlaceInputText()
        {
            string inputCommand = "PLACE 0,0,NORTH";
            Assert.DoesNotThrow(() => Validate.CheckInputCommand(inputCommand));
        }

        /// <summary>
        /// Testing Valid scenario to check the input text with MOVE command
        /// </summary>
        [Test]
        public void TestCorrectMoveInputText()
        {
            string inputCommand = "MOVE";
            Assert.DoesNotThrow(() => Validate.CheckInputCommand(inputCommand));
        }


        /// <summary>
        /// Testing null scenario in the input text check
        /// </summary>
        [Test]
        public void TestNullInputText()
        {
            string inputCommand = string.Empty;
            var ex = Assert.Throws<ArgumentException>(() => Validate.CheckInputCommand(inputCommand));
            Assert.That(ex.Message == "Invalid Command input.");
        }

        #endregion
    }
}