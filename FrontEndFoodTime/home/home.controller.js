
angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService, categoriaService) {

  $scope.usuarioLogado = authService.getUsuario();
  $scope.filtro = { Nome: "", Endereco: "", Categoria: "" };
  $scope.usarLocalizacao = false
  // $scope.filtro.Nome = ""
  // $scope.filtro.Endereco = ""
  // $scope.filtro.Categoria = ""
  estabService.listar();
  navigator.geolocation.getCurrentPosition(function (position) {
    $scope.pos = {
      lat: position.coords.latitude,
      lng: position.coords.longitude
    }
    console.log($scope.pos)
  })

  estabService.listarCinco().then(
    function(response){
      $scope.estabelecimentos = response.data;
      estabelecimentos = response.data;
      console.log(response)
      // estabelecimentos.forEach(function(element) {
      //   debugger
      //   $scope.estabelecimentos[element.Id].Endereco.Latitude = element.Endereco.Latitude;
      // }, this);
    }
  )


  categoriaService.listar().then(
    function (response) {
      $scope.categorias = response.data;
      console.log($scope.categorias)
    }
  );


  $scope.buscarPorFiltros = function () {
    if ($scope.usarLocalizacao) {
      estabService.buscarPorFiltrosLocalizacao($scope.filtro, $scope.pos).then(
        function (response) {
          console.log("listagem")
          $scope.estabelecimentos = response.data;
          console.log($scope.estabelecimentos)
        }
      );
    }
    else {
      estabService.buscarPorFiltros($scope.filtro).then(
        function (response) {
          console.log("listagem")
          $scope.estabelecimentos = response.data;
          console.log($scope.estabelecimentos)
        }
      );
    }
  }

  $scope.setUsarLocalizacao = function (usarLocalizacao) {
    $scope.usarLocalizacao = usarLocalizacao;
    console.log($scope.usarLocalizacao)
  }


});
