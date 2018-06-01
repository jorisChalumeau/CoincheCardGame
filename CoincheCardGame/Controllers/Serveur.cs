using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CoincheCardGame.Models;

namespace CoincheCardGame.Controllers
{
    public class Serveur
    {
        private static Thread _thEcoute;

        private static void Main(string[] args)
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _thEcoute = new Thread(listen);
            _thEcoute.Start();
            Partie partie = new Partie();
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
                Console.WriteLine("Données reçues en provenance de {0}:{1}.", client.Address, client.Port);

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("CONTENU DU MESSAGE : {0}\n", message);
            }
        }
    }
}