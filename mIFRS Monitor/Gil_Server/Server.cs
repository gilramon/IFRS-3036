using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Gil_Server
{
    /// <summary>
    /// 
    /// </summary>
    public class Server
    {
         Timer _timer;
         string m_PortNumber;
        /// <summary>
        /// 
        /// </summary>
        public Server(string i_port)
        {
            _timer = new Timer(_timer_Elapsed,null,0,100);
            m_PortNumber = i_port;
            
        }



        TcpListener tcpListener;
        private Thread listenThread;
        /// <summary>
        /// 
        /// </summary>
        public class stringEventArgs : EventArgs
        {
            /// <summary>
            /// 
            /// </summary>
            public string StrData { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class DataEventArgs : EventArgs
        {
            /// <summary>
            /// 
            /// </summary>
            public byte[] BytesData { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ConnectionNumber { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler DataRecievedNotifyDelegate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataReceived(DataEventArgs e)
        {
            if (DataRecievedNotifyDelegate != null)
            {
                DataRecievedNotifyDelegate(null, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler InformationNotifyDelegate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnInformationNotify(stringEventArgs e)
        {
            if (InformationNotifyDelegate != null)
            {
                InformationNotifyDelegate(null, e);
            }
        }

        void InformationNotify(string i_str)
        {
            stringEventArgs e = new stringEventArgs();

            e.StrData = i_str;

            OnInformationNotify(e);
        }

        void DataReceivedNotify(ConnectionClass i_Connection,byte[] i_bytes)
        {
            DataEventArgs e = new DataEventArgs();

            //for (int i = 0; i < GilConectionsClassList.Count; i++)
            //{
            //    if (GilConectionsClassList[i] == i_Connection)
            //    {
            //        e.ConnectionNumber = i;
            //    }

            //}
            e.ConnectionNumber = i_Connection.TcpClientConnection.Client.RemoteEndPoint.ToString();
            e.BytesData = i_bytes;
            OnDataReceived(e);
        }

        bool m_CloseServer = false;
        // bool IsTimedOutTimerEnabled = false;
         //int GetDataIntervalCounter = 0;


        bool m_IsServerActive = false;
        /// <summary>
        /// 
        /// </summary>
        public bool IsServerActive
        {       
            get
            {
                return m_IsServerActive;
            }
            set
            {
                m_IsServerActive = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsConnectedToClient
        {
            get
            {
                if (clientStream == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }



        /// <summary>
        /// 
        /// </summary>
        public void Open_Server()
        {
            m_CloseServer = false;
            //oldColor = ListenBox.BackColor;
            IsServerActive = true;
            try
            {

                int m_Port = int.Parse(m_PortNumber);
                // Initializes the Listener
                tcpListener = new TcpListener(IPAddress.Any, m_Port);


                InformationNotify("Server Started at port " + m_Port);
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();
                



            }
            catch (SocketException se)
            {
                InformationNotify(se.ToString());

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Close_Server()
        {
            InformationNotify("Server Stoped ");


            DisposeServer();

            IsServerActive = false;
            NumberOfOpenConnections = 0;

        }

        private void DisposeServer()
        {
            _timer.Dispose();
            m_CloseServer = true;
            foreach (ConnectionClass con in GilConectionsClassList)
            {
                con.RemoveConnection();
            }

            //IsTimedOutTimerEnabled = false;

            if (tcpListener != null)
            {
                tcpListener.Server.Close();
                tcpListener.Stop();
            }

            if (this.listenThread != null)
            {
                this.listenThread.Abort();
            }

            GilConectionsClassList.Clear();
            GilConectionsClassList.TrimExcess();


            if (clientStream != null)
            {
                clientStream.Dispose();
                clientStream = null;
            }

            System.GC.Collect();
        }


        static List<ConnectionClass> GilConectionsClassList = new List<ConnectionClass>();
        private void ListenForClients()
        {
            try
            {
                this.tcpListener.Start();

                while (true)
                {
                    //blocks until a client has connected to the server
                    TcpClient client = this.tcpListener.AcceptTcpClient();

                    //create a thread to handle communication 
                    //with connected client

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    //ThreadsList.Add(clientThread);
                    

                    ConnectionClass ConClass = new ConnectionClass(clientThread, client,120);
                    //ConClass.m_clientThread = clientThread;
                    //ConClass.m_Tcpclient = client;

                    clientThread.Start(ConClass);
                    GilConectionsClassList.Add(ConClass);

                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                //    LogGeneral.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
            catch (System.Threading.ThreadAbortException)
            {
                //    LogGeneral.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
            catch (Exception ex)
            {
                InformationNotify(ex.ToString());
               // LogGeneral.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }

        TcpClient tcpClient;
        NetworkStream clientStream;
        private void HandleClientComm(object client)
        {
            ConnectionClass connection = (ConnectionClass)client;
            try
            {
                if (m_CloseServer == true)
                {
                    return;
                }

                

                tcpClient = (TcpClient)connection.TcpClientConnection;

                clientStream = tcpClient.GetStream();
                NetworkStream clientStreamPrivate = tcpClient.GetStream();

                ////blocks until a client has connected to the server
                //TcpClient client = this.tcpListener.AcceptTcpClient();

                //string clientIPAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                //var port = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port;
                InformationNotify("Connection accepted from " + tcpClient.Client.RemoteEndPoint);



                //LogGeneral.LogMessage(Color.Green, Color.White, "Connection accepted, " + tcpClient.Client.RemoteEndPoint.ToString(), true, true);

                byte[] message = new byte[4096];
                int bytesRead;

                //IsTimedOutTimerEnabled = true;
                //GetDataIntervalCounter = 0;

                while (true)
                {

                    if (m_CloseServer == true)
                    {
                        if (clientStream != null)
                        {
                            clientStream.Dispose();
                            clientStream = null;
                        }
                        return;
                    }
                    bytesRead = 0;


                    Array.Clear(message, 0, message.Length);
                    //blocks until a client sends a message
                    bytesRead = clientStreamPrivate.Read(message, 0, 4096);

                    

                    if (bytesRead == 0)
                    {
                        break;
                    }
                    else
                    {
                        clientStream = clientStreamPrivate;
                        DataReceivedNotify(connection,message);
                        connection.ConnectionTimeOut = 120;
                    }



                }


            }

            catch (Exception ex)
            {
                InformationNotify(ex.Message.ToString());

            }


            if (connection.ConnectionTimeOut == 0)
            {
                InformationNotify("Connection Closed due time out: " );
            }
            else
            {
                InformationNotify("Connection Closed: " );
            }


        }

        //int m_TimeOutKeepAlivein100ms = 3000;
        int m_NumberOfOpenConnections = 0;
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfOpenConnections
        {
            get
            {
                return m_NumberOfOpenConnections;
            }
            set
            {
                m_NumberOfOpenConnections = value;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int SetTimeoutinSeconds
        //{
        //    get
        //    {
        //        return m_TimeOutKeepAlivein100ms;
        //    }
        //    set
        //    {
        //        m_TimeOutKeepAlivein100ms = value;
        //    }
        //}

        static UInt32 SecondsTimer = 0;
         void _timer_Elapsed(object data)
        {
            //// Gil: 
             bool SecondElapsed = (SecondsTimer % 10 == 0);
            //if (NumberOfOpenConnections == 0 && clientStream != null)
            //{
            //    clientStream.Dispose();
            //    clientStream = null;
            //}

             if(GilConectionsClassList.Count == 0)
             {
                 clientStream = null;
                 GilConectionsClassList.Clear();
             }
            // Gil: Check for thread alive
            try
            {
                SecondsTimer++;

                List<ConnectionClass> ConnectionsListToRemove = new List<ConnectionClass>();
                foreach (ConnectionClass con in GilConectionsClassList.ToArray())
                {
                    if (SecondElapsed)
                    {
                        con.ConnectionTimeOut--;
                    }

                    if (!con.IsAlive() || con.ConnectionTimeOut == 0)
                    {
                        con.RemoveConnection();
                        ConnectionsListToRemove.Add(con);
                    }
                }
                foreach (ConnectionClass con in ConnectionsListToRemove.ToArray())
                {
                    GilConectionsClassList.Remove(con);
                }
                ConnectionsListToRemove.Clear();

                NumberOfOpenConnections = GilConectionsClassList.Count;
            }
            catch (Exception ex)
            {
                InformationNotify(ex.ToString());

                foreach (ConnectionClass con in GilConectionsClassList.ToArray())
                {
                        con.RemoveConnection(); 
                }
                GilConectionsClassList.Clear();
            }
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         public List<string> GetAllOpenConnections()
         {
             List<string> ret = new List<string>();
             foreach (ConnectionClass con in GilConectionsClassList)
             {
                 ret.Add(con.TcpClientConnection.Client.RemoteEndPoint.ToString());
             }

             return ret;
         }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_Connection"></param>
        /// <param name="i_SendData"></param>
         public void WriteDataToServer(string i_Connection,byte[] i_SendData)
         {
             foreach(ConnectionClass con in GilConectionsClassList)
             {
                 if (con.TcpClientConnection.Client.RemoteEndPoint.ToString() == i_Connection)
                 {
                     NetworkStream Ns = con.TcpClientConnection.GetStream();


                     try
                     {
                         if (Ns != null && NumberOfOpenConnections != 0)
                         {
                             Ns.Write(i_SendData, 0, i_SendData.Length);
                         }
                     }
                     catch (Exception ex)
                     {
                         InformationNotify(ex.ToString());
                     }
                 }
             }
             
             
         }

    }
}
