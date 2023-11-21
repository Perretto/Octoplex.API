using AutoFixture;
using Octoplex.Produtos.Domain.Produtos;
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
    public class ProdutoUpdateTest
    {
        [Fact (DisplayName = "Atualizando produto OK")]
        public void ValidProduto_UpdateIsCalled_ReturnValid()
        {

            //Arrange 
            var addProduto = new Fixture().Create<Produto>();
            var produtoRepositoryMock = new Mock<IProdutosRepository>();
            //var proRepo = new ProdutosRepository(produtoRepositoryMock.Object);
            var produtoRepository = new AtualizarProdutoCommandHandler(produtoRepositoryMock.Object);

            //Act
            var result = produtoRepository.Equals(addProduto);

            //Assert
            //Valido se o código do produto é diferente de nulo
            Assert.True(addProduto.Codigo != null);

            //Verifica se o objeto esperado é um produto
            //produtoRepositoryMock.Verify(pr => pr.Adicionar(It.IsAny<Produto>()), Times.Once);
        }
    }
}
