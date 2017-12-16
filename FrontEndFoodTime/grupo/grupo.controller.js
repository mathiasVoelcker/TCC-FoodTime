angular.module('app')
.controller('GrupoController', function ($scope, authService, toastr, usuarioService, grupoService, fotoService, $http) {

  var usuarioLogado = authService.getUsuario()
  $scope.grupo = {Nome: "", Foto: "", IdUsuarios: [usuarioLogado.Id]};
  grupoService.buscarGrupoPorUsuario(authService.getUsuario().Id).then(
    function(response){
      console.log(response)
      $scope.gruposUsuario = response.data
    }
  )

  $scope.selecionarParticipante = function(participante){
    $scope.grupo.IdUsuarios.push(participante.Id)
    console.log($scope.grupo)
  }


  $scope.criarGrupo = function(grupo){
    var file = document.getElementById('file').files[0];
    if(file != undefined){
      if($scope.formGrupo.$valid){
        $scope.addFoto(file)
        console.log(grupo)
        grupoService.criarGrupo(grupo).then(
          function(response){
            toastr.success('Grupo criado com sucesso!')
            $location.path(`/informacoesGrupo/${response.data.Id}`)
          })

        }
      }
    }

    $scope.addFoto = function(file){
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

});
