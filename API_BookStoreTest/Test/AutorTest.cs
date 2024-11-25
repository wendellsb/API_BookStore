using API_BookStoreTest.ControllersTest;
using API_BookStoreTest.Model;
using API_BookStoreTest.ModelTest;
using API_BookStoreTest.ServicesTest;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API_BookStoreTest.Test
{
    public class AutorTest
    {
        [Fact(DisplayName = "ListarAutores - Retorna Lista de Autores existentes")]
        public async Task ListarAutores_DeveRetornarListaDeAutoresComStatus200()
        {
            // Arrange
            var mockAutorInterface = new Mock<IAutorInterfaceTest>();

            // Configurar o retorno do método mockado
            var autoresEsperados = new List<AutorModelTest>
            {
                new AutorModelTest {
                    Id = 1,
                    Nome = "Autor 1",
                    DataNascimento = DateTime.Now,
                    Pais = "Brasil"
                },
                new AutorModelTest {
                    Id = 2,
                    Nome = "Autor 2",
                    DataNascimento = DateTime.Now,
                    Pais = "EUA"
                }
            };
            mockAutorInterface
                .Setup(a => a.ListarAutores())
                .ReturnsAsync(autoresEsperados);

            var controller = new AutorControllerTest(mockAutorInterface.Object);

            // Act
            var resultado = await controller.ListarAutores();

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<List<AutorModelTest>>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<List<AutorModelTest>>>(okResult.Value);

            Assert.Equal(autoresEsperados, responseModel.Data);
            mockAutorInterface.Verify(a => a.ListarAutores(), Times.Once);
        }

        [Fact(DisplayName = "CriarAutor - Retorna Criação do Autor com status 200")]
        public async Task CriarAutor_DeveRetornarVerdadeiroParaCriacaoDoAutor()
        {
            // Arrange
            var mockAutorInterface = new Mock<IAutorInterfaceTest>();

            var autorEntrada = new AutorModelTest
            {
                Id = 1,
                Nome = "Autor 1",
                DataNascimento = DateTime.Now,
                Pais = "Brasil"
            };

            var autorEsperado = new ResponseModelTest<List<AutorModelTest>>
            {
                Data = new List<AutorModelTest>
                {
                    new AutorModelTest
                    {
                        Id = 1,
                        Nome = "Autor 1",
                        DataNascimento = DateTime.Now,
                        Pais = "Brasil"
                    }
                },
                Mensagem = "Autor criado com sucesso",
                Sucesso = true
            };

            mockAutorInterface
                .Setup(a => a.CriarAutor(It.IsAny<AutorModelTest>()))
                .ReturnsAsync(autorEsperado);

            var controller = new AutorControllerTest(mockAutorInterface.Object);

            // Act
            var resultado = await controller.CriarAutor(autorEntrada);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ResponseModelTest<List<AutorModelTest>>>>(resultado);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseModel = Assert.IsType<ResponseModelTest<List<AutorModelTest>>>(okResult.Value);

            Assert.Equal(autorEsperado.Data, responseModel.Data);
            Assert.Equal(autorEsperado.Mensagem, responseModel.Mensagem);
            Assert.True(responseModel.Sucesso);

            mockAutorInterface.Verify(a => a.CriarAutor(It.IsAny<AutorModelTest>()), Times.Once);

        }

        [Fact(DisplayName = "ExcluirAutor - Retorna Exclusão do Autor com status 200")]
        public async Task ExcuirAutor_DeveRetornarVerdadeiroParaExclusaoDoAutor()
        {
            // Arrange
            int idAutor = 1;

            var mockAutorInterface = new Mock<IAutorInterfaceTest>();

            // Simulando o retorno da exclusão
            var expectedResponse = new ResponseModelTest<List<AutorModelTest>>
            {
                Data = new List<AutorModelTest>(), // Pode ser nulo ou com itens, dependendo do seu retorno esperado
                Mensagem = "Autor excluído com sucesso",
                Sucesso = true
            };

            mockAutorInterface
                .Setup(x => x.ExcluirAutor(idAutor))
                .ReturnsAsync(expectedResponse);

            var controller = new AutorControllerTest(mockAutorInterface.Object);

            // Act
            var result = await controller.ExcluirAutor(idAutor);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Verifica se é um 200 OK
            var actualResponse = Assert.IsType<ResponseModelTest<List<AutorModelTest>>>(okResult.Value); // Verifica o tipo do valor retornado

            Assert.True(actualResponse.Sucesso);
            Assert.Equal(expectedResponse.Mensagem, actualResponse.Mensagem);
            Assert.Equal(expectedResponse.Data, actualResponse.Data);

            mockAutorInterface.Verify(x => x.ExcluirAutor(idAutor), Times.Once);
        }

    }
}