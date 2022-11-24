namespace BackendServer.AGVC
{
    public class ForkAGVC : AGVCBase
    {
        public static string ROS_Topic_FORK = "/turtle1/cmd_vel";

        public enum FORK_ACTION
        {
            /// <summary>
            /// 前
            /// </summary>
            FORWARD,
            /// <summary>
            /// 後
            /// </summary>
            BACKWARD,
            /// <summary>
            /// 上
            /// </summary>
            UP,
            /// <summary>
            /// 下
            /// </summary>
            DOWN,
            /// <summary>
            /// 前傾
            /// </summary>
            Incline_FORWARD,
            /// <summary>
            /// 後傾
            /// </summary>
            Incline_BACKWARD

        }

        public ForkAGVC(int id) : base(id)
        {

        }
        public override bool Move(MOVE_DIRECTION direction, double value, out string errMsg)
        {
            return base.Move(direction, value, out errMsg);
        }
        public override bool Move(string direction, double value, out string errMsg)
        {
            return base.Move(direction, value, out errMsg);
        }

        public void ForkAction(FORK_ACTION action)
        {

        }
    }
}
