angular.module('app')
  .controller('PerfilUsuarioController', function ($scope, $routeParams, authService, $http, usuarioService) {

    $scope.usuario = authService.getUsuario();
    console.log($scope.usuario)
    // console.log($scope.usuario.DataNascimento)
    // console.log($scope.usuario)
    buscarRecomendacoes()


    usuarioService.buscarAvaliacoesUsuario($scope.usuario.Id).then(
      function (response) {
        console.log(response.data)
        $scope.avaliacoes = response.data
        $scope.$apply()
      }
    )


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
          }
        )
      })
    }

    $scope.excluirRecomendacao = function (idEstabelecimento) {
      usuarioService.excluirRecomendacao(idEstabelecimento, $scope.usuario.Id).then(
        function (response) {
          console.log(response)
          buscarRecomendacoes()
        }
      )
    }

    $scope.formatarPrecoMedio = function(numero){
      numero = numero.toFixed(2);
      return numero.toString().replace(/[.]/, ",")
    }

  });
