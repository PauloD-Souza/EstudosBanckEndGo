using System.ComponentModel;

namespace AtividadesGoo;

public class ValidacaoDados
{
    private String nome {get; set;}
    private long cpf {get;set;}
    private DateTime dataNascimento {get;set;}
    private float rendaMensal {get;set;}
    private char estadoCivil {get;set;}
    private int dependentes {get;set;}

    public ValidacaoDados (String nome, long cpf, DateTime dataNascimento, float rendaMensal, char estadoCivil, int dependentes){
        this.nome = nome;
        this.cpf = cpf;
        this.dataNascimento = dataNascimento;
        this.rendaMensal = rendaMensal;
        this.estadoCivil = estadoCivil;
        this.dependentes = dependentes;
    }
}
