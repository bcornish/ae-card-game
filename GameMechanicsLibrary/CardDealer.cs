using System;
using System.Collections.Generic;
using System.Text;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

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
                    necessaryCards++;
                }
                else if (necessaryCards < 3)
                {
                    dealtCards.Add(card);
                    necessaryCards++;
                }
            }
                return cards;
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
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void ShuffleSystemCards(List<SystemCard> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                SystemCard value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
