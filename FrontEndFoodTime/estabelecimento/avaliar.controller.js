angular.module('app').controller('AvaliarController', function ($scope, estabService, authService) {

  $scope.avaliacao
  $scope.avaliar = function(avaliacao){
    console.log(authService.getUsuario())
    $scope.avaliacao.idUsuario = authService.getUsuario().Id
    console.log(avaliacao);
    // estabService.criarAvaliacao(avaliacao).then(
    //   function(response){
    //     console.log(response)
    //   }
    // )
  }
});
