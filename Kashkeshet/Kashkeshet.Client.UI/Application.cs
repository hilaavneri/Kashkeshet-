using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kashkeshet.Client;
using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Messages;

namespace Client.UI
{
    public class Application
    {
        public void Run()
        {
            Bootsrapper b = new Bootsrapper();
            var chat = new Chat(new List<ChatMessageInfo>(), ChatTypes.Global);
            var chats = new List<Chat>();
            chats.Add(chat);
            var writer = new ConsoleDataWriter(new ConcurrentQueue<byte[]>());
            var client = b.Create(writer,chats, "127.0.0.1",5500);
            Task.Run(()=> client.Run());
            Task.Run(() =>
            {
                while (true)
                {
                    string msg = Console.ReadLine();
                    writer.AddMsg(Encoding.ASCII.GetBytes(msg));

                }
            });
            while (true)
            {
                foreach (var c in chats)
                {
                    foreach (var item in c.Messages)
                    {
                        Console.WriteLine("GOT MESSAGAE FROM:" 
                            +item.SenderUserName);
                    }
                    c.Messages.Clear();
                }
            }
        }
    }
}
