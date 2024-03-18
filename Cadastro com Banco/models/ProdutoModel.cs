using System.ComponentModel.DataAnnotations;

namespace Cadastro_com_Banco.models;

public class ProdutoModel
{
    [Key]
    public long ProdutoID { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
    public bool IsAcabando { get; set; }
}