angular.module('app')
.controller('NotificacoesController', function ($scope, usuarioService, authService, $http) {

  var idUsuario = authService.getUsuario().Id

  usuarioService.buscarSolicitacoesGrupo(idUsuario).then(
    function(response){
      console.log(response)
      $scope.solicitacoes = response.data
    }
  )

  $scope.aceitarSolicitacao = function(idGrupo){
    usuarioService.aprovarSolicitacao(idGrupo, idUsuario).then(
      function(response){
        console.log(response)
        alert("Você agora faz parte deste grupo!");
      }
    )
  }
});
