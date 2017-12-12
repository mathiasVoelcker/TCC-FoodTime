angular.module('app')
.controller('GrupoController', function ($scope, authService, usuarioService, grupoService, $http) {

    grupoService.buscarGrupoPorUsuario(authService.getUsuario().Id).then(
      function(response){
        console.log(response)
        $scope.gruposUsuario = response.data
      }
    )

  });
