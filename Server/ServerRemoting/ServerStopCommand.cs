﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAServer.ServerRemoting
{
    class ServerStopCommand : IRemoteCommand
    {
        public string HelpText => "Stop a server. Requires one argument: server name";

        public RemotingResponse OnCommandRun(List<string> args)
        {
            var handle = args[0];
            if (!Program.VirtualServers.ContainsKey(handle))
                return new RemotingResponse() {message = "Server not found", status = true};

            Program.StopServer(handle);
            return new RemotingResponse() { message = "Server stopped", status = true};
        }
    }
}