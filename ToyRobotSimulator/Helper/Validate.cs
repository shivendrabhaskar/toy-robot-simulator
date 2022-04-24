using ToyRobotSimulator.Enums;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Helper
{
    public static class Validate
    {

        #region Validate PLACE command
        /// <summary>
        /// Apply validation on the provided PLACE command
        /// </summary>
        /// <param name="place"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void PlaceCommand(string place)
        {
            try
            {
                if (place == null && place == string.Empty)
                    throw new ArgumentException("Invalid Input for PLACE command");

                //Check for Valid space seperated Values
                string[] SpaceSeperated = place.Split(' ');
                if (SpaceSeperated == null || SpaceSeperated.Length != 2)
                    throw new ArgumentException("Invalid Input argument for PLACE command");
                if (!Enum.IsDefined(typeof(Command), SpaceSeperated[0]))
                    throw new ArgumentException("Invalid command input. You can only enter in format PLACE X,Y,Face");

                //Check for Valid Comma Seperated Values
                string[] CommaSeperated = SpaceSeperated[1].Split(',');
                if (CommaSeperated == null || CommaSeperated.Length != 3)
                    throw new ArgumentException("Invalid Input argument for PLACE command");
                if (!Enum.IsDefined(typeof(Direction), CommaSeperated[2]))
                    throw new ArgumentException("Invalid Direction input. You can only enter in NORTH,SOUTH,EAST,WEST");
                if (Convert.ToInt32(CommaSeperated[0]) > 5 || Convert.ToInt32(CommaSeperated[0]) < 0)
                    throw new ArgumentException("Invalid X coordiante input. You can only enter in values from 0-5");
                if (Convert.ToInt32(CommaSeperated[1]) > 5 || Convert.ToInt32(CommaSeperated[1]) < 0)
                    throw new ArgumentException("Invalid Y coordiante input. You can only enter in values from 0-5");
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Check TOY position on the 5x5 Board
        /// <summary>
        /// Apply validation on the current position of the toy to be within the Board
        /// </summary>
        /// <param name="toyPosition"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckToyPosition(ToyPositionModel toyPosition)
        {
            try
            {
                if (toyPosition == null)
                    throw new ArgumentException("Invalid Input command");
                if (toyPosition.XPosition > 5 || toyPosition.XPosition < 0)
                    throw new ArgumentException("Entered commands lead to invalid positioning of the toy on the 5x5 Board");
                if (toyPosition.YPosition > 5 || toyPosition.YPosition < 0)
                    throw new ArgumentException("Entered commands lead to invalid positioning of the toy on the 5x5 Board");
                if (!Enum.IsDefined(typeof(Direction), toyPosition.Face))
                    throw new ArgumentException("Invalid Direction input. You can only enter in NORTH,SOUTH,EAST,WEST");

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Validate input commands

        /// <summary>
        /// Apply validation on the input commands
        /// </summary>
        /// <param name="command"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckInputCommand(string command)
        {
            try
            {
                if (command == null || command == string.Empty)
                    throw new ArgumentException("Invalid Command input.");

                string[] item = command.Split(' ');
                if (!Enum.IsDefined(typeof(Command), item[0].ToString()))
                    throw new ArgumentException("Invalid Command input. You can only enter in PLACE,MOVE,LEFT,RIGHT,REPORT");

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        } 
        #endregion

    }
}
