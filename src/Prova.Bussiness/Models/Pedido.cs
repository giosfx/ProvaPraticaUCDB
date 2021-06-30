﻿using System;

namespace Prova.Bussiness.Models
{
    public class Pedido : Entity
    {
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}