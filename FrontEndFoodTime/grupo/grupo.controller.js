angular.module('app')
.controller('GrupoController', function ($scope, authService, usuarioService, grupoService, $http) {


  $scope.mostraTabela = false
  $scope.naoEncontrou = false
  $scope.usuarios
  $scope.grupo = {Nome: "", Imagem: "https://image.freepik.com/icones-gratis/grupo-de-homens_318-62649.jpg", IdUsuarios: []};
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
      }
    )
  }



  grupoService.buscarGrupo(authService.getUsuario().Id).then(
    function(response){
      console.log(response)
      $scope.gruposUsuario = response.data
    }
  )

  $scope.selecionarUsuario = function(usuario){
    $scope.usuarios.splice(($scope.usuarios.indexOf(usuario)), 1); //remover usuario de lista de participantes quando selecionado
    $scope.solicitacoes.push(usuario); //inserir usuario a lista de solicitacoes para o grupo
    $scope.grupo.IdUsuarios.push(usuario.Id)

  }

  $scope.criarGrupo = function(grupo){
    console.log(grupo)
    grupoService.criarGrupo(grupo).then(
      function(response){
        alert("Grupo criado com sucesso")
      }
    )
  }

});
