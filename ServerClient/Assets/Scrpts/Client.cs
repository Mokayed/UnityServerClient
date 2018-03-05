using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System.Net.Sockets;
using UnityEngine;
using System;


public class Client : MonoBehaviour
{


    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    public void ConnectToServer()
    {
        if (socketReady)
            return;
        string host = "10.50.131.78";
        int port = 50945;



        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
           
            socketReady = true;

        }
        catch (Exception e)
        {
            Debug.Log("Socket error; " + e.Message);
        }

    }
    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                
                string data = reader.ReadLine();
                Debug.Log("from server: " + data);

            }
        }
    }
}

