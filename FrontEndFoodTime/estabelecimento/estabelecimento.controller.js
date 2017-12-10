angular.module('app').controller('EstabelecimentoController', function ($scope, $routeParams, authService, estabService, $http) {
  var IdEstabelecimento = $routeParams.IdEstabelecimento;
  estabService.buscarEstabelecimentoPorId(IdEstabelecimento).then(
    function(response){
      console.log(response)
    }
  )
});
