using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading.Tasks;
using PStudioLibrary;

namespace Server;

public class Methods
{
    public static async Task<ComplexMessage> GetMatches(ComplexMessage cm)
    {
        var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        if (await DbHandler.GetMatches(user))
        {
            return new ComplexMessage()
            {
                StatusCode = 303
            };
        }
        else
        {
            await DbHandler.AddUserAsync(user);
            return new ComplexMessage()
            {
                StatusCode = 200
            };
        }
    }
    
    public static async Task<ComplexMessage> GetUser(ComplexMessage cm)
    {
        var userCredentials =
            (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var user = await DbHandler.GetUserAsync(userCredentials.login,
            userCredentials.password);
        if (user != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.Serialize(user)
                },
                StatusCode = 200
            };
        else 
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> GetClient(ComplexMessage cm)
    {
        var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var client = await DbHandler.GetClientAsync(user);
        if (client != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.Serialize(client)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> GetPhotographer(ComplexMessage cm)
    {
        var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var photographer = await DbHandler.GetPhotographerAsync(user);
        if (photographer != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.Serialize(photographer)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> GetOrders(ComplexMessage cm)
    {
        var user = (User) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var orders = user.role switch
        {
            "Исполнитель" => await DbHandler.GetOrdersPhAsync(user),
            "Клиент" => await DbHandler.GetOrdersClAsync(user)
        };
        if (orders != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.SerializeDictionary(orders)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> GetOrder(ComplexMessage cm)
    {
        var orderCredentials = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var orders = await DbHandler.GetOrderAsync(orderCredentials.id);
        if (orders != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.Serialize(orders)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> UpdateOrder(ComplexMessage cm)
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
            return new ComplexMessage()
            {
                StatusCode = 404
            };
        }
        return new ComplexMessage()
        {
            StatusCode = 200
        };
    }

    public static async Task<ComplexMessage> GetPhotographers(ComplexMessage cm)
    {
        var photographers = await DbHandler.GetPhotographersAsync();
        Dictionary<int, string> photDictionary = 
            photographers.Select(p => (p.id, $"Имя: {DbHandler.GetUsersAsync().Result.FirstOrDefault(u => u.id == p.id)!.name}, Рейтинг: {(p.rating == null ? "Неизвестно" : p.rating)}")).ToDictionary(tuple => tuple.id, tuple => tuple.Item2);
        if (photographers != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.SerializeDictionary(photDictionary)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }

    public static async Task<ComplexMessage> InsertOrder(ComplexMessage cm)
    {
        var order = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);

        try
        {
            await DbHandler.InsertOrder(order);
        }
        catch
        {
            return new ComplexMessage()
            {
                StatusCode = 404
            };
        }
        return new ComplexMessage()
        {
            StatusCode = 200
        };
    }
    
    public static async Task<ComplexMessage> DeleteOrder(ComplexMessage cm)
    {
        var order = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);

        try
        {
            await DbHandler.DeleteOrder(order);
        }
        catch
        {
            return new ComplexMessage()
            {
                StatusCode = 404
            };
        }
        return new ComplexMessage()
        {
            StatusCode = 200
        };
    }
    
    public static async Task<ComplexMessage> UpdatePair(ComplexMessage cm)
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
            return new ComplexMessage()
            {
                StatusCode = 404
            };
        }
        return new ComplexMessage()
        {
            StatusCode = 200
        };
    }
    public static async Task<ComplexMessage> GetPhotoById(ComplexMessage cm)
    {
        var orderCredentials = (Order) SerializeAndDeserialize.Deserialize(cm.Messages[0].Data);
        var photos = await DbHandler.GetPhotosByOrderAsync(orderCredentials);
        if (photos != null)
            return new ComplexMessage()
            {
                Messages = new[]
                {
                    SerializeAndDeserialize.Serialize(photos)
                },
                StatusCode = 200
            };
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    }
    
    public static async Task<ComplexMessage> RestorePassword(ComplexMessage cm)
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
            return new ComplexMessage()
            {
                StatusCode = 200
            };
        }
        else
            return new ComplexMessage()
            {
                StatusCode = 404
            };
    } 
}