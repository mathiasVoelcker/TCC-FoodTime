angular.module('app').controller('EstabelecimentoController', function ($scope, $routeParams, authService, estabService, $http) {
  $scope.IdEstabelecimento = $routeParams.IdEstabelecimento;
  estabService.buscarEstabelecimentoPorId($scope.IdEstabelecimento).then(
    function(response){
      console.log(response)
      $scope.estabelecimento = response.data

    }
  )
  // estabService.buscarAvaliacoesEstab(IdEstabelecimento).then(
  //   function(response){
  //     console.log(response)
  //     $scope.avaliacoes = response.data
  //   }
  // )\
});
