using AutoFixture;
using Octoplex.Empresas.Domain.Empresas;
using Moq;

namespace TestEmpresa
{
    public class EmpresaAddTest
    {
        [Fact(DisplayName = "Cadastro de Empresa OK")]
        public async void ValidEmpresa_AddIsCalled_ReturnValid()
        {
            //Arrange
            var addEmpresa = new Fixture().Create<Empresa>();
            var produtoRepositoryMock = new Mock<IEmpresaRepository>();
           
            //Act

            //Assert
        }
    }
}