angular.module('app').controller('AvaliarController', function ($scope, $routeParams, estabService, authService) {

  estabService.buscarEstabelecimentoPorId($routeParams.IdEstabelecimento).then(
    function(response){
      $scope.estabelecimento = response.data
    }
  )

  $scope.usuarioLogado = authService.getUsuario();

  $scope.avaliacao
  $scope.avaliar = function(avaliacao){
    console.log(authService.getUsuario())
    $scope.avaliacao.nota = parseInt($scope.avaliacao.nota)
    $scope.avaliacao.idUsuario = authService.getUsuario().Id
    $scope.avaliacao.IdEstabelecimento = parseInt($routeParams.IdEstabelecimento)
    console.log(avaliacao);
    estabService.criarAvaliacao(avaliacao).then(
      function(response){
        console.log(response)
        alert("Avaliação feita com sucesso!")
      }, function(response){
        console.log(response)
      }
    )
  }
});
