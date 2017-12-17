angular.module('app')
  .controller('PerfilUsuarioController', function ($scope, $routeParams, authService, $http, usuarioService) {

    $scope.usuario = authService.getUsuario();
    console.log($scope.usuario)
    // console.log($scope.usuario.DataNascimento)
    // console.log($scope.usuario)
    buscarRecomendacoes()
    $scope.carregouRecomendacao = false


    usuarioService.buscarAvaliacoesUsuario($scope.usuario.Id).then(
      function (response) {
        console.log(response.data)
        $scope.avaliacoes = response.data
        $scope.$apply()
      }
    )

    $scope.getStars = function(rating) {
      // Get the value
      var val = parseFloat(rating);
      // Turn value into number/100
      var size = val*10;
      return size + '%';
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

    $scope.formatarPrecoMedio = function(numero){
      numero = numero.toFixed(2);
      return numero.toString().replace(/[.]/, ",")
    }

    $scope.formatarData =function (data) {
      data = data.substring(0, 10)
      var dataArray = data.split("-")
      var retorno = dataArray[2] + "/" + dataArray[1] + "/" + dataArray[0]
      return retorno
    }

    $scope.formatarData =function (data) {
      data = data.substring(0, 10)
      var dataArray = data.split("-")
      var retorno = dataArray[2] + "/" + dataArray[1] + "/" + dataArray[0]
      return retorno
    } 
  });
