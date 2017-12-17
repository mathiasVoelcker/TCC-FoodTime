angular.module('app').controller('HomeController', function ($scope, $sce, authService, $http, estabService, categoriaService) {

  $scope.trustSrc = function(latitude, longitude) {
    return $sce.trustAsResourceUrl(`https://maps.google.com/maps?q=${latitude},${longitude}&hl=es;z=14&amp;&output=embed`);
  }

  $scope.usuarioLogado = authService.getUsuario();
  $scope.filtro = { Nome: "", Endereco: "", Categoria: "" };
  $scope.usarLocalizacao = false
  $scope.estabelecimentos = []
  // $scope.filtro.Nome = ""
  // $scope.filtro.Endereco = ""
  // $scope.filtro.Categoria = ""
  $scope.mapaCarregado = false

  estabService.listar();
  navigator.geolocation.getCurrentPosition(function (position) {
    $scope.pos = {
      lat: position.coords.latitude,
      lng: position.coords.longitude
    }
    console.log($scope.pos)
  })

  window.mapsCallBack = function(){
    $scope.mapaCarregado = true
    $scope.$apply()
  }

  estabService.listarCinco().then(
    function(response){
      $scope.estabelecimentos = response.data;
      estabelecimentos = response.data;
      console.log(response)
      // $scope.$apply();
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
          $scope.estabelecimentos = response.data;
          console.log($scope.estabelecimentos)
          // $scope.$apply();
        }
      );
    }
    else {
      estabService.buscarPorFiltros($scope.filtro).then(
        function (response) {
          $scope.estabelecimentos = response.data;
          console.log($scope.estabelecimentos)
          // $scope.$apply();
        }
      );
    }
  }

  $scope.setUsarLocalizacao = function (usarLocalizacao) {
    $scope.usarLocalizacao = usarLocalizacao;
    console.log($scope.usarLocalizacao)
  }

});
