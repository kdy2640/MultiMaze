﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeServer
{
    public class Player
    {
        public Socket clientSocket;
        public int PlayerCode;
        public bool isExist;
    }
}
