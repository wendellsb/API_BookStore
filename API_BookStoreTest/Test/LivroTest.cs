using API_BookStoreTest.ControllersTest;
using API_BookStoreTest.ModelTest;
using API_BookStoreTest.ServicesTest;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace API_BookStoreTest.Test
{
    public class LivroTest
    {
        [Fact(DisplayName = "ListarLivro - Retorna Lista de Livro existentes")]
        public async Task ListarLivros_DeveRetornarListaDeLivrosComStatus200()
        {
            // Arrange
            var mockLivroInterface = new Mock<ILivroInterfaceTest>();

            // Configurar o retorno do método mockado
            var livrosEsperados = new List<LivroModelTest>
            {
                new LivroModelTest {
                    Id = 1,
                    Titulo = "Harry Potter",
                    AutorId = 1,
                    Categoria = "Fantasia",
                    DataPublicacao = DateTime.Now,
                    Preco = 40,
                    QuantidadeEstoque = 4
                },
                new LivroModelTest {
                    Id = 2,
                    Titulo = "Harry Potter 2",
                    AutorId = 2,
                    Categoria = "Fantasia",
                    DataPublicacao = DateTime.Now,
                    Preco = 46,
                    QuantidadeEstoque = 6
                }
             };
            mockLivroInterface
                .Setup(a => a.ListarLivros())
                .ReturnsAsync(livrosEsperados);

            var controller = new LivroControllerTest(mockLivroInterface.Object);

            // Act
            var resultado = await controller.ListarLivros();

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<List<LivroModelTest>>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<List<LivroModelTest>>>(okResult.Value);

            Assert.Equal(livrosEsperados, responseModel.Data);
            mockLivroInterface.Verify(a => a.ListarLivros(), Times.Once);
        }



        [Fact(DisplayName = "CriarLivro - Retorna Criação do Livro com status 200")]
        public async Task CriarLivro_DeveRetornarVerdadeiroParaCriacaoDoLivro()
        {
            // Arrange
            var mockLivroInterface = new Mock<ILivroInterfaceTest>();

            var livroEntrada = new LivroModelTest
            {
                Id = 2,
                Titulo = "Harry Potter",
                AutorId = 2,
                Categoria = "Fantasia",
                DataPublicacao = DateTime.Now,
                Preco = 30,
                QuantidadeEstoque = 10
            };

            var livroEsperado = new ResponseModelTest<List<LivroModelTest>>
            {
                Data = new List<LivroModelTest>
                {
                    new LivroModelTest
                    {
                        Id = 2,
                        Titulo = "Harry Potter",
                        AutorId = 2,
                        Categoria = "Fantasia",
                        DataPublicacao = DateTime.Now,
                        Preco = 30,
                        QuantidadeEstoque = 10
                    }
                },
                Mensagem = "Livro criado com sucesso",
                Sucesso = true
            };

            mockLivroInterface
                .Setup(a => a.CriarLivro(It.IsAny<LivroModelTest>()))
                .ReturnsAsync(livroEsperado);

            var controller = new LivroControllerTest(mockLivroInterface.Object);

            // Act
            var resultado = await controller.CriarLivro(livroEntrada);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<List<LivroModelTest>>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<List<LivroModelTest>>>(okResult.Value);

            Assert.Equal(livroEsperado.Data, responseModel.Data);
            Assert.Equal(livroEsperado.Mensagem, responseModel.Mensagem);
            Assert.True(responseModel.Sucesso);

            mockLivroInterface.Verify(a => a.CriarLivro(It.IsAny<LivroModelTest>()), Times.Once);

        }


        [Fact(DisplayName = "ExcluirLivro - Retorna Exclusão do Livro com status 200")]
        public async Task ExcuirLivro_DeveRetornarVerdadeiroParaExclusaoDoLivro()
        {
            // Arrange
            int idLivro = 1;

            var mockLivroInterface = new Mock<ILivroInterfaceTest>();

            // Simulando o retorno da exclusão
            var expectedResponse = new ResponseModelTest<List<LivroModelTest>>
            {
                // Pode ser nulo ou com itens, dependendo do seu retorno esperado
                Data = new List<LivroModelTest>(),
                Mensagem = "Livro excluído com sucesso",
                Sucesso = true
            };

            mockLivroInterface
                .Setup(x => x.ExcluirLivro(idLivro))
                .ReturnsAsync(expectedResponse);

            var controller = new LivroControllerTest(mockLivroInterface.Object);

            // Act
            var result = await controller.ExcluirLivro(idLivro);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualResponse = Assert.IsType<ResponseModelTest<List<LivroModelTest>>>(okResult.Value); // Verifica o tipo do valor retornado

            Assert.True(actualResponse.Sucesso);
            Assert.Equal(expectedResponse.Mensagem, actualResponse.Mensagem);
            Assert.Equal(expectedResponse.Data, actualResponse.Data);

            mockLivroInterface.Verify(x => x.ExcluirLivro(idLivro), Times.Once);
        }


        [Fact(DisplayName = "BuscarLivrosTitulo - Retorna livro com sucesso e status 200")]
        public async Task BuscarLivrosTitulo_DeveRetornarLivroEStatus200()
        {
            // Arrange
            var mockLivroInterface = new Mock<ILivroInterfaceTest>();

            string titulo = "O Senhor dos Anéis";

            var livroEsperado = new ResponseModelTest<LivroModelTest>
            {
                Data = new LivroModelTest
                {
                    Id = 2,
                    Titulo = "O Senhor dos Anéis",
                    AutorId = 2,
                    Categoria = "Fantasia",
                    DataPublicacao = DateTime.Now,
                    Preco = 30,
                    QuantidadeEstoque = 10
                },
                Mensagem = "Livro encontrado.",
                Sucesso = true
            };

            mockLivroInterface
                .Setup(l => l.BuscarLivrosTitulo(titulo))
                .ReturnsAsync(livroEsperado);

            var controller = new LivroControllerTest(mockLivroInterface.Object);

            // Act
            var resultado = await controller.BuscarLivrosTitulo(titulo);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<LivroModelTest>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<LivroModelTest>>(okResult.Value);

            Assert.Equal(livroEsperado.Data, responseModel.Data);
            Assert.Equal(livroEsperado.Mensagem, responseModel.Mensagem);
            Assert.True(responseModel.Sucesso);

            // Verificar que o método foi chamado exatamente uma vez com o parâmetro correto
            mockLivroInterface.Verify(l => l.BuscarLivrosTitulo(titulo), Times.Once);
        }


        [Fact(DisplayName = "CompraLivros - Retorna livro atualizado com sucesso e status 200")]
        public async Task CompraLivros_DeveRetornarLivroAtualizadoEStatus200()
        {
            // Arrange
            var mockLivroInterface = new Mock<ILivroInterfaceTest>();

            int idLivro = 1;
            int quantidade = 10;

            // Configurar o retorno esperado do mock
            var livroAtualizado = new ResponseModelTest<LivroModelTest>
            {
                Data = new LivroModelTest
                {
                    Id = 1,
                    Titulo = "O Senhor dos Anéis",
                    AutorId = 2,
                    Categoria = "Fantasia",
                    DataPublicacao = DateTime.Now,
                    Preco = 30,
                    QuantidadeEstoque = 10 // Estoque atualizado
                },
                Mensagem = "Compra realizada com sucesso.",
                Sucesso = true
            };

            mockLivroInterface
                .Setup(l => l.CompraLivros(idLivro, quantidade))
                .ReturnsAsync(livroAtualizado);

            var controller = new LivroControllerTest(mockLivroInterface.Object);

            // Act
            var resultado = await controller.CompraLivros(idLivro, quantidade);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<LivroModelTest>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<LivroModelTest>>(okResult.Value);

            Assert.Equal(livroAtualizado.Data, responseModel.Data);
            Assert.Equal(livroAtualizado.Mensagem, responseModel.Mensagem);
            Assert.True(responseModel.Sucesso);

            // Verificar que o método foi chamado exatamente uma vez com os parâmetros corretos
            mockLivroInterface.Verify(l => l.CompraLivros(idLivro, quantidade), Times.Once);
        }
    }
}
