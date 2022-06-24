using System;

namespace PStudioLibrary
{
    [Serializable]
    public class Message
    {
        public byte[] Data { get; set; }
    }

    [Serializable]
    public class ComplexMessage
    {
        public Message[] Messages { get; set; } 
        public int StatusCode { get; set; }
    }
}