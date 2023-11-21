using Moq;
using Xunit;
using AutoFixture;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Handlers;
using Octoplex.Kernel;

namespace Octoplex.Produtos.Tests.Application
{
    public class ProdutoAddTest
    {
        [Fact(DisplayName = "Cadastro de Produtos OK")]
        public async void ValidProduto_AddIsCalled_ReturnValid()
        {
            //Arrange 
            var addProduct = new Fixture().Create<Produto>();
            var productRepositoryMock = new Mock<IProdutosRepository>();
            var addProductCommand = new ProdutoCommand(addProduct);

            productRepositoryMock.Setup(pr => pr.Adicionar(It.IsAny<Produto>())).Verifiable();
            //Verifica o retorno se é do tipo produto (addProduto = new Fixture().Create<Produto>())
            productRepositoryMock.Setup(pr => pr.Adicionar(It.IsAny<Produto>())).Returns(Task.FromResult(Result<Exception, Produto>.Of(addProduct)));
            //Passa o produto Mock para o Handler
            var addProductCommandHandler = new AdicionarProdutoCommandHandler(productRepositoryMock.Object);

            #region Testes 
            //produtoRepositoryMock.Setup(pr => pr.Adicionar(It.IsAny<Produto>())).Returns(Task.FromResult(product));

            //var proRepo = new ProdutosRepository(produtoRepositoryMock.Object);
            //var produtoRepository = new AdicionarProdutoCommandHandler(produtoRepositoryMock.Object);
            #endregion

            //Act
            var productResult = await addProductCommandHandler.Handle(addProductCommand, new CancellationToken());

            //Assert
            productRepositoryMock.Verify(pr => pr.Adicionar(It.IsAny<Produto>()), Times.Once);
            Assert.NotNull(productResult);                  //Verifica se o retorno não é nulo
            Assert.Equal(addProduct.Id, productResult.Id); //Compara se o ID dos 2 objetos

            #region Teste anterior
            //var result = produtoRepository.Equals(addProduto);

            //Assert
            //Valido se o código do produto é diferente de nulo

            //Assert.True(addProduto.Codigo != null);

            //Verifica se o objeto esperado é um produto
            #endregion

        }
    }
}