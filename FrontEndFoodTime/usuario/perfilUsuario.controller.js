angular.module('app')
.controller('PerfilUsuarioController', function ($scope, $routeParams, authService, $http, usuarioService) {

  $scope.usuario = authService.getUsuario();
  console.log($scope.usuario)
  // console.log($scope.usuario.DataNascimento)
  // console.log($scope.usuario)
  $scope.MensagemErro = ''
  buscarRecomendacoes()
  $scope.carregouRecomendacao = false


  usuarioService.buscarAvaliacoesUsuario($scope.usuario.Id).then(
    function (response) {
      console.log(response.data)
      $scope.avaliacoes = response.data
      $scope.$apply()
    },

  )

  $scope.retornarPreferencias = function(){
    var preferencias = ""
    $scope.usuario.Preferencias.forEach(function(preferencia) {
      preferencias = preferencias + preferencia.Descricao + ", ";
    })
    return preferencias.substring(0, preferencias.length - 2);
  }

  // //teste de buscar o primeiro
  // buscarUsuario(1);

  function buscarRecomendacoes() {
    navigator.geolocation.getCurrentPosition(function (position) {
      var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      }
      console.log(pos)
      usuarioService.buscarRecomendacao($scope.usuario.Id, pos.lat, pos.lng).then(
        function (response) {
          console.log(response)
          $scope.recomendacoes = response.data
          $scope.carregouRecomendacao = true
        },
        function (response){
          $scope.MensagemErro = response.data.Message
          $scope.carregouRecomendacao = true
        }
      )
    })
  }

  $scope.excluirRecomendacao = function (idEstabelecimento) {
    $scope.carregouRecomendacao = false
    usuarioService.excluirRecomendacao(idEstabelecimento, $scope.usuario.Id).then(
      function (response) {
        console.log(response)
        buscarRecomendacoes()
      }
    )
  }
});
