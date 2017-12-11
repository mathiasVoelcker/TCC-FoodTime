
angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService, categoriaService) {

  $scope.usuarioLogado = authService.getUsuario();
  $scope.filtro = {Nome: "", Endereco: "", Categoria: ""};
  // $scope.filtro.Nome = ""
  // $scope.filtro.Endereco = ""
  // $scope.filtro.Categoria = ""
  estabService.listar();
  let filtro = [];

  estabService.listarCinco().then(
      function(response){
        $scope.estabelecimentos = response.data;
        estabelecimentos = response.data;
        console.log($scope.filtro)
        // estabelecimentos.forEach(function(element) {
        //   debugger
        //   $scope.estabelecimentos[element.Id].Endereco.Latitude = element.Endereco.Latitude;
        // }, this);

        // $scope.estabelecimentos.Endereco[].Latitude= response.data.Endereco.Latitude;
        // $scope.estabelecimentos.Endereco.Longitude= response.data.Endereco.Longitude;
        if(response.data.Fotos!=undefined)
        $scope.estabelecimentos.foto = response.data.Fotos[0].Caminho;
      }
    );

    categoriaService.listar().then(
      function(response){
        $scope.categorias = response.data;
        console.log($scope.categorias)
      }
    );


    $scope.buscarPorFiltros = function (){
      console.log("dentro da funcao")
      console.log($scope.filtro);
      estabService.buscarPorFiltros($scope.filtro).then(
        function(response){
          console.log(response)
          $scope.estabelecimentos = response.data;
        }
      );
    }


  });
