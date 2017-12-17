angular.module('app').directive('recomendacoesDiretiva', function () {

  return {
    restrict: 'E',
    scope: {
      recomendacoes: '=',
      buscarRecomendacoes: '=',
      carregouRecomendacao: '='
    },
    templateUrl: '../usuario/recomendacoes.directive.html',
    controller: function ($scope, authService, $rootScope, preferenciasService, usuarioService) {

      $scope.carregouRecomendacao = false

      $scope.excluirRecomendacao = function (idEstabelecimento) {
        $scope.carregouRecomendacao = false
        usuarioService.excluirRecomendacao(idEstabelecimento, $scope.usuario.Id).then(
          function (response) {
            console.log(response)
            $scope.buscarRecomendacoes()
          }
        )
      }

    }
  }
})
