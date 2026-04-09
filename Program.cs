using System;
using System.Collections.Generic;

namespace HelloCS;

public class CanMessage
{
    public uint Id { get; set; }
    public byte[] Data { get; set; }
    public DateTime Timestamp { get; set; }

    public CanMessage(uint id, byte[] data)
    {
        Id = id;
        Data = data;
        Timestamp = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"[{Timestamp:HH:mm:ss.fff}] ID=0x{Id:X4} DLC={Data.Length} Data={BitConverter.ToString(Data)}";
    }
}

public class MessageLogger
{
    private readonly List<CanMessage> _log = new();

    public void Log(CanMessage msg)
    {
        _log.Add(msg);
        Console.WriteLine($"Logged: {msg}");
    }

    public int Count => _log.Count;

    public IEnumerable<CanMessage> MessagesWithId(uint id)
    {
        foreach (var msg in _log)
        {
            if (msg.Id == id)
                yield return msg;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CAN message logger demo");
        Console.WriteLine("------------------------");

        var logger = new MessageLogger();

        logger.Log(new CanMessage(0x0CF00400, new byte[] { 0x10, 0x20, 0x30, 0x40 }));
        logger.Log(new CanMessage(0x18FEF100, new byte[] { 0xAA, 0xBB }));
        logger.Log(new CanMessage(0x0CF00400, new byte[] { 0x11, 0x22, 0x33, 0x44 }));

        Console.WriteLine($"\nTotal messages logged: {logger.Count}");

        Console.WriteLine("\nMessages with ID 0x0CF00400:");
        foreach (var msg in logger.MessagesWithId(0x0CF00400))
        {
            Console.WriteLine($"  {msg}");
        }
    }
}