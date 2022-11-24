using System;

namespace BackendServer
{
    public static class APPInitializer
    {
        public static string ROS_BRIDGE_URL = "ws://192.168.0.55:9090";
        public static async void InitializeAsync()
        {
            await Task.Delay(1);
            bool connect = ROS.RosBridge.ConnectTo(ROS_BRIDGE_URL, out string errMsg);
            Console.WriteLine("ROS Bridge({0}):{1}", ROS_BRIDGE_URL, connect ? "已連線" : "連線失敗");
            if (!connect)
                await BridgeConnectRetry();
        }

        private static async Task BridgeConnectRetry()
        {
            await Task.Delay(1);
            _ = Task.Run(() =>
             {
                 while (true)
                 {
                     Thread.Sleep(1000);
                     bool connect = ROS.RosBridge.ConnectTo(ROS_BRIDGE_URL, out string errMsg);
                     Console.WriteLine("ROS Bridge({0}):{1}", ROS_BRIDGE_URL, connect ? "已連線" : "連線失敗");
                     if (connect)
                         break;
                 }
             });
        }
    }
}
