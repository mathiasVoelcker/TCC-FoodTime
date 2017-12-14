angular.module('app').directive('preferenciasDiretiva', function () {

  return {
    restrict: 'E',
    scope: {
      comTodasPreferencias: '=',
      adicionarPreferenciasFunc: '=',
      removerPreferenciasFunc: '='
    },
    templateUrl: '../preferencias/preferencia.directive.html',
    controller: function ($scope, authService, $rootScope, preferenciasService, usuarioService) {
      console.log($scope.comTodasPreferencias)
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
            // preferenciasService.listarPreferenciasMenosAsDoUsuario(idUsuario);
          }


          $scope.trocaLimite = function trocaLimite() {
            var target = document.getElementById("listarTodos");
            if (target.checked == true)
            $scope.limit = 'All';
            else
            $scope.limit = 5;
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
            // $scope.grupo.IdUsuarios.push(preferencia)
          }
          $scope.retirarSelecionarPreferencia = function (preferencia) {
            $scope.preferenciasSelecionadas.splice(($scope.preferenciasSelecionadas.indexOf(preferencia)), 1);
            $scope.preferencias.push(preferencia);
            if($scope.comTodasPreferencias){
              $scope.removerPreferenciasFunc(preferencia.Id)
            }
            // $scope.grupo.IdUsuarios.push(preferencia)
          }

          $scope.adicionarPreferencias = function () {
            debugger
            console.log($scope.preferenciasSelecionadas)
            idPreferencias = $scope.preferenciasSelecionadas.map(function (pref) {
              return pref.Id
            });
            $scope.idPreferencias = idPreferencias;
            console.log(idPreferencias)
            usuarioService.adicionarPreferencias(idPreferencias, idUsuario).then(
              function(response){
                alert("Preferencias atualizadas!")
              }
            )
          }
        },
      }
    });
