using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Server : MonoBehaviour
{

    public int port = 50945;
    TcpListener listener;
    int counter = 0;
    private TcpClient c;
    private void Start()
    {


        try
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
       
            Debug.Log("Server has been started on port" + port.ToString());
                

        }
        catch (Exception e)
        {
            Debug.Log("Socket error" + e.Message);

        }
    }


    public void Update()
       
    {
            if (listener.Pending())
        {
            c = listener.AcceptTcpClient();
            counter++;
            Debug.Log("#" + counter + " Connected!");
            


            StreamWriter sw = new StreamWriter(c.GetStream());

            sw.WriteLine("hello!");
            sw.Flush();

   



       
        }
        }

    }

