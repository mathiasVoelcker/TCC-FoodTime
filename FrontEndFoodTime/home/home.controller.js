
angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService, categoriaService) {

  $scope.usuarioLogado = authService.getUsuario();
  $scope.buscarPorFiltros = buscarPorFiltros;
  estabService.listar();
  categoriaService.listar();
  let filtro = [];

    estabService.listarCinco().then(
      function(response){
        $scope.estabelecimentos = response.data;
        estabelecimentos = response.data;
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
      }
    );


    function buscarPorFiltros(endereco, nome, categorias){
      debugger
      filtro.push(endereco);
      filtro.push(nome);
      filtro.push(categorias);
      estabService.buscarPorFiltros(filtro).then(
        function(response){
          debugger
          $scope.estabelecimentosFiltrados = response.data;
        }
      );
    }


  });
