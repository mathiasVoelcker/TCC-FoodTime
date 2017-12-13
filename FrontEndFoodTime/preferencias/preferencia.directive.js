angular.module('app').directive('preferenciasDiretiva', function () {

  return {
    restrict: 'E',
    templateUrl: '../preferencias/preferencia.directive.html',
    controller: function ($scope, authService, $rootScope, preferenciasService) {

      preferenciasService.listar();

      preferenciasService.listar().then(
        function (response) {
          $scope.preferencias = response.data;
        });

        $scope.trocaLimite = function trocaLimite() {
        var target = document.getElementById("listarTodos");
        if (target.checked == true)
          $scope.limit = 'All';
        else
          $scope.limit = 5;
      }

      var usuarioLogado = authService.getUsuario()
      $scope.mostraTabela = false
      $scope.naoEncontrou = false
      $scope.preferencias
      var novasPreferencias = []
      $scope.preferenciasSelecionadas = []

      $scope.selecionarPreferencia = function(preferencia){
        $scope.preferencias.splice(($scope.preferencias.indexOf(preferencia)), 1);
        $scope.preferenciasSelecionadas.push(preferencia);
        // $scope.grupo.IdUsuarios.push(preferencia)
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
