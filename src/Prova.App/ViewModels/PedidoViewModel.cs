using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prova.App.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        [DisplayName("Data de Vencimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVencimento { get; set; }
    }
}
