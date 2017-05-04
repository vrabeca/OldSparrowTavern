using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace OldSparrowTavern
{
    public class ChatHub : Hub
    {
        static ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void SendToSpecific(string name, string message, string to)
        {
            Clients.Caller.broadcastMessage(name, message);
            Clients.Client(dic[to]).broadcastMessage(name, message);
        }

        public void Notify(string name, string id)
        {
            dic.TryAdd(name, id);
            foreach (KeyValuePair<String, String> entry in dic)
            {
            Clients.Caller.online(entry.Key);
            }
            Clients.Others.enters(name);
            
        }
        
        public Task OnDisconnected()
        {
            var name = dic.FirstOrDefault(x => x.Value == Context.ConnectionId.ToString());
            string s;
            dic.TryRemove(name.Key, out s);

            return Clients.All.disconnected(name.Key);
        }
    }
}