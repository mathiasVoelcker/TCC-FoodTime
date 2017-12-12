angular.module('app').directive('adicionarParticipantes', function(){
  return {
    scope: {
      "idgrupo": "=idgrupo",
      "nome": "=nome",
      "foto": "=foto",
      "estacriando": "=estacriando"
    },
    controller: function ($scope, $rootScope, usuarioService, grupoService, authService, $route){
      var usuarioLogado = authService.getUsuario()

      $scope.mostraTabela = false
      $scope.naoEncontrou = false
      $scope.usuarios
      $scope.grupo = {Nome: "", Foto: "", IdUsuarios: []};
      console.log($scope.grupo)
      $scope.solicitacoes = []
      if($scope.estacriando){
        $scope.solicitacoes = [usuarioLogado]
        $scope.grupo = {Nome: $scope.nome, Foto: "https://image.freepik.com/icones-gratis/grupo-de-homens_318-62649.jpg", IdUsuarios: [ usuarioLogado.Id]};
      }

      $scope.buscarUsuarioPorFiltro = function(filtro){
        if($scope.estacriando){
          usuarioService.buscarPorFiltro(filtro).then(
            function(response){
              $scope.usuarios = response.data
              atualizarTabelasParticipantes()
            }
          )
        }
        else{
          usuarioService.buscarPorGrupo($scope.idgrupo, filtro).then(
            function(response){
              $scope.usuarios = response.data
              atualizarTabelasParticipantes()
            }
          )
        }
      }

      $scope.selecionarUsuario = function(usuario){
        $scope.usuarios.splice(($scope.usuarios.indexOf(usuario)), 1); //remover usuario de lista de participantes quando selecionado
        $scope.solicitacoes.push(usuario); //inserir usuario a lista de solicitacoes para o grupo
        $scope.grupo.IdUsuarios.push(usuario.Id)
      }
      $scope.salvarGrupo = function(grupo){
        if($scope.estacriando){
          criarGrupo(grupo)
        }
        else{
          atualizarGrupo(grupo.IdUsuarios)
        }
      }
      function criarGrupo(grupo){
        if($scope.nome == undefined){
          alert("Grupo deve ter um Nome");
        }
        else{
          grupo.Nome = $scope.nome
          console.log(grupo)
          grupoService.criarGrupo(grupo).then(
            function(response){
              alert("Grupo criado com sucesso")
            })
          }
        }

        function atualizarGrupo(idUsuarios){
          alert("Vou Atualizar Um Grupo")
          console.log(idUsuarios)
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
