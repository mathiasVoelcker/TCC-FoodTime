angular.module('app')
  .directive('cwiHeader', function (authService, $rootScope) {
    return {
      restrict: 'E',
      scope: {},
      templateUrl: '../home/header.directive.html',

      controller: function ($scope, toastr, usuarioService, authService, $http, $location) {

        atualizarUsuario();

        function redirecionar(promise) {
          promise.then(function () {
            $location.path('/meusGrupos/');
          })
        }

        $scope.logout = authService.logout;

        $rootScope.$on('authLoginSuccess', function () {
          atualizarUsuario();
        });

        $rootScope.$on('authLogoutSuccess', function () {
          atualizarUsuario();
        });

        function atualizarUsuario() {
          $scope.usuario = authService.getUsuario();
          console.log(authService.getUsuario())
        }
       
        if($scope.usuario != undefined){
          console.log(authService.getUsuario().Id);
          var idUsuario = authService.getUsuario().Id;
          
            usuarioService.buscarSolicitacoesGrupo(idUsuario).then(
              function(response){
                console.log(response)
                $scope.solicitacoes = response.data
              }
            )
          
            $scope.aceitarSolicitacao = function(idGrupo){
              let promise;
              promise = usuarioService.aprovarSolicitacao(idGrupo, idUsuario).then(
                function(response){
                  console.log(response)
                  toastr.success('Você agora faz parte deste grupo!');
                  redirecionar(promise);
                }
              )
            }
            $scope.rejeitarSolicitacao = function(idNotificacao){
              let promise;
              promise = usuarioService.rejeitarSolicitacao(idNotificacao).then(
                function(response){
                  console.log(response)
                  toastr.success('Você Rejeitou a solicitação do grupo!');
                  redirecionar(promise);
                }
              )
            }
        }
      } 
    }

  });


