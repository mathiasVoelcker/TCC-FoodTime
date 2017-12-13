angular.module('app')
.controller('GrupoController', function ($scope, authService, usuarioService, grupoService, fotoService, $http) {

  grupoService.buscarGrupoPorUsuario(authService.getUsuario().Id).then(
    function(response){
      console.log(response)
      $scope.gruposUsuario = response.data
    }
  )

});
