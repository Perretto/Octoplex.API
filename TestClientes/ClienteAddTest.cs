using AutoFixture;
using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Web.Application.Features.Clientes.Commands;
using Octoplex.Clientes.Web.Application.Features.Clientes.Handlers;
using Octoplex.Kernel;
using Moq;

namespace TestClientes
{
    public class ClienteAddTest
    {
        [Fact (DisplayName = "Cadastro de Clientes OK")]
        public async void ValidCliente_AddIsCalled_ReturnValid()
        {
            //Arrange
            var addCliente = new Fixture().Create<Cliente>();
            var clienteRepositoryMock = new Mock<IClientesRepository>();
            var addClienteCommand = new ClienteCommand(addCliente);

            clienteRepositoryMock.Setup(c => c.Adicionar(It.IsAny<Cliente>())).Verifiable();
            clienteRepositoryMock.Setup(c => c.Adicionar(It.IsAny<Cliente>())).Returns(Task.FromResult(Result<Exception, Cliente>.Of(addCliente)));
            //var addClienteCommandHandler = new AdicionarClienteCommandHandler(clienteRepositoryMock.Object);

            //Act
            //var clienteResult = await addClienteCommandHandler.Handle(addClienteCommand, new CancellationToken());

            //Assert
            clienteRepositoryMock.Verify(c => c.Adicionar(It.IsAny<Cliente>()), Times.Once);
            //Assert.NotNull(clienteResult);
            //Assert.Equal(addCliente.Id , clienteResult.Id);
            //Assert.Equal(addCliente.NomeCliente, clienteResult.NomeCliente);

        }
    }
}