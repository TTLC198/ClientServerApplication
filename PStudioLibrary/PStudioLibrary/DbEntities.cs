using System;

namespace PStudioLibrary
{
    [Serializable]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

    [Serializable]
    public class Order
    {
        public int id { get; set; }
        public string? message { get; set; }
        public int p_id { get; set; }
        public int c_id { get; set; }
        public bool isCompleted { get; set; }
    }
    
    [Serializable]
    public class Client
    {
        public int id { get; set; }
        public Int32? completed_orders { get; set; }
    }
    
    [Serializable]
    public class Photographer
    {
        public int id { get; set; }
        public Int32? completed_orders { get; set; }
        public Int16? rating { get; set; }
    }

    [Serializable]
    public class Photo
    {
        public int id { get; set; }
        public int or_id { get; set; }
        public byte[] data { get; set; }
    }
}