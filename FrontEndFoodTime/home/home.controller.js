
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

  estabService.listarMapa().then(
    function (response) {
      
      $scope.estabelecimentos = response.data;
      // estabelecimentos = response.data;
      $scope.estabelecimentos.forEach(function(element) {
        debugger
        element.Endereco.link;
        let link = "http://maps.google.com/maps?hl=en&amp;ie=UTF8&amp;ll="+element.Endereco.Latitude+","+element.Endereco.Longitude+"&amp;spn="+element.Endereco.Longitude+",17&amp;t=m&amp;z=17&amp;output=embed";
        element.Endereco.link = link;
        console.log(element.Endereco.link);
      }, this);
     
    //  $scope.mapa = "http://maps.google.com/maps?hl=en&amp;ie=UTF8&amp;ll="+estabelecimentos.Endereco.Latitude+","+estabelecimentos.Endereco.Latitude+"&amp;spn="+estabelecimentos.Endereco.Latitude+",17&amp;t=m&amp;z=17&amp;output=embed";
      console.log(response)

      if (response.data.Fotos != undefined)
        $scope.estabelecimentos.foto = response.data.Fotos[0].Caminho;
    }
  );

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
