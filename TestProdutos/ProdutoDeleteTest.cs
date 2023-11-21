using AutoFixture;
using Octoplex.Kernel;
using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using Octoplex.Produtos.Web.Application.Features.Produtos.Handlers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProdutos
{
    public class ProdutoDeleteTest
    {
        [Theory (DisplayName = "Delete de Produtos por ID OK")]
        [InlineData(3)]
        public void ValidProduto_DeleteIsCalled_ReturnValid(int _id)
        {
            //Arrange
            var addProduto = new Fixture().Create<Produto>();
            var produtoRepositoryMock = new Mock<IProdutosRepository>();
            
            var deleteProdutoCommand = new ExcluirProdutoCommand(_id);
            produtoRepositoryMock.Setup(pr => pr.Excluir(_id)).Verifiable();
            produtoRepositoryMock.Setup(pr => pr.Excluir(_id)).Returns(Task.FromResult(Result<Exception, Produto>.Of(addProduto)));
            
            var deleteProdutoCommandHandler = new ExcluirProdutoCommandHandler(produtoRepositoryMock.Object);

            //Act
            var deleteResult = deleteProdutoCommandHandler.Handle(deleteProdutoCommand, new CancellationToken());

            //Assert
            produtoRepositoryMock.Verify(pr => pr.Excluir(_id), Times.Once());
            Assert.Equal(addProduto.Id, deleteResult.Result.Id);
            Assert.Equal(addProduto.Descricao, deleteResult.Result.Descricao);

            #region Testando 21-11-2022
            ////Arrange
            //var addProduto = new Fixture().Create<Produto>();
            //var produtoRepositoryMock = new Mock<IProdutosRepository>();
            ////var proRepo = new ProdutosRepository(produtoRepositoryMock.Object);
            //var produtoRepository = new ExcluirProdutoCommandHandler(produtoRepositoryMock.Object);

            ////Act
            //var result = produtoRepository.Equals(addProduto);

            ////Assert
            ////Valido se o código do produto é diferente de nulo
            //Assert.True(addProduto.Codigo != null);

            ////Verifica se o objeto esperado é um produto
            ////produtoRepositoryMock.Verify(pr => pr.Adicionar(It.IsAny<Produto>()), Times.Once);
            #endregion

        }
    }
}
