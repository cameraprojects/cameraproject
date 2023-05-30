using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UdpReceiver
{
    public class Udp
    {
        private UdpClient _rcvClient;

        public Udp() { }

        public void InitRcvClient(int rcvPort)
        {
            _rcvClient?.Close();

            try
            {
                _rcvClient = new UdpClient(rcvPort);
            }
            catch (Exception ex)
            {
                // Error Handling
                return;
            }
        }

        public void CloseClient()
        {
            _rcvClient?.Close();
        }

        public void ReceiveMessage(IUdpCallback callbackTarget, out string msg)
        {
            msg = "";
            var udpState = new UdpState() { Client = _rcvClient, CallbackTarget = callbackTarget };
            // Restart to receive asynchronously
            _rcvClient?.BeginReceive(OnReceived, udpState);
        }

        private void OnReceived(IAsyncResult ar)
        {
            var client = ((UdpState)ar.AsyncState).Client;
            var callbackTarget = ((UdpState)ar.AsyncState).CallbackTarget;
            IPEndPoint ep = null;
            try
            {
                var rcvBytes = client.EndReceive(ar, ref ep);
                var rcvString = Encoding.ASCII.GetString(rcvBytes);
                // Execute callback
                callbackTarget.OnReceivedCallback(rcvString);
            }
            catch (Exception ex)
            {
                // Error Handling
            }
            // Restart to receive
            var udpState = new UdpState() { Client = client, CallbackTarget = callbackTarget };
            client.BeginReceive(OnReceived, udpState);
        }

        private struct UdpState
        {
            public UdpClient Client;
            public IUdpCallback CallbackTarget;
        }
    }

    public interface IUdpCallback
    {
        void OnReceivedCallback(string val);
    }
}