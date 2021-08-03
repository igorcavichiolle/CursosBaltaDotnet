using System;
using System.Collections.Generic;

namespace PropriedadesPrivadas
{
    /// <summary>
    /// Classe que representa o pedido em sí, classe publica que pode ser instanciada e manipulada
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Atributo privado do tipo lista (IList) onde podemos fazer as operações de adicionar ou remover itens
        /// Privado pois não será visivel em outra camada do código, apenas internamente nesta classe
        /// </summary>
        private IList<OrderItem> _items;

        /// <summary>
        /// Construtor que recebe o cliente, quando for instanciado a classe Order deve-se obrigatoriamente passar um novo Customer
        /// Demais parametros como Number, Date e _items serão criado de maneira automatica quando for instanciado a classe Order
        /// </summary>
        /// <param name="customer">Cliente dono do pedido</param>
        /// <param name="_items">Lista interna dos itens do pedido, essa lista não é acessada externamente</param>
        public Order(string customer)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            Date = DateTime.Now;
            Customer = customer;
            _items = new List<OrderItem>();
        }

        /// <summary>
        /// Demais atributos, Number, Date e Customer tem seu setter como private, 
        /// onde não é possivel usar uma instancia da classe Order para passar valores para eles
        /// </summary>
        public string Number { get; private set; }  
        public DateTime Date { get; private set; }
        public string Customer { get; private set; }

        /// <summary>
        /// Essa é o nosso modelo de lista virtual em formato de IEnumerable
        /// IEnumerable não permite o uso do método lista.Add(item)
        /// Essa lista não será usada, foi criada apenas para não permitir a inclusao de itens por fora
        /// O get desta lista retona a nossa lista privada _items
        /// </summary>
        public IEnumerable<OrderItem> Items
        {
            get
            {
                return _items;
            }
        }

        /// <summary>
        /// Método que será acessivel por uma instancia para adiconar itens ao pedido
        /// Esse método trata a entrada de dados para não deixar inserir dados errados
        /// ao final do método insere o item na nossa lista privada _items
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(OrderItem item)
        {
            if (item == null)
                throw new Exception("Item inválido");

            _items.Add(item);
        }

        /// <summary>
        /// Método publico que percorre a nossa lista Items chamano o método GetTotalItem para cada item do pedido
        /// </summary>
        /// <returns>Retona o valor total de todos os itens do pedido</returns>
        public decimal GetTotalOrder()
        {
            var total = 0m;
            foreach (var item in Items)
            {
                total += item.GetTotalItem();
            }

            return total;
        }
    }
}