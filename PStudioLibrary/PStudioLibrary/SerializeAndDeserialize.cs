using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PStudioLibrary
{
    class CustomBinder : SerializationBinder
    {
        public override Type BindToType
            (string assemblyName, string typeName)
        {

            Assembly currentasm =
                Assembly.GetExecutingAssembly();

            return Type.GetType($"{currentasm.GetName().Name}.{typeName.Split('.')[1]}");
        }
    }

    public class SerializeAndDeserialize
    {
        public static Message Serialize(object
            anySerializableObject)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, anySerializableObject);
                return new Message { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(byte[] data)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream(data))
            {
                return formatter.Deserialize(memoryStream);
            }
        }
        
        public static Message SerializeDictionary(Dictionary<int, string> dictionary)
        {
            using (var memoryStream = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(memoryStream);
                writer.Write(dictionary.Count);
                foreach (var obj in dictionary)
                {
                    writer.Write(obj.Key);
                    writer.Write(obj.Value);
                }
                return new Message {Data = memoryStream.ToArray()};
            }
        }

        public static Dictionary<int, string> DeserializeDictionary(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                BinaryReader reader = new BinaryReader(memoryStream);
                int count = reader.ReadInt32();
                var dictionary = new Dictionary<int, string>(count);
                for (int n = 0; n < count; n++)
                {
                    var key = reader.ReadInt32();
                    var value = reader.ReadString();
                    dictionary.Add(key, value);
                }
                return dictionary;
            }
        }
    }
}