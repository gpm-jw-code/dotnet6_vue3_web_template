using BackendServer.AGVC;
using BackendServer.ROS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForkRobotController : ControllerBase
    {
        ForkAGVC forkAGVC = new ForkAGVC(0);
        public ForkRobotController()
        {

        }

        [HttpGet("Move")]
        public async Task<IActionResult> Move(string direction, double value)
        {
            bool success = forkAGVC.Move(direction, value, out string errmsg);
            return Ok(string.Format("{0},{1}=>{2}:{3}", direction, value, success ? "發布成功" : "發布失敗", errmsg));
        }

        [HttpGet("Fork")]
        public async Task<IActionResult> Fork(string action)
        {
            return Ok(string.Format("{0}", action));
        }



        [HttpGet("MoveTopic")]
        public async Task<IActionResult> GetMoveTopic()
        {
            return Ok(AGVCBase.ROS_Topic_MOVE);
        }
        [HttpPost("MoveTopic")]
        public async Task<IActionResult> SetMoveTopic(string topic)
        {
            AGVCBase.ROS_Topic_MOVE = topic;
            return Ok(AGVCBase.ROS_Topic_MOVE);
        }



        [HttpGet("ForkControlTopic")]
        public async Task<IActionResult> GetForkControlTopic()
        {
            return Ok(ForkAGVC.ROS_Topic_FORK);
        }

        [HttpPost("ForkControlTopic")]
        public async Task<IActionResult> SetForkControlTopic(string topic)
        {
            ForkAGVC.ROS_Topic_FORK= topic;
            return Ok(ForkAGVC.ROS_Topic_FORK);
        }
    }
}
