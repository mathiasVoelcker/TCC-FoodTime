angular.module('app').controller('InformacoesGrupoController', function ($scope, $routeParams, $route, toastr, authService, grupoService, usuarioService, $http) {

  var IdUsuarios = []
  $scope.mostraRecomendacoes = false
  $scope.participantes = []
  $scope.solicitacoes = []
  var novosParticipantes = []
  var idUsuario = authService.getUsuario().Id
  var idGrupo = $routeParams.IdGrupo
  $scope.carregouRecomendacao = false

  $scope.buscarRecomendacoes = function(){
    navigator.geolocation.getCurrentPosition(function (position) {
      var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      }
      grupoService.buscarRecomendacao(idUsuario, idGrupo, pos.lat, pos.lng).then(
        function (response) {
          // $scope.mostraRecomendacoes = (typeof response.data != "string")
          $scope.recomendacoes = response.data
          $scope.carregouRecomendacao = true
        })
      })
    }

  grupoService.buscarGrupo($routeParams.IdGrupo).then(
    function (response) {
      $scope.grupo = response.data
      $scope.grupo.GrupoUsuarios.forEach(function (grupoUsuario) {
        if (grupoUsuario.Aprovado) {
          $scope.participantes.push(grupoUsuario)
        }
        else {
          $scope.solicitacoes.push(grupoUsuario)
        }
      })
      $scope.buscarRecomendacoes()
    })

    $scope.selecionarParticipante = function(participante){
      IdUsuarios.push(participante.Id)
      console.log(IdUsuarios)
    }

    $scope.removerParticipante = function(participante){
      $scope.grupo.IdUsuarios.splice($scope.grupo.IdUsuarios.indexOf(participante.Id), 1)
      console.log($scope.grupo)
    }

    $scope.atualizarGrupo = function(){
      if(IdUsuarios.length == 0){
        toastr.error('Nenhum usuário selecionado!')
      }
      else{
        var novoParticipante = {IdUsuario: 0, idGrupo: idGrupo, Aprovado: false}
        IdUsuarios.forEach(function(idUsuario){
          novoParticipante.IdUsuario = idUsuario
          novosParticipantes.push(novoParticipante)
        })
        grupoService.atualizarGrupo(novosParticipantes).then(
          function(response){
            console.log(response)
            toastr.success('Grupo atualizado com sucesso!')
            $route.reload();
          },
          function(response){
            toastr.error(response.data.Message)
          }
        )
      }
    }

      $scope.formatarPrecoMedio = function(numero){
        numero = numero.toFixed(2);
        return numero.toString().replace(/[.]/, ",")
      }
    })
