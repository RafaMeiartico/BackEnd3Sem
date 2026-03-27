using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    [Column("idContato")]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [StringLength(100)]
    public string FormaContato { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    public Guid? IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoContatoNavigation { get; set; }
}
