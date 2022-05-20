using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAlfaAPI.Model
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} percisa ter entre {2} e {1} caracteres", MinimumLength =2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} percisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Documento { get; set; }

        public int TipoFornecedor { get; set; }

        public bool Ativo { get; set; }
    }
}
