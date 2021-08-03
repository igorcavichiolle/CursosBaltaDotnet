using System;
using System.Collections.Generic;

namespace PropriedadesPrivadas
{
    /// <summary>
    /// Classe que representa o pedido em s�, classe publica que pode ser instanciada e manipulada
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Atributo privado do tipo lista (IList) onde podemos fazer as opera��es de adicionar ou remover itens
        /// Privado pois n�o ser� visivel em outra camada do c�digo, apenas internamente nesta classe
        /// </summary>
        private IList<OrderItem> _items;

        /// <summary>
        /// Construtor que recebe o cliente, quando for instanciado a classe Order deve-se obrigatoriamente passar um novo Customer
        /// Demais parametros como Number, Date e _items ser�o criado de maneira automatica quando for instanciado a classe Order
        /// </summary>
        /// <param name="customer">Cliente dono do pedido</param>
        /// <param name="_items">Lista interna dos itens do pedido, essa lista n�o � acessada externamente</param>
        public Order(string customer)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            Date = DateTime.Now;
            Customer = customer;
            _items = new List<OrderItem>();
        }

        /// <summary>
        /// Demais atributos, Number, Date e Customer tem seu setter como private, 
        /// onde n�o � possivel usar uma instancia da classe Order para passar valores para eles
        /// </summary>
        public string Number { get; private set; }  
        public DateTime Date { get; private set; }
        public string Customer { get; private set; }

        /// <summary>
        /// Essa � o nosso modelo de lista virtual em formato de IEnumerable
        /// IEnumerable n�o permite o uso do m�todo lista.Add(item)
        /// Essa lista n�o ser� usada, foi criada apenas para n�o permitir a inclusao de itens por fora
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
        /// M�todo que ser� acessivel por uma instancia para adiconar itens ao pedido
        /// Esse m�todo trata a entrada de dados para n�o deixar inserir dados errados
        /// ao final do m�todo insere o item na nossa lista privada _items
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(OrderItem item)
        {
            if (item == null)
                throw new Exception("Item inv�lido");

            _items.Add(item);
        }

        /// <summary>
        /// M�todo publico que percorre a nossa lista Items chamano o m�todo GetTotalItem para cada item do pedido
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