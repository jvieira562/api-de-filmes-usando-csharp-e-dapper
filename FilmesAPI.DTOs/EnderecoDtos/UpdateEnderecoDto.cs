﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.EnderecoDtos
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo Cep deve ter no máximo 8 caracteres.")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório.")]
        [Range(0, 9999999, ErrorMessage = "O número deve ter no mínimo 1 e no máximo 9999999.")]
        public int Numero { get; set; }
        
    }
}
