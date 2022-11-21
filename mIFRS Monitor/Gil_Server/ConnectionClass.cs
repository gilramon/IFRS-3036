using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Gil_Server
{
    class ConnectionClass : Object
    {
        public ConnectionClass(Thread i_ConnectionThread, TcpClient i_TcpClientConnection,UInt32 i_ConnectionTimeOut)
        {
            m_ConnectionThread = i_ConnectionThread;
            m_TcpClientConnection = i_TcpClientConnection;
            m_ConnectionTimeOut = i_ConnectionTimeOut;
            //m_ConnectionUniqueNumber = DateTime.Now.GetHashCode();
        }
        //TcpClientConnection.Client.RemoteEndPoint
        //int m_ConnectionUniqueNumber;
        

        Thread m_ConnectionThread;
        public Thread ConnectionThread
        {
            get
            {
                return m_ConnectionThread;
            }
            set
            {
                m_ConnectionThread = value;
            }
        }

        TcpClient m_TcpClientConnection;
        public TcpClient TcpClientConnection
        {
            get
            {
                return m_TcpClientConnection;
            }
            set
            {
                m_TcpClientConnection = value;
            }
        }

        UInt32 m_ConnectionTimeOut;
        public UInt32 ConnectionTimeOut
        {
            get
            {
                return m_ConnectionTimeOut;
            }
            set
            {
                m_ConnectionTimeOut = value;
            }
        }


        

        public void RemoveConnection()
        {
            if (m_TcpClientConnection != null)
            {
                m_TcpClientConnection.Close();
            }

            if (m_ConnectionThread != null)
            {
                m_ConnectionThread.Abort();
            }
        }

        public bool IsAlive()
        {
            if (m_ConnectionThread != null )   
            {
                if(    !m_ConnectionThread.IsAlive)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
