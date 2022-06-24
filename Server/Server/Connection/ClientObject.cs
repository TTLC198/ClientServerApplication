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
                                    var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    if (await DbHandler.GetMatches(user))
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 303
                                        });
                                    }
                                    else
                                    {
                                        await DbHandler.AddUserAsync(user);
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 200
                                        });
                                    }
                                });
                                break;
                            case 202: //Get user
                                Task.Run(async () =>
                                {
                                    var userCredentials =
                                        (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var user = await DbHandler.GetUserAsync(userCredentials.login,
                                        userCredentials.password);
                                    if (user != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.Serialize(user)
                                            },
                                            StatusCode = 200
                                        });
                                    else 
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 203: //Get client
                                Task.Run(async () =>
                                {
                                    var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var client = await DbHandler.GetClientAsync(user);
                                    if (client != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.Serialize(client)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 204: //Get photographer
                                Task.Run(async () =>
                                {
                                    var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var photographer = await DbHandler.GetPhotographerAsync(user);
                                    if (photographer != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.Serialize(photographer)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 205: //Get orders dictionary
                                Task.Run(async () =>
                                {
                                    var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var orders = user.role switch
                                    {
                                        "Исполнитель" => await DbHandler.GetOrdersPhAsync(user),
                                        "Клиент" => await DbHandler.GetOrdersClAsync(user)
                                    };
                                    if (orders != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.SerializeDictionary(orders)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 206: // Get selected order
                                Task.Run(async () =>
                                {
                                    var orderCredentials = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var orders = await DbHandler.GetOrderAsync(orderCredentials.id);
                                    if (orders != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.Serialize(orders)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 207: // Update existing order
                                Task.Run(async () =>
                                {
                                    var order = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var photos = (List<Photo>) SerializeAndDeserialize.Deserialize(cm.Messages[1].Data);

                                    try
                                    {
                                        await DbHandler.UpdateOrder(order);
                                        await DbHandler.InsertPhotos(photos);
                                    }
                                    catch
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                    }
                                    finally
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 200
                                        });
                                    }
                                });
                                break;
                            case 208: // Get photographers dictionary
                                Task.Run(async () =>
                                {
                                    var photographers = await DbHandler.GetPhotographersAsync();
                                    Dictionary<int, string> photDictionary = 
                                        photographers.Select(p => (p.id, $"Имя: {DbHandler.GetUsersAsync().Result.FirstOrDefault(u => u.id == p.id)!.name}, Рейтинг: {(p.rating == null ? "Неизвестно" : p.rating)}")).ToDictionary(tuple => tuple.id, tuple => tuple.Item2);
                                    if (photographers != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.SerializeDictionary(photDictionary)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 209: //Insert new order
                                Task.Run(async () =>
                                {
                                    var order = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);

                                    try
                                    {
                                        await DbHandler.InsertOrder(order);
                                    }
                                    catch
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                    }
                                    finally
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 200
                                        });
                                    }
                                });
                                break;
                            case 210: // Update ph and cl
                                Task.Run(async () =>
                                {
                                    var order = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var client = (Client) SerializeAndDeserialize.Deserialize(cm.Messages[1].Data);
                                    var photographerCredentials = (Photographer) SerializeAndDeserialize.Deserialize(cm.Messages[2].Data);

                                    try
                                    {
                                        var photographers = await DbHandler.GetPhotographersAsync();
                                        var photographer = photographers.FirstOrDefault(ph => ph.id == order.p_id);
                                        photographer!.rating = (short?) ((photographer.rating ?? 5 + photographerCredentials.rating) / 2);
                                        photographer.completed_orders++;
                                        order.isCompleted = false;

                                        await DbHandler.UpdateOrder(order);
                                        await DbHandler.UpdatePhotographer(photographer);
                                        await DbHandler.UpdateClient(client);
                                    }
                                    catch
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                    }
                                    finally
                                    {
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 200
                                        });
                                    }
                                });
                                break;
                            case 211: //Get photos by order id
                                Task.Run(async () =>
                                {
                                    var orderCredentials = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var photos = await DbHandler.GetPhotosByOrderAsync(orderCredentials);
                                    if (photos != null)
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            Messages = new[]
                                            {
                                                SerializeAndDeserialize.Serialize(photos)
                                            },
                                            StatusCode = 200
                                        });
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
                                });
                                break;
                            case 212: //Restore password
                                Task.Run(async () =>
                                {
                                    var tempUser = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
                                    var users = await DbHandler.GetUsersAsync();
                                    var findedUser = users.FirstOrDefault(u => u.email == tempUser.email);
                                    if (findedUser != null)
                                    {
                                        MailAddress from = new MailAddress("///", "///");
                                        MailAddress to = new MailAddress(tempUser.email);
                                        MailMessage m = new MailMessage(from, to);
                                        m.Subject = "Восстановление пароля";
                    
                                        m.Body = "<h1>Пароль: " + Services.GetHashString(findedUser.password) + "</h1>";
                                        m.IsBodyHtml = true;
                                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = new NetworkCredential("///", "///");
                                        smtp.EnableSsl = true;
                                        smtp.Send(m);
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 200
                                        });
                                    }
                                    else
                                        await Services.SendComplexMessageAsync(_stream, new ComplexMessage()
                                        {
                                            StatusCode = 404
                                        });
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