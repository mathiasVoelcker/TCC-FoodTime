angular.module('app').directive('preferenciasDiretiva', function () {

  return {
    restrict: 'E',
    templateUrl: '../preferencias/preferencia.directive.html',
    controller: function ($scope, authService, $rootScope, preferenciasService) {

      preferenciasService.listar();
      preferenciasService.listarCinco();

      preferenciasService.listar().then(
        function (response) {
          debugger
          $scope.preferencias = response.data;
        });

      preferenciasService.listarCinco().then(
        function (response) {
          debugger
          $scope.cincoPreferencias = response.data;
        });

        $scope.trocaLimite = function trocaLimite() {
        debugger
        var target = document.getElementById("listarTodos");
        if (target.checked == true)
          $scope.limit = 'All';
        else
          $scope.limit = 5;
      }


      // $scope.preferencias = preferencias;
      // $scope.mostraTabela = false
      // $scope.naoEncontrou = false
      // $scope.grupo = {Nome: "", IdPreferencias: []};
      // $scope.solicitacoes = []
      // $scope.buscarUsuarioPorFiltro = function(filtro){
      //   usuarioService.buscarPorFiltro(filtro).then(
      //     function(response){
      //       $scope.preferencias = response.data
      //       for(var i = 0; i < $scope.preferencias.length; i++){
      //         $scope.solicitacoes.forEach(function(solicitacao){
      //           if($scope.preferencias[i].Id == solicitacao.Id){
      //             $scope.preferencias.splice(i, 1);
      //           }
      //         })
      //       }
      //       if($scope.preferencias.length != 0){
      //         $scope.mostraTabela = true
      //         $scope.naoEncontrou = false
      //       }
      //       else{
      //         $scope.naoEncontrou = true
      //         $scope.mostraTabela = false
      //       }
      //     }
      //   )
      // }



    }
  }
});

