angular.module('app')
.controller('NotificacoesController', function ($scope, usuarioService, authService, $http) {

  var idUsuario = authService.getUsuario().Id

  usuarioService.buscarSolicitacoesGrupo(idUsuario).then(
    function(response){
      console.log(response)
      $scope.solicitacoes = response.data
    }
  )
});
