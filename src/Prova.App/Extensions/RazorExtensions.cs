using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Prova.App.Extensions
{
    public static class RazorExtensions
    {
        public static string CorValidade(this RazorPage page, DateTime dataValidade)
        {
            int diferencaDiasAtualValidade = (dataValidade - DateTime.Today).Days;

            if (diferencaDiasAtualValidade > 0 && diferencaDiasAtualValidade < 4) return "background-color:orange";

            if (diferencaDiasAtualValidade > 3) return "background-color:green";

            return "background-color:red";
            
        }

        public static string DataMascara(this RazorPage page, DateTime dataValidade)
        {
            return dataValidade.ToString("dd/MM/yyyy");
        }

        public static string DisplayDesconto(this RazorPage page, DateTime dataValidade)
        {
            return (dataValidade - DateTime.Today).Days < 3 ? "none" : "";
        }
    }
}