angular.module('app')
  .controller('HomeController', function ($scope, authService, $http) {
    debugger
    $scope.usuarioLogado = authService.getUsuario();
  });
