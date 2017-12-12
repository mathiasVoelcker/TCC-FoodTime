angular.module('app').controller('InformacoesGrupoController', function ($scope, $routeParams, authService, usuarioService, grupoService, $http) {

  $scope.participantes = []
  $scope.solicitacoes = []
  grupoService.buscarGrupo($routeParams.IdGrupo).then(
    function(response){
      console.log(response)
      $scope.grupo = response.data
      $scope.grupo.GrupoUsuarios.forEach(function(grupoUsuario){
        if(grupoUsuario.Aprovado){
          $scope.participantes.push(grupoUsuario)
        }
        else{
          $scope.solicitacoes.push(grupoUsuario)
        }
      })
    })
  })
