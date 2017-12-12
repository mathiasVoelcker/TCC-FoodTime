angular.module('app').directive('adicionarParticipantes', function(){
  return {
    scope: {
      "nome": "=nome",
      "foto": "=foto"
    },
    controller: function ($scope, $rootScope, usuarioService, grupoService, $route){
      $scope.mostraTabela = false
      $scope.naoEncontrou = false
      $scope.usuarios
      $scope.grupo = {Nome: $scope.nome, Foto: "https://image.freepik.com/icones-gratis/grupo-de-homens_318-62649.jpg", IdUsuarios: []};
      console.log($scope.grupo)
      $scope.solicitacoes = []
      $scope.buscarUsuarioPorFiltro = function(filtro){
        usuarioService.buscarPorFiltro(filtro).then(
          function(response){
            $scope.usuarios = response.data
            for(var i = 0; i < $scope.usuarios.length; i++){
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
          })
        }

        $scope.selecionarUsuario = function(usuario){
          $scope.usuarios.splice(($scope.usuarios.indexOf(usuario)), 1); //remover usuario de lista de participantes quando selecionado
          $scope.solicitacoes.push(usuario); //inserir usuario a lista de solicitacoes para o grupo
          $scope.grupo.IdUsuarios.push(usuario.Id)
        }

        $scope.criarGrupo = function(grupo){
          grupo.Nome = $scope.nome
          console.log(grupo)
          grupoService.criarGrupo(grupo).then(
            function(response){
              alert("Grupo criado com sucesso")
            })
          }
        },
        templateUrl: 'grupo/adicionar_participantes.directive.html'
      }
    });
