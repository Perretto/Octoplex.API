using AutoFixture;
using Octoplex.Kernel;
using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Commands;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Handlers;
using Moq;

namespace TestUsuarios
{
    public class UsuarioAddTest
    {
        [Fact(DisplayName = "Adicionar Usuario OK")]
        public async void ValidUser_AddIsCalled_ReturnValid()
        {
            //Arrange
            var addUser = new Fixture().Create<Usuario>();
            var userRepositoryMock = new Mock<IUsuarioRepository>();
            var addUserCommand = new UsuarioCommand(addUser);
            userRepositoryMock.Setup(u => u.Adicionar(It.IsAny<Usuario>())).Verifiable();
            userRepositoryMock.Setup(u => u.Adicionar(It.IsAny<Usuario>())).Returns(Task.FromResult(Result<Exception, Usuario>.Of(addUser)));

            var addUsuarioCommandHandler = new AdicionarUsuarioCommandHandler(userRepositoryMock.Object);

            //Act
            var usuarioResult = await addUsuarioCommandHandler.Handle(addUserCommand, new CancellationToken());

            //Assert
            userRepositoryMock.Verify(u => u.Adicionar(It.IsAny<Usuario>()), Times.Once);
            Assert.NotNull(usuarioResult);
            Assert.Equal(addUser.Id, usuarioResult.Id);

        }
    }
}