
using System.Collections.ObjectModel;

namespace AtividadesGoo
{
    public class ListaIntervalo
    {
        private List<Intervalo> _intervalos;

        public ListaIntervalo()
        {
            _intervalos = new List<Intervalo>();
        }

        public void Add(Intervalo novoIntervalo)
        {
            foreach (var intervalo in _intervalos)
            {
                if (intervalo.TemIntersecao(novoIntervalo))
                {
                    throw new ArgumentException("Novo intervalo se sobrepõe a um intervalo existente.");
                }
            }
            _intervalos.Add(novoIntervalo);
            _intervalos = _intervalos.OrderBy(i => i.dataHoraInicial).ToList();
        }

        public IReadOnlyList<Intervalo> Intervalos
        {
            get
            {
                return new ReadOnlyCollection<Intervalo>(_intervalos);
            }
        }

        public override string ToString()
        {
            return $"ListaIntervalo({string.Join(", ", _intervalos)})";
        }
    }
}