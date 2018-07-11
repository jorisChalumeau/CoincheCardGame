using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Server.Models;

namespace Server.Controllers
{
    public class Serveur
    {
        private static Thread _thEcoute;
        private static Partie partie;
        private static void Main(string[] args)
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _thEcoute = new Thread(listen);
            _thEcoute.Start();
            partie = new Partie();
        }

        private static void listen()
        {
            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5000);
            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                string message = Encoding.Default.GetString(data);
                if (message.Substring(0, 3) == "log")
                {
                    ArrayList p = new ArrayList();
                    p.Add(message.Substring(3));
                    p.Add(client.Address.ToString());
                    p.Add(client.Port);
                    if (partie.addPlayer(p))
                    {
                        ArrayList players = partie.getPlayers();
                        ArrayList player = new ArrayList();
                        for (int i = 0; i < players.Count; i++)
                        {
                            player = (ArrayList)players[i];
                            Console.WriteLine(player);
                            if(player != null)
                                sendMessage("Welcome " + message.Substring(3), player[1].ToString(), (int) player[2]);
                        }
                    } else
                    {
                        sendMessage("Sorry "+p[0]+", the game is already full",p[1].ToString(),(int)p[2]);
                    }
                    
                }                
            }
        }
        
        private static void sendMessage(string message, string address, int port)
        {
            //Sérialisation du message en tableau de bytes.
            byte[] msg = Encoding.Default.GetBytes(message);
            UdpClient server = new UdpClient();
            Console.WriteLine(address);
            Console.WriteLine(port);
            //La méthode Send envoie un message UDP.
            server.Send(msg, msg.Length, address, port);
            server.Close();
        }
    }
}