angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService) {
    
  $scope.usuarioLogado = authService.getUsuario();

  estabService.listar();

    estabService.listar().then(
      function(response){
        $scope.estabelecimentos = response.data;
        $scope.estabelecimentos.foto = response.data.Fotos[0].Caminho;
      }
    );
    
  });
