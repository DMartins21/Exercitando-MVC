using ExerMVC.Context;

namespace ExerMVC.Models
{
    public class CarrinhoCompra
    {
        private readonly ExerContext _context;

        public CarrinhoCompra(ExerContext context)
        {
            _context = context;
        }
        
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessãp

            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtém um serviço do tipo do nosso contexto

            var context = services.GetService<ExerContext>();

            // obtém ou gera o Id do carrinho na Sessão

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
    }
}
