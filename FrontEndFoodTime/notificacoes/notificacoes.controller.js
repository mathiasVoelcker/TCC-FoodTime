angular.module('app')
.controller('NotificacoesController', function ($scope, toastr, usuarioService, authService, $http) {

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
        toastr.success('Você agora faz parte deste grupo!');
      }
    )
  }
});
