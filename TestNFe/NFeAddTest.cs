using AutoFixture;
using Octoplex.Kernel;
using Octoplex.NFe.Domain.Interface;
using Octoplex.NFe.Domain.NFe;
using Octoplex.NFe.Web.Application.Features.NFe.Commands;
using Moq;

namespace TestNFe
{
    public class NFeAddTest
    {
        [Fact (DisplayName = "Adicionar NFe OK")]
        public void ValidNFe_AddIsCalled_ReturnValid()
        {
            //Arrange
            var addNFe = new Fixture().Create<NFe>();
            var nfeRepositoryMock = new Mock<INFeRepository>();
            var addNFeCommand = new NFeCommand(addNFe);
            nfeRepositoryMock.Setup(nf => nf.GerarXMLNFe(It.IsAny<NFe>())).Verifiable();
            nfeRepositoryMock.Setup(nf => nf.GerarXMLNFe(It.IsAny<NFe>())).Returns(Task.FromResult(Result<Exception, NFe>.Of(addNFe)));


            //Act


            //Assert

        }
    }
}