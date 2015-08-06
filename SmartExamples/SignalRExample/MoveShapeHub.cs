using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Security;

namespace SignalRExample
{
    public static class UserCounter
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public void dragShape(int x, int y)
        {
            Clients.Others.shapeMoved(x, y);    // method will be called from the client, when user move shape
        }

        public override Task OnConnected()
        {
            UserCounter.ConnectedIds.Add(Context.ConnectionId);
            Clients.All.userConnected(UserCounter.ConnectedIds.Count());
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            return this.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserCounter.ConnectedIds.Remove(Context.ConnectionId);
            Clients.All.userConnected(UserCounter.ConnectedIds.Count());
            return base.OnDisconnected(stopCalled);
        }
    }
}