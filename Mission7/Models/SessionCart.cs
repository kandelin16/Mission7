using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission7.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession tempSession = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = tempSession.GetJson<SessionCart>("cart") ?? new SessionCart();

            cart.session = tempSession;

            return cart;
        }

        public override void AddItem(Books book, int qty)
        {
            base.AddItem(book, qty);
            session.SetJson("cart", this);
        }
        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            session.SetJson("cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            session.Remove("cart");
        }
    }
}
