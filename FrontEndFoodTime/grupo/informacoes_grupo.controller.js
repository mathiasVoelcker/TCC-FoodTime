angular.module('app').controller('InformacoesGrupoController', function ($scope, $routeParams, authService, grupoService, $http) {

  $scope.participantes = []
  $scope.solicitacoes = []
  var idUsuario = authService.getUsuario().Id
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
      buscarRecomendacoes($scope.grupo.Id)
    })

    function buscarRecomendacoes(idGrupo){
      navigator.geolocation.getCurrentPosition(function(position) {
        var pos = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        }
        console.log(pos)
        grupoService.buscarRecomendacao(idUsuario, idGrupo, pos.lat, pos.lng).then(
          function (response){
            console.log(response)
            $scope.recomendacoes = response.data
          })
      })
    }
  })
