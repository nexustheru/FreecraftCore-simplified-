using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreecraftCore.API;
using FreecraftCore.Crypto;
using FreecraftCore.Handlers;
using FreecraftCore.Network;
using FreecraftCore.Packet;
using FreecraftCore.Serializer;

namespace FreeCraftCoreTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FreecraftCore.Packet.Auth.AuthenticationPacket fpack;
           
        }
    }
}
