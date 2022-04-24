using ToyRobotSimulator.Enums;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Helper
{
    public class ProcessCommand
    {
        #region Calculate the output and manage the commands as provided in the input text
        /// <summary>
        /// Calculates the Current position of toy based on input command
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static string Calculate(string[] lines)
        {
            ToyPositionModel toyPosition = new ToyPositionModel();
            string message = string.Empty;
            int PlaceCommandFound = 0;
            try
            {
                foreach (var item in lines)
                {
                    Validate.CheckInputCommand(item.ToUpper());
                    string[] command = item.ToUpper().Split(' ');

                    switch (command[0])
                    {
                        case "PLACE":
                            UpdatePlace(item.ToUpper(), toyPosition);
                            PlaceCommandFound++;
                            break;
                        case "MOVE":
                            if (PlaceCommandFound > 0) UpdateMove(toyPosition);
                            break;
                        case "LEFT":
                            if (PlaceCommandFound > 0) UpdateLeft(toyPosition);
                            break;
                        case "RIGHT":
                            if (PlaceCommandFound > 0) UpdateRight(toyPosition);
                            break;
                        case "REPORT":
                            if (PlaceCommandFound > 0) message = GetReport(toyPosition);
                            break;
                        default:
                            break;
                    }
                }
                Validate.CheckToyPosition(toyPosition);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            return message;
        }
        #endregion

        #region Process input commands

        #region Process REPORT input command
        /// <summary>
        /// Process the REPORT command
        /// </summary>
        /// <param name="toyPosition"></param>
        /// <returns></returns>
        private static string GetReport(ToyPositionModel toyPosition)
        {
            try
            {
                string message ="Current Toy Position:  " +toyPosition.XPosition.ToString() + "," + toyPosition.YPosition.ToString() + "," + toyPosition.Face.ToString();
                return message;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Process RIGHT input command
        /// <summary>
        /// Process the RIGHT command
        /// </summary>
        /// <param name="toyPosition"></param>
        private static void UpdateRight(ToyPositionModel toyPosition)
        {
            try
            {
                switch (toyPosition.Face)
                {
                    case Direction.NORTH:
                        toyPosition.Face = Direction.EAST;
                        break;
                    case Direction.SOUTH:
                        toyPosition.Face = Direction.WEST;
                        break;
                    case Direction.EAST:
                        toyPosition.Face = Direction.SOUTH;
                        break;
                    case Direction.WEST:
                        toyPosition.Face = Direction.NORTH;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Process LEFT input command
        /// <summary>
        /// Process the LEFT command
        /// </summary>
        /// <param name="toyPosition"></param>
        private static void UpdateLeft(ToyPositionModel toyPosition)
        {
            try
            {
                switch (toyPosition.Face)
                {
                    case Direction.NORTH:
                        toyPosition.Face = Direction.WEST;
                        break;
                    case Direction.SOUTH:
                        toyPosition.Face = Direction.EAST;
                        break;
                    case Direction.EAST:
                        toyPosition.Face = Direction.NORTH;
                        break;
                    case Direction.WEST:
                        toyPosition.Face = Direction.SOUTH;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Process MOVE input command
        /// <summary>
        /// Processes the MOVE command
        /// </summary>
        /// <param name="toyPosition"></param>
        private static void UpdateMove(ToyPositionModel toyPosition)
        {
            try
            {
                switch (toyPosition.Face)
                {
                    case Direction.NORTH:
                        toyPosition.YPosition++;
                        break;
                    case Direction.SOUTH:
                        toyPosition.YPosition--;
                        break;
                    case Direction.EAST:
                        toyPosition.XPosition++;
                        break;
                    case Direction.WEST:
                        toyPosition.XPosition--;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Process PLACE input command
        /// <summary>
        /// Processes the PLACE command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="toyPosition"></param>
        private static void UpdatePlace(string command, ToyPositionModel toyPosition)
        {
            try
            {
                Validate.PlaceCommand(command);
                string[] place = command.Split(' ')[1].Split(',');
                toyPosition.XPosition = Convert.ToInt32(place[0]);
                toyPosition.YPosition = Convert.ToInt32(place[1]);
                toyPosition.Face = Enum.Parse<Direction>(place[2]);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        #endregion 

        #endregion
    }
}
