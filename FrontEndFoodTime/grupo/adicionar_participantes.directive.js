angular.module('app').directive('adicionarParticipantes', function(){
  return {
    scope: {
      "idGrupo": "=idGrupo",
      "estaCriando": "=estaCriando"
    },
    controller: function ($scope, $rootScope, toastr, usuarioService, grupoService, authService, fotoService, $route){

      var usuarioLogado = authService.getUsuario()
      $scope.mostraTabela = false
      $scope.naoEncontrou = false
      $scope.usuarios
      $scope.grupo = {Nome: "", Foto: "", IdUsuarios: []};
      var novosParticipantes = []
      $scope.solicitacoes = []
      if($scope.estaCriando){
        $scope.solicitacoes = [usuarioLogado]
        $scope.grupo = {Nome: "", Foto: "https://image.freepik.com/icones-gratis/grupo-de-homens_318-62649.jpgs", IdUsuarios: [ usuarioLogado.Id]};
      }

      $scope.buscarUsuarioPorFiltro = function(filtro){
        if($scope.estaCriando){
          usuarioService.buscarPorFiltro(filtro).then(
            function(response){
              $scope.usuarios = response.data
              atualizarTabelasParticipantes()
            }
          )
        }
        else{
          usuarioService.buscarPorGrupo($scope.idGrupo, filtro).then(
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
        if($scope.estaCriando){
          criarGrupo(grupo)
        }
        else{
          atualizarGrupo(grupo.IdUsuarios)
        }
      }

      function criarGrupo(grupo){
        if($scope.grupo.Nome == undefined){
          toastr.error('Grupo deve ter um Nome!')
        }
        else{
          $scope.addFoto()
          console.log(grupo)
          grupoService.criarGrupo(grupo).then(
            function(response){
              toastr.success('Grupo criado com sucesso!')
            })
          }
        }

        function atualizarGrupo(idUsuarios){
          if(idUsuarios.length == 0){
            toastr.error('Nenhum usuário selecionado!')
          }
          else{
            var novoParticipante = {IdUsuario: 0, idGrupo: $scope.idGrupo, Aprovado: false}
            idUsuarios.forEach(function(idUsuario){
              novoParticipante.IdUsuario = idUsuario
              novosParticipantes.push(novoParticipante)
            })
            grupoService.atualizarGrupo(novosParticipantes).then(
              function(response){
                console.log(response)
                toastr.success('Grupo atualizado com sucesso!')
              }
            )
          }
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

        $scope.addFoto = function(){
          var file = document.getElementById('file').files[0];
          var fd = new FormData();
          fd.append('file', file);
          $scope.grupo.Foto = file.name;
          fotoService.addFoto(fd).then(
            function(response){
              console.log("Foto adicionada com sucesso!");
            }, function(response){
            }
          )
        }

      },
      templateUrl: 'grupo/adicionar_participantes.directive.html'
    }
  });
