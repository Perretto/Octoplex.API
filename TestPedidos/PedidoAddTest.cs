using AutoFixture;
using Octoplex.Kernel;
using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Commands;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Handlers;
using Moq;

namespace TestPedidos
{
    public class PedidoAddTest
    {
        [Fact (DisplayName = "Adicionar Pedido OK")]
        public async void ValidPedido_AddIsCalled_ReturnValid()
        {
            //Arrange
            var addPedido = new Fixture().Create<Pedido>();
            var pedidoRepositoryMock = new Mock<IPedidosRepository>();
            var addPedidoCommand = new PedidoCommand(addPedido);

            pedidoRepositoryMock.Setup(x => x.Adicionar(It.IsAny<Pedido>())).Verifiable();
            pedidoRepositoryMock.Setup(x => x.Adicionar(It.IsAny<Pedido>())).Returns(Task.FromResult(Result<Exception, Pedido>.Of(addPedido)));

            //var addPedidoCommandHandler = new AdicionarPedidoCommandHandler(pedidoRepositoryMock.Object);

            //Act
            //var pedidoResult = await addPedidoCommandHandler.Handle(addPedidoCommand, new CancellationToken());

            //Assert
            //pedidoRepositoryMock.Verify(x => x.Adicionar(It.IsAny<Pedido>()), Times.Once);
            //Assert.NotNull(pedidoResult);
            //Assert.Equal(addPedido.Id, pedidoResult.Id);

        }
    }
}