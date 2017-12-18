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

      // $scope.carregouRecomendacao = false
      $scope.usuario = authService.getUsuario();

      $scope.excluirRecomendacao = function (idEstabelecimento) {
        $scope.carregouRecomendacao = false
        usuarioService.excluirRecomendacao(idEstabelecimento, $scope.usuario.Id).then(
          function (response) {
            console.log(response)
            $scope.buscarRecomendacoes()
            $scope.carregouRecomendacao = true
          }
        )
      }

      $scope.formatarPrecoMedio = function(numero){
        numero = numero.toFixed(2);
        return numero.toString().replace(/[.]/, ",")
      }

      $scope.retornarRelevancia = function(relevancia){
        // var retorno = (1 - (relevancia/5)).toFixed(2);
        var retorno = relevancia * 100
        return retorno.toFixed(2);
      }
    }
  }
})
