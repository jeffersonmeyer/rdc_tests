using Dapper;
using RDC.Tests.PersonalFinances.Models;
using System.Collections.Generic;
using System.Dynamic;

namespace RDC.Tests.PersonalFinances.DataAccess
{
    public class LancamentosDataAccess
    {
        public void InserirLancamentos(IEnumerable<Lancamento> lancamentos)
        {
            var parameters = new List<DynamicParameters>();

            foreach (var item in lancamentos)
            {
                var valor = item.Valor;
                if((item.Tipo=="D" && item.Valor > 0) || (item.Tipo == "C" && item.Valor < 0))
                {
                    valor = item.Valor * -1;
                }

                var par = new DynamicParameters();
                par.Add("@Data", item.Data);
                par.Add("@Valor", valor);
                par.Add("@Descricao", item.Descricao);
                par.Add("@Conta", item.Conta);
                par.Add("@Tipo", item.Tipo);
                parameters.Add(par);
            }

            DataAccessBase.ExecuteProc("InserirLancamento", parameters);
        }

        public Totalizacao ObterTotalizadoresELancamentos(int ano, int mes)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Ano", ano);
            parameters.Add("@Mes", mes);
            var lancamentos = DataAccessBase.GetProcResult<Lancamento>("ObterLancamentosPorMes", parameters);
            foreach (var lancamento in lancamentos)
            {
                if (lancamento.Valor < 0)
                {
                    lancamento.Valor *= -1;
                }
            }

            var totalizadores = DataAccessBase.GetProcResult<Total>("ObterTotalizadoresPorMes", parameters);

            var resultado = new Totalizacao
            {
                Lancamentos = lancamentos,
                Totalizadores = MapearTotalizadores(totalizadores)
            };

            return resultado;
        }

        private object MapearTotalizadores(IEnumerable<Total> totais)
        {
            var resultado = new ExpandoObject() as IDictionary<string, object>;
            var saldo = 0M;
            foreach (var total in totais)
            {
                saldo += total.Valor;
                resultado.Add(total.Conta, total.Valor);
            }

            resultado.Add("Saldo", saldo);
            return resultado;
        }
    }
}
