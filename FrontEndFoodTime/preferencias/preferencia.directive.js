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
    controller: function ($scope, authService, toastr, $rootScope, preferenciasService, usuarioService, $location) {
      console.log($scope.comTodasPreferencias)
      var idUsuario = authService.getUsuario().Id

      function redirecionar(promise) {
        promise.then(function () {
          $location.path('/perfilUsuario/');
        })
      }

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


          $scope.trocaLimite = function trocaLimite() {
            var target = document.getElementById("listarTodos");
            if ($scope.flag)
            {
              $scope.limit = 'All';
            }
            else
            {
              $scope.limit = 5;
            }
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
            let promise;
            console.log($scope.preferenciasSelecionadas)
            idPreferencias = $scope.preferenciasSelecionadas.map(function (pref) {
              return pref.Id
            });
            $scope.idPreferencias = idPreferencias;
            console.log(idPreferencias)
            promise = usuarioService.adicionarPreferencias(idPreferencias, idUsuario).then(
              function(response){
                toastr.success('Preferências atualizadas!')
                redirecionar(promise);
              }
            )
          }
        },
      }
    });
