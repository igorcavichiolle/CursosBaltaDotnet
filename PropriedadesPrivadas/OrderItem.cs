namespace PropriedadesPrivadas
{
    /// <summary>
    /// Classe que representa o item de um pedido
    /// � uma classe publica que pode ser instanciada e manipulda sem restri��es
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// M�todo construtor que obriga quando um novo OrderItem for instanciado passar os parametros product, quantity e price
        /// </summary>
        /// <param name="product">Nome do produto</param>
        /// <param name="quantity">Quantidade</param>
        /// <param name="price">Pre�o</param>
        public OrderItem(string product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// M�todo que retona a soma do pre�o do produto e a quantide pedida
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalItem()
        {
            return Price * Quantity;
        }
    }
}