using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PStudioLibrary;

namespace Server
{
    public class DbHandler
    {
        public static async Task<bool> GetMatches(User user)
        {
            using PStudioContext db = new PStudioContext();
            return await db.Users.AnyAsync(u => u.email == user.email || u.login == user.login);
        }

        public static async Task AddUserAsync(User user)
        {
            using PStudioContext db = new PStudioContext();

            db.Users.Add(user);
            await db.SaveChangesAsync();
            if (user.role == "Исполнитель")
                await db.Database.ExecuteSqlCommandAsync("INSERT INTO Photographers VALUES ({0}, DEFAULT, 0)", user.id);
            else
                await db.Database.ExecuteSqlCommandAsync("INSERT INTO Clients VALUES ({0}, 0)", user.id);

            await db.SaveChangesAsync();
        }

        public static async Task<User> GetUserAsync(string login, string password)
        {
            using PStudioContext db = new PStudioContext();
            var pwd = Services.GetHashString(password);
            var users = await db.Users.ToListAsync();
            return users.FirstOrDefault(u =>
                u.login == login && u.password == Services.GetHashString(password));
        }
        
        public static async Task<Client> GetClientAsync(User user)
        {
            using PStudioContext db = new PStudioContext();
            var cls = await db.Clients.ToListAsync();
            return cls.FirstOrDefault(c => c.id == user.id);
        }
        
        public static async Task<Photographer> GetPhotographerAsync(User user)
        {
            using PStudioContext db = new PStudioContext();
            var phs = await db.Photographers.ToListAsync();
            return phs.FirstOrDefault(p => p.id == user.id);
        }
        
        public static async Task<Dictionary<int, string>> GetOrdersPhAsync(User user)
        {
            using PStudioContext db = new PStudioContext();
            var orders = await db.Orders.ToListAsync();
            return orders.Where(or => or.p_id == user.id && !or.isCompleted)
                .Select(or => (or.id, or.message)).ToDictionary(tuple => tuple.id, tuple => tuple.message);
        }
        
        public static async Task<Dictionary<int, string>> GetOrdersClAsync(User user)
        {
            using PStudioContext db = new PStudioContext();
            var orders = await db.Orders.ToListAsync();
            return orders.Where(or => or.c_id == user.id)
                .Select(or => (or.id, or.message)).ToDictionary(tuple => tuple.id, tuple => tuple.message);
        }
        
        public static async Task<List<Photographer>> GetPhotographersAsync()
        {
            using PStudioContext db = new PStudioContext();
            return await db.Photographers.ToListAsync();
        }
        
        public static async Task<List<User>> GetUsersAsync()
        {
            using PStudioContext db = new PStudioContext();
            return await db.Users.ToListAsync();
        }
        
        public static async Task<List<Photo>> GetPhotosByOrderAsync(Order order)
        {
            using PStudioContext db = new PStudioContext();
            var photos = await db.Photos.ToListAsync();
            return photos.Where(ph => ph.or_id == order.id).ToList();
        }
        
        public static async Task<List<Order>> GetOrdersAsync()
        {
            using PStudioContext db = new PStudioContext();
            var orders = await db.Orders.ToListAsync();
            return orders;
        }
        
        public static async Task<Order> GetOrderAsync(int id)
        {
            using PStudioContext db = new PStudioContext();
            var orders = await db.Orders.ToListAsync();
            return orders.FirstOrDefault(o => o.id == id);
        }
        
        public static async Task UpdateOrder(Order order)
        {
            using PStudioContext db = new PStudioContext();
            var temp_order = await db.Orders.FirstAsync(o => o.id == order.id);
            temp_order.isCompleted = order.isCompleted;
            await db.SaveChangesAsync();
        }
        
        public static async Task DeletePhotographer(int id)
        {
            using PStudioContext db = new PStudioContext();
            var temp_user = await db.Photographers.FirstAsync(u => u.id == id);
            db.Photographers.Remove(temp_user);
            await db.SaveChangesAsync();
        }
        
        public static async Task DeleteClient(int id)
        {
            using PStudioContext db = new PStudioContext();
            var temp_user = await db.Clients.FirstAsync(u => u.id == id);
            db.Clients.Remove(temp_user);
            await db.SaveChangesAsync();
        }
        
        public static async Task DeleteUser(int id)
        {
            using PStudioContext db = new PStudioContext();
            var temp_user = await db.Users.FirstAsync(u => u.id == id);
            db.Users.Remove(temp_user);
            await db.SaveChangesAsync();
        }
        
        public static async Task DeleteUser(User user)
        {
            using PStudioContext db = new PStudioContext();
            var temp_user = await db.Users.FirstAsync(u => u.id == user.id);
            db.Users.Remove(temp_user);
            await db.SaveChangesAsync();
        }
        
        public static async Task DeleteOrder(int id)
        {
            using PStudioContext db = new PStudioContext();
            var temp_order = await db.Orders.FirstAsync(o => o.id == id);
            db.Orders.Remove(temp_order);
            await db.SaveChangesAsync();
        }
        
        public static async Task DeleteOrder(Order order)
        {
            using PStudioContext db = new PStudioContext();
            var temp_order = await db.Orders.FirstAsync(o => o.id == order.id);
            db.Orders.Remove(temp_order);
            await db.SaveChangesAsync();
        }
        
        public static async Task InsertPhotos(List<Photo> photos)
        {
            using PStudioContext db = new PStudioContext();
            db.Photos.AddRange(photos);
            await db.SaveChangesAsync();
        }
        
        public static async Task InsertOrder(Order order)
        {
            using PStudioContext db = new PStudioContext();
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }
        
        public static async Task UpdatePhotographer(Photographer photographer)
        {
            using PStudioContext db = new PStudioContext();
            var temp_ph = await db.Photographers.FirstAsync(p => p.id == photographer.id);
            temp_ph.completed_orders = photographer.completed_orders;
            temp_ph.rating = photographer.rating;
            await db.SaveChangesAsync();
        }
        
        public static async Task UpdateClient(Client client)
        {
            using PStudioContext db = new PStudioContext();
            var temp_cl = await db.Clients.FirstAsync(cl => cl.id == client.id);
            temp_cl.completed_orders = client.completed_orders;
            await db.SaveChangesAsync();
        }
    }
}