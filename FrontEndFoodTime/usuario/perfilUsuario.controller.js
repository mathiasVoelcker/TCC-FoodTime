angular.module('app')
.controller('PerfilUsuarioController', function ($scope, $routeParams, authService, $http, usuarioService) {

  var idUsuario = $routeParams.IdUsuario;
  usuarioService.buscarUsuario(idUsuario)
  .then(function (response){
    $scope.usuario = response.data;

    $scope.usuario.DataNascimento = formatarData($scope.usuario.DataNascimento)
    console.log($scope.usuario.DataNascimento)
    console.log($scope.usuario)
    buscarRecomendacoes()
  })

  usuarioService.buscarAvaliacoesUsuario(idUsuario).then(
    function (response){
      console.log(response.data)
      $scope.avaliacoes = response.data
    }
  )


  // //teste de buscar o primeiro
  // buscarUsuario(1);

  function formatarData(data){
    data = data.substring(0, 10)
    var dataArray = data.split("-")
    var retorno = dataArray[2] + "/" + dataArray[1] + "/" + dataArray[0]
    return retorno
  }

  function buscarRecomendacoes(){
    navigator.geolocation.getCurrentPosition(function(position) {
      var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      }
      console.log(pos)
      usuarioService.buscarRecomendacao(idUsuario, pos.lat, pos.lng).then(
        function (response){
          console.log(response)
          $scope.recomendacoes = response.data
        }
      )
    })
  }

  $scope.excluirRecomendacao = function(idEstabelecimento){
    console.log("ENTROU")
    usuarioService.excluirRecomendacao(idEstabelecimento, idUsuario).then(
      function(response){
        console.log(response)
        buscarRecomendacoes()
      }
    )
  }

});
