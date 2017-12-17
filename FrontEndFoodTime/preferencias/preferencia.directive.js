angular.module('app').directive('preferenciasDiretiva', function () {

  return {
    restrict: 'E',
    scope: {
      comTodasPreferencias: '=',
      idEstabelecimento: '=',
      adicionarPreferenciasFunc: '=',
      removerPreferenciasFunc: '='
    },
    templateUrl: '../preferencias/preferencia.directive.html',
    controller: function ($scope, authService, toastr, $rootScope, preferenciasService, usuarioService) {
      console.log($scope.comTodasPreferencias)
      var idUsuario = authService.getUsuario().Id

      if ($scope.comTodasPreferencias) {
        preferenciasService.listarPorEstab($scope.idEstabelecimento).then(
          function (response) {
            $scope.preferencias = response.data;
          });
        } else {
          preferenciasService.listarPreferenciasMenosAsDoUsuario(idUsuario).then(
            function (response) {
              $scope.preferencias = response.data;
              console.log($scope.preferencias)
            });
            // preferenciasService.listarPreferenciasMenosAsDoUsuario(idUsuario);
          }

          $scope.mostraTabela = false
          $scope.naoEncontrou = false
          $scope.preferencias
          var novasPreferencias = []
          $scope.preferenciasSelecionadas = []
          $scope.idPreferencias = [];

          $scope.selecionarPreferencia = function (preferencia) {
            $scope.preferencias.splice(($scope.preferencias.indexOf(preferencia)), 1);
            $scope.preferenciasSelecionadas.push(preferencia);
            if($scope.comTodasPreferencias){
              $scope.adicionarPreferenciasFunc(preferencia.Id)
            }
          }

          $scope.retirarSelecionarPreferencia = function (preferencia) {
            $scope.preferenciasSelecionadas.splice(($scope.preferenciasSelecionadas.indexOf(preferencia)), 1);
            $scope.preferencias.push(preferencia);
            if($scope.comTodasPreferencias){
              $scope.removerPreferenciasFunc(preferencia.Id)
            }
          }

          $scope.adicionarPreferencias = function () {
            console.log($scope.preferenciasSelecionadas)
            idPreferencias = $scope.preferenciasSelecionadas.map(function (pref) {
              return pref.Id
            });
            $scope.idPreferencias = idPreferencias;
            console.log(idPreferencias)
            usuarioService.adicionarPreferencias(idPreferencias, idUsuario).then(
              function(response){
                toastr.success('Preferencias atualizadas!')
              }
            )
          }
        },
      }
    });
