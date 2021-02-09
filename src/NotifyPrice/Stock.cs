using System;
using System.Collections.Generic;

namespace NotifyPrice
{
    public abstract class Stock
    {
        private decimal _price;
        private readonly List<INotity> _objservers = new();
        public Stock(string symbol, decimal price)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new System.ArgumentException($"'{nameof(symbol)}' não pode ser nulo nem vazio.", nameof(symbol));
            }

            Symbol = symbol;
            _price = price;
        }

        public string Symbol { get; }
        public decimal Price 
        { 
            get => _price;
            set 
            {
                _price = value;
                Notify();
            }
            
        }

        public DateTime Date { get; set; }

        public void Notify() => _objservers.ForEach(n => n.Fire(this));
         public void Subscribe(INotity notity)
        {
            _objservers.Add(notity);
            Console.WriteLine($"Notificando que {notity.Trader.Email} está recebendo atualizãções de {Symbol}");
        }

        public void UnSubscribe(INotity notity)
        {
            _objservers.Remove(notity);
            Console.WriteLine($"Notificando que {notity.Trader.Email} NÃO está recebendo atualizãções de {Symbol}");
        }
        

    }
}