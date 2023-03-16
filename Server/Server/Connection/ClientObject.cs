using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading.Tasks;
using PStudioLibrary;

namespace Server
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream _stream { get; private set; }
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient,
            ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
            Console.WriteLine($"New connection with id: {Id}");
            _stream = client.GetStream();
        }

        public void Process()
        {
            ComplexMessage cm = new ComplexMessage();
            while (true)
            {
                try
                {
                    if (_stream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[6297630];
                        do
                        {
                            _stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        } while (_stream.DataAvailable);
                        _stream.Flush();
                        cm = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                        switch (cm.StatusCode)
                        {
                            case 201: // Get matсhes(registration)
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetMatches(cm)
                                    );
                                });
                                break;
                            case 202: //Get user
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetUser(cm)
                                    );
                                });
                                break;
                            case 203: //Get client
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetClient(cm)
                                    );
                                });
                                break;
                            case 204: //Get photographer
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetPhotographer(cm)
                                    );
                                });
                                break;
                            case 205: //Get orders dictionary
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetOrders(cm)
                                    );
                                });
                                break;
                            case 206: // Get selected order
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetOrder(cm)
                                    );
                                });
                                break;
                            case 207: // Update existing order
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.UpdateOrder(cm)
                                    );
                                });
                                break;
                            case 208: // Get photographers dictionary
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetPhotographers(cm)
                                    );
                                });
                                break;
                            case 209: //Insert new order
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.InsertOrder(cm)
                                    );
                                });
                                break;
                            case 210: // Update ph and cl
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.UpdatePair(cm)
                                    );
                                });
                                break;
                            case 211: //Get photos by order id
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.GetPhotoById(cm)
                                    );
                                });
                                break;
                            case 212: //Restore password
                                Task.Run(async () =>
                                {
                                    await Services.SendComplexMessageAsync(_stream,
                                        await Methods.RestorePassword(cm)
                                    );
                                });
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.client.Close();
                }
            }
        }
    }
}