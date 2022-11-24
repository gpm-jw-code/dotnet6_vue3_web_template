using RosSharp.RosBridgeClient;

namespace BackendServer.ROS
{
    public class RosBridge
    {
        public static RosBridge bridge;
        public static bool ConnectTo(string ws_url, out string errMsg)
        {
            bridge = new RosBridge();
            return bridge.Connect(ws_url, out errMsg);
        }
        public static bool IsAlive => bridge.rosSocket == null ? false : bridge.rosSocket.protocol.IsAlive();

        public RosSocket rosSocket { get; private set; }
        /// <summary>
        /// 與rosbridge連線
        /// </summary>
        /// <param name="uri">e.g ws://172.18.186.101:9090</param>   
        /// <param name="errMsg"></param>
        /// <returns></returns>
        virtual public bool Connect(string uri, out string errMsg)
        {
            errMsg = string.Empty;
            rosSocket = null;
            try
            {
                rosSocket = new RosSocket(new RosSharp.RosBridgeClient.Protocols.WebSocketSharpProtocol(uri));
                //SubscribePosInfo();
                return rosSocket.protocol.IsAlive();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        virtual public void SubscribePosInfo()
        {

        }

        virtual public void MonitorStatus()
        {

        }

    }
}
