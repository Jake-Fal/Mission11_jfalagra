﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Mission09_jfalagra.Infrastructure;
using System;
using System.Text.Json.Serialization;

namespace Mission09_jfalagra.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }
        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
