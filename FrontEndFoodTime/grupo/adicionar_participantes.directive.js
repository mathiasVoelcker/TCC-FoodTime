angular.module('app').directive('adicionarParticipantes', function(){
  return {
    scope: {
      "idGrupo": "=idGrupo",
      "selecionarParticipante": "=selecionarParticipante"
      // "removerParticipantes": "=removerParticipantes"
    },
    controller: function ($scope, $rootScope, $location, toastr, usuarioService, grupoService, authService, fotoService, $route){

      var usuarioLogado = authService.getUsuario()
      $scope.mostraTabela = false
      $scope.naoEncontrou = false
      $scope.usuarios
      $scope.solicitacoes = []
      if($scope.idGrupo == 0){
        $scope.solicitacoes = [usuarioLogado]
      }

      $scope.buscarUsuarioPorFiltro = function(filtro){
        usuarioService.buscarPorGrupo($scope.idGrupo, filtro).then(
          function(response){
            $scope.usuarios = response.data
            atualizarTabelasParticipantes()
          }
        )
      }

      $scope.selecionarUsuario = function(usuario){
        $scope.usuarios.splice($scope.usuarios.indexOf(usuario), 1); //remover usuario de lista de participantes quando selecionado
        $scope.solicitacoes.push(usuario); //inserir usuario a lista de solicitacoes para o grupo
        $scope.selecionarParticipante(usuario)
      }

      function atualizarTabelasParticipantes(){
        for(var i = 0; i < $scope.usuarios.length; i++){
          if($scope.usuarios[i].Id == usuarioLogado){
            $scope.usuarios.splice(i, 1);
          }
          $scope.solicitacoes.forEach(function(solicitacao){
            if($scope.usuarios[i].Id == solicitacao.Id){
              $scope.usuarios.splice(i, 1);
            }
          })
        }
        if($scope.usuarios.length != 0){
          $scope.mostraTabela = true
          $scope.naoEncontrou = false
        }
        else{
          $scope.naoEncontrou = true
          $scope.mostraTabela = false
        }
      }

    },
    templateUrl: 'grupo/adicionar_participantes.directive.html'
  }
});
