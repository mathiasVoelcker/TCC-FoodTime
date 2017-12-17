angular.module('app').controller('EstabelecimentoController', function ($scope, $routeParams, authService, estabService, preferenciasService, $http) {
  $scope.IdEstabelecimento = $routeParams.IdEstabelecimento;
  $scope.preferencias = []
  estabService.buscarEstabelecimentoPorId($scope.IdEstabelecimento).then(
    function(response){
      console.log(response)
      $scope.estabelecimento = response.data

    }
  )

  preferenciasService.listarPreferenciasDeEstabelecimento($scope.IdEstabelecimento).then(
    function(response){
      var preferencias = response.data
      preferencias.forEach(function(preferencia) {
        $scope.preferencias = $scope.preferencias + preferencia.Descricao + ", ";
      })
       $scope.preferencias = $scope.preferencias.substring(0, $scope.preferencias.length - 2);
    }
  )

  // estabService.buscarAvaliacoesEstab(IdEstabelecimento).then(
  //   function(response){
  //     console.log(response)
  //     $scope.avaliacoes = response.data
  //   }
  // )\
});
