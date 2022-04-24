using Microsoft.AspNetCore.Mvc;
using ToyRobotSimulator.Helper;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Controllers
{
    public class ToyController : Controller
    {
        /// <summary>
        /// ActionMethod to Render the view intially via Get call
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ToyOperator()
        {
            return View();
        }

        /// <summary>
        /// Process input Command text and provide appropriate results
        /// </summary>
        /// <param name="toyCommandModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ToyOperator(ToyCommandModel toyCommandModel)
        {
            string message = "Invalid Input";
            if (toyCommandModel != null && toyCommandModel.InputCommand != null && toyCommandModel.InputCommand != string.Empty)
            {
                try
                {
                    toyCommandModel.OutputMessage = message;
                    string[] lines = toyCommandModel.InputCommand.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    toyCommandModel.OutputMessage = ProcessCommand.Calculate(lines);
                }
                catch (ArgumentException ex)
                {
                    toyCommandModel.OutputMessage = ex.Message;
                }
            }
            return View(toyCommandModel);
        }

    }
}
