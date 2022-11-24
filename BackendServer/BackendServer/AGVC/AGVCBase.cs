using BackendServer.ROS;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;

namespace BackendServer.AGVC
{
    public class AGVCBase
    {
        public int ID;
        public static string ROS_Topic_MOVE = "/turtle1/cmd_vel";
        public enum MOVE_DIRECTION
        {
            FORWARD,
            BACKWARD,
            RIGHT,
            LEFT
        }

        public AGVCBase(int ID)
        {
            this.ID = ID;
        }

        virtual public bool Move(MOVE_DIRECTION direction, double value, out string errmsg)
        {
            errmsg = "";
            if (!RosBridge.IsAlive)
            {
                errmsg = "ROS Bridge尚未連線";
                return false;
            }
            try
            {
                string id = RosBridge.bridge.rosSocket.Advertise<Twist>(ROS_Topic_MOVE);
                Twist message = GetMoveMessage(direction, value);
                RosBridge.bridge.rosSocket.Publish(id, message);
                return true;
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
        }

        virtual public bool Move(string direction, double value, out string errMsg)
        {
            var EDirection = Enum.GetValues(typeof(MOVE_DIRECTION)).Cast<MOVE_DIRECTION>().FirstOrDefault(dir => dir.ToString().ToUpper() == direction.ToUpper());
            return Move(EDirection, value, out errMsg);
        }


        private Twist GetMoveMessage(MOVE_DIRECTION direction, double value)
        {
            Twist twist = new Twist();
            if (direction == MOVE_DIRECTION.FORWARD | direction == MOVE_DIRECTION.BACKWARD)
                twist.linear = new Vector3 { x = value, y = 0, z = 0 };
            else if (direction == MOVE_DIRECTION.RIGHT | direction == MOVE_DIRECTION.LEFT)
                twist.angular = new Vector3 { x = 0, y = 0, z = value };

            return twist;
        }
    }
}
