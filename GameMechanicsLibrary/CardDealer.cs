using System;
using System.Collections.Generic;
using System.Text;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;
using System.Security.Cryptography;

namespace GameMechanicsLibrary
{
    public class CardDealer
    {
        public List<Card> ListAllCards()
        {
            // get all records and convert them to models
            CardDatabase database = new CardDatabase();
            database.OpenConnection();
            List<CardRecord> records = database.RequestAllCards();
            List<Card> cards = new List<Card>();
            foreach (CardRecord cardRecord in records)
            {
                Card holderCard = new Card();
                holderCard.PopulateCardFromRecord(cardRecord);
                cards.Add(holderCard);
            }
            // randomize them
            ShuffleCards(cards);
            database.CloseConnection();
            return cards;
        }
        // Given a sensor, give 1 right card and 2 random cards
        public List<Card> DealCardsForSensor(SystemCard system)
        {
            List<Card> cards = ListAllCards();
            // run them through matcher in random order until a match is found
            CardMatcher matcher = new CardMatcher();
            int necessaryCards = 3;
            List<Card> dealtCards = new List<Card>();
            foreach (Card card in cards)
            {
                if (matcher.CheckForMatch(card, system))
                {
                    dealtCards.Add(card);
                    
                }
                else if (necessaryCards > 1)
                {
                    dealtCards.Add(card);
                    necessaryCards--;
                }
            }
                return dealtCards;
        }

        // Give a random sensor
        public SystemCard ChooseRandomSensor()
        {
            // get all records and convert them to models
            List<SystemCard> cards = GenerateSystemList();
            return cards[0];
        }
        // Give a list of n sensors in a random order
        public List<SystemCard> GenerateSystemList()
        {
            // get all records and convert them to models
            SensorDatabase database = new SensorDatabase();
            database.OpenConnection();
            List<SensorRecord> records = database.RequestAllSensors();
            List<SystemCard> cards = new List<SystemCard>();
            foreach (SensorRecord record in records)
            {
                SystemCard holderCard = new SystemCard();
                holderCard.PopulateSystemFromRecord(record);
                cards.Add(holderCard);
            }
            ShuffleSystemCards(cards);
            return cards;
        }

        private void ShuffleCards(List<Card> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void ShuffleSystemCards(List<SystemCard> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                SystemCard value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
