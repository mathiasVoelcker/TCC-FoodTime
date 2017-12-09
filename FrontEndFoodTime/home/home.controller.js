angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService) {
    
  $scope.usuarioLogado = authService.getUsuario();

  estabService.listar();

    estabService.listar().then(
      function(response){
        debugger
        $scope.estabelecimentos = response.data;
      }
    );
    
    console.log($scope.estabelecimentos);
  });
