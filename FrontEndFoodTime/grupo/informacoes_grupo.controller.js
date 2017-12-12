angular.module('app').controller('InformacoesGrupoController', function ($scope, $routeParams, authService, grupoService, usuarioService, $http) {

  $scope.participantes = []
  $scope.solicitacoes = []
  $scope.mostraRecomendacoes = false
  var idUsuario = authService.getUsuario().Id
  var idGrupo = $routeParams.IdGrupo
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
      buscarRecomendacoes()
    })

    function buscarRecomendacoes() {
      navigator.geolocation.getCurrentPosition(function (position) {
        var pos = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        }
        grupoService.buscarRecomendacao(idUsuario, idGrupo, pos.lat, pos.lng).then(
          function (response) {
            $scope.mostraRecomendacoes = (typeof response.data != "string")
            $scope.recomendacoes = response.data
          })
        })
      }

      $scope.excluirRecomendacao = function (idEstabelecimento) {
        usuarioService.excluirRecomendacao(idEstabelecimento, idUsuario).then(
          function (response) {
            console.log(response)
            buscarRecomendacoes()
          }
        )
      }
    })
