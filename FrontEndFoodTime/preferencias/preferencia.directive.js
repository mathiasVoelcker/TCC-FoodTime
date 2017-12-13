angular.module('app').directive('preferenciasDiretiva', function () {

  return {
    restrict: 'E',
    scope: {
      comTodasPreferencias: '='
    },
    templateUrl: '../preferencias/preferencia.directive.html',
    controller: function ($scope, authService, $rootScope, preferenciasService) {

      console.log($scope.comTodasPreferencias);
      var idUsuario = authService.getUsuario().Id
     
      if ($scope.comTodasPreferencias) {
        preferenciasService.listar().then(
          function (response) {
            $scope.preferencias = response.data;
          });
        preferenciasService.listar();
        
      } else {
        preferenciasService.listarPreferenciasMenosAsDoUsuario(idUsuario).then(
          function (response) {
            $scope.preferencias = response.data;
          });
        preferenciasService.listarPreferenciasMenosAsDoUsuario(idUsuario);
        
      }


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

      $scope.selecionarPreferencia = function (preferencia) {
        $scope.preferencias.splice(($scope.preferencias.indexOf(preferencia)), 1);
        $scope.preferenciasSelecionadas.push(preferencia);
        // $scope.grupo.IdUsuarios.push(preferencia)
      }
      $scope.retirarSelecionarPreferencia = function (preferencia) {
        $scope.preferenciasSelecionadas.splice(($scope.preferenciasSelecionadas.indexOf(preferencia)), 1);
        $scope.preferencias.push(preferencia);
       
        // $scope.grupo.IdUsuarios.push(preferencia)
      }

      $scope.AdicionarPreferencias = function () {
        console.log($scope.preferenciasSelecionadas)
        idPreferencias = $scope.preferenciasSelecionadas.map(function (pref) {
          return pref.Id
        });
        console.log(idPreferencias)
        usuarioService.adicionarPreferencias(idPreferencias, usuarioLogado.Id)
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
