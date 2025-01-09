using System.Security.Claims;

namespace Business.Interfaces
{
    public interface IUsuario
    {
        public string Name { get; }
        public Guid ObterIdUsuario();
        public string ObterEmailUsuario();
        public bool EstaAltenticado();
        public bool EstaEmRegra(string role);
        public IEnumerable<Claim> ObterClaim();
    }
}
