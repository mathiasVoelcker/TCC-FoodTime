angular.module('app')
.controller('PerfilUsuarioController', function ($scope, authService, $http, usuarioService) {

    function buscarUsuario(id){
        usuarioService.getUsuario(id)
        .then(function (response){
            debugger
            $scope.usuario = response.data;
        })
    }
    //teste de buscar o primeiro
    buscarUsuario(1);
});